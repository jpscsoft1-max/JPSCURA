using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class GLD : Form
    {
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

        // ================= LOAD EMPLOYEES BY DEPARTMENT =================
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
                cmbEmployee.Items.Add(new ComboBoxItem
                {
                    Id = Convert.ToInt32(dr["Emp_id"]),          // EmpId
                    ExtraId = Convert.ToInt32(dr["RoleId"]),    // RoleId
                    Text = $"{dr["Emp_code"]} - {dr["Emp_Name"]} - {dr["RoleName"]}"
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

        // ================= SAVE =================
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

            // RealName extract (CODE - NAME - ROLE)
            string[] parts = empItem.Text.Split('-');
            string realName = parts.Length >= 2 ? parts[1].Trim() : empItem.Text;

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            using SqlCommand cmd = new SqlCommand(@"
                INSERT INTO EMPLOYEE_MASTER.dbo.Users
                (Emp_id, Username, Password, RealName, RoleId, DepartmentId)
                VALUES
                (@EmpId, @Username, @Password, @RealName, @RoleId, @DepartmentId)
            ", con);

            cmd.Parameters.AddWithValue("@EmpId", empItem.Id);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            cmd.Parameters.AddWithValue("@RealName", realName);
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

            cmbDepartment.SelectedIndex = 0;

            cmbEmployee.Items.Clear();
            cmbEmployee.Items.Add("-- Select Employee --");
            cmbEmployee.SelectedIndex = 0;
        }
    }
}
