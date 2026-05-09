using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class ChangePassword : Form
    {
        private bool isOldPasswordVisible = false;
        private bool isNewPasswordVisible = false;
        private bool isPasswordVisible = false;

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtOldPassword.PasswordChar = '●';
            txtNewPassword.PasswordChar = '●';


            LoadEyeImage(false); // same as login

            this.AcceptButton = btnChange;
            this.CancelButton = btncancel;

            txtOldPassword.Focus();
        }

        // ================= CHANGE BUTTON =================
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text))
            {
                MessageBox.Show("Enter current password");
                txtOldPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Enter new password");
                txtNewPassword.Focus();
                return;
            }

            if (txtOldPassword.Text.Trim() == txtNewPassword.Text.Trim())
            {
                MessageBox.Show("New password cannot be same as old password");
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(DBconection.GetConnectionString()))
                {
                    con.Open();

                    // 🔹 Check current password
                    SqlCommand checkCmd = new SqlCommand(@"
                SELECT COUNT(*) 
                FROM EMPLOYEE_MASTER.dbo.Users
                WHERE UserId = @id AND Password = @old
            ", con);

                    checkCmd.Parameters.AddWithValue("@id", Session.UserId);
                    checkCmd.Parameters.AddWithValue("@old", txtOldPassword.Text.Trim());

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Current password is incorrect");
                        return;
                    }

                    // ================= ADMIN FLOW =================
                    if (Session.Role == "ADMIN")
                    {
                        SqlCommand updateCmd = new SqlCommand(@"
                    UPDATE EMPLOYEE_MASTER.dbo.Users
                    SET Password = @new
                    WHERE UserId = @id
                ", con);

                        updateCmd.Parameters.AddWithValue("@new", txtNewPassword.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@id", Session.UserId);

                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Password changed successfully..!");
                        this.Close();
                    }
                    // ================= USER FLOW =================
                    else
                    {
                        // 🔹 Check already pending request
                        SqlCommand checkReq = new SqlCommand(@"
                    SELECT COUNT(*) 
                    FROM EMPLOYEE_MASTER.dbo.PasswordChangeRequests
                    WHERE UserId = @uid AND Status = 'Pending'
                ", con);

                        checkReq.Parameters.AddWithValue("@uid", Session.UserId);

                        int exists = (int)checkReq.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show("You already have a pending request");
                            return;
                        }

                        // 🔹 Insert request
                        SqlCommand insertCmd = new SqlCommand(@"
                    INSERT INTO EMPLOYEE_MASTER.dbo.PasswordChangeRequests
                    (UserId, OldPassword, NewPassword, Status, RequestedAt)
                    VALUES (@uid, @old, @new, 'Pending', GETDATE())
                ", con);

                        insertCmd.Parameters.AddWithValue("@uid", Session.UserId);
                        insertCmd.Parameters.AddWithValue("@old", txtOldPassword.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@new", txtNewPassword.Text.Trim());

                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Request sent to admin..!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }
        // ================= CANCEL =================
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================= EYE TOGGLE (SAME AS LOGIN) =================
        private void picEye_Click(object sender, EventArgs e)
        {
            isOldPasswordVisible = !isOldPasswordVisible;

            txtOldPassword.PasswordChar = isOldPasswordVisible ? '\0' : '●';

            piceye2.Image = isOldPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_close;
        }

        private void picEye2_Click(object sender, EventArgs e)
        {
            isNewPasswordVisible = !isNewPasswordVisible;

            txtNewPassword.PasswordChar = isNewPasswordVisible ? '\0' : '●';

            picEye.Image = isNewPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_close;
        }
        // ================= SAME FUNCTION AS LOGIN =================
        private void LoadEyeImage(bool open)
        {
            picEye.Image = open
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_close;
        }
    }
}