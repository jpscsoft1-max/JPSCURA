using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class EditInfo : Form
    {
        public event Action<string> UserNameUpdated;

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
    e.Blood_Grp,
    d.DepartmentName,
    r.RoleName
FROM EMPLOYEE_MASTER..Employees e
LEFT JOIN EMPLOYEE_MASTER..Departments d
    ON e.DepartmentId = d.DepartmentId
LEFT JOIN EMPLOYEE_MASTER..Roles r
    ON e.RoleId = r.RoleId
WHERE e.Emp_id = @EmpId
", con);

            cmd.Parameters.AddWithValue("@EmpId", Session.UserId);

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
                txtBloodGroup.Text = dr["Blood_Grp"].ToString();
                txtDepartment.Text = dr["DepartmentName"].ToString();
                txtRole.Text = dr["RoleName"].ToString();
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
    Address    = @Address
WHERE Emp_id = @EmpId
", con);

            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
            cmd.Parameters.AddWithValue("@AltContact", txtAltContact.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@EmpId", Session.UserId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // ================= EDIT PROFILE CLICK =================
        private void lblEditProfile_Click(object sender, EventArgs e)
        {
            ApplyBaseUI();   // reset first
            EnableEditMode();
        }

        private void btnSaveUSer_Click(object sender, EventArgs e)
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            using SqlCommand cmd = new SqlCommand(@"
UPDATE EMPLOYEE_MASTER..Employees
SET 
    Emp_Name = @Name,
    Contact_no = @Contact,
    Alt_Contact = @AltContact,
    Address = @Address
WHERE Emp_id = @EmpId
", con);

            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
            cmd.Parameters.AddWithValue("@AltContact", txtAltContact.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@EmpId", Session.UserId);

            con.Open();
            cmd.ExecuteNonQuery();

            // 🔹 STEP 2.1: SESSION UPDATE
            Session.RealName = txtName.Text.Trim();

            // 🔹 STEP 2.2: HOME KO SIGNAL
            UserNameUpdated?.Invoke(Session.RealName);

            // 🔹 STEP 2.3: BACK TO DISPLAY MODE
            ApplyBaseUI();
            LoadLoggedInUserData();

            MessageBox.Show("Profile updated successfully");
        }
    }
    }

