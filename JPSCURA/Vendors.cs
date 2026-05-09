using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class Vendors : Form
    {
        private const int SEARCH_GAP = 4;
        private CancellationTokenSource pincodeCTS;

        public Vendors()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void Vendors_Load(object sender, EventArgs e)
        {
            // DEFAULT
            rdoGST.Checked = true;
            txtGSTNo.Visible = true;
            txtPANNo.Visible = false;

            // ===== BUTTON EVENTS =====
            btnClear.Click += btnClear_Click;

            // ===== RADIO =====
            rdoGST.CheckedChanged += RadioChanged;
            rdoPAN.CheckedChanged += RadioChanged;

            // ===== CHECKBOX =====
            chksameas.CheckedChanged += chksameas_CheckedChanged;

            // ===== BILLING SYNC =====
            txtAddressLine1.TextChanged += txtBillingAddress_TextChanged;


            // ===== BILLING COPY TO SHIPPING =====
            txtAddressLine1.TextChanged += BillingChanged;
            txtAddressLine2.TextChanged += BillingChanged;
            txtPinCode.TextChanged += BillingChanged;
            txtCity.TextChanged += BillingChanged;
            txtState.TextChanged += BillingChanged;

            // ===== PINCODE =====
            txtPinCode.TextChanged += TxtPinCode_TextChanged;
            txtShipPinCode.TextChanged += TxtShipPinCode_TextChanged;

            // ===== SEARCH =====
            txtSearchVendors.TextChanged += ApplyVendorSearch;
            txtSearchVendorNo.TextChanged += ApplyVendorSearch;
            txtSearchVendorEmail.TextChanged += ApplyVendorSearch;
            txtVendorSearchGST.TextChanged += ApplyVendorSearch;
            txtVendorSearchPAN.TextChanged += ApplyVendorSearch;
            txtSeachVendorBillingAddress.TextChanged += ApplyVendorSearch;
            txtSearchVendorShippingAddress.TextChanged += ApplyVendorSearch;

            // ===== GRID EVENTS =====
            dgvVendors.Scroll += dgvVendors_Scroll;
            dgvVendors.ColumnWidthChanged += dgvVendors_ColumnWidthChanged;
            this.Resize += Vendors_Resize;

            // ✅ FINAL FIX (NO SHOWN EVENT)
            SetupVendorGrid();
            EnableDoubleBuffering(this);
            LoadVendorGrid();
            SyncVendorSearchBoxes();
        }

        private void EnableDoubleBuffering(System.Windows.Forms.Control control)
        {
            typeof(System.Windows.Forms.Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true, null);

            foreach (System.Windows.Forms.Control child in control.Controls)
                EnableDoubleBuffering(child);
        }

        // ================= GRID SETUP =================
        private void SetupVendorGrid()
        {
            dgvVendors.DataSource = null;
            dgvVendors.Columns.Clear();

            dgvVendors.AllowUserToAddRows = false;
            dgvVendors.ReadOnly = true;
            dgvVendors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendors.MultiSelect = false;
            dgvVendors.RowHeadersVisible = false;
            dgvVendors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendors.EnableHeadersVisualStyles = false;

            dgvVendors.BackgroundColor = Color.White;
            dgvVendors.GridColor = Color.LightGray;
            dgvVendors.BorderStyle = BorderStyle.FixedSingle;
            dgvVendors.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvVendors.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgvVendors.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVendors.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvVendors.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgvVendors.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvVendors.DefaultCellStyle.BackColor = Color.White;
            dgvVendors.DefaultCellStyle.ForeColor = Color.Black;
            dgvVendors.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvVendors.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvVendors.AllowUserToResizeColumns = false;
            dgvVendors.AllowUserToResizeRows = false;

            // ⭐ ADD COLUMNS WITH EXACT KEYS USED BY SEARCH & SYNC
            dgvVendors.Columns.Add("srno", "Sr No");
            dgvVendors.Columns.Add("name", "Name");
            dgvVendors.Columns.Add("contact", "Contact No");
            dgvVendors.Columns.Add("altcontact", "Alt Contact No");
            dgvVendors.Columns.Add("email", "Email");
            dgvVendors.Columns.Add("gst", "GST No");
            dgvVendors.Columns.Add("pan", "PAN No");
            dgvVendors.Columns.Add("billing", "Billing Address");
            dgvVendors.Columns.Add("shipping", "Shipping Address");

            dgvVendors.Columns["srno"].FillWeight = 5;
            dgvVendors.Columns["name"].FillWeight = 15;
            dgvVendors.Columns["contact"].FillWeight = 10;
            dgvVendors.Columns["altcontact"].FillWeight = 10;
            dgvVendors.Columns["email"].FillWeight = 15;
            dgvVendors.Columns["gst"].FillWeight = 10;
            dgvVendors.Columns["pan"].FillWeight = 10;
            dgvVendors.Columns["billing"].FillWeight = 18;
            dgvVendors.Columns["shipping"].FillWeight = 18;

            dgvVendors.ColumnHeadersHeight = 35;
            dgvVendors.RowPostPaint += dgvVendors_RowPostPaint;
        }

        // ================= SR NO =================
        private void dgvVendors_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvVendors.Rows[e.RowIndex].Cells["srno"].Value = e.RowIndex + 1;
        }

        private void LoadVendorGrid()
        {
            if (dgvVendors.Columns.Count == 0)
            {
                SetupVendorGrid();
            }

            try
            {
                dgvVendors.Rows.Clear();

                using SqlConnection con =
                    new SqlConnection(DBconection.GetConnectionString());

                using SqlCommand cmd = new SqlCommand(@"
SELECT
    Vendor_Name,
    Contact_No,
    Alt_Contact_No,
    Vendor_Email,
    Vendor_GST,
    Vendor_PAN,
    Billing_Address,
    Shipping_Address
FROM PURCHASE_MASTER.dbo.Vendors
ORDER BY Vendor_Name
", con);

                con.Open();

                using SqlDataReader dr = cmd.ExecuteReader();

                int sr = 1;

                while (dr.Read())
                {
                    dgvVendors.Rows.Add(
                        sr++,
                        dr["Vendor_Name"]?.ToString() ?? "",
                        dr["Contact_No"]?.ToString() ?? "",
                        dr["Alt_Contact_No"]?.ToString() ?? "",
                        dr["Vendor_Email"]?.ToString() ?? "",
                        dr["Vendor_GST"]?.ToString() ?? "",
                        dr["Vendor_PAN"]?.ToString() ?? "",
                        dr["Billing_Address"]?.ToString() ?? "",
                        dr["Shipping_Address"]?.ToString() ?? ""
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading vendors:\n" + ex.Message,
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvVendors.Refresh();   // ✅ force UI refresh
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
                CopyBillingToShipping();
                SetShippingReadOnly(true);
            }
            else
            {
                SetShippingReadOnly(false);
            }
        }

        private void CopyBillingToShipping()
        {
            txtShipAddressLine1.Text = txtAddressLine1.Text;
            txtShipAddressLine2.Text = txtAddressLine2.Text;
            txtShipPinCode.Text = txtPinCode.Text;
            txtShipCity.Text = txtCity.Text;
            txtShipState.Text = txtState.Text;
        }

        private void SetShippingReadOnly(bool value)
        {
            txtShipAddressLine1.ReadOnly = value;
            txtShipAddressLine2.ReadOnly = value;
            txtShipPinCode.ReadOnly = value;
            txtShipCity.ReadOnly = value;
            txtShipState.ReadOnly = value;
        }

        private void txtBillingAddress_TextChanged(object sender, EventArgs e)
        {
            if (chksameas.Checked)
                txtShipAddressLine1.Text = txtAddressLine1.Text;
        }

        // ================= ADD VENDOR =================
        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                using SqlConnection con =
                    new SqlConnection(DBconection.GetConnectionString());

                using SqlCommand cmd = new SqlCommand(@"
INSERT INTO PURCHASE_MASTER.dbo.Vendors
(
    Vendor_Name,
    Contact_No,
    Alt_Contact_No,
    Vendor_Email,
    Vendor_GST,
    Vendor_PAN,
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

                cmd.Parameters.AddWithValue("@name", txtVendorName.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", txtVendorMoNo.Text.Trim());
                cmd.Parameters.AddWithValue("@altcontact", txtAltContact.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtVendorEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@gst", rdoGST.Checked ? txtGSTNo.Text.Trim() : "");
                cmd.Parameters.AddWithValue("@pan", rdoPAN.Checked ? txtPANNo.Text.Trim() : "");
                cmd.Parameters.AddWithValue("@billing", GetBillingAddressCombined());
                cmd.Parameters.AddWithValue("@shipping", GetShippingAddressCombined());

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Vendor added successfully ✔",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadVendorGrid();
                    SyncVendorSearchBoxes(); // ⭐ re-sync search boxes after reload
                }
                else
                {
                    MessageBox.Show("Insert failed. No rows affected.",
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving vendor:\n" + ex.Message,
                    "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= VALIDATION =================
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtVendorName.Text))
            {
                MessageBox.Show("Vendor name is required");
                txtVendorName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtVendorMoNo.Text))
            {
                MessageBox.Show("Contact number is required");
                txtVendorMoNo.Focus();
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

        // ================= SEARCH =================
        private void ApplyVendorSearch(object sender, EventArgs e)
        {
            if (dgvVendors.Rows.Count == 0) return;

            string name = txtSearchVendors.Text.Trim();
            string contact = txtSearchVendorNo.Text.Trim();
            string email = txtSearchVendorEmail.Text.Trim();
            string gst = txtVendorSearchGST.Text.Trim();
            string pan = txtVendorSearchPAN.Text.Trim();
            string billing = txtSeachVendorBillingAddress.Text.Trim();
            string shipping = txtSearchVendorShippingAddress.Text.Trim();

            foreach (DataGridViewRow row in dgvVendors.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                visible &= string.IsNullOrEmpty(name) || (row.Cells["name"].Value?.ToString() ?? "").ToLower().Contains(name.ToLower());
                visible &= string.IsNullOrEmpty(contact) || (row.Cells["contact"].Value?.ToString() ?? "").StartsWith(contact);
                visible &= string.IsNullOrEmpty(email) || (row.Cells["email"].Value?.ToString() ?? "").ToLower().Contains(email.ToLower());
                visible &= string.IsNullOrEmpty(gst) || (row.Cells["gst"].Value?.ToString() ?? "").StartsWith(gst);
                visible &= string.IsNullOrEmpty(pan) || (row.Cells["pan"].Value?.ToString() ?? "").StartsWith(pan);
                visible &= string.IsNullOrEmpty(billing) || (row.Cells["billing"].Value?.ToString() ?? "").ToLower().Contains(billing.ToLower());
                visible &= string.IsNullOrEmpty(shipping) || (row.Cells["shipping"].Value?.ToString() ?? "").ToLower().Contains(shipping.ToLower());

                row.Visible = visible;
            }
        }

        // ================= SEARCH BOX SYNC =================
        private void SyncVendorSearchBoxes()
        {
            if (dgvVendors.Columns.Count == 0) return;

            SetVendorSearchBox(txtSearchVendors, "name");
            SetVendorSearchBox(txtSearchVendorNo, "contact");
            SetVendorSearchBox(txtSearchVendorEmail, "email");
            SetVendorSearchBox(txtVendorSearchGST, "gst");
            SetVendorSearchBox(txtVendorSearchPAN, "pan");
            SetVendorSearchBox(txtSeachVendorBillingAddress, "billing");
            SetVendorSearchBox(txtSearchVendorShippingAddress, "shipping");
        }

        private void SetVendorSearchBox(TextBox txt, string columnName)
        {
            if (!dgvVendors.Columns.Contains(columnName)) return;

            Rectangle rect = dgvVendors.GetColumnDisplayRectangle(
                dgvVendors.Columns[columnName].Index, true);

            txt.Left = rect.Left + dgvVendors.Left + (SEARCH_GAP / 2);
            txt.Width = rect.Width - SEARCH_GAP;
        }

        private void dgvVendors_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                SyncVendorSearchBoxes();
        }

        private void dgvVendors_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SyncVendorSearchBoxes();
        }

        private void Vendors_Resize(object sender, EventArgs e)
        {
            SyncVendorSearchBoxes();
        }

        // ================= ADDRESS HELPERS =================
        private string GetBillingAddressCombined()
        {
            return string.Join(", ",
                new[]
                {
                    txtAddressLine1.Text.Trim(),
                    txtAddressLine2.Text.Trim(),
                    txtPinCode.Text.Trim(),
                    txtCity.Text.Trim(),
                    txtState.Text.Trim()
                }.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private string GetShippingAddressCombined()
        {
            return string.Join(", ",
                new[]
                {
                    txtShipAddressLine1.Text.Trim(),
                    txtShipAddressLine2.Text.Trim(),
                    txtShipPinCode.Text.Trim(),
                    txtShipCity.Text.Trim(),
                    txtShipState.Text.Trim()
                }.Where(x => !string.IsNullOrWhiteSpace(x)));
        }



        private void BillingChanged(object sender, EventArgs e)
        {
            if (chksameas.Checked)
                CopyBillingToShipping();
        }

        // ================= PINCODE AUTO-FILL =================
        private async Task FetchPincodeData(string pincode)
        {
            try
            {
                using HttpClient client = new HttpClient();
                string url = $"https://api.postalpincode.in/pincode/{pincode}";
                var response = await client.GetStringAsync(url);
                var json = JsonDocument.Parse(response);
                var root = json.RootElement[0];

                if (root.GetProperty("Status").GetString() == "Success")
                {
                    var postOffice = root.GetProperty("PostOffice")[0];
                    txtState.Text = postOffice.GetProperty("State").GetString();
                    txtCity.Text = postOffice.GetProperty("District").GetString();

                    if (chksameas.Checked)
                        CopyBillingToShipping();
                }
            }
            catch { }
        }

        private async Task FetchShippingPincode(string pin)
        {
            try
            {
                using HttpClient client = new HttpClient();
                string url = $"https://api.postalpincode.in/pincode/{pin}";
                var response = await client.GetStringAsync(url);
                var json = JsonDocument.Parse(response);
                var root = json.RootElement[0];

                if (root.GetProperty("Status").GetString() == "Success")
                {
                    var po = root.GetProperty("PostOffice")[0];
                    txtShipCity.Text = po.GetProperty("District").GetString();
                    txtShipState.Text = po.GetProperty("State").GetString();
                }
                else
                {
                    txtShipCity.Clear();
                    txtShipState.Clear();
                }
            }
            catch { }
        }

        private async void TxtPinCode_TextChanged(object sender, EventArgs e)
        {
            pincodeCTS?.Cancel();
            pincodeCTS = new CancellationTokenSource();

            try
            {
                string pin = txtPinCode.Text.Trim();

                if (pin.Length < 6)
                {
                    txtState.Clear();
                    txtCity.Clear();

                    if (chksameas.Checked)
                        CopyBillingToShipping();

                    return;
                }

                await Task.Delay(100, pincodeCTS.Token);

                if (pin.Length == 6)
                    await FetchPincodeData(pin);
            }
            catch (TaskCanceledException) { }
        }

        private async void TxtShipPinCode_TextChanged(object sender, EventArgs e)
        {
            if (txtShipPinCode.Text.Length < 6)
            {
                txtShipCity.Clear();
                txtShipState.Clear();
                return;
            }

            await FetchShippingPincode(txtShipPinCode.Text.Trim());
        }

        // ================= CLEAR FORM =================
        private void ClearForm()
        {
            txtVendorName.Clear();
            txtVendorMoNo.Clear();
            txtAltContact.Clear();
            txtVendorEmail.Clear();
            txtGSTNo.Clear();
            txtPANNo.Clear();

            txtAddressLine1.Clear();
            txtAddressLine2.Clear();
            txtPinCode.Clear();
            txtCity.Clear();
            txtState.Clear();

            txtShipAddressLine1.Clear();
            txtShipAddressLine2.Clear();
            txtShipPinCode.Clear();
            txtShipCity.Clear();
            txtShipState.Clear();

            rdoGST.Checked = true;
            chksameas.Checked = false;
            SetShippingReadOnly(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void panelVendorsright_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}