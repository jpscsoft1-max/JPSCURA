using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class AddEmp : Form
    {
        public AddEmp()
        {
            InitializeComponent();
        }

        private void AddEmp_Load(object sender, EventArgs e)
        {
            LoadDepartments();
       
            LoadBloodGroup();
        }
        private void InsertSelect(DataTable dt, string idCol, string nameCol)
        {
            DataRow dr = dt.NewRow();
            dr[idCol] = 0;
            dr[nameCol] = "-- Select --";
            dt.Rows.InsertAt(dr, 0);
        }

        private void LoadDepartments()
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT DepartmentId, DepartmentName FROM EMPLOYEE_MASTER..Departments ORDER BY DepartmentName",
                con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            InsertSelect(dt, "DepartmentId", "DepartmentName");

            cmbDepartment.DataSource = dt;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentId";
        }

        private void LoadRolesByDepartment(int departmentId)
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());

            SqlDataAdapter da = new SqlDataAdapter(
                @"SELECT RoleId, RoleName 
          FROM EMPLOYEE_MASTER..Roles
          WHERE DepartmentId = @deptId
          ORDER BY RoleName", con);

            da.SelectCommand.Parameters.AddWithValue("@deptId", departmentId);

            DataTable dt = new DataTable();
            da.Fill(dt);

            InsertSelect(dt, "RoleId", "RoleName");

            cmbRole.DataSource = dt;
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleId";
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptId = GetComboValueSafe(cmbDepartment);

            if (deptId > 0)
            {
                LoadRolesByDepartment(deptId);
                cmbRole.SelectedIndex = 0;
            }
            else
            {
                cmbRole.DataSource = null;
                cmbRole.Items.Clear();
                cmbRole.Items.Add("-- Select --");
                cmbRole.SelectedIndex = 0;
            }
        }

        private void LoadBloodGroup()
        {
            cmbBloodGroup.Items.Clear();

            cmbBloodGroup.Items.Add("-- Select Blood Group --");
            cmbBloodGroup.Items.Add("A+");
            cmbBloodGroup.Items.Add("A-");
            cmbBloodGroup.Items.Add("B+");
            cmbBloodGroup.Items.Add("B-");
            cmbBloodGroup.Items.Add("O+");
            cmbBloodGroup.Items.Add("O-");
            cmbBloodGroup.Items.Add("AB+");
            cmbBloodGroup.Items.Add("AB-");

            cmbBloodGroup.SelectedIndex = 0;
        }
        private int GetComboValueSafe(ComboBox cmb)
        {
            if (cmb.SelectedValue == null)
                return 0;

            if (cmb.SelectedValue is DataRowView drv)
                return Convert.ToInt32(drv.Row[0]);

            return Convert.ToInt32(cmb.SelectedValue);
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            int deptId = GetComboValueSafe(cmbDepartment);
            int roleId = GetComboValueSafe(cmbRole);

            if (deptId <= 0 || roleId <= 0 || cmbBloodGroup.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Department, Role and Blood Group");
                return;
            }

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            con.Open();

            SqlCommand cmd = new SqlCommand(@"
INSERT INTO EMPLOYEE_MASTER..Employees
(Emp_code, Emp_Name, Contact_no, Alt_Contact, Email,
 Address, Aadharcard, Blood_Grp,
 Account_No, RoleId, DepartmentId,
 CreatedAt, IFSC_Code,IsActive)
VALUES
(@code,@name,@contact,@alt,@email,
 @addr,@aadhar,@blood,
 @acc,@role,@dept,
 GETDATE(),@ifsc,1)", con);

            cmd.Parameters.AddWithValue("@code", txtEMPCode.Text.Trim());
            cmd.Parameters.AddWithValue("@name", txtEMP.Text.Trim());
            cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
            cmd.Parameters.AddWithValue("@alt", txtAltContact.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@addr", txtaddress.Text.Trim());
            cmd.Parameters.AddWithValue("@aadhar", txtAadhar.Text.Trim());
            cmd.Parameters.AddWithValue("@blood", cmbBloodGroup.Text);
            cmd.Parameters.AddWithValue("@acc", txtBankAcc.Text.Trim());
            cmd.Parameters.AddWithValue("@ifsc", txtIFSC.Text.Trim());
            cmd.Parameters.AddWithValue("@role", roleId);
            cmd.Parameters.AddWithValue("@dept", deptId);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Employee added successfully");
            ClearEmployeeForm();
        }

        private void ClearEmployeeForm()
        {
            // TextBoxes clear
            txtEMPCode.Clear();
            txtEMP.Clear();
            txtContact.Clear();
            txtAltContact.Clear();
            txtEmail.Clear();
            txtaddress.Clear();
            txtAadhar.Clear();
            txtBankAcc.Clear();
            txtIFSC.Clear();

            // Department reset
            cmbDepartment.SelectedIndex = 0;

            // Role combo safe reset
            cmbRole.DataSource = null;
            cmbRole.Items.Clear();
            cmbRole.Text = "-- Select --";

            // Blood group reset
            if (cmbBloodGroup.Items.Count > 0)
                cmbBloodGroup.SelectedIndex = 0;

            txtEMPCode.Focus();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearEmployeeForm ();
        }
    }
}
