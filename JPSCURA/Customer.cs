using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void Customer_Load(object sender, EventArgs e)
        {
            // DEFAULT
            rdoGST.Checked = true;
            txtGSTNo.Visible = true;
            txtPANNo.Visible = false;

            // EVENTS
            rdoGST.CheckedChanged += RadioChanged;
            rdoPAN.CheckedChanged += RadioChanged;
            chksameas.CheckedChanged += chksameas_CheckedChanged;
            txtCustomerAddress.TextChanged += txtBillingAddress_TextChanged;

            // GRID
            SetupCustomerGrid();
            LoadCustomerGrid();
        }

        // ================= GRID SETUP (SAME AS SEMIFINISHED) =================
        private void SetupCustomerGrid()
        {
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.EnableHeadersVisualStyles = false;

            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.LightGray;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgv.DefaultCellStyle.Font =
                new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;

            // 🔥 SAME AS SEMIFINISHED (IMPORTANT)
            dgv.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            dgv.Columns.Clear();

            dgv.Columns.Add("srno", "Sr No");
            dgv.Columns.Add("name", "Name");
            dgv.Columns.Add("contact", "Contact No");
            dgv.Columns.Add("altcontact", "Alt Contact No");
            dgv.Columns.Add("email", "Email");
            dgv.Columns.Add("gst", "GST No");
            dgv.Columns.Add("pan", "PAN No");
            dgv.Columns.Add("billing", "Billing Address");
            dgv.Columns.Add("shipping", "Shipping Address");

            dgv.Columns["srno"].FillWeight = 5;
            dgv.Columns["name"].FillWeight = 15;
            dgv.Columns["contact"].FillWeight = 10;
            dgv.Columns["altcontact"].FillWeight = 10;
            dgv.Columns["email"].FillWeight = 15;
            dgv.Columns["gst"].FillWeight = 10;
            dgv.Columns["pan"].FillWeight = 10;
            dgv.Columns["billing"].FillWeight = 18;
            dgv.Columns["shipping"].FillWeight = 18;

            dgv.ColumnHeadersHeight = 35;

            dgv.RowPostPaint += dgv_RowPostPaint;
        }

        // ================= SR NO =================
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["srno"].Value = e.RowIndex + 1;
        }

        // ================= LOAD GRID =================
        private void LoadCustomerGrid()
        {
            dgv.Rows.Clear();

            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
SELECT
    Cust_Name,
    Contact_No,
    Alt_Contact_No,
    Cust_Email,
    Customer_GST,
    Customer_PAN,
    Billing_Address,
    Shipping_Address
FROM SALES_MASTER..Customers
ORDER BY Cust_Name
", con);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgv.Rows.Add(
                    0,
                    dr["Cust_Name"],
                    dr["Contact_No"],
                    dr["Alt_Contact_No"],
                    dr["Cust_Email"],
                    dr["Customer_GST"],
                    dr["Customer_PAN"],
                    dr["Billing_Address"],
                    dr["Shipping_Address"]
                );
            }
        }

        // ================= RADIO GST / PAN =================
        private void RadioChanged(object sender, EventArgs e)
        {
            if (rdoGST.Checked)
            {
                txtGSTNo.Visible = true;
                txtPANNo.Visible = false;
                txtPANNo.Clear();
            }
            else
            {
                txtPANNo.Visible = true;
                txtGSTNo.Visible = false;
                txtGSTNo.Clear();
            }
        }

        // ================= SAME AS BILLING =================
        private void chksameas_CheckedChanged(object sender, EventArgs e)
        {
            if (chksameas.Checked)
            {
                txtshippingaddress.Text = txtCustomerAddress.Text;
                txtshippingaddress.ReadOnly = true;
            }
            else
            {
                txtshippingaddress.Clear();
                txtshippingaddress.ReadOnly = false;
            }
        }

        private void txtBillingAddress_TextChanged(object sender, EventArgs e)
        {
            if (chksameas.Checked)
                txtshippingaddress.Text = txtCustomerAddress.Text;
        }

        // ================= ADD CUSTOMER =================
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
INSERT INTO SALES_MASTER..Customers
(
    Cust_Name,
    Contact_No,
    Alt_Contact_No,
    Cust_Email,
    Customer_GST,
    Customer_PAN,
    Billing_Address,
    Shipping_Address
)
VALUES
(
    @name,
    @contact,
    @altcontact,
    @email,
    @gst,
    @pan,
    @billing,
    @shipping
)", con);

            cmd.Parameters.AddWithValue("@name", txtCustomerName.Text.Trim());
            cmd.Parameters.AddWithValue("@contact", txtCustomerMoNo.Text.Trim());
            cmd.Parameters.AddWithValue("@altcontact", txtAltContact.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtCustomerEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@gst", rdoGST.Checked ? txtGSTNo.Text.Trim() : "");
            cmd.Parameters.AddWithValue("@pan", rdoPAN.Checked ? txtPANNo.Text.Trim() : "");
            cmd.Parameters.AddWithValue("@billing", txtCustomerAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@shipping", txtshippingaddress.Text.Trim());

            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Customer added successfully ✔",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadCustomerGrid();   // 🔥 refresh grid
        }

        // ================= VALIDATION =================
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Customer name is required");
                txtCustomerName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerMoNo.Text))
            {
                MessageBox.Show("Contact number is required");
                txtCustomerMoNo.Focus();
                return false;
            }

            if (rdoGST.Checked && string.IsNullOrWhiteSpace(txtGSTNo.Text))
            {
                MessageBox.Show("GST number is required");
                txtGSTNo.Focus();
                return false;
            }

            if (rdoPAN.Checked && string.IsNullOrWhiteSpace(txtPANNo.Text))
            {
                MessageBox.Show("PAN number is required");
                txtPANNo.Focus();
                return false;
            }

            return true;
        }

        // ================= CLEAR =================
        private void ClearForm()
        {
            txtCustomerName.Clear();
            txtCustomerMoNo.Clear();
            txtAltContact.Clear();
            txtCustomerEmail.Clear();
            txtCustomerAddress.Clear();
            txtshippingaddress.Clear();
            txtGSTNo.Clear();
            txtPANNo.Clear();

            rdoGST.Checked = true;
            chksameas.Checked = false;
        }
    }
}
