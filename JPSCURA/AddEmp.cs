using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class AddEmp : Form
    {
        // ✅ FLAG to prevent validation during clear
        private bool isClearing = false;
        private bool emailEdited = false;

        public AddEmp()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void AddEmp_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadBloodGroup();

            // Set placeholder for Employee Code
            SetPlaceholder(txtEMPCode, "Enter Employee Code");

            // Max length limits
            txtAadhar.MaxLength = 12;
            txtContact.MaxLength = 10;
            txtAltContact.MaxLength = 10;
            txtBankAcc.MaxLength = 18;
            txtIFSC.MaxLength = 11;

            // Digit-only fields
            txtAadhar.KeyPress += AllowOnlyDigits;
            txtContact.KeyPress += AllowOnlyDigits;
            txtAltContact.KeyPress += AllowOnlyDigits;
            txtBankAcc.KeyPress += AllowOnlyDigits;
            txtEmail.TextChanged += (s, e) =>
            {
                if (!isClearing)
                    emailEdited = true;
            };

            // IFSC restrictions
            txtIFSC.KeyPress += txtIFSC_KeyPress;
            txtIFSC.TextChanged += (s, ev) =>
            {
                if (!isClearing)
                {
                    txtIFSC.Text = txtIFSC.Text.ToUpper();
                    txtIFSC.SelectionStart = txtIFSC.Text.Length;
                }
            };

            // Email validation on leave
            txtEmail.Leave += txtEmail_Leave;
        }

        // ================= PLACEHOLDER HELPERS =================
        private void SetPlaceholder(TextBox txt, string placeholderText)
        {
            // Store placeholder in Tag
            txt.Tag = placeholderText;

            // Set initial placeholder
            txt.Text = placeholderText;
            txt.ForeColor = Color.Gray;

            // Remove existing handlers to avoid duplicates
            txt.Enter -= RemovePlaceholder;
            txt.Leave -= RestorePlaceholder;

            // Attach handlers
            txt.Enter += RemovePlaceholder;
            txt.Leave += RestorePlaceholder;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (isClearing) return; // ✅ Don't trigger during clear

            TextBox txt = (TextBox)sender;
            if (txt.ForeColor == Color.Gray && txt.Tag != null)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void RestorePlaceholder(object sender, EventArgs e)
        {
            if (isClearing) return; // ✅ Don't trigger during clear

            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text) && txt.Tag != null)
            {
                txt.Text = txt.Tag.ToString();
                txt.ForeColor = Color.Gray;
            }
        }

        // ================= COMMON =================
        private void InsertSelect(DataTable dt, string idCol, string nameCol)
        {
            DataRow dr = dt.NewRow();
            dr[idCol] = 0;
            dr[nameCol] = "-- Select --";
            dt.Rows.InsertAt(dr, 0);
        }

        private int GetComboValueSafe(ComboBox cmb)
        {
            if (cmb.SelectedValue == null)
                return 0;

            if (cmb.SelectedValue is DataRowView drv)
                return Convert.ToInt32(drv.Row[0]);

            return Convert.ToInt32(cmb.SelectedValue);
        }

        // ================= LOAD DEPARTMENT =================
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
            if (isClearing) return; // ✅ Don't trigger during clear

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

        // ================= VALIDATION HELPERS =================
        private void AllowOnlyDigits(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtIFSC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            // 🔒 CLEAR / PROGRAMMATIC CHANGE → SKIP
            if (isClearing)
                return;

            // 🔒 USER NE TYPE HI NAHI KIYA → SKIP
            if (!emailEdited)
                return;

            // 🔒 EMPTY → SKIP (add-time validation me already handle ho raha)
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return;

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show(
                    "Invalid email format",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
            }
        }

        

        // ================= GET ACTUAL TEXT (SKIP PLACEHOLDER) =================
        private string GetActualText(TextBox txt)
        {
            // If text is placeholder (gray color), return empty
            if (txt.ForeColor == Color.Gray && txt.Tag != null)
                return "";

            return txt.Text.Trim();
        }

        // ================= ADD EMPLOYEE =================
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            int deptId = GetComboValueSafe(cmbDepartment);
            int roleId = GetComboValueSafe(cmbRole);

            if (deptId <= 0 || roleId <= 0 || cmbBloodGroup.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Department, Role and Blood Group");
                return;
            }

            // ✅ Get actual employee code (skip placeholder)
            string empCode = GetActualText(txtEMPCode);
            if (string.IsNullOrEmpty(empCode))
            {
                MessageBox.Show("Employee code is required");
                txtEMPCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEMP.Text))
            {
                MessageBox.Show("Employee name is required");
                txtEMP.Focus();
                return;
            }

            if (txtContact.Text.Length != 10)
            {
                MessageBox.Show("Contact number must be exactly 10 digits");
                txtContact.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtAltContact.Text) &&
                txtAltContact.Text.Length != 10)
            {
                MessageBox.Show("Alternate contact must be exactly 10 digits");
                txtAltContact.Focus();
                return;
            }

            if (txtAadhar.Text.Length != 12)
            {
                MessageBox.Show("Aadhar must be exactly 12 digits");
                txtAadhar.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required");
                txtEmail.Focus();
                return;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid email address");
                txtEmail.Focus();
                return;
            }

            if (txtIFSC.Text.Length != 11)
            {
                MessageBox.Show("IFSC code must be exactly 11 characters");
                txtIFSC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBankAcc.Text))
            {
                MessageBox.Show("Bank account number is required");
                txtBankAcc.Focus();
                return;
            }

            try
            {
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
INSERT INTO EMPLOYEE_MASTER..Employees
(Emp_code, Emp_Name, Contact_no, Alt_Contact, Email,
 Address, Aadharcard, Blood_Grp,
 Account_No, RoleId, DepartmentId,
 CreatedAt, IFSC_Code, IsActive)
VALUES
(@code,@name,@contact,@alt,@email,
 @addr,@aadhar,@blood,
 @acc,@role,@dept,
 GETDATE(),@ifsc,1)", con);

                cmd.Parameters.AddWithValue("@code", empCode);
                cmd.Parameters.AddWithValue("@name", txtEMP.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@alt", txtAltContact.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@addr", txtaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@aadhar", Convert.ToInt64(txtAadhar.Text.Trim()));
                cmd.Parameters.AddWithValue("@blood", cmbBloodGroup.Text);
                cmd.Parameters.AddWithValue("@acc", txtBankAcc.Text.Trim());
                cmd.Parameters.AddWithValue("@ifsc", txtIFSC.Text.Trim());
                cmd.Parameters.AddWithValue("@role", roleId);
                cmd.Parameters.AddWithValue("@dept", deptId);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Employee added successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearEmployeeForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= CLEAR =================
        private void ClearEmployeeForm()
        {
            emailEdited = false;

            // 🔥 ULTIMATE FIX: Detach Leave event BEFORE setting flag
            txtEmail.Leave -= txtEmail_Leave;

            // Set flag
            isClearing = true;

            try
            {
                // 🔹 CLEAR ALL TEXT FIELDS
                txtEMPCode.Text = "";
                txtEMP.Text = "";
                txtContact.Text = "";
                txtAltContact.Text = "";
                txtEmail.Text = "";
                txtaddress.Text = "";
                txtAadhar.Text = "";
                txtBankAcc.Text = "";
                txtIFSC.Text = "";

                // 🔹 RESET COMBO BOXES
                cmbDepartment.SelectedIndex = 0;

                cmbRole.DataSource = null;
                cmbRole.Items.Clear();
                cmbRole.Items.Add("-- Select --");
                cmbRole.SelectedIndex = 0;

                cmbBloodGroup.SelectedIndex = 0;
            }
            finally
            {
                // Reset flag
                isClearing = false;

                // 🔥 Re-attach email validation
                txtEmail.Leave += txtEmail_Leave;
            }

            // 🔥 Restore placeholder with full setup
            txtEMPCode.Tag = "Enter Employee Code";
            txtEMPCode.Text = "Enter Employee Code";
            txtEMPCode.ForeColor = Color.Gray;

            // Ensure events are attached
            txtEMPCode.Enter -= RemovePlaceholder;
            txtEMPCode.Leave -= RestorePlaceholder;
            txtEMPCode.Enter += RemovePlaceholder;
            txtEMPCode.Leave += RestorePlaceholder;

            // Focus
            txtEMPCode.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearEmployeeForm();
        }
    }
}