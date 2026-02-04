using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class GLD : Form
    {
        // 🔐 Password state
        private bool isPasswordVisible = false;

        public GLD()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void GLD_Load(object sender, EventArgs e)
        {
            PositionPanelTopCenter();
            LoadDepartments();

            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;

            // 🔒 SAME AS LOGIN FORM
            txtPassword.PasswordChar = '●';
            isPasswordVisible = false;

            picTogglePassword.Image = Properties.Resources.eye_close;
            picTogglePassword.Cursor = Cursors.Hand;
        }

        // ================= PANEL POSITION =================
        private void PositionPanelTopCenter()
        {
            int topMargin = 120;
            int x = (panelMainGLD.Width - panelCenterGLD.Width) / 2;
            int y = topMargin;

            panelCenterGLD.Location = new Point(Math.Max(0, x), y);
        }

        private void GLD_Resize(object sender, EventArgs e)
        {
            PositionPanelTopCenter();
        }

        // ================= LOAD DEPARTMENTS =================
        private void LoadDepartments()
        {
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("-- Select Department --");
            cmbDepartment.SelectedIndex = 0;

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            using SqlCommand cmd = new SqlCommand(@"
                SELECT DepartmentId, DepartmentName
                FROM EMPLOYEE_MASTER.dbo.Departments
                ORDER BY DepartmentName
            ", con);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbDepartment.Items.Add(new ComboBoxItem
                {
                    Id = Convert.ToInt32(dr["DepartmentId"]),
                    Text = dr["DepartmentName"].ToString()
                });
            }
        }

        // ================= LOAD EMPLOYEES =================
        private void LoadEmployeesByDepartment(int departmentId)
        {
            cmbEmployee.Items.Clear();
            cmbEmployee.Items.Add("-- Select Employee --");
            cmbEmployee.SelectedIndex = 0;

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            using SqlCommand cmd = new SqlCommand(@"
                SELECT
                    e.Emp_id,
                    e.Emp_code,
                    e.Emp_Name,
                    e.RoleId,
                    r.RoleName
                FROM EMPLOYEE_MASTER.dbo.Employees e
                LEFT JOIN EMPLOYEE_MASTER.dbo.Roles r
                    ON e.RoleId = r.RoleId
                WHERE e.DepartmentId = @DeptId
                ORDER BY e.Emp_Name
            ", con);

            cmd.Parameters.AddWithValue("@DeptId", departmentId);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string empCode = dr["Emp_code"].ToString();
                if (!empCode.StartsWith("EMP-"))
                    empCode = "EMP-" + empCode.PadLeft(3, '0');

                cmbEmployee.Items.Add(new ComboBoxItem
                {
                    Id = Convert.ToInt32(dr["Emp_id"]),          // EmpId
                    ExtraId = Convert.ToInt32(dr["RoleId"]),    // RoleId
                    EmpName = dr["Emp_Name"].ToString(),
                    Text = $"{empCode} - {dr["Emp_Name"]} - {dr["RoleName"]}"
                });
            }
        }

        // ================= DEPARTMENT CHANGE =================
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedIndex <= 0) return;

            if (cmbDepartment.SelectedItem is ComboBoxItem dept)
            {
                LoadEmployeesByDepartment(dept.Id);
            }
        }

        // ================= PASSWORD TOGGLE (LOGIN FORM SAME) =================
        private void picTogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            txtPassword.PasswordChar = isPasswordVisible ? '\0' : '●';

            picTogglePassword.Image = isPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_close;
        }

        // 🔒 Auto hide when focus leaves
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';
            picTogglePassword.Image = Properties.Resources.eye_close;
            isPasswordVisible = false;
        }

        // ================= SAVE LOGIN =================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cmbDepartment.SelectedIndex <= 0 ||
                cmbEmployee.SelectedIndex <= 0)
            {
                MessageBox.Show("Please fill all details");
                return;
            }

            ComboBoxItem empItem = (ComboBoxItem)cmbEmployee.SelectedItem;
            ComboBoxItem deptItem = (ComboBoxItem)cmbDepartment.SelectedItem;

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            using SqlCommand cmd = new SqlCommand(@"
                INSERT INTO EMPLOYEE_MASTER.dbo.Users
                (Emp_id, Username, Password, RealName, RoleId, DepartmentId, IsActive, CreatedAt)
                VALUES
                (@EmpId, @Username, @Password, @RealName, @RoleId, @DepartmentId, 1, GETDATE())
            ", con);

            cmd.Parameters.AddWithValue("@EmpId", empItem.Id);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim()); // later hash
            cmd.Parameters.AddWithValue("@RealName", empItem.EmpName);
            cmd.Parameters.AddWithValue("@RoleId", empItem.ExtraId);
            cmd.Parameters.AddWithValue("@DepartmentId", deptItem.Id);

            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Login details saved successfully ✔");
            ClearForm();
        }

        // ================= CLEAR =================
        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();

            txtPassword.PasswordChar = '●';
            picTogglePassword.Image = Properties.Resources.eye_close;
            isPasswordVisible = false;

            cmbDepartment.SelectedIndex = 0;

            cmbEmployee.Items.Clear();
            cmbEmployee.Items.Add("-- Select Employee --");
            cmbEmployee.SelectedIndex = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
