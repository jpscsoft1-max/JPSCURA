using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class PasswordConfirmForm : Form
    {
        private bool isPasswordVisible = false;

        // 🔓 Result flag
        public bool IsVerified { get; private set; } = false;

        public PasswordConfirmForm()
        {
            InitializeComponent();
        }

        private void PasswordConfirmForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            picEye.Image = Properties.Resources.eye_close;
            txtPassword.Focus();

            this.AcceptButton = btnpassConfirm;   // ✅ ENTER = CONFIRM
            this.CancelButton = btnpasscancel;
        }


        // 👁️ Eye open / close
        private void picEye_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            txtPassword.UseSystemPasswordChar = !isPasswordVisible;
            picEye.Image = isPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_close;
        }

        // ✅ Confirm
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter password",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (VerifyPassword(txtPassword.Text.Trim()))
            {
                IsVerified = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid password",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // ❌ Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsVerified = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 🔐 Password verification
        private bool VerifyPassword(string password)
        {
            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
                SELECT COUNT(1)
                FROM EMPLOYEE_MASTER..Users
                WHERE UserId = @UserId
                  AND Password = @Password
            ", con);

            // 👇 Logged-in user ka EmpId
            cmd.Parameters.AddWithValue("@UserId", Session.UserId);
            cmd.Parameters.AddWithValue("@Password", password); // hashing later

            con.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

    }
}
