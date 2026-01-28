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

        private void Customer_Load(object sender, EventArgs e)
        {
            rdoGST.Checked = true;

            txtGSTNo.Visible = true;
            txtPANNo.Visible = false;

            rdoGST.CheckedChanged += RadioChanged;
            rdoPAN.CheckedChanged += RadioChanged;

            chksameas.CheckedChanged += chksameas_CheckedChanged;
            txtCustomerAddress.TextChanged += txtBillingAddress_TextChanged;
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

        // ================= SAME AS ADDRESS =================
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

            cmd.Parameters.AddWithValue("@gst",
                rdoGST.Checked ? txtGSTNo.Text.Trim() : "");

            cmd.Parameters.AddWithValue("@pan",
                rdoPAN.Checked ? txtPANNo.Text.Trim() : "");

            cmd.Parameters.AddWithValue("@billing", txtCustomerAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@shipping", txtshippingaddress.Text.Trim());

            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show(
                "Customer added successfully ✔",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearForm();
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

        // ================= CLEAR FORM =================
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
