using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace JPSCURA
{
    public partial class LoginForm : Form
    {
        private bool isPasswordVisible = false;

        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;   // Enter key support
        }



        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            txtPassword.PasswordChar = '●';
            LoadEyeImage(false);
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

                    // 🔹 STEP 1: Check username + password
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

                            // 🔒 STEP 2: User active check
                            if (!Convert.ToBoolean(dr["IsActive"]))
                            {
                                MessageBox.Show(
                                    "Your account is temporarily disabled. Please contact the administrator.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return;
                            }

                            // 🔒 STEP 3: Employee active check
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

                // ✅ SUCCESS
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

                pnl.Region = new Region(path);

                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}