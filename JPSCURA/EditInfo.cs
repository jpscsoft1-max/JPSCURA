using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class EditInfo : Form
    {
        public event Action<string> UserNameUpdated;
        // ===== OLD VALUES =====
        private string oldName;
        private string oldContact;
        private string oldAltContact;
        private string oldAddress;
        private string oldAccount;
        private string oldIFSC;

        public EditInfo()
        {
            InitializeComponent();

        }

        // ================= FORM LOAD =================
        private void EditInfo_Load(object sender, EventArgs e)
        {
            ApplyBaseUI();          // 👈 clean display mode
            LoadLoggedInUserData(); // 👈 load current user
            UpdateUserProfile();
            FixAlignment();
        }

        // ================= BASE UI (VIEW MODE) =================
        private void ApplyBaseUI()
        {
            Font labelFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            Font valueFont = new Font("Segoe UI", 12F, FontStyle.Regular);

            foreach (Control ctrl in tblProfile.Controls)
            {
                // ===== LABEL =====
                if (ctrl is Label lbl)
                {
                    lbl.Font = labelFont;
                    lbl.ForeColor = Color.Black;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                }

                // ===== TEXTBOX =====
                if (ctrl is TextBox txt)
                {
                    txt.Font = valueFont;
                    txt.BorderStyle = BorderStyle.None;
                    txt.BackColor = Color.White;
                    txt.ReadOnly = true;
                    txt.Cursor = Cursors.Default;
                    txt.TabStop = false;

                    // remove old underline if any
                    txt.Controls.Clear();
                }
            }
        }

        // ================= EDIT MODE =================
        private void EnableEditMode()
        {
            EnableEditable(txtName);
            EnableEditable(txtContact);
            EnableEditable(txtAltContact);
            EnableEditable(txtAddress);
            EnableEditable(txtEmail);
            EnableEditable(txtBankAcc);
            EnableEditable(txtIFSC);
        }
        private void FixAlignment()
        {
            foreach (Control c in tblProfile.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    txt.Margin = new Padding(3, 8, 3, 3);
                }
                else if (c is Label lbl)
                {
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                    lbl.Margin = new Padding(3, 8, 3, 3);
                }
            }
        }

        private void EnableEditable(TextBox txt)
        {
            txt.ReadOnly = false;
            txt.Cursor = Cursors.IBeam;
            txt.TabStop = true;

            // Bottom RoyalBlue underline
            Panel underline = new Panel
            {
                Height = 2,
                Dock = DockStyle.Bottom,
                BackColor = Color.RoyalBlue
            };

            txt.Controls.Add(underline);
        }

        // ================= LOAD LOGGED IN USER =================
        private void LoadLoggedInUserData()
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            using SqlCommand cmd = new SqlCommand(@"
SELECT
    e.Emp_code,
    e.Emp_Name,
    e.Contact_no,
    e.Alt_Contact,
    e.Email,
    e.Address,
    e.Aadharcard,
    e.Account_No,
    e.IFSC_Code,
    e.Blood_Grp,
    d.DepartmentName,
    r.RoleName
FROM EMPLOYEE_MASTER..Users u
INNER JOIN EMPLOYEE_MASTER..Employees e
    ON u.Emp_id = e.Emp_id
LEFT JOIN EMPLOYEE_MASTER..Departments d
    ON e.DepartmentId = d.DepartmentId
LEFT JOIN EMPLOYEE_MASTER..Roles r
    ON e.RoleId = r.RoleId
WHERE u.UserId = @UserId;
", con);

            cmd.Parameters.AddWithValue("UserId", Session.UserId);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtEmpCode.Text = dr["Emp_code"].ToString();
                txtName.Text = dr["Emp_Name"].ToString();
                txtContact.Text = dr["Contact_no"].ToString();
                txtAltContact.Text = dr["Alt_Contact"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtAadhar.Text = dr["Aadharcard"].ToString();
                txtBankAcc.Text = dr["Account_No"].ToString();
                txtIFSC.Text = dr["IFSC_Code"].ToString();
                txtBloodGroup.Text = dr["Blood_Grp"].ToString();
                txtDepartment.Text = dr["DepartmentName"].ToString();
                txtRole.Text = dr["RoleName"].ToString();

                // ===== STORE ORIGINAL VALUES =====
                oldName = txtName.Text.Trim();
                oldContact = txtContact.Text.Trim();
                oldAltContact = txtAltContact.Text.Trim();
                oldAddress = txtAddress.Text.Trim();
                oldAccount = txtBankAcc.Text.Trim();
                oldIFSC = txtIFSC.Text.Trim();

            }
        }
        //For Update Detailes In DB
        private void UpdateUserProfile()
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            using SqlCommand cmd = new SqlCommand(@"
UPDATE EMPLOYEE_MASTER..Employees
SET
    Emp_Name   = @Name,
    Contact_no = @Contact,
    Alt_Contact = @AltContact,
    IFSC_Code=@ifsc,
Account_No=@account,
    Address    = @Address
WHERE Emp_id = @EmpId
", con);

            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
            cmd.Parameters.AddWithValue("@AltContact", txtAltContact.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@account", txtBankAcc.Text.Trim());
            cmd.Parameters.AddWithValue("@ifsc", txtIFSC.Text.Trim());
            cmd.Parameters.AddWithValue("@EmpId", Session.UserId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // ================= EDIT PROFILE CLICK =================


        private void btnSaveUSer_Click(object sender, EventArgs e)
        {
            {
                // ===== NO CHANGE VALIDATION =====
                bool isChanged =
                    oldName != txtName.Text.Trim() ||
                    oldContact != txtContact.Text.Trim() ||
                    oldAltContact != txtAltContact.Text.Trim() ||
                    oldAddress != txtAddress.Text.Trim() ||
                    oldAccount != txtBankAcc.Text.Trim() ||
                    oldIFSC != txtIFSC.Text.Trim();

                if (!isChanged)
                {
                    MessageBox.Show(
                        "No changes detected.\nPlease edit something before saving.",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // ===== CONFIRMATION =====
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to save the changes?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    RestoreOldValues(); // old data back
                    EnableEditMode();   // still editable
                    return;
                }

                // ===== UPDATE DATABASE =====
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                using SqlCommand cmd = new SqlCommand(@"
UPDATE e
SET 
    e.Emp_Name = @Name,
    e.Contact_no = @Contact,
    e.Alt_Contact = @AltContact,
    e.IFSC_Code = @IFSC,
    e.Account_No = @Account,
    e.Address = @Address
FROM EMPLOYEE_MASTER..Employees e
INNER JOIN EMPLOYEE_MASTER..Users u ON u.Emp_id = e.Emp_id
WHERE u.UserId = @UserId
", con);

                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@AltContact", txtAltContact.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Account", txtBankAcc.Text.Trim());
                cmd.Parameters.AddWithValue("@IFSC", txtIFSC.Text.Trim());
                cmd.Parameters.AddWithValue("@UserId", Session.UserId);

                con.Open();
                cmd.ExecuteNonQuery();

                // ===== SESSION + UI =====
                Session.RealName = txtName.Text.Trim();
                UserNameUpdated?.Invoke(Session.RealName);

                ApplyBaseUI();
                LoadLoggedInUserData();

                MessageBox.Show(
                    "Profile updated successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            ApplyBaseUI();   // reset first
            EnableEditMode();
        }

        private void RestoreOldValues()
        {
            txtName.Text = oldName;
            txtContact.Text = oldContact;
            txtAltContact.Text = oldAltContact;
            txtAddress.Text = oldAddress;
            txtBankAcc.Text = oldAccount;
            txtIFSC.Text = oldIFSC;
        }

    }
}
