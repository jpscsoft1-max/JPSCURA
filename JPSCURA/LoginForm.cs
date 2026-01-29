using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class LoginForm : Form
    {
        private bool isPasswordVisible = false;
        private Region cachedPanelRegion = null;

        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;

            // 🔥 Form level double buffering
            this.DoubleBuffered = true;
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);
            this.UpdateStyles();

            // 🔥 Panel ko double buffered banao
            SetDoubleBuffered(pnlLogin);

            // 🔥 Baaki controls ko bhi
            if (txtUsername != null) SetDoubleBuffered(txtUsername);
            if (txtPassword != null) SetDoubleBuffered(txtPassword);
            if (btnLogin != null) SetDoubleBuffered(btnLogin);
            if (picEye != null) SetDoubleBuffered(picEye);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        // 🔥 Kisi bhi control ko double buffered banana
        private void SetDoubleBuffered(Control control)
        {
            if (control == null) return;

            try
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    System.Reflection.BindingFlags.SetProperty |
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic,
                    null, control, new object[] { true });
            }
            catch { }
        }

        // 🔥 MAIN FIX - Background erase disable
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            txtPassword.PasswordChar = '●';
            LoadEyeImage(false);

            // 🔥 Panel region pehle set kar do
            SetupPanelRegion();
        }

        // 🔥 Panel ka region ek baar setup karo
        private void SetupPanelRegion()
        {
            if (cachedPanelRegion != null)
                return;

            int radius = 18;
            int borderThickness = 2;

            Rectangle rect = new Rectangle(
                borderThickness,
                borderThickness,
                pnlLogin.Width - borderThickness * 2,
                pnlLogin.Height - borderThickness * 2
            );

            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radius * 2;

                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                cachedPanelRegion = new Region(path);
                pnlLogin.Region = cachedPanelRegion;
            }
        }

        // ================= LOGIN =================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter username and password",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(DBconection.GetConnectionString()))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                SELECT 
    U.UserId,
    U.RealName,
    U.Username,
    U.RoleId,              
    U.IsActive,
    R.RoleName,
    D.DepartmentName,
    E.Emp_id,
    E.Emp_Name,
    E.IsActive AS EmpIsActive
FROM EMPLOYEE_MASTER..Users U
INNER JOIN EMPLOYEE_MASTER..Roles R
    ON U.RoleId = R.RoleId
INNER JOIN EMPLOYEE_MASTER..Departments D
    ON U.DepartmentId = D.DepartmentId
INNER JOIN EMPLOYEE_MASTER..Employees E
    ON U.Emp_id = E.Emp_id
WHERE U.Username = @u
  AND U.Password = @p
", con))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (!dr.Read())
                            {
                                MessageBox.Show(
                                    "Invalid username or password",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;
                            }

                            if (!Convert.ToBoolean(dr["IsActive"]))
                            {
                                MessageBox.Show(
                                    "Your account is temporarily disabled. Please contact the administrator.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;
                            }

                            if (!Convert.ToBoolean(dr["EmpIsActive"]))
                            {
                                MessageBox.Show(
                                    "Employee record is inactive. Login is not allowed.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;
                            }

                            Session.UserId = Convert.ToInt32(dr["UserId"]);
                            Session.RoleId = Convert.ToInt32(dr["RoleId"]);
                            Session.RealName = dr["RealName"].ToString();
                            Session.Username = dr["Username"].ToString();
                            Session.Role = dr["RoleName"].ToString().Trim().ToUpper();
                            Session.Department = dr["DepartmentName"].ToString().Trim();
                        }
                    }
                }

                Home home = new Home();
                home.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Login Error:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= ENTER KEY =================
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Login();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ================= EYE TOGGLE =================
        private void picEye_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.PasswordChar = isPasswordVisible ? '\0' : '●';
            LoadEyeImage(isPasswordVisible);
        }

        private void LoadEyeImage(bool open)
        {
            picEye.Image = open
                ? Image.FromFile("eye_open.png")
                : Image.FromFile("eye_close.png");
        }

        // ================= PANEL PAINT =================
        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            int radius = 18;
            int borderThickness = 2;

            Color borderColor = Color.FromArgb(59, 43, 151);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rect = new Rectangle(
                borderThickness,
                borderThickness,
                pnl.Width - borderThickness * 2,
                pnl.Height - borderThickness * 2
            );

            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radius * 2;

                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            cachedPanelRegion?.Dispose();
            base.OnFormClosed(e);
        }

        private void loginclosebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}