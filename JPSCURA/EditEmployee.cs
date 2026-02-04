using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace JPSCURA
{
    

    public partial class EditEmployee : Form
    {
        // 🔒 VALIDATION HELPERS
        private bool isLoadingData = false;

        // 🔒 ORIGINAL VALUES (FOR CHANGE DETECTION)
        private string _origEmpName;
        private string _origContact;
        private string _origAltContact;
        private string _origEmail;
        private string _origAddress;
        private string _origAadhar;
        private string _origBlood;
        private string _origAccount;
        private string _origIFSC;
        private int _origDepartmentId;
        private int _origRoleId;
        private readonly int _empId;

        // ================= CONSTRUCTOR =================
        public EditEmployee(int empId)
        {
            InitializeComponent();
            _empId = empId;

        }
        public static class SecurityHelper
        {
            public static bool ConfirmWithPassword()
            {
                using (PasswordConfirmForm frm = new PasswordConfirmForm())
                {
                    return frm.ShowDialog() == DialogResult.OK && frm.IsVerified;
                }
            }
        }

        // ================= FORM LOAD =================
        private void EditEmployee_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnUpdate;
            this.CancelButton = btncancel;

            isLoadingData = true;

            LoadDepartments();
            LoadEmployeeData();

            // 🔢 MAX LENGTHS
            txtContact.MaxLength = 10;
            txtAltContact.MaxLength = 10;
            txtAadhar.MaxLength = 12;
            txtAccountNo.MaxLength = 18;
            txtIFSC.MaxLength = 11;

            // 🔢 DIGIT ONLY
            txtContact.KeyPress += AllowOnlyDigits;
            txtAltContact.KeyPress += AllowOnlyDigits;
            txtAadhar.KeyPress += AllowOnlyDigits;
            txtAccountNo.KeyPress += AllowOnlyDigits;

            // 🏧 IFSC
            txtIFSC.KeyPress += IFSC_KeyPress;
            txtIFSC.TextChanged += (s, e2) =>
            {
                txtIFSC.Text = txtIFSC.Text.ToUpper();
                txtIFSC.SelectionStart = txtIFSC.Text.Length;
            };

            // ✉️ EMAIL
            txtEmail.Leave += txtEmail_Leave;

            isLoadingData = false;
        }


        private void LoadEmployeeData()
        {
            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
        SELECT
            Emp_code,
            Emp_Name,
            Contact_no,
            Alt_Contact,
            Email,
            Address,
            Aadharcard,
            Blood_Grp,
            Account_No,
            IFSC_Code,
            DepartmentId,
            RoleId
        FROM EMPLOYEE_MASTER..Employees
        WHERE Emp_id = @EmpId
    ", con);

            cmd.Parameters.AddWithValue("@EmpId", _empId);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtEmpCode.Text = dr["Emp_code"].ToString();
                txtEmpName.Text = dr["Emp_Name"].ToString();
                txtContact.Text = dr["Contact_no"].ToString();
                txtAltContact.Text = dr["Alt_Contact"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtAadhar.Text = dr["Aadharcard"].ToString();
                txtBloodGroup.Text = dr["Blood_Grp"].ToString();
                txtAccountNo.Text = dr["Account_No"].ToString();
                txtIFSC.Text = dr["IFSC_Code"].ToString();

                int deptId = Convert.ToInt32(dr["DepartmentId"]);
                int roleId = Convert.ToInt32(dr["RoleId"]);
                // 🔥 STORE ORIGINAL VALUES
                _origEmpName = txtEmpName.Text.Trim();
                _origContact = txtContact.Text.Trim();
                _origAltContact = txtAltContact.Text.Trim();
                _origEmail = txtEmail.Text.Trim();
                _origAddress = txtAddress.Text.Trim();
                _origAadhar = txtAadhar.Text.Trim();
                _origBlood = txtBloodGroup.Text.Trim();
                _origAccount = txtAccountNo.Text.Trim();
                _origIFSC = txtIFSC.Text.Trim();
                _origDepartmentId = deptId;
                _origRoleId = roleId;

                // 🔥 SET DEPARTMENT FIRST
                cmbDepartment.SelectedValue = deptId;

                // 🔥 LOAD ROLES OF THAT DEPARTMENT
                LoadRolesByDepartment(deptId);

                // 🔥 SET ROLE
                cmbRole.SelectedValue = roleId;
            }

            txtEmpCode.ReadOnly = true;
        }


        // ================= UPDATE BUTTON =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;
            if (!HasAnyChange())
            {
                MessageBox.Show(
                    "No changes detected.\nPlease modify at least one field before updating.",
                    "Nothing to Update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            if (cmbDepartment.SelectedValue == null || cmbRole.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select Department and Role",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            con.Open();
            using SqlTransaction tran = con.BeginTransaction();

            try
            {
                // ================= UPDATE EMPLOYEES =================
                using SqlCommand cmdEmp = new SqlCommand(@"
            UPDATE EMPLOYEE_MASTER..Employees
            SET
                Emp_Name     = @EmpName,
                Contact_no   = @Contact,
                Alt_Contact  = @AltContact,
                Email        = @Email,
                Address      = @Address,
                Aadharcard   = @Aadhar,
                Blood_Grp    = @Blood,
                Account_No   = @Account,
                IFSC_Code    = @IFSC,
                DepartmentId = @DepartmentId,
                RoleId       = @RoleId
            WHERE Emp_id = @EmpId
        ", con, tran);

                cmdEmp.Parameters.AddWithValue("@EmpName", txtEmpName.Text.Trim());
                cmdEmp.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                cmdEmp.Parameters.AddWithValue("@AltContact", txtAltContact.Text.Trim());
                cmdEmp.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmdEmp.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmdEmp.Parameters.AddWithValue("@Aadhar", txtAadhar.Text.Trim());
                cmdEmp.Parameters.AddWithValue("@Blood", txtBloodGroup.Text.Trim());
                cmdEmp.Parameters.AddWithValue("@Account", txtAccountNo.Text.Trim());
                cmdEmp.Parameters.AddWithValue("@IFSC", txtIFSC.Text.Trim());
                cmdEmp.Parameters.AddWithValue("@DepartmentId", cmbDepartment.SelectedValue);
                cmdEmp.Parameters.AddWithValue("@RoleId", cmbRole.SelectedValue);
                cmdEmp.Parameters.AddWithValue("@EmpId", _empId);

                cmdEmp.ExecuteNonQuery();

                // ================= UPDATE USERS =================
                using SqlCommand cmdUser = new SqlCommand(@"
            UPDATE EMPLOYEE_MASTER..Users
            SET
               
                DepartmentId = @DepartmentId,
                RoleId       = @RoleId
            WHERE Emp_id = @EmpId
        ", con, tran);

               
                cmdUser.Parameters.AddWithValue("@DepartmentId", cmbDepartment.SelectedValue);
                cmdUser.Parameters.AddWithValue("@RoleId", cmbRole.SelectedValue);
                cmdUser.Parameters.AddWithValue("@EmpId", _empId);

                cmdUser.ExecuteNonQuery();

                // ================= COMMIT =================
                tran.Commit();

                MessageBox.Show(
                    "Employee & User details updated successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(
                    "Update failed:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ================= VALIDATION =================
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtEmpName.Text))
            {
                MessageBox.Show("Employee name is required");
                txtEmpName.Focus();
                return false;
            }

            if (txtContact.Text.Length != 10)
            {
                MessageBox.Show("Contact number must be exactly 10 digits");
                txtContact.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtAltContact.Text) &&
                txtAltContact.Text.Length != 10)
            {
                MessageBox.Show("Alternate contact must be exactly 10 digits");
                txtAltContact.Focus();
                return false;
            }

            if (txtAadhar.Text.Length != 12)
            {
                MessageBox.Show("Aadhar must be exactly 12 digits");
                txtAadhar.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Invalid email address");
                txtEmail.Focus();
                return false;
            }

            if (txtIFSC.Text.Length != 11)
            {
                MessageBox.Show("Invalid IFSC code");
                txtIFSC.Focus();
                return false;
            }

            return true;
        }


        // ================= CANCEL BUTTON (OPTIONAL) =================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string empName = txtEmpName.Text.Trim();

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete this employee?\n\n" +
                $"Employee Name: {empName}",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            // 🔐 PASSWORD CONFIRM (ADDED)
            if (!SecurityHelper.ConfirmWithPassword())
                return;

            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
        UPDATE EMPLOYEE_MASTER..Employees
        SET IsActive = 0
        WHERE Emp_id = @EmpId
    ", con);

            cmd.Parameters.AddWithValue("@EmpId", _empId);

            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show(
                $"Employee '{empName}' deleted successfully.",
                "Deleted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        }

        private void LoadDepartments()
        {
            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(
                "SELECT DepartmentId, DepartmentName FROM EMPLOYEE_MASTER..Departments",
                con);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentId";
            cmbDepartment.DataSource = dt;
        }
        private void LoadRolesByDepartment(int departmentId)
        {
            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
        SELECT RoleId, RoleName
        FROM EMPLOYEE_MASTER..Roles
        WHERE DepartmentId = @DepartmentId
    ", con);

            cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleId";
            cmbRole.DataSource = dt;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedValue == null)
                return;

            if (cmbDepartment.SelectedValue is int deptId)
            {
                LoadRolesByDepartment(deptId);
            }
        }

        private bool HasAnyChange()
        {
            if (_origEmpName != txtEmpName.Text.Trim()) return true;
            if (_origContact != txtContact.Text.Trim()) return true;
            if (_origAltContact != txtAltContact.Text.Trim()) return true;
            if (_origEmail != txtEmail.Text.Trim()) return true;
            if (_origAddress != txtAddress.Text.Trim()) return true;
            if (_origAadhar != txtAadhar.Text.Trim()) return true;
            if (_origBlood != txtBloodGroup.Text.Trim()) return true;
            if (_origAccount != txtAccountNo.Text.Trim()) return true;
            if (_origIFSC != txtIFSC.Text.Trim()) return true;

            if (_origDepartmentId != Convert.ToInt32(cmbDepartment.SelectedValue)) return true;
            if (_origRoleId != Convert.ToInt32(cmbRole.SelectedValue)) return true;

            return false; 
        }

        // ================= INPUT RESTRICTIONS =================
        private void AllowOnlyDigits(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void IFSC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled =
                !char.IsLetterOrDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (isLoadingData) return;

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show(
                    "Invalid email format",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtEmail.Focus();
            }
        }

    }
}
