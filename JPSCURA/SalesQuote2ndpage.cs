using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class SalesQuote2ndpage : Form
    {
        private bool isLoading = false;
        private readonly string? editingQuotationNo;
        private int? currentSalesQuotationId;
        private string currentQuotationStatus = string.Empty;
        private string currentPdfPath = string.Empty;
        private const int LayoutMargin = 10;
        private const int SectionGap = 8;
        private const int TopSectionHeight = 320;
        private const int ButtonPanelHeight = 52;
        private const int TermsPanelHeight = 120;

        public SalesQuote2ndpage(string? quotationNo = null)
        {
            InitializeComponent();
            editingQuotationNo = quotationNo;
            QuestPDF.Settings.License = LicenseType.Community;
        }

        // ─────────────────────────────────────────────────────────────
        //  FORM LOAD
        // ─────────────────────────────────────────────────────────────
        private void SalesQuote2ndpage_Load(object sender, EventArgs e)
        {
            try
            {
                isLoading = true;
                LoadCustomerCombo();
                LoadGSTTypeCombo();
                SetGSTDefault();
                SetupItemGrid();
                StyleGrid();
                cmbselectcustomer.SelectedIndexChanged += cmbselectcustomer_SelectedIndexChanged;
                cmbgst.SelectedIndexChanged += cmbgst_SelectedIndexChanged;
                txtGSTno.TextChanged += txtGSTno_TextChanged;
                this.Resize += SalesQuote2ndpage_Resize;
                ShowAddressFields();
                UpdateGSTColumns();
                isLoading = false;
                LoadTermsControls();
                PositionTermsPanel();
                StyleTermsPanel();
                ApplyResponsiveLayout();
                txtQuotationNo.ReadOnly = true;
                if (!string.IsNullOrWhiteSpace(editingQuotationNo))
                    LoadQuotationForEdit(editingQuotationNo);
                else
                    InitializeNewQuotationState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form Load Error: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  GRID SETUP & STYLE
        // ─────────────────────────────────────────────────────────────
        private void StyleGrid()
        {
            try
            {
                dgvItems.Dock = DockStyle.None;
                dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                dgvItems.BackgroundColor = System.Drawing.Color.White;
                dgvItems.BorderStyle = BorderStyle.None;
                dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvItems.RowHeadersVisible = false;
                dgvItems.AllowUserToAddRows = false;
                dgvItems.AllowUserToResizeRows = false;
                dgvItems.GridColor = System.Drawing.Color.LightGray;
                dgvItems.EnableHeadersVisualStyles = false;
                dgvItems.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 122, 183);
                dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dgvItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                dgvItems.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgvItems.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
                dgvItems.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                dgvItems.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
                dgvItems.RowTemplate.Height = 35;
                dgvItems.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch { }
        }

        private void SetupItemGrid()
        {
            try
            {
                dgvItems.Columns.Clear();
                dgvItems.Columns.Add("SrNo", "Sr No");
                dgvItems.Columns.Add("ItemName", "Item Name");
                var desc = new DataGridViewTextBoxColumn
                {
                    Name = "Description",
                    HeaderText = "Item Description",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                desc.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvItems.Columns.Add(desc);
                dgvItems.Columns.Add("ModelNo", "Model No");
                dgvItems.Columns.Add("HSN", "HSN/SAC");
                dgvItems.Columns.Add("Qty", "Qty");
                dgvItems.Columns.Add("Rate", "Rate/Each");
                dgvItems.Columns.Add("GST", "GST %");
                dgvItems.Columns.Add("CGST", "CGST");
                dgvItems.Columns.Add("SGST", "SGST");
                dgvItems.Columns.Add("Total", "Total (Without GST)");
                ConfigureItemGridColumns();
                AddNewRow();
                dgvItems.CellEndEdit += dgvItems_CellEndEdit;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grid Setup Error: " + ex.Message);
            }
        }

        private void AddNewRow()
        {
            try
            {
                int rowIndex = dgvItems.Rows.Add();
                DataGridViewRow row = dgvItems.Rows[rowIndex];
                row.Cells["SrNo"].Value = rowIndex + 1;
                row.Cells["CGST"].Value = string.Empty;
                row.Cells["SGST"].Value = string.Empty;
                row.Cells["Total"].Value = string.Empty;
                PositionTermsPanel();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try { AddNewRow(); }
            catch (Exception ex) { MessageBox.Show("Add Row Button Error: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int totalRows = dgvItems.Rows.Count;
                if (totalRows <= 1)
                {
                    MessageBox.Show("First row cannot be deleted.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dgvItems.Rows.RemoveAt(totalRows - 1);
                PositionTermsPanel();
                for (int i = 0; i < dgvItems.Rows.Count; i++)
                    dgvItems.Rows[i].Cells["SrNo"].Value = i + 1;
            }
            catch (Exception ex) { MessageBox.Show("Delete Row Error: " + ex.Message); }
        }

        // ─────────────────────────────────────────────────────────────
        //  GST HELPERS
        // ─────────────────────────────────────────────────────────────
        private bool IsGujaratGST()
        {
            try { return txtGSTno.Text.Length >= 2 && txtGSTno.Text.StartsWith("24"); }
            catch { return false; }
        }

        private bool IsWithGST() =>
            string.Equals(cmbgst.Text, "With GST", StringComparison.OrdinalIgnoreCase);

        private bool UsesSplitGST() => IsWithGST() && IsGujaratGST();
        private bool UsesIntegratedGST() => IsWithGST() && !IsGujaratGST();

        private void UpdateGSTColumns()
        {
            try
            {
                bool withGST = IsWithGST();
                bool gujarat = IsGujaratGST();
                dgvItems.Columns["GST"].Visible = withGST;
                dgvItems.Columns["CGST"].Visible = withGST && gujarat;
                dgvItems.Columns["SGST"].Visible = withGST && gujarat;
                UpdateTaxColumnHeaders();
                ConfigureItemGridColumns();
            }
            catch (Exception ex) { MessageBox.Show("GST Column Error: " + ex.Message); }
        }

        private double GetGridGSTPercentage()
        {
            try
            {
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (double.TryParse(Convert.ToString(row.Cells["GST"].Value), out double gst) && gst > 0)
                        return gst;
                }
            }
            catch { }
            return 0;
        }

        private void UpdateTaxColumnHeaders(double? gstPercentage = null)
        {
            try
            {
                double gst = gstPercentage ?? GetGridGSTPercentage();
                double splitGST = gst / 2;
                dgvItems.Columns["Rate"].HeaderText = "Rate/Each";
                dgvItems.Columns["Total"].HeaderText = "Total (Without GST)";
                dgvItems.Columns["GST"].HeaderText = UsesIntegratedGST() ? "IGST %" : "GST %";
                dgvItems.Columns["CGST"].HeaderText = splitGST > 0 ? $"CGST ({splitGST:0.##}%)/QTY" : "CGST (%)/QTY";
                dgvItems.Columns["SGST"].HeaderText = splitGST > 0 ? $"SGST ({splitGST:0.##}%)/QTY" : "SGST (%)/QTY";
            }
            catch { }
        }

        private void ConfigureItemGridColumns()
        {
            try
            {
                SetColumnFillWeight("SrNo", 45);
                SetColumnFillWeight("ItemName", 120);
                SetColumnFillWeight("Description", 170);
                SetColumnFillWeight("ModelNo", 95);
                SetColumnFillWeight("HSN", 95);
                SetColumnFillWeight("Qty", 60);
                SetColumnFillWeight("Rate", 70);
                SetColumnFillWeight("GST", UsesIntegratedGST() ? 75 : 65);
                SetColumnFillWeight("CGST", 90);
                SetColumnFillWeight("SGST", 90);
                SetColumnFillWeight("Total", 100);
                SetColumnAlignment("SrNo", DataGridViewContentAlignment.MiddleCenter);
                SetColumnAlignment("Qty", DataGridViewContentAlignment.MiddleRight);
                SetColumnAlignment("Rate", DataGridViewContentAlignment.MiddleRight);
                SetColumnAlignment("GST", DataGridViewContentAlignment.MiddleRight);
                SetColumnAlignment("CGST", DataGridViewContentAlignment.MiddleRight);
                SetColumnAlignment("SGST", DataGridViewContentAlignment.MiddleRight);
                SetColumnAlignment("Total", DataGridViewContentAlignment.MiddleRight);
            }
            catch { }
        }

        private void SetColumnFillWeight(string columnName, float fillWeight)
        {
            if (dgvItems.Columns.Contains(columnName))
                dgvItems.Columns[columnName].FillWeight = fillWeight;
        }

        private void SetColumnAlignment(string columnName, DataGridViewContentAlignment alignment)
        {
            if (dgvItems.Columns.Contains(columnName))
                dgvItems.Columns[columnName].DefaultCellStyle.Alignment = alignment;
        }

        private static bool RowHasCalculationInputs(DataGridViewRow row)
        {
            foreach (string columnName in new[] { "Qty", "Rate", "GST" })
            {
                string value = Convert.ToString(row.Cells[columnName].Value) ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(value))
                    return true;
            }
            return false;
        }

        private QuoteTaxBreakdown CalculateQuoteTaxBreakdown(double qty, double rate, double gstPct)
        {
            double subtotal = qty * rate;
            double gstAmount = IsWithGST() ? subtotal * gstPct / 100d : 0d;

            if (UsesSplitGST())
            {
                double splitTotal = gstAmount / 2d;
                double splitPerQty = qty > 0 ? splitTotal / qty : 0d;
                return new QuoteTaxBreakdown(subtotal, gstAmount, splitPerQty, splitPerQty, splitTotal, splitTotal, 0d);
            }

            if (UsesIntegratedGST())
                return new QuoteTaxBreakdown(subtotal, gstAmount, 0d, 0d, 0d, 0d, gstAmount);

            return new QuoteTaxBreakdown(subtotal, 0d, 0d, 0d, 0d, 0d, 0d);
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                DataGridViewRow row = dgvItems.Rows[e.RowIndex];
                double.TryParse(Convert.ToString(row.Cells["Qty"].Value), out double qty);
                double.TryParse(Convert.ToString(row.Cells["Rate"].Value), out double rate);
                double.TryParse(Convert.ToString(row.Cells["GST"].Value), out double gst);

                if (!RowHasCalculationInputs(row))
                {
                    row.Cells["CGST"].Value = string.Empty;
                    row.Cells["SGST"].Value = string.Empty;
                    row.Cells["Total"].Value = string.Empty;
                    UpdateTaxColumnHeaders();
                    return;
                }

                QuoteTaxBreakdown breakdown = CalculateQuoteTaxBreakdown(qty, rate, gst);
                row.Cells["Total"].Value = breakdown.Subtotal.ToString("0.00");

                if (UsesSplitGST())
                {
                    row.Cells["CGST"].Value = breakdown.CGSTPerQty.ToString("0.00");
                    row.Cells["SGST"].Value = breakdown.SGSTPerQty.ToString("0.00");
                }
                else
                {
                    row.Cells["CGST"].Value = "";
                    row.Cells["SGST"].Value = "";
                }
                UpdateTaxColumnHeaders(gst);
            }
            catch { }
        }

        private void cmbgst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { UpdateGSTColumns(); } catch { }
        }

        private void txtGSTno_TextChanged(object sender, EventArgs e)
        {
            try { UpdateGSTColumns(); } catch { }
        }

        private void rdoGST_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch { }
        }

        private void rdoPAN_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch { }
        }

        private void SalesQuote2ndpage_Resize(object sender, EventArgs e)
        {
            try { ApplyResponsiveLayout(); } catch { }
        }

        private void ApplyResponsiveLayout()
        {
            try
            {
                ConfigureContainers();
                LayoutLeftSection();
                LayoutRightSection();
                LayoutActionButtons();
                PositionTermsPanel();
                StyleTermsPanel();
                LayoutGridArea();
                tblpanelmain.BringToFront();
                panelTOP.BringToFront();
                panelTerms.BringToFront();
            }
            catch { }
        }

        private void ConfigureContainers()
        {
            try
            {
                tblpanelmain.Height = TopSectionHeight;
                panelTOP.Height = ButtonPanelHeight;
                panelTOP.BackColor = panelMain.BackColor;
                panelleft.Dock = DockStyle.Fill;
                panelright.Dock = DockStyle.Fill;
            }
            catch { }
        }

        private void LayoutLeftSection()
        {
            try
            {
                int labelX = 10;
                int fieldX = Math.Max(220, Math.Min(250, panelleft.ClientSize.Width / 3));
                int labelWidth = Math.Max(150, fieldX - labelX - 12);
                int fieldWidth = Math.Max(180, panelleft.ClientSize.Width - fieldX - 16);
                lblSelectCustomer.SetBounds(labelX, 22, labelWidth, 23);
                cmbselectcustomer.SetBounds(fieldX, 20, fieldWidth, 23);
                lblquotationdate.SetBounds(labelX, 62, labelWidth, 23);
                dtQuotationDate.SetBounds(fieldX, 60, fieldWidth, 23);
                lblKingAttn.SetBounds(labelX, 102, labelWidth, 23);
                txtkindattname.SetBounds(fieldX, 100, fieldWidth, 23);
                lblreferncedate.SetBounds(labelX, 142, labelWidth, 23);
                txtBuyersreferenceanddate.SetBounds(fieldX, 140, fieldWidth, 23);
                lblCustomerAddress.SetBounds(labelX, 182, labelWidth, 23);
                txtAddressLine1.SetBounds(fieldX, 180, fieldWidth, 23);
                txtAddressLine2.SetBounds(fieldX, 205, fieldWidth, 23);
                txtPinCode.SetBounds(fieldX, 230, fieldWidth, 23);
                txtCity.SetBounds(fieldX, 255, fieldWidth, 23);
                txtState.SetBounds(fieldX, 280, fieldWidth, 23);
            }
            catch { }
        }

        private void LayoutRightSection()
        {
            try
            {
                int labelX = 10;
                int fieldX = Math.Max(185, Math.Min(240, panelright.ClientSize.Width / 3));
                int labelWidth = Math.Max(130, fieldX - labelX - 12);
                int fieldWidth = Math.Max(180, panelright.ClientSize.Width - fieldX - 16);
                lblQuotationNo.SetBounds(labelX, 22, labelWidth, 23);
                txtQuotationNo.SetBounds(fieldX, 20, fieldWidth, 23);
                lblGST.SetBounds(labelX, 62, labelWidth, 23);
                cmbgst.SetBounds(fieldX, 60, fieldWidth, 23);
                rdoGST.Location = new System.Drawing.Point(labelX, 100);
                rdoPAN.Location = new System.Drawing.Point(labelX + 95, 100);
                txtGSTno.SetBounds(fieldX, 100, fieldWidth, 23);
                txtPANNo.SetBounds(fieldX, 100, fieldWidth, 23);
                lblCustShippingaddress.SetBounds(labelX, 182, labelWidth, 23);
                txtShipAddressLine1.SetBounds(fieldX, 180, fieldWidth, 23);
                txtShipAddressLine2.SetBounds(fieldX, 205, fieldWidth, 23);
                txtShipPinCode.SetBounds(fieldX, 230, fieldWidth, 23);
                txtShipCity.SetBounds(fieldX, 255, fieldWidth, 23);
                txtShipState.SetBounds(fieldX, 280, fieldWidth, 23);
            }
            catch { }
        }

        private void LayoutActionButtons()
        {
            try
            {
                int top = Math.Max(8, (panelTOP.Height - 32) / 2);
                int gap = 12;
                int right = panelTOP.ClientSize.Width - LayoutMargin;
                btnAddRow.SetBounds(right - 145, top, 145, 32);
                right = btnAddRow.Left - gap;
                btnDelete.SetBounds(right - 145, top, 145, 32);
                right = btnDelete.Left - gap;
                btnGenerate.SetBounds(right - 145, top, 145, 32);
                right = btnGenerate.Left - gap;
                btnSave.SetBounds(right - 90, top - 3, 90, 38);
                int clearAreaWidth = Math.Max(150, btnSave.Left - (LayoutMargin * 2));
                int clearLeft = LayoutMargin + Math.Max(0, (clearAreaWidth - btnClear.Width) / 2);
                btnClear.SetBounds(clearLeft, top, 141, 32);
            }
            catch { }
        }

        private void LayoutGridArea()
        {
            try
            {
                int gridLeft = 0;
                int gridTop = panelTOP.Bottom + SectionGap;
                int gridWidth = Math.Max(250, panelMain.ClientSize.Width);
                int gridHeight = Math.Max(160, panelTerms.Top - gridTop - SectionGap);
                dgvItems.SetBounds(gridLeft, gridTop, gridWidth, gridHeight);
            }
            catch { }
        }

        // ─────────────────────────────────────────────────────────────
        //  ADDRESS / CUSTOMER
        // ─────────────────────────────────────────────────────────────
        private void ShowAddressFields()
        {
            try
            {
                txtAddressLine1.Visible = true;
                txtAddressLine2.Visible = true;
                txtPinCode.Visible = true;
                txtCity.Visible = true;
                txtState.Visible = true;
                txtShipAddressLine1.Visible = true;
                txtShipAddressLine2.Visible = true;
                txtShipPinCode.Visible = true;
                txtShipCity.Visible = true;
                txtShipState.Visible = true;
            }
            catch { }
        }

        private void PopulateAddressFields(
            string address,
            System.Windows.Forms.TextBox line1,
            System.Windows.Forms.TextBox line2,
            System.Windows.Forms.TextBox pinCode,
            System.Windows.Forms.TextBox city,
            System.Windows.Forms.TextBox state)
        {
            try
            {
                line1.Clear(); line2.Clear(); pinCode.Clear(); city.Clear(); state.Clear();
                if (string.IsNullOrWhiteSpace(address)) return;
                string[] parts = address.Split(',');
                if (parts.Length > 0) line1.Text = parts[0].Trim();
                if (parts.Length > 1) line2.Text = parts[1].Trim();
                if (parts.Length > 2) pinCode.Text = parts[2].Trim();
                if (parts.Length > 3) city.Text = parts[3].Trim();
                if (parts.Length > 4) state.Text = string.Join(", ", parts, 4, parts.Length - 4).Trim();
            }
            catch { }
        }

        private void LoadCustomerCombo()
        {
            try
            {
                cmbselectcustomer.Items.Clear();
                cmbselectcustomer.Items.Add("Select Customer");
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                using SqlCommand cmd = new SqlCommand("SELECT Cust_Name FROM SALES_MASTER..Customers ORDER BY Cust_Name", con);
                con.Open();
                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    cmbselectcustomer.Items.Add(dr["Cust_Name"]?.ToString());
                cmbselectcustomer.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Customer Load Error: " + ex.Message); }
        }

        private void LoadCustomerDetails(string custName)
        {
            try
            {
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                using SqlCommand cmd = new SqlCommand(
                    @"SELECT Billing_Address, Shipping_Address, Customer_GST, Customer_PAN
                      FROM SALES_MASTER.dbo.Customers WHERE Cust_Name=@name", con);
                cmd.Parameters.AddWithValue("@name", custName);
                con.Open();
                using SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string billing = dr["Billing_Address"]?.ToString() ?? "";
                    string shipping = dr["Shipping_Address"]?.ToString() ?? "";
                    PopulateAddressFields(billing, txtAddressLine1, txtAddressLine2, txtPinCode, txtCity, txtState);
                    PopulateAddressFields(shipping, txtShipAddressLine1, txtShipAddressLine2, txtShipPinCode, txtShipCity, txtShipState);
                    txtGSTno.Text = dr["Customer_GST"]?.ToString();
                    txtPANNo.Text = dr["Customer_PAN"]?.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("Customer Details Error: " + ex.Message); }
        }

        private void LoadGSTTypeCombo()
        {
            try
            {
                cmbgst.Items.Clear();
                cmbgst.Items.Add("With GST");
                cmbgst.Items.Add("Without GST");
                cmbgst.SelectedIndex = 0;
            }
            catch { }
        }

        private void SetGSTDefault()
        {
            try
            {
                rdoGST.Checked = true;
                txtGSTno.Visible = true;
                txtPANNo.Visible = false;
            }
            catch { }
        }

        private void cmbselectcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (isLoading) return;
                if (cmbselectcustomer.SelectedIndex <= 0) { ClearCustomerFields(); return; }
                ClearCustomerFields();
                LoadCustomerDetails(cmbselectcustomer.Text);
            }
            catch { }
        }

        private void ClearCustomerFields()
        {
            try
            {
                txtAddressLine1.Clear(); txtAddressLine2.Clear(); txtPinCode.Clear();
                txtCity.Clear(); txtState.Clear();
                txtShipAddressLine1.Clear(); txtShipAddressLine2.Clear(); txtShipPinCode.Clear();
                txtShipCity.Clear(); txtShipState.Clear();
                txtGSTno.Clear(); txtPANNo.Clear();
                dgvItems.Rows.Clear();
                AddNewRow();
                SetGSTDefault();
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try { ClearCustomerFields(); } catch { }
        }

        // ─────────────────────────────────────────────────────────────
        //  TERMS PANEL
        // ─────────────────────────────────────────────────────────────
        private void LoadTermsControls()
        {
            try
            {
                cmbValidity.Items.Clear();
                cmbValidity.Items.Add("1 Week");
                cmbValidity.Items.Add("2 Weeks");
                cmbValidity.Items.Add("3 Weeks");
                cmbValidity.Items.Add("1 Month");
                cmbValidity.SelectedIndex = 0;
                txtDeliveryPeriod.PlaceholderText = "Delivery Period";
                txtPaymentTerms.PlaceholderText = "Payment Terms";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void PositionTermsPanel()
        {
            try
            {
                panelTerms.Height = TermsPanelHeight;
                panelTerms.Width = Math.Min(430, Math.Max(320, panelMain.ClientSize.Width - (LayoutMargin * 2)));
                panelTerms.Left = LayoutMargin;
                panelTerms.Top = panelMain.ClientSize.Height - panelTerms.Height - LayoutMargin;
            }
            catch { }
        }

        private void StyleTermsPanel()
        {
            try
            {
                panelTerms.BackColor = System.Drawing.Color.FromArgb(83, 144, 204);
                panelTerms.BorderStyle = BorderStyle.None;
                lblValidity.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                lblDelivery.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                lblPayment.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                int labelX = 10;
                int inputX = 155;
                int inputWidth = Math.Max(140, panelTerms.Width - inputX - 12);
                lblValidity.SetBounds(labelX, 12, 120, 23);
                cmbValidity.SetBounds(inputX, 8, inputWidth, 23);
                lblDelivery.SetBounds(labelX, 45, 140, 23);
                txtDeliveryPeriod.SetBounds(inputX, 41, inputWidth, 23);
                lblPayment.SetBounds(labelX, 78, 120, 23);
                txtPaymentTerms.SetBounds(inputX, 74, inputWidth, 23);
            }
            catch { }
        }

        // ─────────────────────────────────────────────────────────────
        //  SAVE / VALIDATE HELPERS
        // ─────────────────────────────────────────────────────────────
        private bool ValidateQuotationForSave()
        {
            if (cmbselectcustomer.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a customer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbselectcustomer.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtQuotationNo.Text))
                txtQuotationNo.Text = GetQuotationNumberPreview(false);
            return true;
        }

        private void InitializeNewQuotationState()
        {
            currentSalesQuotationId = null;
            currentQuotationStatus = string.Empty;
            currentPdfPath = string.Empty;
            dtQuotationDate.Value = DateTime.Today;
            txtQuotationNo.Text = GetQuotationNumberPreview(false);
            UpdateActionButtons();
        }

        private void UpdateActionButtons()
        {
            btnGenerate.Enabled = true;
        }

        private static string GetFinancialYearCode(DateTime date)
        {
            int startYear = date.Month >= 4 ? date.Year : date.Year - 1;
            int endYear = startYear + 1;
            return $"{startYear % 100:00}-{endYear % 100:00}";
        }

        private static string GetQuotationDateCode(DateTime date) => date.ToString("yyMMdd");

        private static string BuildQuotationNumber(bool isGenerated, DateTime date, int sequence)
        {
            string quotationNumber = $"JPSC-Q-{GetFinancialYearCode(date)}-{GetQuotationDateCode(date)}-{sequence:00}";
            return isGenerated ? quotationNumber : quotationNumber + "(S)";
        }

        private static int ExtractQuotationSequence(string quotationNumber)
        {
            if (string.IsNullOrWhiteSpace(quotationNumber)) return 0;
            string normalized = quotationNumber.Trim();
            if (normalized.EndsWith("(S)", StringComparison.OrdinalIgnoreCase))
                normalized = normalized[..^3];
            int lastDashIndex = normalized.LastIndexOf('-');
            if (lastDashIndex < 0 || lastDashIndex >= normalized.Length - 1) return 0;
            return int.TryParse(normalized[(lastDashIndex + 1)..], out int sequence) ? sequence : 0;
        }

        private static bool IsTemporaryQuotationNumber(string quotationNumber) =>
            !string.IsNullOrWhiteSpace(quotationNumber) &&
            quotationNumber.Trim().EndsWith("(S)", StringComparison.OrdinalIgnoreCase);

        private string GetQuotationNumberPreview(bool isGenerated)
        {
            try
            {
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                con.Open();
                return GetNextQuotationNumber(con, null, isGenerated);
            }
            catch { return BuildQuotationNumber(isGenerated, DateTime.Today, 1); }
        }

        private string GetNextQuotationNumber(SqlConnection con, SqlTransaction? transaction, bool isGenerated)
        {
            string fyCode = GetFinancialYearCode(DateTime.Today);
            string prefix = $"JPSC-Q-{fyCode}-";
            int maxSequence = 0;
            using SqlCommand cmd = new SqlCommand(
                @"SELECT SalesQuotationNo FROM SALES_MASTER.dbo.SalesQuotations
                  WHERE SalesQuotationNo LIKE @quotationPattern", con, transaction);
            cmd.Parameters.AddWithValue("@quotationPattern", prefix + "%");
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string quotationNumber = dr["SalesQuotationNo"]?.ToString() ?? string.Empty;
                if (!quotationNumber.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) continue;
                if (isGenerated && IsTemporaryQuotationNumber(quotationNumber)) continue;
                int sequence = ExtractQuotationSequence(quotationNumber);
                if (sequence > maxSequence) maxSequence = sequence;
            }
            return BuildQuotationNumber(isGenerated, DateTime.Today, maxSequence + 1);
        }

        private static void DeleteObsoleteDraft(string? oldQuotationNo, string? newQuotationNo)
        {
            if (string.IsNullOrWhiteSpace(oldQuotationNo) || string.IsNullOrWhiteSpace(newQuotationNo) ||
                string.Equals(oldQuotationNo, newQuotationNo, StringComparison.OrdinalIgnoreCase))
                return;
            char[] invalidChars = Path.GetInvalidFileNameChars();
            string oldSafeFileName = new string(oldQuotationNo.Select(ch => invalidChars.Contains(ch) ? '_' : ch).ToArray());
            string newSafeFileName = new string(newQuotationNo.Select(ch => invalidChars.Contains(ch) ? '_' : ch).ToArray());
            string folderPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "QuotationDrafts");
            string oldPath = Path.Combine(folderPath, oldSafeFileName + ".json");
            string newPath = Path.Combine(folderPath, newSafeFileName + ".json");
            if (File.Exists(oldPath) && !string.Equals(oldPath, newPath, StringComparison.OrdinalIgnoreCase))
                File.Delete(oldPath);
        }

        private int? GetCustomerIdByName(string customerName)
        {
            try
            {
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                con.Open();
                string[] possibleColumns = { "Cust_Id", "CustomerId", "Customer_ID", "Id" };
                foreach (string columnName in possibleColumns)
                {
                    try
                    {
                        using SqlCommand cmd = new SqlCommand(
                            $@"SELECT TOP 1 [{columnName}] FROM SALES_MASTER.dbo.Customers WHERE Cust_Name = @name", con);
                        cmd.Parameters.AddWithValue("@name", customerName);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value && int.TryParse(result.ToString(), out int customerId))
                            return customerId;
                    }
                    catch (SqlException ex) when (ex.Message.IndexOf("Invalid column name", StringComparison.OrdinalIgnoreCase) >= 0) { continue; }
                }
            }
            catch { }
            return null;
        }

        private string GetCustomerNameById(int? customerId)
        {
            if (!customerId.HasValue) return string.Empty;
            try
            {
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                con.Open();
                string[] possibleColumns = { "Cust_Id", "CustomerId", "Customer_ID", "Id" };
                foreach (string columnName in possibleColumns)
                {
                    try
                    {
                        using SqlCommand cmd = new SqlCommand(
                            $@"SELECT TOP 1 Cust_Name FROM SALES_MASTER.dbo.Customers WHERE [{columnName}] = @customerId", con);
                        cmd.Parameters.AddWithValue("@customerId", customerId.Value);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            return result.ToString() ?? string.Empty;
                    }
                    catch (SqlException ex) when (ex.Message.IndexOf("Invalid column name", StringComparison.OrdinalIgnoreCase) >= 0) { continue; }
                }
            }
            catch { }
            return string.Empty;
        }

        // ─────────────────────────────────────────────────────────────
        //  SAVE RECORD
        // ─────────────────────────────────────────────────────────────
        private bool SaveQuotationRecord(string requestedStatus, string pdfPath)
        {
            string previousQuotationNo = txtQuotationNo.Text.Trim();
            DateTime previousQuotationDate = dtQuotationDate.Value;
            try
            {
                if (!ValidateQuotationForSave()) return false;
                int? customerId = GetCustomerIdByName(cmbselectcustomer.Text.Trim());
                if (!customerId.HasValue)
                {
                    MessageBox.Show("Customer ID not found.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                con.Open();
                using SqlTransaction transaction = con.BeginTransaction();

                string effectiveStatus = requestedStatus;
                string effectivePdfPath = string.IsNullOrWhiteSpace(pdfPath) ? string.Empty : pdfPath;

                if (currentQuotationStatus.Equals("Generated", StringComparison.OrdinalIgnoreCase) &&
                    requestedStatus.Equals("Saved", StringComparison.OrdinalIgnoreCase))
                {
                    effectiveStatus = "Generated";
                    effectivePdfPath = currentPdfPath;
                }

                bool needsGeneratedNumber =
                    effectiveStatus.Equals("Generated", StringComparison.OrdinalIgnoreCase) &&
                    !currentQuotationStatus.Equals("Generated", StringComparison.OrdinalIgnoreCase) &&
                    IsTemporaryQuotationNumber(txtQuotationNo.Text.Trim());

                bool needsSavedNumber =
                    !currentSalesQuotationId.HasValue &&
                    effectiveStatus.Equals("Saved", StringComparison.OrdinalIgnoreCase);

                if (needsGeneratedNumber)
                {
                    txtQuotationNo.Text = GetNextQuotationNumber(con, transaction, true);
                    dtQuotationDate.Value = DateTime.Today;
                }
                else if (needsSavedNumber)
                {
                    txtQuotationNo.Text = GetNextQuotationNumber(con, transaction, false);
                    dtQuotationDate.Value = DateTime.Today;
                }

                if (!SaveQuotationSnapshot())
                {
                    transaction.Rollback();
                    txtQuotationNo.Text = previousQuotationNo;
                    dtQuotationDate.Value = previousQuotationDate;
                    return false;
                }

                int salesQuotationId;
                if (currentSalesQuotationId.HasValue)
                {
                    salesQuotationId = currentSalesQuotationId.Value;
                    using SqlCommand updateCmd = new SqlCommand(
                        @"UPDATE SALES_MASTER.dbo.SalesQuotations
                          SET SalesQuotationNo=@quotationNo, SalesQuotationDate=@quotationDate,
                              Cust_Id=@custId, PdfPath=@pdfPath, Status=@status
                          WHERE SalesQuotationId=@salesQuotationId", con, transaction);
                    updateCmd.Parameters.AddWithValue("@quotationNo", txtQuotationNo.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@quotationDate", dtQuotationDate.Value.Date);
                    updateCmd.Parameters.AddWithValue("@custId", customerId.Value);
                    updateCmd.Parameters.AddWithValue("@pdfPath", string.IsNullOrWhiteSpace(effectivePdfPath) ? DBNull.Value : effectivePdfPath);
                    updateCmd.Parameters.AddWithValue("@status", effectiveStatus);
                    updateCmd.Parameters.AddWithValue("@salesQuotationId", salesQuotationId);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    using SqlCommand insertCmd = new SqlCommand(
                        @"INSERT INTO SALES_MASTER.dbo.SalesQuotations
                          (SalesQuotationNo, SalesQuotationDate, Cust_Id, PdfPath, Status)
                          VALUES (@quotationNo, @quotationDate, @custId, @pdfPath, @status);
                          SELECT CAST(SCOPE_IDENTITY() AS INT);", con, transaction);
                    insertCmd.Parameters.AddWithValue("@quotationNo", txtQuotationNo.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@quotationDate", dtQuotationDate.Value.Date);
                    insertCmd.Parameters.AddWithValue("@custId", customerId.Value);
                    insertCmd.Parameters.AddWithValue("@pdfPath", string.IsNullOrWhiteSpace(effectivePdfPath) ? DBNull.Value : effectivePdfPath);
                    insertCmd.Parameters.AddWithValue("@status", effectiveStatus);
                    salesQuotationId = Convert.ToInt32(insertCmd.ExecuteScalar());
                }

                SaveQuotationDetails(con, transaction, salesQuotationId);
                transaction.Commit();
                currentSalesQuotationId = salesQuotationId;
                currentQuotationStatus = effectiveStatus;
                currentPdfPath = effectivePdfPath;
                DeleteObsoleteDraft(previousQuotationNo, txtQuotationNo.Text.Trim());
                UpdateActionButtons();
                return true;
            }
            catch (Exception ex)
            {
                txtQuotationNo.Text = previousQuotationNo;
                dtQuotationDate.Value = previousQuotationDate;
                MessageBox.Show("Save Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveQuotationDetails(SqlConnection con, SqlTransaction transaction, int salesQuotationId)
        {
            EnsureSalesQuotationDetailTextSchema(con, transaction);
            HashSet<string> detailColumns = GetSalesQuotationDetailColumns(con, transaction);
            Dictionary<string, SalesQuotationDetailColumnInfo> detailColumnInfo = GetSalesQuotationDetailColumnInfo(con, transaction);

            using SqlCommand deleteCmd = new SqlCommand(
                @"DELETE FROM SALES_MASTER.dbo.SalesQuotationDetails WHERE SalesQuotationId=@salesQuotationId", con, transaction);
            deleteCmd.Parameters.AddWithValue("@salesQuotationId", salesQuotationId);
            deleteCmd.ExecuteNonQuery();

            List<QuoteItem> items = GetGridItemsForPersistence();
            if (items.Count == 0) items.Add(new QuoteItem());

            foreach (QuoteItem item in items)
            {
                string? buyersReferenceColumn = FindExistingColumn(detailColumns,
                    "Buyers_Reference_And_Date", "Byuers_Reference_And_Date",
                    "Buyers Reference And Date", "Byuers Reference And Date", "BuyersReferenceAndDate");
                string? kindAttnColumn = FindExistingColumn(detailColumns, "KindAttnName");
                string? itemNameColumn = FindExistingColumn(detailColumns, "ItemName");
                string? itemDescriptionColumn = FindExistingColumn(detailColumns, "ItemDescription");
                string? modelNoColumn = FindExistingColumn(detailColumns, "ModelNo");
                string? hsnColumn = FindExistingColumn(detailColumns, "HSN_SAC", "HSN_SAC ");
                string? qtyColumn = FindExistingColumn(detailColumns, "Qty");
                string? rateColumn = FindExistingColumn(detailColumns, "Rate");
                string? gstColumn = FindExistingColumn(detailColumns, "GST");
                string? cgstColumn = FindExistingColumn(detailColumns, "CGST");
                string? sgstColumn = FindExistingColumn(detailColumns, "SGST");
                string? totalColumn = FindExistingColumn(detailColumns, "Total");
                string? validityColumn = FindExistingColumn(detailColumns, "Validity");
                string? deliveryPeriodColumn = FindExistingColumn(detailColumns, "DeliveryPeriod");
                string? paymentTermsColumn = FindExistingColumn(detailColumns, "PaymentTerms");

                List<string> insertColumns = new List<string> { "SalesQuotationId" };
                List<string> insertParameters = new List<string> { "@salesQuotationId" };

                void AddColumnIfExists(string? columnName, string parameterName)
                {
                    if (string.IsNullOrWhiteSpace(columnName)) return;
                    insertColumns.Add($"[{columnName}]");
                    insertParameters.Add(parameterName);
                }

                AddColumnIfExists(kindAttnColumn, "@kindAttnName");
                AddColumnIfExists(buyersReferenceColumn, "@buyersReference");
                AddColumnIfExists(itemNameColumn, "@itemName");
                AddColumnIfExists(itemDescriptionColumn, "@itemDescription");
                AddColumnIfExists(modelNoColumn, "@modelNo");
                AddColumnIfExists(hsnColumn, "@hsnSac");
                AddColumnIfExists(qtyColumn, "@qty");
                AddColumnIfExists(rateColumn, "@rate");
                AddColumnIfExists(gstColumn, "@gst");
                AddColumnIfExists(cgstColumn, "@cgst");
                AddColumnIfExists(sgstColumn, "@sgst");
                AddColumnIfExists(totalColumn, "@total");
                AddColumnIfExists(validityColumn, "@validity");
                AddColumnIfExists(deliveryPeriodColumn, "@deliveryPeriod");
                AddColumnIfExists(paymentTermsColumn, "@paymentTerms");

                using SqlCommand insertCmd = new SqlCommand(
                    $@"INSERT INTO SALES_MASTER.dbo.SalesQuotationDetails
                      ({string.Join(", ", insertColumns)}) VALUES ({string.Join(", ", insertParameters)})",
                    con, transaction);

                insertCmd.Parameters.AddWithValue("@salesQuotationId", salesQuotationId);
                AddTypedDetailParameter(insertCmd, "@kindAttnName", kindAttnColumn, txtkindattname.Text, detailColumnInfo, "Kind Attention Name");
                AddTypedDetailParameter(insertCmd, "@buyersReference", buyersReferenceColumn, txtBuyersreferenceanddate.Text, detailColumnInfo, "Buyer's Reference And Date");
                AddTypedDetailParameter(insertCmd, "@itemName", itemNameColumn, item.ItemName, detailColumnInfo, "Item Name");
                AddTypedDetailParameter(insertCmd, "@itemDescription", itemDescriptionColumn, item.Desc, detailColumnInfo, "Item Description");
                AddTypedDetailParameter(insertCmd, "@modelNo", modelNoColumn, item.ModelNo, detailColumnInfo, "Model No");
                AddTypedDetailParameter(insertCmd, "@hsnSac", hsnColumn, item.HSN, detailColumnInfo, "HSN/SAC");
                AddTypedDetailParameter(insertCmd, "@qty", qtyColumn, item.Qty, detailColumnInfo, "Qty");
                AddTypedDetailParameter(insertCmd, "@rate", rateColumn, item.Rate, detailColumnInfo, "Rate");
                AddTypedDetailParameter(insertCmd, "@gst", gstColumn, item.GSTPct, detailColumnInfo, "GST");
                AddTypedDetailParameter(insertCmd, "@cgst", cgstColumn, item.CGST, detailColumnInfo, "CGST");
                AddTypedDetailParameter(insertCmd, "@sgst", sgstColumn, item.SGST, detailColumnInfo, "SGST");
                AddTypedDetailParameter(insertCmd, "@total", totalColumn, item.Total, detailColumnInfo, "Total");
                AddTypedDetailParameter(insertCmd, "@validity", validityColumn, cmbValidity.Text, detailColumnInfo, "Validity");
                AddTypedDetailParameter(insertCmd, "@deliveryPeriod", deliveryPeriodColumn, txtDeliveryPeriod.Text, detailColumnInfo, "Delivery Period");
                AddTypedDetailParameter(insertCmd, "@paymentTerms", paymentTermsColumn, txtPaymentTerms.Text, detailColumnInfo, "Payment Terms");
                insertCmd.ExecuteNonQuery();
            }
        }

        private List<QuoteItem> GetGridItemsForPersistence()
        {
            List<QuoteItem> items = new List<QuoteItem>();
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow) continue;
                QuoteItem item = new QuoteItem
                {
                    SrNo = row.Cells["SrNo"].Value?.ToString() ?? "",
                    ItemName = row.Cells["ItemName"].Value?.ToString() ?? "",
                    Desc = row.Cells["Description"].Value?.ToString() ?? "",
                    ModelNo = row.Cells["ModelNo"].Value?.ToString() ?? "",
                    HSN = row.Cells["HSN"].Value?.ToString() ?? "",
                    Qty = row.Cells["Qty"].Value?.ToString() ?? "",
                    Rate = row.Cells["Rate"].Value?.ToString() ?? "",
                    GSTPct = row.Cells["GST"].Value?.ToString() ?? "",
                    CGST = row.Cells["CGST"].Value?.ToString() ?? "",
                    SGST = row.Cells["SGST"].Value?.ToString() ?? "",
                    Total = row.Cells["Total"].Value?.ToString() ?? ""
                };
                bool hasAnyValue =
                    !string.IsNullOrWhiteSpace(item.ItemName) || !string.IsNullOrWhiteSpace(item.Desc) ||
                    !string.IsNullOrWhiteSpace(item.ModelNo) || !string.IsNullOrWhiteSpace(item.HSN) ||
                    !string.IsNullOrWhiteSpace(item.Qty) || !string.IsNullOrWhiteSpace(item.Rate) ||
                    !string.IsNullOrWhiteSpace(item.GSTPct) || !string.IsNullOrWhiteSpace(item.CGST) ||
                    !string.IsNullOrWhiteSpace(item.SGST) || !string.IsNullOrWhiteSpace(item.Total);
                if (hasAnyValue) items.Add(item);
            }
            return items;
        }

        private HashSet<string> GetSalesQuotationDetailColumns(SqlConnection con, SqlTransaction? transaction)
        {
            HashSet<string> columns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            using SqlCommand cmd = new SqlCommand(
                @"SELECT COLUMN_NAME FROM SALES_MASTER.INFORMATION_SCHEMA.COLUMNS
                  WHERE TABLE_NAME='SalesQuotationDetails'", con, transaction);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string columnName = dr["COLUMN_NAME"]?.ToString() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(columnName)) columns.Add(columnName);
            }
            return columns;
        }

        private Dictionary<string, SalesQuotationDetailColumnInfo> GetSalesQuotationDetailColumnInfo(SqlConnection con, SqlTransaction? transaction)
        {
            var columns = new Dictionary<string, SalesQuotationDetailColumnInfo>(StringComparer.OrdinalIgnoreCase);
            using SqlCommand cmd = new SqlCommand(
                @"SELECT COLUMN_NAME, DATA_TYPE, NUMERIC_PRECISION, NUMERIC_SCALE
                  FROM SALES_MASTER.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='SalesQuotationDetails'", con, transaction);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string columnName = dr["COLUMN_NAME"]?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(columnName)) continue;
                string dataType = dr["DATA_TYPE"]?.ToString() ?? string.Empty;
                int? precision = dr["NUMERIC_PRECISION"] != DBNull.Value ? Convert.ToInt32(dr["NUMERIC_PRECISION"]) : null;
                int? scale = dr["NUMERIC_SCALE"] != DBNull.Value ? Convert.ToInt32(dr["NUMERIC_SCALE"]) : null;
                columns[columnName] = new SalesQuotationDetailColumnInfo(columnName, dataType, precision, scale);
            }
            return columns;
        }

        private void EnsureSalesQuotationDetailTextSchema(SqlConnection con, SqlTransaction transaction)
        {
            Dictionary<string, SalesQuotationDetailColumnInfo> columnInfo = GetSalesQuotationDetailColumnInfo(con, transaction);

            void EnsureTextColumn(string[] candidates, string sqlType)
            {
                string? actualColumnName = FindExistingColumn(columnInfo.Keys, candidates);
                if (string.IsNullOrWhiteSpace(actualColumnName)) return;
                if (!columnInfo.TryGetValue(actualColumnName, out SalesQuotationDetailColumnInfo? info)) return;
                if (IsTextSqlType(info.DataType)) return;
                using SqlCommand alterCmd = new SqlCommand(
                    $@"ALTER TABLE SALES_MASTER.dbo.SalesQuotationDetails ALTER COLUMN [{actualColumnName}] {sqlType} NULL", con, transaction);
                alterCmd.ExecuteNonQuery();
                columnInfo[actualColumnName] = new SalesQuotationDetailColumnInfo(actualColumnName, sqlType, null, null);
            }

            void EnsureDecimalColumn(string[] candidates, string sqlType)
            {
                string? actualColumnName = FindExistingColumn(columnInfo.Keys, candidates);
                if (string.IsNullOrWhiteSpace(actualColumnName)) return;
                if (!columnInfo.TryGetValue(actualColumnName, out SalesQuotationDetailColumnInfo? info)) return;
                if (IsSufficientDecimalSqlType(info, 18, 2)) return;
                using SqlCommand alterCmd = new SqlCommand(
                    $@"ALTER TABLE SALES_MASTER.dbo.SalesQuotationDetails ALTER COLUMN [{actualColumnName}] {sqlType} NULL", con, transaction);
                alterCmd.ExecuteNonQuery();
                columnInfo[actualColumnName] = new SalesQuotationDetailColumnInfo(actualColumnName, sqlType, 18, 2);
            }

            EnsureTextColumn(new[] { "KindAttnName" }, "NVARCHAR(255)");
            EnsureTextColumn(new[] { "Buyers_Reference_And_Date", "Byuers_Reference_And_Date", "BuyersReferenceAndDate" }, "NVARCHAR(255)");
            EnsureTextColumn(new[] { "ItemName" }, "NVARCHAR(255)");
            EnsureTextColumn(new[] { "ItemDescription" }, "NVARCHAR(MAX)");
            EnsureTextColumn(new[] { "ModelNo" }, "NVARCHAR(255)");
            EnsureTextColumn(new[] { "HSN_SAC", "HSN_SAC " }, "NVARCHAR(255)");
            EnsureTextColumn(new[] { "Validity" }, "NVARCHAR(100)");
            EnsureTextColumn(new[] { "DeliveryPeriod" }, "NVARCHAR(255)");
            EnsureTextColumn(new[] { "PaymentTerms" }, "NVARCHAR(255)");
            EnsureDecimalColumn(new[] { "Qty" }, "DECIMAL(18,2)");
            EnsureDecimalColumn(new[] { "Rate" }, "DECIMAL(18,2)");
            EnsureDecimalColumn(new[] { "GST" }, "DECIMAL(18,2)");
            EnsureDecimalColumn(new[] { "CGST" }, "DECIMAL(18,2)");
            EnsureDecimalColumn(new[] { "SGST" }, "DECIMAL(18,2)");
            EnsureDecimalColumn(new[] { "Total" }, "DECIMAL(18,2)");
        }

        private void AddTypedDetailParameter(
            SqlCommand command, string parameterName, string? actualColumnName,
            string? rawValue, IReadOnlyDictionary<string, SalesQuotationDetailColumnInfo> columnInfo, string displayName)
        {
            object value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(actualColumnName) &&
                columnInfo.TryGetValue(actualColumnName, out SalesQuotationDetailColumnInfo? info))
                value = ConvertValueForColumn(rawValue, info, displayName);
            else if (!string.IsNullOrWhiteSpace(rawValue))
                value = rawValue.Trim();
            command.Parameters.AddWithValue(parameterName, value);
        }

        private object ConvertValueForColumn(string? rawValue, SalesQuotationDetailColumnInfo info, string displayName)
        {
            string value = rawValue?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(value)) return DBNull.Value;
            string dataType = info.DataType.Trim().ToLowerInvariant();
            if (IsIntegerSqlType(dataType))
            {
                if (long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out long longValue) ||
                    long.TryParse(value, NumberStyles.Integer, CultureInfo.CurrentCulture, out longValue))
                    return longValue;
                throw new InvalidOperationException($"{displayName} must be numeric.");
            }
            if (IsDecimalSqlType(dataType))
            {
                if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalValue) ||
                    decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out decimalValue))
                    return decimalValue;
                throw new InvalidOperationException($"{displayName} must be numeric.");
            }
            if (dataType == "bit")
            {
                if (bool.TryParse(value, out bool boolValue)) return boolValue;
                if (value == "1") return true;
                if (value == "0") return false;
                throw new InvalidOperationException($"{displayName} must be True/False.");
            }
            if (IsDateSqlType(dataType))
            {
                if (DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dateValue) ||
                    DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                    return dateValue;
                throw new InvalidOperationException($"{displayName} must be a valid date.");
            }
            return value;
        }

        private static bool IsIntegerSqlType(string dataType) =>
            dataType is "tinyint" or "smallint" or "int" or "bigint";
        private static bool IsDecimalSqlType(string dataType) =>
            dataType is "decimal" or "numeric" or "money" or "smallmoney" or "float" or "real";
        private static bool IsDateSqlType(string dataType) =>
            dataType is "date" or "datetime" or "datetime2" or "smalldatetime" or "datetimeoffset";
        private static bool IsSufficientDecimalSqlType(SalesQuotationDetailColumnInfo info, int requiredPrecision, int requiredScale) =>
            IsDecimalSqlType(info.DataType) && info.NumericPrecision.HasValue && info.NumericScale.HasValue &&
            info.NumericPrecision.Value >= requiredPrecision && info.NumericScale.Value >= requiredScale;
        private static bool IsTextSqlType(string dataType)
        {
            string normalized = dataType.Trim().ToLowerInvariant();
            return normalized == "text" || normalized == "ntext" ||
                   normalized.StartsWith("char", StringComparison.Ordinal) ||
                   normalized.StartsWith("nchar", StringComparison.Ordinal) ||
                   normalized.StartsWith("varchar", StringComparison.Ordinal) ||
                   normalized.StartsWith("nvarchar", StringComparison.Ordinal);
        }

        private string? FindExistingColumn(IEnumerable<string> columns, params string[] candidates)
        {
            foreach (string candidate in candidates)
            {
                string? match = columns.FirstOrDefault(col => string.Equals(col, candidate, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrWhiteSpace(match)) return match;
            }
            foreach (string candidate in candidates)
            {
                string normalizedCandidate = NormalizeColumnName(candidate);
                if (string.IsNullOrWhiteSpace(normalizedCandidate)) continue;
                string? match = columns.FirstOrDefault(col =>
                    string.Equals(NormalizeColumnName(col), normalizedCandidate, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrWhiteSpace(match)) return match;
            }
            return null;
        }

        private static string NormalizeColumnName(string? value) =>
            string.IsNullOrWhiteSpace(value) ? string.Empty : new string(value.Where(char.IsLetterOrDigit).ToArray());

        private string GetQuotationDraftFolderPath() =>
            Path.Combine(System.Windows.Forms.Application.StartupPath, "QuotationDrafts");

        private string GetQuotationDraftFilePath(string quotationNo)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            string safeFileName = new string(quotationNo.Select(ch => invalidChars.Contains(ch) ? '_' : ch).ToArray());
            return Path.Combine(GetQuotationDraftFolderPath(), safeFileName + ".json");
        }

        private bool SaveQuotationSnapshot()
        {
            try
            {
                QuotationSnapshot snapshot = BuildQuotationSnapshot();
                Directory.CreateDirectory(GetQuotationDraftFolderPath());
                string json = JsonSerializer.Serialize(snapshot, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(GetQuotationDraftFilePath(snapshot.QuotationNo), json);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Draft Save Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private QuotationSnapshot BuildQuotationSnapshot()
        {
            List<QuoteItem> items = new List<QuoteItem>();
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow) continue;
                items.Add(new QuoteItem
                {
                    SrNo = row.Cells["SrNo"].Value?.ToString() ?? "",
                    ItemName = row.Cells["ItemName"].Value?.ToString() ?? "",
                    Desc = row.Cells["Description"].Value?.ToString() ?? "",
                    ModelNo = row.Cells["ModelNo"].Value?.ToString() ?? "",
                    HSN = row.Cells["HSN"].Value?.ToString() ?? "",
                    Qty = row.Cells["Qty"].Value?.ToString() ?? "",
                    Rate = row.Cells["Rate"].Value?.ToString() ?? "",
                    GSTPct = row.Cells["GST"].Value?.ToString() ?? "",
                    CGST = row.Cells["CGST"].Value?.ToString() ?? "",
                    SGST = row.Cells["SGST"].Value?.ToString() ?? "",
                    Total = row.Cells["Total"].Value?.ToString() ?? ""
                });
            }
            return new QuotationSnapshot
            {
                QuotationNo = txtQuotationNo.Text.Trim(),
                QuotationDate = dtQuotationDate.Value,
                CustomerName = cmbselectcustomer.Text,
                GSTType = cmbgst.Text,
                IsGSTSelected = rdoGST.Checked,
                GSTNo = txtGSTno.Text.Trim(),
                PANNo = txtPANNo.Text.Trim(),
                KindAttentionName = txtkindattname.Text.Trim(),
                BuyersReference = txtBuyersreferenceanddate.Text.Trim(),
                BillingAddressLine1 = txtAddressLine1.Text.Trim(),
                BillingAddressLine2 = txtAddressLine2.Text.Trim(),
                BillingPinCode = txtPinCode.Text.Trim(),
                BillingCity = txtCity.Text.Trim(),
                BillingState = txtState.Text.Trim(),
                ShippingAddressLine1 = txtShipAddressLine1.Text.Trim(),
                ShippingAddressLine2 = txtShipAddressLine2.Text.Trim(),
                ShippingPinCode = txtShipPinCode.Text.Trim(),
                ShippingCity = txtShipCity.Text.Trim(),
                ShippingState = txtShipState.Text.Trim(),
                Validity = cmbValidity.Text,
                DeliveryPeriod = txtDeliveryPeriod.Text.Trim(),
                PaymentTerms = txtPaymentTerms.Text.Trim(),
                Items = items
            };
        }

        // ─────────────────────────────────────────────────────────────
        //  LOAD FOR EDIT
        // ─────────────────────────────────────────────────────────────
        private void LoadQuotationForEdit(string quotationNo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(quotationNo)) return;
                string draftPath = GetQuotationDraftFilePath(quotationNo);
                QuotationSnapshot? draftSnapshot = null;
                if (File.Exists(draftPath))
                {
                    string draftJson = File.ReadAllText(draftPath);
                    draftSnapshot = JsonSerializer.Deserialize<QuotationSnapshot>(draftJson);
                }
                if (LoadQuotationFromDatabase(quotationNo))
                {
                    if (draftSnapshot != null) FillMissingQuotationValuesFromSnapshot(draftSnapshot);
                    return;
                }
                if (!File.Exists(draftPath)) { LoadQuotationHeaderFromDatabase(quotationNo); return; }
                if (draftSnapshot == null) return;
                ApplyQuotationSnapshot(draftSnapshot);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Modify Load Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillMissingQuotationValuesFromSnapshot(QuotationSnapshot snapshot)
        {
            if (IsEffectivelyEmptyText(txtkindattname.Text, "Concerned Person Name") &&
                !string.IsNullOrWhiteSpace(snapshot.KindAttentionName))
                txtkindattname.Text = snapshot.KindAttentionName;
            if (IsEffectivelyEmptyText(txtBuyersreferenceanddate.Text, "Reference Note") &&
                !string.IsNullOrWhiteSpace(snapshot.BuyersReference))
                txtBuyersreferenceanddate.Text = snapshot.BuyersReference;
            if (string.IsNullOrWhiteSpace(txtDeliveryPeriod.Text) && !string.IsNullOrWhiteSpace(snapshot.DeliveryPeriod))
                txtDeliveryPeriod.Text = snapshot.DeliveryPeriod;
            if (string.IsNullOrWhiteSpace(txtPaymentTerms.Text) && !string.IsNullOrWhiteSpace(snapshot.PaymentTerms))
                txtPaymentTerms.Text = snapshot.PaymentTerms;
            if (string.IsNullOrWhiteSpace(cmbValidity.Text) && !string.IsNullOrWhiteSpace(snapshot.Validity))
                cmbValidity.SelectedItem = snapshot.Validity;
        }

        private static bool IsEffectivelyEmptyText(string? value, params string[] seedTexts)
        {
            string normalizedValue = value?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(normalizedValue)) return true;
            foreach (string seedText in seedTexts)
                if (string.Equals(normalizedValue, seedText, StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }

        private bool LoadQuotationFromDatabase(string quotationNo)
        {
            try
            {
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                con.Open();
                using SqlCommand headerCmd = new SqlCommand(
                    @"SELECT TOP 1 SalesQuotationId, SalesQuotationNo, SalesQuotationDate, Cust_Id, Status, PdfPath
                      FROM SALES_MASTER.dbo.SalesQuotations WHERE SalesQuotationNo=@quotationNo", con);
                headerCmd.Parameters.AddWithValue("@quotationNo", quotationNo);
                using SqlDataReader headerReader = headerCmd.ExecuteReader();
                if (!headerReader.Read()) return false;
                int salesQuotationId = Convert.ToInt32(headerReader["SalesQuotationId"]);
                string customerName = string.Empty;
                if (headerReader["Cust_Id"] != DBNull.Value && int.TryParse(headerReader["Cust_Id"].ToString(), out int customerId))
                    customerName = GetCustomerNameById(customerId);
                QuotationSnapshot snapshot = new QuotationSnapshot
                {
                    QuotationNo = headerReader["SalesQuotationNo"]?.ToString() ?? quotationNo,
                    QuotationDate = headerReader["SalesQuotationDate"] != DBNull.Value
                        ? Convert.ToDateTime(headerReader["SalesQuotationDate"]) : DateTime.Today,
                    CustomerName = customerName
                };
                currentSalesQuotationId = salesQuotationId;
                currentQuotationStatus = headerReader["Status"]?.ToString() ?? string.Empty;
                currentPdfPath = headerReader["PdfPath"]?.ToString() ?? string.Empty;
                headerReader.Close();

                HashSet<string> detailColumns = GetSalesQuotationDetailColumns(con, null);
                string? buyersReferenceColumn = FindExistingColumn(detailColumns,
                    "Buyers_Reference_And_Date", "Byuers_Reference_And_Date", "BuyersReferenceAndDate");
                string? kindAttnColumn = FindExistingColumn(detailColumns, "KindAttnName");
                string? itemNameColumn = FindExistingColumn(detailColumns, "ItemName");
                string? itemDescriptionColumn = FindExistingColumn(detailColumns, "ItemDescription");
                string? modelNoColumn = FindExistingColumn(detailColumns, "ModelNo");
                string? hsnColumn = FindExistingColumn(detailColumns, "HSN_SAC", "HSN_SAC ");
                string? qtyColumn = FindExistingColumn(detailColumns, "Qty");
                string? rateColumn = FindExistingColumn(detailColumns, "Rate");
                string? gstColumn = FindExistingColumn(detailColumns, "GST");
                string? cgstColumn = FindExistingColumn(detailColumns, "CGST");
                string? sgstColumn = FindExistingColumn(detailColumns, "SGST");
                string? totalColumn = FindExistingColumn(detailColumns, "Total");
                string? validityColumn = FindExistingColumn(detailColumns, "Validity");
                string? deliveryPeriodColumn = FindExistingColumn(detailColumns, "DeliveryPeriod");
                string? paymentTermsColumn = FindExistingColumn(detailColumns, "PaymentTerms");
                string orderByColumn = FindExistingColumn(detailColumns, "Id") ?? "SalesQuotationId";

                string SelectColumn(string? actualColumnName, string alias) =>
                    string.IsNullOrWhiteSpace(actualColumnName) ? $"NULL AS [{alias}]" : $"[{actualColumnName}] AS [{alias}]";

                using SqlCommand detailsCmd = new SqlCommand(
                    $@"SELECT {SelectColumn(kindAttnColumn, "KindAttnName")},
                              {SelectColumn(buyersReferenceColumn, "BuyersReference")},
                              {SelectColumn(itemNameColumn, "ItemName")},
                              {SelectColumn(itemDescriptionColumn, "ItemDescription")},
                              {SelectColumn(modelNoColumn, "ModelNo")},
                              {SelectColumn(hsnColumn, "HSN_SAC")},
                              {SelectColumn(qtyColumn, "Qty")},
                              {SelectColumn(rateColumn, "Rate")},
                              {SelectColumn(gstColumn, "GST")},
                              {SelectColumn(cgstColumn, "CGST")},
                              {SelectColumn(sgstColumn, "SGST")},
                              {SelectColumn(totalColumn, "Total")},
                              {SelectColumn(validityColumn, "Validity")},
                              {SelectColumn(deliveryPeriodColumn, "DeliveryPeriod")},
                              {SelectColumn(paymentTermsColumn, "PaymentTerms")}
                      FROM SALES_MASTER.dbo.SalesQuotationDetails
                      WHERE SalesQuotationId=@salesQuotationId ORDER BY [{orderByColumn}]", con);
                detailsCmd.Parameters.AddWithValue("@salesQuotationId", salesQuotationId);
                using SqlDataReader detailsReader = detailsCmd.ExecuteReader();
                bool hasDetails = false;
                while (detailsReader.Read())
                {
                    hasDetails = true;
                    if (string.IsNullOrWhiteSpace(snapshot.KindAttentionName))
                        snapshot.KindAttentionName = detailsReader["KindAttnName"]?.ToString() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(snapshot.BuyersReference))
                        snapshot.BuyersReference = detailsReader["BuyersReference"]?.ToString() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(snapshot.Validity))
                        snapshot.Validity = detailsReader["Validity"]?.ToString() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(snapshot.DeliveryPeriod))
                        snapshot.DeliveryPeriod = detailsReader["DeliveryPeriod"]?.ToString() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(snapshot.PaymentTerms))
                        snapshot.PaymentTerms = detailsReader["PaymentTerms"]?.ToString() ?? string.Empty;
                    QuoteItem item = new QuoteItem
                    {
                        ItemName = detailsReader["ItemName"]?.ToString() ?? string.Empty,
                        Desc = detailsReader["ItemDescription"]?.ToString() ?? string.Empty,
                        ModelNo = detailsReader["ModelNo"]?.ToString() ?? string.Empty,
                        HSN = detailsReader["HSN_SAC"]?.ToString() ?? string.Empty,
                        Qty = detailsReader["Qty"]?.ToString() ?? string.Empty,
                        Rate = detailsReader["Rate"]?.ToString() ?? string.Empty,
                        GSTPct = detailsReader["GST"]?.ToString() ?? string.Empty,
                        CGST = detailsReader["CGST"]?.ToString() ?? string.Empty,
                        SGST = detailsReader["SGST"]?.ToString() ?? string.Empty,
                        Total = detailsReader["Total"]?.ToString() ?? string.Empty
                    };
                    bool hasAnyItemValue =
                        !string.IsNullOrWhiteSpace(item.ItemName) || !string.IsNullOrWhiteSpace(item.Desc) ||
                        !string.IsNullOrWhiteSpace(item.ModelNo) || !string.IsNullOrWhiteSpace(item.HSN) ||
                        !string.IsNullOrWhiteSpace(item.Qty) || !string.IsNullOrWhiteSpace(item.Rate);
                    if (hasAnyItemValue) snapshot.Items.Add(item);
                }
                if (!hasDetails) return false;
                ApplyQuotationSnapshot(snapshot);
                UpdateActionButtons();
                return true;
            }
            catch { return false; }
        }

        private void LoadQuotationHeaderFromDatabase(string quotationNo)
        {
            try
            {
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                using SqlCommand cmd = new SqlCommand(
                    @"SELECT TOP 1 SalesQuotationId, SalesQuotationNo, SalesQuotationDate, Cust_Id, Status, PdfPath
                      FROM SALES_MASTER.dbo.SalesQuotations WHERE SalesQuotationNo=@quotationNo", con);
                cmd.Parameters.AddWithValue("@quotationNo", quotationNo);
                con.Open();
                using SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read()) return;
                currentQuotationStatus = dr["Status"]?.ToString() ?? string.Empty;
                currentPdfPath = dr["PdfPath"]?.ToString() ?? string.Empty;
                currentSalesQuotationId = dr["SalesQuotationId"] != DBNull.Value ? Convert.ToInt32(dr["SalesQuotationId"]) : null;
                string customerName = string.Empty;
                if (dr["Cust_Id"] != DBNull.Value && int.TryParse(dr["Cust_Id"].ToString(), out int customerId))
                    customerName = GetCustomerNameById(customerId);
                isLoading = true;
                txtQuotationNo.Text = dr["SalesQuotationNo"]?.ToString() ?? quotationNo;
                if (dr["SalesQuotationDate"] != DBNull.Value && DateTime.TryParse(dr["SalesQuotationDate"].ToString(), out DateTime quotationDate))
                    dtQuotationDate.Value = quotationDate;
                if (!string.IsNullOrWhiteSpace(customerName))
                {
                    int customerIndex = cmbselectcustomer.FindStringExact(customerName);
                    if (customerIndex >= 0) cmbselectcustomer.SelectedIndex = customerIndex;
                    LoadCustomerDetails(customerName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Modify Load Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
                UpdateGSTColumns();
                UpdateActionButtons();
            }
        }

        private void ApplyQuotationSnapshot(QuotationSnapshot snapshot)
        {
            try
            {
                isLoading = true;
                txtQuotationNo.Text = snapshot.QuotationNo;
                if (snapshot.QuotationDate > DateTime.MinValue) dtQuotationDate.Value = snapshot.QuotationDate;
                if (!string.IsNullOrWhiteSpace(snapshot.CustomerName))
                {
                    int customerIndex = cmbselectcustomer.FindStringExact(snapshot.CustomerName);
                    if (customerIndex >= 0) cmbselectcustomer.SelectedIndex = customerIndex;
                    LoadCustomerDetails(snapshot.CustomerName);
                }
                txtkindattname.Text = snapshot.KindAttentionName;
                txtBuyersreferenceanddate.Text = snapshot.BuyersReference;
                if (!string.IsNullOrWhiteSpace(snapshot.BillingAddressLine1)) txtAddressLine1.Text = snapshot.BillingAddressLine1;
                if (!string.IsNullOrWhiteSpace(snapshot.BillingAddressLine2)) txtAddressLine2.Text = snapshot.BillingAddressLine2;
                if (!string.IsNullOrWhiteSpace(snapshot.BillingPinCode)) txtPinCode.Text = snapshot.BillingPinCode;
                if (!string.IsNullOrWhiteSpace(snapshot.BillingCity)) txtCity.Text = snapshot.BillingCity;
                if (!string.IsNullOrWhiteSpace(snapshot.BillingState)) txtState.Text = snapshot.BillingState;
                if (!string.IsNullOrWhiteSpace(snapshot.ShippingAddressLine1)) txtShipAddressLine1.Text = snapshot.ShippingAddressLine1;
                if (!string.IsNullOrWhiteSpace(snapshot.ShippingAddressLine2)) txtShipAddressLine2.Text = snapshot.ShippingAddressLine2;
                if (!string.IsNullOrWhiteSpace(snapshot.ShippingPinCode)) txtShipPinCode.Text = snapshot.ShippingPinCode;
                if (!string.IsNullOrWhiteSpace(snapshot.ShippingCity)) txtShipCity.Text = snapshot.ShippingCity;
                if (!string.IsNullOrWhiteSpace(snapshot.ShippingState)) txtShipState.Text = snapshot.ShippingState;
                if (!string.IsNullOrWhiteSpace(snapshot.GSTNo)) txtGSTno.Text = snapshot.GSTNo;
                if (!string.IsNullOrWhiteSpace(snapshot.PANNo)) txtPANNo.Text = snapshot.PANNo;
                bool useGST = snapshot.IsGSTSelected;
                if (!string.IsNullOrWhiteSpace(snapshot.GSTNo)) useGST = true;
                else if (!string.IsNullOrWhiteSpace(snapshot.PANNo)) useGST = false;
                else if (!string.IsNullOrWhiteSpace(txtGSTno.Text)) useGST = true;
                cmbgst.SelectedItem = string.IsNullOrWhiteSpace(snapshot.GSTType)
                    ? (useGST ? "With GST" : "Without GST") : snapshot.GSTType;
                rdoGST.Checked = useGST;
                rdoPAN.Checked = !useGST;
                if (!string.IsNullOrWhiteSpace(snapshot.Validity)) cmbValidity.SelectedItem = snapshot.Validity;
                txtDeliveryPeriod.Text = snapshot.DeliveryPeriod;
                txtPaymentTerms.Text = snapshot.PaymentTerms;
                dgvItems.Rows.Clear();
                if (snapshot.Items != null && snapshot.Items.Count > 0)
                {
                    foreach (QuoteItem item in snapshot.Items)
                    {
                        int rowIndex = dgvItems.Rows.Add();
                        DataGridViewRow row = dgvItems.Rows[rowIndex];
                        row.Cells["SrNo"].Value = string.IsNullOrWhiteSpace(item.SrNo) ? (rowIndex + 1).ToString() : item.SrNo;
                        row.Cells["ItemName"].Value = item.ItemName;
                        row.Cells["Description"].Value = item.Desc;
                        row.Cells["ModelNo"].Value = item.ModelNo;
                        row.Cells["HSN"].Value = item.HSN;
                        row.Cells["Qty"].Value = item.Qty;
                        row.Cells["Rate"].Value = item.Rate;
                        row.Cells["GST"].Value = item.GSTPct;
                        row.Cells["CGST"].Value = item.CGST;
                        row.Cells["SGST"].Value = item.SGST;
                        row.Cells["Total"].Value = item.Total;
                    }
                }
                else
                {
                    AddNewRow();
                }
                UpdateGSTColumns();
                ApplyResponsiveLayout();
            }
            finally { isLoading = false; }
        }

        private void OpenSalesQuotationList()
        {
            try
            {
                if (this.Parent is Panel parentPanel)
                {
                    parentPanel.Controls.Clear();
                    Salesquotes frm = new Salesquotes
                    {
                        TopLevel = false,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill
                    };
                    parentPanel.Controls.Add(frm);
                    frm.Show();
                    return;
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Navigation Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  SAVE BUTTON
        // ─────────────────────────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!SaveQuotationRecord("Saved", string.Empty)) return;
            MessageBox.Show("Quotation saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ─────────────────────────────────────────────────────────────
        //  GENERATE BUTTON
        // ─────────────────────────────────────────────────────────────
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!currentSalesQuotationId.HasValue)
                {
                    MessageBox.Show("Please save the quotation first, then generate the PDF.", "Save Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ValidateQuotationForSave()) return;

                string previousQuotationNo = txtQuotationNo.Text.Trim();
                DateTime previousQuotationDate = dtQuotationDate.Value;
                bool useNewGeneratedNumber = !currentQuotationStatus.Equals("Generated", StringComparison.OrdinalIgnoreCase);
                string targetGeneratedQuotationNo = useNewGeneratedNumber ? GetQuotationNumberPreview(true) : previousQuotationNo;

                if (useNewGeneratedNumber)
                {
                    txtQuotationNo.Text = targetGeneratedQuotationNo;
                    dtQuotationDate.Value = DateTime.Today;
                    this.Refresh();
                    System.Windows.Forms.Application.DoEvents();
                }

                string saveDialogQuotationNo = txtQuotationNo.Text.Trim();
                if (saveDialogQuotationNo.EndsWith("(S)", StringComparison.OrdinalIgnoreCase))
                    saveDialogQuotationNo = saveDialogQuotationNo[..^3];

                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "PDF File|*.pdf",
                    FileName = "Quotation_" + saveDialogQuotationNo + ".pdf",
                    Title = "Save Quotation PDF"
                };

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (!GenerateQuotationPDF(save.FileName))
                    {
                        txtQuotationNo.Text = previousQuotationNo;
                        dtQuotationDate.Value = previousQuotationDate;
                        return;
                    }
                    if (!SaveQuotationRecord("Generated", save.FileName))
                    {
                        txtQuotationNo.Text = previousQuotationNo;
                        dtQuotationDate.Value = previousQuotationDate;
                        return;
                    }
                    DialogResult result = MessageBox.Show(
                        "PDF Saved Successfully!\nDo you want to open it?",
                        "Open PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        Process.Start(new ProcessStartInfo(save.FileName) { UseShellExecute = true });
                }
                else if (useNewGeneratedNumber)
                {
                    txtQuotationNo.Text = previousQuotationNo;
                    dtQuotationDate.Value = previousQuotationDate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Generate Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  ✅ FIXED PDF GENERATION
        //  Key fixes:
        //  1. itemsPerPage uses a fixed value (9 for split GST, 10 otherwise)
        //     based on the template's 27 item rows (row 14 to row 40, step 3).
        //  2. Each page is its own worksheet from the template copy.
        //  3. Non-last pages do NOT render summary rows (totals/terms).
        //  4. PrintArea covers A1:G61 for complete layout.
        //  5. No manual shape manipulation that could break second page.
        // ─────────────────────────────────────────────────────────────
        private bool GenerateQuotationPDF(string pdfPath)
        {
            Microsoft.Office.Interop.Excel.Application? excel = null;
            Microsoft.Office.Interop.Excel.Workbook? wb = null;
            string tempExcel = Path.Combine(Path.GetTempPath(),
                "quotation_temp_" + Guid.NewGuid().ToString("N") + ".xlsx");

            try
            {
                string templatePath = Path.Combine(
                    System.Windows.Forms.Application.StartupPath, "Templates", "QuotationTemplate.xlsx");

                if (!File.Exists(templatePath))
                {
                    MessageBox.Show($"Template not found:\n{templatePath}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                List<QuoteItem> printableItems = GetPrintableQuotationItems();
                if (printableItems.Count == 0)
                    printableItems.Add(new QuoteItem { SrNo = "1" });

                // Template layout (confirmed from PDF output):
                //   Col A         = Sr.No
                //   Col B:C merge = Particular  (item name + desc + model/hsn + gst%)
                //   Col D:E merge = Qty
                //   Col F         = Rate/Each
                //   Col G         = Total Amt. (Without GST)
                // Each item slot occupies 3 rows (row N, N+1, N+2 merged vertically).
                // Item slots start at row 14: slots at rows 14,17,20,23,26,29,32,35,38,41
                // That gives 10 slots maximum per page.
                // For Split-GST we keep 9 slots to leave room for CGST/SGST rows.
                int itemsPerPage = UsesSplitGST() ? 9 : 10;
                int totalPages = Math.Max(1, (int)Math.Ceiling(printableItems.Count / (double)itemsPerPage));
                QuotationTotals totals = CalculatePrintableTotals(printableItems);

                using (var workbook = new XLWorkbook(templatePath))
                {
                    var templateSheet = workbook.Worksheet(1);

                    // Copy template for extra pages BEFORE renaming
                    for (int pageIndex = 2; pageIndex <= totalPages; pageIndex++)
                        templateSheet.CopyTo(workbook, "Page" + pageIndex);

                    templateSheet.Name = "Page1";

                    for (int pageIndex = 1; pageIndex <= totalPages; pageIndex++)
                    {
                        var ws = workbook.Worksheet("Page" + pageIndex);
                        bool isLastPage = (pageIndex == totalPages);

                        List<QuoteItem> pageItems = printableItems
                            .Skip((pageIndex - 1) * itemsPerPage)
                            .Take(itemsPerPage)
                            .ToList();

                        PrepareQuotationWorksheet(ws, pageItems, totals, isLastPage);
                    }

                    workbook.SaveAs(tempExcel);
                }

                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                wb = excel.Workbooks.Open(tempExcel,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                foreach (Microsoft.Office.Interop.Excel.Worksheet xlSheet in wb.Worksheets)
                {
                    try
                    {
                        xlSheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                        xlSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
                        xlSheet.PageSetup.PrintArea = "$A$1:$G$61";
                        xlSheet.PageSetup.Zoom = false;
                        xlSheet.PageSetup.FitToPagesWide = 1;
                        xlSheet.PageSetup.FitToPagesTall = 1;
                        xlSheet.PageSetup.LeftMargin = excel.InchesToPoints(0.55);
                        xlSheet.PageSetup.RightMargin = excel.InchesToPoints(0.08);
                        xlSheet.PageSetup.TopMargin = excel.InchesToPoints(0.20);
                        xlSheet.PageSetup.BottomMargin = excel.InchesToPoints(0.48);
                        xlSheet.PageSetup.HeaderMargin = excel.InchesToPoints(0.12);
                        xlSheet.PageSetup.FooterMargin = excel.InchesToPoints(0.24);
                        xlSheet.PageSetup.CenterHorizontally = true;
                        // Move page number slightly above the bottom edge
                        xlSheet.PageSetup.CenterFooter = "&8Page : &P/&N";
                        xlSheet.PageSetup.LeftFooter = string.Empty;
                        xlSheet.PageSetup.RightFooter = string.Empty;

                        AdjustQuotationShapes(xlSheet);
                    }
                    finally
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                    }
                }

                wb.ExportAsFixedFormat(
                    Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF,
                    pdfPath,
                    Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard,
                    true, false,
                    Type.Missing, Type.Missing,
                    false);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (wb != null) { try { wb.Close(false); } catch { } System.Runtime.InteropServices.Marshal.ReleaseComObject(wb); }
                if (excel != null) { try { excel.Quit(); } catch { } System.Runtime.InteropServices.Marshal.ReleaseComObject(excel); }
                try { if (File.Exists(tempExcel)) File.Delete(tempExcel); } catch { }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        // ─────────────────────────────────────────────────────────────
        //  WORKSHEET PREPARATION
        // ─────────────────────────────────────────────────────────────
        private void PrepareQuotationWorksheet(
        IXLWorksheet ws, List<QuoteItem> pageItems, QuotationTotals totals, bool isLastPage)
        {
            ClearQuotationWorksheetContent(ws);
            NormalizeQuotationTableLayout(ws);
            PopulateQuotationHeader(ws);
            PopulateQuotationItems(ws, pageItems);
            PopulateQuotationFooterBand(ws);          // ✅ ALWAYS on every page
            if (isLastPage)
                PopulateQuotationSummary(ws, totals); // only last page gets totals+terms
        }
        private void PopulateQuotationFooterBand(IXLWorksheet ws)
        {
            // The template's footer band (rows 50–61: company info, bank details,
            // signature box, bottom image strip) is static content that the template
            // already carries.  Because we only clear rows 1–49 in
            // ClearQuotationWorksheetContent, it is automatically preserved on
            // every copied page.  Nothing extra needs to be written here.
        }
        private void ClearQuotationWorksheetContent(IXLWorksheet ws)
        {
            // Header area
            foreach (string addr in new[] { "A5", "A6", "C6", "A8", "A9", "A10", "A11", "A12", "C8", "C9" })
                try { ws.Cell(addr).Clear(XLClearOptions.Contents); } catch { }

            // Item rows 14–43
            for (int r = 14; r <= 43; r++)
                for (int c = 1; c <= 7; c++)
                    try { ws.Cell(r, c).Clear(XLClearOptions.Contents); } catch { }

            // Summary/terms rows
            foreach (string addr in new[] { "D43", "G43", "D44", "G44", "D45", "G45", "A46", "A47", "A48", "A49" })
                try { ws.Cell(addr).Clear(XLClearOptions.Contents); } catch { }
        }
        private void NormalizeQuotationTableLayout(IXLWorksheet ws)
        {
            try
            {
                ws.Cell("A13").Value = "Sr.No";
                ws.Cell("B13").Value = "Particular";
                ws.Cell("D13").Value = "Quantity";
                ws.Cell("F13").Value = "Rate/Each";
                ws.Cell("G13").Value = "Total Amt.\n(Without GST)";

                ws.Row(13).Height = 24;
                ws.Range("A13:G13").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Range("A13:G13").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range("A13:G13").Style.Alignment.WrapText = true;
                ws.Range("A13:G13").Style.Font.Bold = true;
                ws.Cell("A13").Style.Font.FontSize = 9;
                ws.Cell("B13").Style.Font.FontSize = 9;
                ws.Cell("D13").Style.Font.FontSize = 9;
                ws.Cell("F13").Style.Font.FontSize = 8.5;
                ws.Cell("G13").Style.Font.FontSize = 7.5;

                // Rebuild only the two merged blocks used by the template:
                // B:C for Particular and D:E for Quantity.
                // Doing this explicitly keeps item details visible again
                // while removing the broken internal seam inside Quantity.
                for (int row = 14; row <= 41; row += 3)
                {
                    try { ws.Range(row, 2, row + 2, 3).Unmerge(); } catch { }
                    try { ws.Range(row, 4, row + 2, 5).Unmerge(); } catch { }

                    var particularRange = ws.Range(row, 2, row + 2, 3);
                    var qtyRange = ws.Range(row, 4, row + 2, 5);

                      try { particularRange.Merge(); } catch { }
                      try { qtyRange.Merge(); } catch { }

                      // Clear any leftover per-block borders from the template.
                      // We draw the continuous column lines later for the whole body.
              particularRange.Style.Border.LeftBorder = XLBorderStyleValues.None;
              particularRange.Style.Border.RightBorder = XLBorderStyleValues.None;
              particularRange.Style.Border.TopBorder = XLBorderStyleValues.None;
              particularRange.Style.Border.BottomBorder = XLBorderStyleValues.None;

              qtyRange.Style.Border.LeftBorder = XLBorderStyleValues.None;
              qtyRange.Style.Border.RightBorder = XLBorderStyleValues.None;
              qtyRange.Style.Border.TopBorder = XLBorderStyleValues.None;
              qtyRange.Style.Border.BottomBorder = XLBorderStyleValues.None;

                      particularRange.Style.Alignment.WrapText = true;
                      particularRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                      particularRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                    qtyRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    qtyRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                }

                ws.Range("A14:A41").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range("A14:A41").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                ws.Range("B14:C41").Style.Alignment.WrapText = true;
                ws.Range("B14:C41").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                ws.Range("B14:C41").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                ws.Range("D14:E41").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range("D14:E41").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                ws.Range("F14:F41").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                ws.Range("F14:F41").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                ws.Range("G14:G41").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                ws.Range("G14:G41").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                // Remove the template's repeated horizontal borders in the item body so
                // the middle area stays clean instead of showing a box per item block.
                ws.Range("A14:G41").Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range("A14:G41").Style.Border.BottomBorder = XLBorderStyleValues.None;

            // Re-apply only the vertical structure and the outside frame of the body.
            // Use continuous column-edge borders so later pages do not show broken
            // border stubs in the middle of the Quantity/Rate area.
            ws.Range("A14:A41").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("A14:A41").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("C14:C41").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("E14:E41").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("F14:F41").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("G14:G41").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            }
            catch { }
        }
        private void PopulateQuotationHeader(IXLWorksheet ws)
        {
            // Row 5 – Quotation number (centered across A:G)
            ws.Cell("A5").Value = "QUOTATION No.: " + NormalizePdfText(txtQuotationNo.Text);
            try { ws.Range("A5:G5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; } catch { }

            // Row 6 – Kind Attn (col A) + Date (col C area)
            ws.Cell("A6").Value = "Kind Attn.: " + NormalizePdfText(txtkindattname.Text);
            ws.Cell("C6").Value = "Date: " + dtQuotationDate.Value.ToString("dd-MM-yyyy");

            // Rows 8-11 – Billing address (max 4 lines in col A)
            var addrLines = BuildPdfAddressLines(
                "M/S. " + cmbselectcustomer.Text.Trim(),
                txtAddressLine1.Text, txtAddressLine2.Text,
                txtPinCode.Text, txtCity.Text, txtState.Text, 4);

            for (int i = 0; i < 4; i++)
                ws.Cell(8 + i, 1).Value = i < addrLines.Count ? addrLines[i] : string.Empty;

            // Row 12 – GST / PAN
            string gstLabel = !string.IsNullOrWhiteSpace(txtGSTno.Text) ? "GSTIN: " : "PAN: ";
            string gstVal = !string.IsNullOrWhiteSpace(txtGSTno.Text) ? txtGSTno.Text : txtPANNo.Text;
            ws.Cell("A12").Value = gstLabel + NormalizePdfText(gstVal);

            // Buyer's reference – col C area rows 8-9
            try { ws.Range("C8:G8").Merge(); } catch { }
            try { ws.Range("C9:G9").Merge(); } catch { }
            ws.Cell("C8").Value = "Buyer's Reference & Date :";
            ws.Cell("C9").Value = NormalizePdfText(txtBuyersreferenceanddate.Text);
            try
            {
                ws.Range("C8:G9").Style.Alignment.WrapText = true;
                ws.Range("C8:G9").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                ws.Cell("C8").Style.Font.Bold = true;
            }
            catch { }
        }

        // ─────────────────────────────────────────────────────────────
        //  ITEM ROWS (rows 14..41, step 3)
        //
        //  Template column mapping (confirmed from PDF):
        //    Col 1 (A)    = Sr.No     ← write here
        //    Col 2 (B)    = Particular (merged B:C in template)
        //    Col 4 (D)    = Qty       (merged D:E in template)
        //    Col 6 (F)    = Rate/Each
        //    Col 7 (G)    = Total Amt.
        //
        //  The "Quantity" column header in the template spans D:E.
        //  So Qty value must go to col D (index 4), NOT col 5.
        // ─────────────────────────────────────────────────────────────
        private void PopulateQuotationItems(IXLWorksheet ws, List<QuoteItem> pageItems)
        {
            const int StartRow = 14;
            const int RowStep = 3;
            const int MaxRow = 41;   // last valid start row (row 41 = slot 10)

            for (int index = 0; index < pageItems.Count; index++)
            {
                int row = StartRow + (index * RowStep);
                if (row > MaxRow) break;

                QuoteItem item = pageItems[index];

                // ── Sr No (col A) ──
                try
                {
                    ws.Cell(row, 1).Value = item.SrNo;
                    ws.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell(row, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                    ws.Cell(row, 1).Style.Font.Bold = false;
                    ws.Cell(row, 1).Style.Font.FontColor = XLColor.Black;
                }
                catch { }

                // ── Particular (col B – template merges B:C across 3 rows) ──
                BuildParticularCell(ws.Cell(row, 2), item);

                // ── Qty (col D – template merges D:E across 3 rows) ──
                try
                {
                    string qtyFormatted = FormatPdfNumber(item.Qty, allowInteger: true);
                    ws.Cell(row, 4).Value = qtyFormatted;
                    ws.Cell(row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell(row, 4).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(row, 4).Style.Font.FontColor = XLColor.Black;
                    ws.Cell(row, 4).Style.Font.Bold = false;
                }
                catch { }

                // ── Rate/Each (col F) ──
                try
                {
                    ws.Cell(row, 6).Value = FormatPdfNumber(item.Rate, allowInteger: false);
                    ws.Cell(row, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell(row, 6).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(row, 6).Style.Font.FontColor = XLColor.Black;
                    ws.Cell(row, 6).Style.Font.Bold = false;
                    ws.Cell(row, 6).Style.NumberFormat.Format = "#,##0.00";
                }
                catch { }

                // ── Total Amt. (col G) ──
                try
                {
                    ws.Cell(row, 7).Value = FormatPdfNumber(BuildSubtotalWithoutGST(item).ToString(), allowInteger: false);
                    ws.Cell(row, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell(row, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(row, 7).Style.Font.FontColor = XLColor.Black;
                    ws.Cell(row, 7).Style.Font.Bold = false;
                    ws.Cell(row, 7).Style.NumberFormat.Format = "#,##0.00";
                }
                catch { }
            }
        }
        private void BuildParticularCell(IXLCell cell, QuoteItem item)
        {
            string itemName = NormalizePdfText(item.ItemName);
            string itemDesc = NormalizePdfText(item.Desc);
            string modelHsn = BuildModelHsnText(item.ModelNo, item.HSN);
            string taxDesc = BuildPdfTaxDescriptor(item);

            try
            {
                cell.Clear(XLClearOptions.Contents);
                cell.Style.Alignment.WrapText = true;
                cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                cell.Style.Font.FontSize = 8.5;
                cell.Style.Font.FontColor = XLColor.Black;  // reset base colour
                cell.Style.Font.Bold = false;
            }
            catch { }

            try
            {
                var rt = cell.GetRichText();
                bool hasText = false;

                // Line 1: Item Name (bold black)
                if (!string.IsNullOrWhiteSpace(itemName))
                {
                    var t = rt.AddText(itemName);
                    t.SetBold(true);
                    t.SetFontColor(XLColor.Black);
                    hasText = true;
                }

                // Line 2: Description (normal black)
                if (!string.IsNullOrWhiteSpace(itemDesc))
                {
                    if (hasText) rt.AddText(Environment.NewLine).SetFontColor(XLColor.Black);
                    var t = rt.AddText(itemDesc);
                    t.SetBold(false);
                    t.SetFontColor(XLColor.Black);
                    hasText = true;
                }

                // Line 3: Model / HSN (normal black)  +  GST% (bold red, inline)
                bool hasModelHsn = !string.IsNullOrWhiteSpace(modelHsn);
                bool hasGst = !string.IsNullOrWhiteSpace(taxDesc);

                if (hasModelHsn || hasGst)
                {
                    if (hasText) rt.AddText(Environment.NewLine).SetFontColor(XLColor.Black);

                    if (hasModelHsn)
                    {
                        var t = rt.AddText(modelHsn);
                        t.SetBold(false);
                        t.SetFontColor(XLColor.Black);
                        hasText = true;
                    }

                    if (hasGst)
                    {
                        if (hasModelHsn)
                        {
                            rt.AddText("  |  ").SetFontColor(XLColor.Black);
                        }
                        var tg = rt.AddText(taxDesc);
                        tg.SetBold(true);
                        tg.SetFontColor(XLColor.Red);
                    }
                }
            }
            catch
            {
                // Fallback plain text (no rich text)
                try
                {
                    cell.Value = string.Join(Environment.NewLine,
                        new[] { itemName, itemDesc, modelHsn, taxDesc }
                            .Where(s => !string.IsNullOrWhiteSpace(s)));
                    cell.Style.Font.FontColor = XLColor.Black;
                }
                catch { }
            }
        }
        private void PopulateQuotationSummary(IXLWorksheet ws, QuotationTotals totals)
        {
            // The template has summary rows at 43-45.
            // Labels go in D (col 4), values in G (col 7).
            // The template already merges D:F for the label.

            if (UsesSplitGST())
            {
                SetSummaryRow(ws, 43, "CGST Total", totals.CGSTTotal);
                SetSummaryRow(ws, 44, "SGST Total", totals.SGSTTotal);
                SetSummaryRow(ws, 45, "Grand Total (Without GST)", totals.SubtotalWithoutGST);
            }
            else if (UsesIntegratedGST())
            {
                SetSummaryRow(ws, 44, "IGST Total", totals.IGSTTotal);
                SetSummaryRow(ws, 45, "Grand Total (Without GST)", totals.SubtotalWithoutGST);
            }
            else
            {
                SetSummaryRow(ws, 45, "Grand Total (Without GST)", totals.SubtotalWithoutGST);
            }

            // Terms (rows 46-49)
            ws.Cell("A46").Value = "** Validity: Quotation valid for " + NormalizePdfText(cmbValidity.Text);
            ws.Cell("A47").Value = "** Delivery Period : " + NormalizePdfText(txtDeliveryPeriod.Text);
            ws.Cell("A48").Value = "** Payment : " + NormalizePdfText(txtPaymentTerms.Text);
            ws.Cell("A49").Value = "** GST Extra As Applicable.";
            try
            {
                ws.Range("A46:G49").Style.Font.Bold = true;
                ws.Cell("A49").Style.Font.FontColor = XLColor.Red;
                ws.Range("A46:G48").Style.Font.FontColor = XLColor.Black;
            }
            catch { }
        }

        private void SetSummaryRow(IXLWorksheet ws, int rowNumber, string label, double value)
        {
            try
            {
                // Ensure D:F is merged for the label (template may already have it)
                try { ws.Range($"D{rowNumber}:F{rowNumber}").Merge(); } catch { }

                ws.Cell(rowNumber, 4).Value = label;
                ws.Cell(rowNumber, 7).Value = value;

                // Styling
                ws.Cell(rowNumber, 4).Style.Font.Bold = true;
                ws.Cell(rowNumber, 4).Style.Font.FontSize = rowNumber == 45 ? 8 : 9;
                ws.Cell(rowNumber, 4).Style.Font.FontColor = XLColor.Black;
                ws.Cell(rowNumber, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                ws.Cell(rowNumber, 4).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(rowNumber, 4).Style.Alignment.WrapText = true;

                ws.Cell(rowNumber, 7).Style.Font.Bold = true;
                ws.Cell(rowNumber, 7).Style.Font.FontSize = 9;
                ws.Cell(rowNumber, 7).Style.Font.FontColor = XLColor.Black;
                ws.Cell(rowNumber, 7).Style.NumberFormat.Format = "#,##0.00";
                ws.Cell(rowNumber, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                ws.Cell(rowNumber, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                // Apply border so row is visible
                var range = ws.Range($"D{rowNumber}:G{rowNumber}");
                range.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                range.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                range.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                range.Style.Border.RightBorder = XLBorderStyleValues.Thin;

                ws.Row(rowNumber).Height = rowNumber == 45 ? 17 : 15;
            }
            catch { }
        }


        // ─────────────────────────────────────────────────────────────
        //  PRINTABLE ITEMS / TOTALS
        // ─────────────────────────────────────────────────────────────
        private List<QuoteItem> GetPrintableQuotationItems()
        {
            var items = new List<QuoteItem>();
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow || !RowHasPrintableItemData(row)) continue;
                items.Add(new QuoteItem
                {
                    SrNo = (items.Count + 1).ToString(),
                    ItemName = Convert.ToString(row.Cells["ItemName"].Value) ?? string.Empty,
                    Desc = Convert.ToString(row.Cells["Description"].Value) ?? string.Empty,
                    ModelNo = Convert.ToString(row.Cells["ModelNo"].Value) ?? string.Empty,
                    HSN = Convert.ToString(row.Cells["HSN"].Value) ?? string.Empty,
                    Qty = Convert.ToString(row.Cells["Qty"].Value) ?? string.Empty,
                    Rate = Convert.ToString(row.Cells["Rate"].Value) ?? string.Empty,
                    GSTPct = Convert.ToString(row.Cells["GST"].Value) ?? string.Empty,
                    CGST = Convert.ToString(row.Cells["CGST"].Value) ?? string.Empty,
                    SGST = Convert.ToString(row.Cells["SGST"].Value) ?? string.Empty,
                    Total = Convert.ToString(row.Cells["Total"].Value) ?? string.Empty
                });
            }
            return items;
        }

        private QuotationTotals CalculatePrintableTotals(List<QuoteItem> items)
        {
            double subtotal = 0d, cgst = 0d, sgst = 0d, igst = 0d;
            foreach (QuoteItem item in items)
            {
                double s = ParseDouble(item.Total);
                double qty = ParseDouble(item.Qty);
                double gst = ParseDouble(item.GSTPct);
                subtotal += s;
                if (UsesSplitGST()) { cgst += ParseDouble(item.CGST) * qty; sgst += ParseDouble(item.SGST) * qty; }
                else if (UsesIntegratedGST()) { igst += s * gst / 100d; }
            }
            return new QuotationTotals(subtotal, cgst, sgst, igst);
        }

        private bool RowHasPrintableItemData(DataGridViewRow row)
        {
            foreach (string col in new[] { "ItemName", "Description", "ModelNo", "HSN", "Qty", "Rate", "GST" })
            {
                if (!string.IsNullOrWhiteSpace(Convert.ToString(row.Cells[col].Value)))
                    return true;
            }
            return false;
        }

        // ─────────────────────────────────────────────────────────────
        //  PDF TEXT / NUMBER HELPERS
        // ─────────────────────────────────────────────────────────────
        private List<string> BuildPdfAddressLines(string companyLine, string line1, string line2,
            string pinCode, string city, string state, int maxLines)
        {
            var raw = new List<string>();
            if (!string.IsNullOrWhiteSpace(companyLine)) raw.Add(companyLine.Trim());
            if (!string.IsNullOrWhiteSpace(line1)) raw.Add(line1.Trim());
            if (!string.IsNullOrWhiteSpace(line2)) raw.Add(line2.Trim());
            if (!string.IsNullOrWhiteSpace(pinCode)) raw.Add(pinCode.Trim());
            string cs = string.Empty;
            if (!string.IsNullOrWhiteSpace(city)) cs = city.Trim();
            if (!string.IsNullOrWhiteSpace(state)) cs = string.IsNullOrWhiteSpace(cs) ? state.Trim() : cs + ", " + state.Trim();
            if (!string.IsNullOrWhiteSpace(cs)) raw.Add(cs);

            var final = new List<string>();
            foreach (string rl in raw)
                foreach (string sl in SplitPdfLine(rl, 42))
                {
                    if (final.Count >= maxLines) return final;
                    final.Add(sl);
                }
            return final;
        }


        private IEnumerable<string> SplitPdfLine(string input, int maxLength)
        {
            string rem = NormalizePdfText(input);
            if (string.IsNullOrWhiteSpace(rem)) yield break;
            while (rem.Length > maxLength)
            {
                int idx = rem.LastIndexOfAny(new[] { ',', ' ', '-' }, maxLength);
                if (idx <= 0) idx = maxLength;
                yield return rem[..idx].Trim(' ', ',');
                rem = rem[idx..].Trim(' ', ',');
            }
            if (!string.IsNullOrWhiteSpace(rem)) yield return rem;
        }

        private string BuildModelHsnText(string modelNo, string hsn)
        {
            string m = string.IsNullOrWhiteSpace(modelNo) ? string.Empty : "Model: " + NormalizePdfText(modelNo);
            string h = string.IsNullOrWhiteSpace(hsn) ? string.Empty : "HSN/SAC: " + NormalizePdfText(hsn);
            if (!string.IsNullOrWhiteSpace(m) && !string.IsNullOrWhiteSpace(h)) return m + "  |  " + h;
            return !string.IsNullOrWhiteSpace(m) ? m : h;
        }

        private string BuildPdfTaxDescriptor(QuoteItem item)
        {
            if (!IsWithGST() || string.IsNullOrWhiteSpace(item.GSTPct)) return string.Empty;
            string label = UsesIntegratedGST() ? "IGST" : "GST";
            return label + " : " + NormalizePdfText(item.GSTPct) + "%";
        }

        private string NormalizePdfText(string value) =>
            (value ?? string.Empty).Replace("\r", " ").Replace("\n", " ").Trim();

 

        private string FormatPdfNumber(string value, bool allowInteger)
        {
            double p = ParseDouble(value);
            if (allowInteger && Math.Abs(p % 1) < 0.0001d) return p.ToString("0");
            return p.ToString("#,##0.00");
        }

        private double ParseDouble(string value)
        {
            double.TryParse(value, out double p);
            return p;
        }
        private double BuildSubtotalWithoutGST(QuoteItem item)
        {
            double qty = ParseDouble(item.Qty);
            double rate = ParseDouble(item.Rate);
            return qty * rate;
        }
        // ─────────────────────────────────────────────────────────────
        //  SHAPE ALIGNMENT (header/footer images in Excel template)
        // ─────────────────────────────────────────────────────────────
        private void AdjustQuotationShapes(Microsoft.Office.Interop.Excel.Worksheet xlSheet)
        {
            dynamic? shapes = null;
            dynamic? mainRange = null;
            try
            {
                mainRange = xlSheet.Range["A1:G61"];
                double mainLeft = (double)mainRange.Left;
                double mainWidth = (double)mainRange.Width;
                double mainRight = mainLeft + mainWidth;

                shapes = xlSheet.Shapes;

                TryStretchShapeToWidth(shapes, "Picture 3", mainLeft, mainWidth);
                TryStretchShapeToWidth(shapes, "Picture 4", mainLeft, mainWidth);
                TryAlignPillToRight(shapes, "TextBox 5", mainRight);
            }
            catch { }
            finally
            {
                if (mainRange != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(mainRange);
                if (shapes != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(shapes);
            }
        }

        private void TryStretchShapeToWidth(dynamic shapes, string shapeName, double left, double width)
        {
            dynamic? shape = null;
            try
            {
                shape = shapes.Item(shapeName);
                shape.Left = left;
                shape.Width = width;
            }
            catch { }
            finally
            {
                if (shape != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(shape);
            }
        }

        private void TryAlignPillToRight(dynamic shapes, string shapeName, double rightEdge)
        {
            dynamic? shape = null;
            try
            {
                shape = shapes.Item(shapeName);
                double pillWidth = 118d;
                shape.Width = pillWidth;
                shape.Left = rightEdge - pillWidth;
                try
                {
                    shape.TextFrame.Characters().Text = "QUOTATION";
                    shape.TextFrame.HorizontalAlignment =
                        Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    shape.TextFrame.Characters().Font.Size = 11f;
                    shape.TextFrame.Characters().Font.Color =
                        ColorTranslator.ToOle(System.Drawing.Color.White);
                }
                catch { }
            }
            catch { }
            finally
            {
                if (shape != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(shape);
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  DATA MODELS
        // ─────────────────────────────────────────────────────────────
        private class QuoteItem
        {
            public string SrNo { get; set; } = "";
            public string ItemName { get; set; } = "";
            public string Desc { get; set; } = "";
            public string ModelNo { get; set; } = "";
            public string HSN { get; set; } = "";
            public string Qty { get; set; } = "";
            public string Rate { get; set; } = "";
            public string GSTPct { get; set; } = "";
            public string CGST { get; set; } = "";
            public string SGST { get; set; } = "";
            public string Total { get; set; } = "";
        }

        private sealed record QuoteTaxBreakdown(
            double Subtotal, double TotalTax,
            double CGSTPerQty, double SGSTPerQty,
            double CGSTTotal, double SGSTTotal, double IGSTTotal);

        private sealed record QuotationTotals(
            double SubtotalWithoutGST, double CGSTTotal, double SGSTTotal, double IGSTTotal);

        private sealed class QuotationSnapshot
        {
            public string QuotationNo { get; set; } = "";
            public DateTime QuotationDate { get; set; }
            public string CustomerName { get; set; } = "";
            public string GSTType { get; set; } = "";
            public bool IsGSTSelected { get; set; }
            public string GSTNo { get; set; } = "";
            public string PANNo { get; set; } = "";
            public string KindAttentionName { get; set; } = "";
            public string BuyersReference { get; set; } = "";
            public string BillingAddressLine1 { get; set; } = "";
            public string BillingAddressLine2 { get; set; } = "";
            public string BillingPinCode { get; set; } = "";
            public string BillingCity { get; set; } = "";
            public string BillingState { get; set; } = "";
            public string ShippingAddressLine1 { get; set; } = "";
            public string ShippingAddressLine2 { get; set; } = "";
            public string ShippingPinCode { get; set; } = "";
            public string ShippingCity { get; set; } = "";
            public string ShippingState { get; set; } = "";
            public string Validity { get; set; } = "";
            public string DeliveryPeriod { get; set; } = "";
            public string PaymentTerms { get; set; } = "";
            public List<QuoteItem> Items { get; set; } = new List<QuoteItem>();
        }

        private sealed record SalesQuotationDetailColumnInfo(
            string Name, string DataType, int? NumericPrecision, int? NumericScale);
    }
}
