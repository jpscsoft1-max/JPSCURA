using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class SalesQuote2ndpage : Form
    {
        private bool isLoading = false;   // ⭐ IMPORTANT (Event safe)

        public SalesQuote2ndpage()
        {
            InitializeComponent();
        }
        // ================= LOAD =================
        private void SalesQuote2ndpage_Load(object sender, EventArgs e)
        {
            isLoading = true;
            LoadCustomerCombo();
            LoadGSTTypeCombo();
            SetGSTDefault();
            cmbselectcustomer.SelectedIndexChanged += cmbselectcustomer_SelectedIndexChanged;
            isLoading = false;
        }
        // ================= CUSTOMER COMBO =================
        private void LoadCustomerCombo()
        {
            cmbselectcustomer.Items.Clear();
            cmbselectcustomer.Items.Add("Select Customer");

            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
                SELECT Cust_Name
                FROM SALES_MASTER..Customers
                ORDER BY Cust_Name
            ", con);

            con.Open();

            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbselectcustomer.Items.Add(dr["Cust_Name"]?.ToString());
            }

            if (cmbselectcustomer.Items.Count > 0)
                cmbselectcustomer.SelectedIndex = 0;
        }

        // ================= GST DEFAULT =================
        private void SetGSTDefault()
        {
            rdoGST.Checked = true;

            txtGSTno.Visible = true;
            txtPANNo.Visible = false;

            if (cmbgst.Items.Count > 0)
                cmbgst.SelectedIndex = 0;
        }

        // ================= GST TYPE COMBO =================
        private void LoadGSTTypeCombo()
        {
            cmbgst.Items.Clear();

            cmbgst.Items.Add("With GST");
            cmbgst.Items.Add("Without GST");

            if (cmbgst.Items.Count > 0)
                cmbgst.SelectedIndex = 0;
        }

        // ================= RADIO =================
        private void rdoGST_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (rdoGST.Checked)
            {
                txtGSTno.Visible = true;
                txtPANNo.Visible = false;
                txtPANNo.Clear();
                cmbgst.SelectedItem = "With GST";
            }
        }

        private void rdoPAN_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (rdoPAN.Checked)
            {
                txtPANNo.Visible = true;
                txtGSTno.Visible = false;
                txtGSTno.Clear();
                cmbgst.SelectedItem = "Without GST";
            }
        }

        // ================= CUSTOMER SELECT =================
        private void cmbselectcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (cmbselectcustomer.SelectedIndex <= 0)
            {
                ClearCustomerFields();
                return;
            }

            ClearCustomerFields();
            LoadCustomerDetails(cmbselectcustomer.Text);
        }

        // ================= CLEAR =================
        private void ClearCustomerFields()
        {
            txtGSTno.Clear();
            txtPANNo.Clear();
            txtAddressLine1.Clear();
            txtAddressLine2.Clear();
            txtPinCode.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtShipAddressLine1.Clear();
            txtShipAddressLine2.Clear();
            txtShipCity.Clear();
            txtShipPinCode.Clear();
            txtShipState.Clear();
            SetGSTDefault();
        }

        // ================= LOAD CUSTOMER DETAILS =================
        private void LoadCustomerDetails(string custName)
        {
            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
        SELECT *
        FROM SALES_MASTER..Customers
        WHERE Cust_Name = @name
    ", con);

            cmd.Parameters.AddWithValue("@name", custName);

            con.Open();

            using SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string gst = dr["Customer_GST"]?.ToString();
                string pan = dr["Customer_PAN"]?.ToString();
                string billing = dr["Billing_Address"]?.ToString();
                string shipping = dr["Shipping_Address"]?.ToString();

                // ===== GST / PAN =====
                if (!string.IsNullOrWhiteSpace(gst))
                {
                    rdoGST.Checked = true;
                    txtGSTno.Text = gst;
                    cmbgst.SelectedItem = "With GST";
                }
                else if (!string.IsNullOrWhiteSpace(pan))
                {
                    rdoPAN.Checked = true;
                    txtPANNo.Text = pan;
                    cmbgst.SelectedItem = "Without GST";
                }

                // ===== BILLING LOAD =====
                FillAddressProperly(
                    billing,
                    txtAddressLine1,
                    txtAddressLine2,
                    txtPinCode,
                    txtCity,
                    txtState);

                // ===== SHIPPING LOAD =====
                FillAddressProperly(
                    shipping,
                    txtShipAddressLine1,
                    txtShipAddressLine2,
                    txtShipPinCode,
                    txtShipCity,
                    txtShipState);
            }
        }

        // ================= ADDRESS SPLIT =================
        private void FillAddressProperly(
            string fullAddress,
            TextBox line1,
            TextBox line2,
            TextBox pin,
            TextBox city,
            TextBox state)
        {
            if (string.IsNullOrWhiteSpace(fullAddress)) return;

            var parts = fullAddress
                .Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if (parts.Count < 3)
            {
                line1.Text = fullAddress;
                return;
            }

            // ===== LAST 3 ALWAYS =====
            state.Text = parts[parts.Count - 1];
            city.Text = parts[parts.Count - 2];
            pin.Text = parts[parts.Count - 3];

            parts.RemoveRange(parts.Count - 3, 3);

            if (parts.Count > 0)
                line1.Text = parts[0];

            if (parts.Count > 1)
                line2.Text = string.Join(", ", parts.Skip(1));
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCustomerFields();
        }

    }
}
