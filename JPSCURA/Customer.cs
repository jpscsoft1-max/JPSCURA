using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;


namespace JPSCURA
{
    public partial class Customer : Form
    {
        private const int SEARCH_GAP = 4;
        private CancellationTokenSource pincodeCTS;
        private string gstSessionId = "";
        private CancellationTokenSource gstCTS;
        //private const string GST_SERVER = "http://localhost:5001";
        private const string GST_SERVER = "https://gstapi-production.up.railway.app";

        //private const string GST_SERVER = "https://gst-api-1258.onrender.com";

        private static readonly HttpClient http = new HttpClient();




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
            txtAddressLine1.TextChanged += txtBillingAddress_TextChanged;
            txtSearchCustomer.TextChanged += ApplyCustomerSearch;
            txtSearchCustomerNo.TextChanged += ApplyCustomerSearch;
            txtSearchCustomerEmail.TextChanged += ApplyCustomerSearch;
            txtCustomerSearchGST.TextChanged += ApplyCustomerSearch;
            txtCustomerSearchPAN.TextChanged += ApplyCustomerSearch;
            txtSeachCustomerBillingAddress.TextChanged += ApplyCustomerSearch;
            txtSearchCustomerShippingAddress.TextChanged += ApplyCustomerSearch;
            dgv.Scroll += dgv_Scroll;
            dgv.ColumnWidthChanged += dgv_ColumnWidthChanged;
            this.Resize += Customer_Resize;
            txtAddressLine1.TextChanged += BillingAddressChanged;
            txtAddressLine2.TextChanged += BillingAddressChanged;
            txtPinCode.TextChanged += BillingAddressChanged;
            txtState.TextChanged += BillingAddressChanged;

            txtPinCode.TextChanged += TxtPinCode_TextChanged;
            txtAddressLine1.TextChanged += BillingChanged;
            txtAddressLine2.TextChanged += BillingChanged;
            txtPinCode.TextChanged += BillingChanged;
            txtCity.TextChanged += BillingChanged;
            txtState.TextChanged += BillingChanged;
            txtGSTNo.TextChanged += TxtGSTClearCheck;

            txtShipPinCode.TextChanged += TxtShipPinCode_TextChanged;
            EnableDoubleBuffering(this);

            this.Shown += async (s, e) =>
            {
                await GetGSTCaptcha();
            };




            // GRID
            SetupCustomerGrid();
            LoadCustomerGrid();
            SyncCustomerSearchBoxes();

        }
        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true, null);

            foreach (Control child in control.Controls)
                EnableDoubleBuffering(child);
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
            this.SuspendLayout();
            dgv.SuspendLayout();

            try
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

                int sr = 1;

                while (dr.Read())
                {
                    dgv.Rows.Add(
                        sr++,
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
            finally
            {
                dgv.ResumeLayout(true);
                this.ResumeLayout(true);
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
            cmd.Parameters.AddWithValue("@billing", GetBillingAddressCombined());

            cmd.Parameters.AddWithValue("@shipping", GetShippingAddressCombined());


            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Customer added successfully ✔",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadCustomerGrid();
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

        private void ApplyCustomerSearch(object sender, EventArgs e)
        {
            string name = txtSearchCustomer.Text.Trim();
            string contact = txtSearchCustomerNo.Text.Trim();
            string email = txtSearchCustomerEmail.Text.Trim();
            string gst = txtCustomerSearchGST.Text.Trim();
            string pan = txtCustomerSearchPAN.Text.Trim();
            string billing = txtSeachCustomerBillingAddress.Text.Trim();
            string shipping = txtSearchCustomerShippingAddress.Text.Trim();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                // ===== NAME (Contains like AllMaterial Material) =====
                if (!string.IsNullOrEmpty(name))
                {
                    string val = row.Cells["name"].Value?.ToString() ?? "";
                    visible &= val.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // ===== CONTACT =====
                if (!string.IsNullOrEmpty(contact))
                {
                    string val = row.Cells["contact"].Value?.ToString() ?? "";
                    visible &= val.StartsWith(contact, StringComparison.OrdinalIgnoreCase);
                }

                // ===== EMAIL =====
                if (!string.IsNullOrEmpty(email))
                {
                    string val = row.Cells["email"].Value?.ToString() ?? "";
                    visible &= val.IndexOf(email, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // ===== GST =====
                if (!string.IsNullOrEmpty(gst))
                {
                    string val = row.Cells["gst"].Value?.ToString() ?? "";
                    visible &= val.StartsWith(gst, StringComparison.OrdinalIgnoreCase);
                }

                // ===== PAN =====
                if (!string.IsNullOrEmpty(pan))
                {
                    string val = row.Cells["pan"].Value?.ToString() ?? "";
                    visible &= val.StartsWith(pan, StringComparison.OrdinalIgnoreCase);
                }

                // ===== BILLING =====
                if (!string.IsNullOrEmpty(billing))
                {
                    string val = row.Cells["billing"].Value?.ToString() ?? "";
                    visible &= val.IndexOf(billing, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // ===== SHIPPING =====
                if (!string.IsNullOrEmpty(shipping))
                {
                    string val = row.Cells["shipping"].Value?.ToString() ?? "";
                    visible &= val.IndexOf(shipping, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                row.Visible = visible;
            }
        }

        private void SyncCustomerSearchBoxes()
        {
            if (dgv.Columns.Count == 0) return;

            SetCustomerSearchBox(txtSearchCustomer, "name");
            SetCustomerSearchBox(txtSearchCustomerNo, "contact");
            SetCustomerSearchBox(txtSearchCustomerEmail, "email");
            SetCustomerSearchBox(txtCustomerSearchGST, "gst");
            SetCustomerSearchBox(txtCustomerSearchPAN, "pan");
            SetCustomerSearchBox(txtSeachCustomerBillingAddress, "billing");
            SetCustomerSearchBox(txtSearchCustomerShippingAddress, "shipping");
        }
        private void SetCustomerSearchBox(TextBox txt, string columnName)
        {
            if (!dgv.Columns.Contains(columnName)) return;

            Rectangle rect = dgv.GetColumnDisplayRectangle(
                dgv.Columns[columnName].Index,
                true
            );

            txt.Left = rect.Left + dgv.Left + (SEARCH_GAP / 2);
            txt.Width = rect.Width - SEARCH_GAP;
        }

        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                SyncCustomerSearchBoxes();
        }

        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SyncCustomerSearchBoxes();
        }

        private void Customer_Resize(object sender, EventArgs e)
        {
            SyncCustomerSearchBoxes();
        }
        private string GetBillingAddressCombined()
        {
            return string.Join(", ",
                new[]
                {
            txtAddressLine1.Text.Trim(),
            txtAddressLine2.Text.Trim(),
            txtPinCode.Text.Trim(),
            txtCity.Text.Trim(),     // ⭐ ADD THIS
            txtState.Text.Trim()
                }.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private void BillingAddressChanged(object sender, EventArgs e)
        {
            if (chksameas.Checked)
                txtShipAddressLine1.Text = GetBillingAddressCombined();
        }
        private async Task FetchPincodeData(string pincode)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://api.postalpincode.in/pincode/{pincode}";

                    var response = await client.GetStringAsync(url);

                    var json = JsonDocument.Parse(response);

                    var root = json.RootElement[0];

                    if (root.GetProperty("Status").GetString() == "Success")
                    {
                        var postOffice = root
                            .GetProperty("PostOffice")[0];

                        txtState.Text = postOffice
                            .GetProperty("State").GetString();

                        txtCity.Text = postOffice
                            .GetProperty("District").GetString();

                        if (chksameas.Checked)
                            txtShipAddressLine1.Text = GetBillingAddressCombined();
                    }
                }
            }
            catch
            {
                // Silent fail or message if needed
            }
        }


        // ================= CLEAR =================
        private void ClearForm()
        {
            // ===== Basic =====
            txtCustomerName.Clear();
            txtCustomerMoNo.Clear();
            txtAltContact.Clear();
            txtCustomerEmail.Clear();
            txtGSTNo.Clear();
            txtPANNo.Clear();

            // ===== Billing =====
            txtAddressLine1.Clear();
            txtAddressLine2.Clear();
            txtPinCode.Clear();
            txtCity.Clear();
            txtState.Clear();

            // ===== Shipping =====
            txtShipAddressLine1.Clear();
            txtShipAddressLine2.Clear();
            txtShipPinCode.Clear();
            txtShipCity.Clear();
            txtShipState.Clear();

            // ===== Reset Controls =====
            rdoGST.Checked = true;
            chksameas.Checked = false;

            // ===== Enable Shipping =====
            SetShippingReadOnly(false);
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void TxtGSTClearCheck(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGSTNo.Text))
            {
                txtCustomerName.Clear();
                txtAddressLine1.Clear();
                txtAddressLine2.Clear();
                txtCity.Clear();
                txtState.Clear();
                txtPinCode.Clear();
                txtCaptcha.Clear();

                await GetGSTCaptcha(); // New captcha when GST cleared
            }
        }





        private async void TxtPinCode_TextChanged(object sender, EventArgs e)
        {
            // Cancel previous request
            pincodeCTS?.Cancel();
            pincodeCTS = new CancellationTokenSource();

            try
            {
                string pin = txtPinCode.Text.Trim();

                // ⭐ NEW LOGIC — Agar 6 digit nahi hai → Clear
                if (pin.Length < 6)
                {
                    txtState.Clear();
                    txtCity.Clear();

                    if (chksameas.Checked)
                        txtShipAddressLine1.Text = GetBillingAddressCombined();

                    return;
                }

                await Task.Delay(100, pincodeCTS.Token);

                if (pin.Length == 6)
                {
                    await FetchPincodeData(pin);
                }
            }
            catch (TaskCanceledException)
            {
                // ignore
            }
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
        private async Task FetchShippingPincode(string pin)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
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
            }
            catch { }
        }
        //private async Task GetGSTCaptcha()
        //{
        //    try
        //    {
        //        using HttpClient client = new HttpClient();

        //        var res = await client.GetStringAsync(
        //            $"{GST_SERVER}/api/v1/getCaptcha"
        //        );

        //        var root = JsonDocument.Parse(res).RootElement;

        //        if (!root.TryGetProperty("sessionId", out var sid))
        //        {
        //            MessageBox.Show("Captcha Session Error");
        //            return;
        //        }

        //        gstSessionId = sid.GetString();

        //        string image = root.GetProperty("image").GetString();

        //        image = image.Replace("data:image/png;base64,", "");

        //        byte[] imgBytes = Convert.FromBase64String(image);

        //        using MemoryStream ms = new MemoryStream(imgBytes);
        //        picCaptcha.Image = Image.FromStream(ms);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Captcha Load Failed\n" + ex.Message);
        //    }
        //}
        private async Task GetGSTCaptcha()
        {
            try
            {
                var res = await http.GetStringAsync(
                    $"{GST_SERVER}/api/v1/getCaptcha"
                );

                var root = JsonDocument.Parse(res).RootElement;

                gstSessionId = root.GetProperty("sessionId").GetString();

                string image = root.GetProperty("image").GetString();
                image = image.Replace("data:image/png;base64,", "");

                byte[] imgBytes = Convert.FromBase64String(image);

                using MemoryStream ms = new MemoryStream(imgBytes);
                picCaptcha.Image = Image.FromStream(ms);
            }
            catch { }
        }


        private async Task FetchGSTFromLocalServer(string gst, string captcha)
        {
            try
            {
                using HttpClient client = new HttpClient();

                var data = new
                {
                    sessionId = gstSessionId,
                    GSTIN = gst,
                    captcha = captcha
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(data),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                var res = await client.PostAsync(
                    $"{GST_SERVER}/api/v1/getGSTDetails",
                    content
                );

                var result = await res.Content.ReadAsStringAsync();

                // Save to file for debugging
                System.IO.File.WriteAllText(@"C:\temp\gst_raw.json", result);

                // Parse the response
                var root = JsonDocument.Parse(result).RootElement;

                // Check if there's a nested "data" or "result" property
                if (root.TryGetProperty("data", out var data_element))
                {
                    FillGSTNameSafe(data_element);
                    FillGSTAddressSafe(data_element);
                }
                else if (root.TryGetProperty("result", out var result_element))
                {
                    FillGSTNameSafe(result_element);
                    FillGSTAddressSafe(result_element);
                }
                else
                {
                    // Direct root
                    FillGSTNameSafe(root);
                    FillGSTAddressSafe(root);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GST Fetch Error : " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void FillGSTNameSafe(JsonElement root)
        {
            try
            {
                // First try tradeNam (Trade Name)
                if (root.TryGetProperty("tradeNam", out var trade))
                {
                    string tradeName = trade.GetString()?.Trim() ?? "";
                    if (!string.IsNullOrEmpty(tradeName))
                    {
                        txtCustomerName.Text = tradeName;
                        return;
                    }
                }

                // Fallback to legal name (lgnm)
                if (root.TryGetProperty("lgnm", out var legal))
                {
                    string legalName = legal.GetString()?.Trim() ?? "";
                    if (!string.IsNullOrEmpty(legalName))
                    {
                        txtCustomerName.Text = legalName;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Name parse error: {ex.Message}");
            }
        }
        private void FillGSTAddressSafe(JsonElement root)
        {
            try
            {
                if (!root.TryGetProperty("pradr", out var pradr))
                    return;

                if (!pradr.TryGetProperty("adr", out var adrElement))
                    return;

                string fullAddress = adrElement.GetString()?.Trim() ?? "";
                if (string.IsNullOrEmpty(fullAddress))
                    return;

                // Example: "GF SHOP P 5-4, PROPERTY NO 5686, OPP RATLAMI SEV BHANDAR, STATION ROAD, DAHOD, Dahod, Gujarat, 389151"

                // Extract pincode first (6 digits at the end)
                var pincodeMatch = System.Text.RegularExpressions.Regex.Match(fullAddress, @"\b(\d{6})\b");
                if (pincodeMatch.Success)
                {
                    txtPinCode.Text = pincodeMatch.Groups[1].Value;
                    fullAddress = fullAddress.Replace(pincodeMatch.Groups[1].Value, "").Trim(' ', ',');
                }

                // Split remaining by comma
                string[] parts = fullAddress.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(p => p.Trim())
                                             .ToArray();

                // Address Line 1: First 1-2 parts
                if (parts.Length >= 1)
                    txtAddressLine1.Text = parts[0];

                // Address Line 2: Next 1-2 parts  
                if (parts.Length >= 2)
                    txtAddressLine2.Text = string.Join(", ", parts.Skip(1).Take(2));

                // State: Last part usually
                if (parts.Length >= 1)
                {
                    string lastPart = parts[parts.Length - 1];
                    if (lastPart.Length < 30) // States are short
                        txtState.Text = lastPart;
                }

                // City: Second to last
                if (parts.Length >= 2)
                {
                    string cityPart = parts[parts.Length - 2];
                    if (cityPart.Length < 30)
                        txtCity.Text = cityPart;
                }

                if (chksameas.Checked)
                    CopyBillingToShipping();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Address error: {ex.Message}");
            }
        }

        // Helper to safely get string from JSON
        private string GetJsonString(JsonElement element, string propertyName)
        {
            try
            {
                if (element.TryGetProperty(propertyName, out var prop))
                {
                    return prop.GetString()?.Trim() ?? "";
                }
            }
            catch { }

            return "";
        }

        // Helper method to safely fill text fields
        private void FillTextField(JsonElement source, string propertyName, TextBox target)
        {
            try
            {
                if (source.TryGetProperty(propertyName, out var element))
                {
                    string value = element.GetString()?.Trim() ?? "";
                    if (!string.IsNullOrEmpty(value))
                    {
                        target.Text = value;
                    }
                }
            }
            catch
            {
                // Ignore individual field errors
            }
        }

        // Helper to convert state code to name
        private string GetStateNameFromCode(string code)
        {
            var stateMap = new Dictionary<string, string>
    {
        {"01", "Jammu and Kashmir"}, {"02", "Himachal Pradesh"},
        {"03", "Punjab"}, {"04", "Chandigarh"}, {"05", "Uttarakhand"},
        {"06", "Haryana"}, {"07", "Delhi"}, {"08", "Rajasthan"},
        {"09", "Uttar Pradesh"}, {"10", "Bihar"}, {"11", "Sikkim"},
        {"12", "Arunachal Pradesh"}, {"13", "Nagaland"}, {"14", "Manipur"},
        {"15", "Mizoram"}, {"16", "Tripura"}, {"17", "Meghalaya"},
        {"18", "Assam"}, {"19", "West Bengal"}, {"20", "Jharkhand"},
        {"21", "Odisha"}, {"22", "Chhattisgarh"}, {"23", "Madhya Pradesh"},
        {"24", "Gujarat"}, {"26", "Dadra and Nagar Haveli and Daman and Diu"},
        {"27", "Maharashtra"}, {"29", "Karnataka"}, {"30", "Goa"},
        {"31", "Lakshadweep"}, {"32", "Kerala"}, {"33", "Tamil Nadu"},
        {"34", "Puducherry"}, {"35", "Andaman and Nicobar Islands"},
        {"36", "Telangana"}, {"37", "Andhra Pradesh"}, {"38", "Ladakh"}
    };

            return stateMap.ContainsKey(code) ? stateMap[code] : code;
        }









        private async void btnFetchGST_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGSTNo.Text))
            {
                MessageBox.Show("Enter GST");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCaptcha.Text))
            {
                MessageBox.Show("Enter Captcha");
                return;
            }

            await FetchGSTFromLocalServer(
                txtGSTNo.Text.Trim(),
                txtCaptcha.Text.Trim()
            );
        }

        private async void btnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            txtCaptcha.Clear();
            await GetGSTCaptcha();
        }

        private void rdoPAN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPAN.Checked)
            {
                // Hide GST Related Controls
                btnRefreshCaptcha.Visible = false;   // Refresh icon
                txtCaptcha.Visible = false;          // Captcha textbox
                btnFetch.Visible = false;
                picCaptcha.Visible = false;// Fetch Details button
            }
        }

        private void rdoGST_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGST.Checked)
            {
                btnRefreshCaptcha.Visible = true;
                txtCaptcha.Visible = true;
                btnFetch.Visible = true;
                picCaptcha.Visible = true;
            }
        }
    }
}
