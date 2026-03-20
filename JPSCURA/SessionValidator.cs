using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace JPSCURA
{
    public static class SessionValidator
    {
        public static bool IsUserActive()
        {
            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
                SELECT IsActive
                FROM EMPLOYEE_MASTER..Users
                WHERE UserId = @UserId
            ", con);

            cmd.Parameters.AddWithValue("@UserId", Session.UserId);

            con.Open();
            object result = cmd.ExecuteScalar();

            if (result == null)
                return false;

            return Convert.ToBoolean(result);
        }

        public static void ForceLogout()
        {
            MessageBox.Show(
                "Your account has been deactivated by Admin.\nYou will be logged out now.",
                "Access Revoked",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            Application.Restart(); // safest logout
        }
    }
}
