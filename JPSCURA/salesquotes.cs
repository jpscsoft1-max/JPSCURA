using System;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class Salesquotes : Form
    {
        private const int SEARCH_GAP = 4;
        private readonly List<SalesQuotationListItem> quotationItems = new();

        public Salesquotes()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void salesquotes_Load(object sender, EventArgs e)
        {
            SetupGrid();
            WireSearchEvents();
            LoadSalesQuotations();
            btnModify.Click -= btnModify_Click;
            btnModify.Click += btnModify_Click;
            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;
            dgvSalesQuotation.SelectionChanged -= dgvSalesQuotation_SelectionChanged;
            dgvSalesQuotation.SelectionChanged += dgvSalesQuotation_SelectionChanged;
            UpdateDeleteButtonState();
        }

        // ================= GRID SETUP =================
        private void SetupGrid()
        {
            dgvSalesQuotation.Columns.Clear();
            dgvSalesQuotation.Rows.Clear();

            dgvSalesQuotation.AutoGenerateColumns = false;
            dgvSalesQuotation.BackgroundColor = Color.White;
            dgvSalesQuotation.GridColor = Color.White;
            dgvSalesQuotation.RowHeadersVisible = false;
            dgvSalesQuotation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesQuotation.EnableHeadersVisualStyles = false;

            dgvSalesQuotation.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvSalesQuotation.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvSalesQuotation.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgvSalesQuotation.DefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Regular);

            dgvSalesQuotation.DefaultCellStyle.BackColor = Color.White;
            dgvSalesQuotation.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvSalesQuotation.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvSalesQuotation.AllowUserToResizeColumns = false;
            dgvSalesQuotation.AllowUserToResizeRows = false;
            dgvSalesQuotation.AllowUserToAddRows = false;

            dgvSalesQuotation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalesQuotation.MultiSelect = false;
            dgvSalesQuotation.EditMode = DataGridViewEditMode.EditProgrammatically;

            ApplyGridLines();

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn
            {
                Name = "SelectRow",
                HeaderText = "☑",
                Width = 30,
                FillWeight = 5
            };
            dgvSalesQuotation.Columns.Add(chk);

            dgvSalesQuotation.Columns.Add("Quotation_ID", "ID");
            dgvSalesQuotation.Columns["Quotation_ID"].Visible = false;

            dgvSalesQuotation.Columns.Add("CustId", "Cust ID");
            dgvSalesQuotation.Columns["CustId"].Visible = false;

            dgvSalesQuotation.Columns.Add("PdfPath", "Pdf Path");
            dgvSalesQuotation.Columns["PdfPath"].Visible = false;

            dgvSalesQuotation.Columns.Add("SrNo", "Sr No");
            dgvSalesQuotation.Columns.Add("QuotationNo", "Quotation No");
            dgvSalesQuotation.Columns.Add("Status", "Status");
            dgvSalesQuotation.Columns.Add("CustomerName", "Customer Name");

            DataGridViewLinkColumn pdfColumn = new DataGridViewLinkColumn
            {
                Name = "PDF",
                HeaderText = "PDF",
                TrackVisitedState = false,
                LinkBehavior = LinkBehavior.HoverUnderline,
                LinkColor = Color.Black,
                ActiveLinkColor = Color.Black,
                VisitedLinkColor = Color.Black
            };
            dgvSalesQuotation.Columns.Add(pdfColumn);

            foreach (DataGridViewColumn col in dgvSalesQuotation.Columns)
            {
                if (col.Name != "SelectRow")
                    col.ReadOnly = true;
            }

            dgvSalesQuotation.Columns["SrNo"].FillWeight = 6;
            dgvSalesQuotation.Columns["QuotationNo"].FillWeight = 32;
            dgvSalesQuotation.Columns["Status"].FillWeight = 14;
            dgvSalesQuotation.Columns["CustomerName"].FillWeight = 32;
            dgvSalesQuotation.Columns["PDF"].FillWeight = 10;

            SyncSearchBoxesWithGrid();
        }

        // ================= DATA LOAD =================
        private void LoadSalesQuotations()
        {
            try
            {
                quotationItems.Clear();

                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                using SqlCommand cmd = new SqlCommand(
                    @"SELECT SalesQuotationId, SalesQuotationNo, Cust_Id, PdfPath, Status
                      FROM SALES_MASTER.dbo.SalesQuotations
                      ORDER BY SalesQuotationId DESC", con);

                con.Open();
                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int? customerId = null;
                    if (dr["Cust_Id"] != DBNull.Value && int.TryParse(dr["Cust_Id"].ToString(), out int parsedCustomerId))
                        customerId = parsedCustomerId;

                    quotationItems.Add(new SalesQuotationListItem
                    {
                        SalesQuotationId = Convert.ToInt32(dr["SalesQuotationId"]),
                        QuotationNo = dr["SalesQuotationNo"]?.ToString() ?? string.Empty,
                        Status = dr["Status"]?.ToString() ?? "Saved",
                        CustomerId = customerId,
                        CustomerName = GetCustomerNameById(customerId),
                        PdfPath = dr["PdfPath"]?.ToString() ?? string.Empty
                    });
                }

                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sales quotation load error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCustomerNameById(int? customerId)
        {
            if (!customerId.HasValue)
                return string.Empty;

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
                            $@"SELECT TOP 1 Cust_Name
                               FROM SALES_MASTER.dbo.Customers
                               WHERE [{columnName}] = @customerId", con);
                        cmd.Parameters.AddWithValue("@customerId", customerId.Value);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            return result.ToString() ?? string.Empty;
                    }
                    catch (SqlException ex) when (ex.Message.IndexOf("Invalid column name", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        continue;
                    }
                }
            }
            catch { }

            return string.Empty;
        }

        private void ApplyFilters()
        {
            try
            {
                string quotationNoSearch = txtSearchQuotationNo.Text.Trim();
                string statusSearch = txtSearchStatus.Text.Trim();
                string customerSearch = txtSerachCustomerName.Text.Trim();

                IEnumerable<SalesQuotationListItem> filteredItems = quotationItems.Where(item =>
                    (string.IsNullOrWhiteSpace(quotationNoSearch) || item.QuotationNo.Contains(quotationNoSearch, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrWhiteSpace(statusSearch) || item.Status.Contains(statusSearch, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrWhiteSpace(customerSearch) || item.CustomerName.Contains(customerSearch, StringComparison.OrdinalIgnoreCase)));

                PopulateGrid(filteredItems);
            }
            catch { }
        }

        private void PopulateGrid(IEnumerable<SalesQuotationListItem> items)
        {
            dgvSalesQuotation.Rows.Clear();

            int srNo = 1;
            foreach (SalesQuotationListItem item in items)
            {
                bool canView = item.Status.Equals("Generated", StringComparison.OrdinalIgnoreCase);

                int rowIndex = dgvSalesQuotation.Rows.Add(
                    false,
                    item.SalesQuotationId,
                    item.CustomerId?.ToString() ?? string.Empty,
                    item.PdfPath,
                    srNo++,
                    item.QuotationNo,
                    item.Status,
                    item.CustomerName,
                    canView ? "View" : string.Empty);

                StyleQuotationRow(dgvSalesQuotation.Rows[rowIndex], item.Status, canView);
            }

            UpdateDeleteButtonState();
        }

        private void StyleQuotationRow(DataGridViewRow row, string status, bool canView)
        {
            Color backgroundColor = Color.White;

            if (status.Equals("Saved", StringComparison.OrdinalIgnoreCase))
                backgroundColor = Color.LightYellow;
            else if (status.Equals("Generated", StringComparison.OrdinalIgnoreCase))
                backgroundColor = Color.LightGreen;

            row.DefaultCellStyle.BackColor = backgroundColor;
            row.DefaultCellStyle.SelectionBackColor = backgroundColor;
            row.DefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewCell pdfCell = row.Cells["PDF"];
            pdfCell.Style.BackColor = Color.White;
            pdfCell.Style.SelectionBackColor = Color.White;
            pdfCell.Style.ForeColor = Color.Black;
            pdfCell.Style.SelectionForeColor = Color.Black;
            pdfCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (!canView)
                pdfCell.Value = string.Empty;
        }

        // ================= GRID LINE STYLE =================
        private void ApplyGridLines()
        {
            dgvSalesQuotation.BorderStyle = BorderStyle.FixedSingle;
            dgvSalesQuotation.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvSalesQuotation.GridColor = Color.LightGray;

            dgvSalesQuotation.EnableHeadersVisualStyles = false;
            dgvSalesQuotation.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        }

        // ================= EVENTS =================
        private void WireSearchEvents()
        {
            txtSearchQuotationNo.TextChanged -= SearchTextChanged;
            txtSearchStatus.TextChanged -= SearchTextChanged;
            txtSerachCustomerName.TextChanged -= SearchTextChanged;

            txtSearchQuotationNo.TextChanged += SearchTextChanged;
            txtSearchStatus.TextChanged += SearchTextChanged;
            txtSerachCustomerName.TextChanged += SearchTextChanged;
        }

        private void SearchTextChanged(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvSalesQuotation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName = dgvSalesQuotation.Columns[e.ColumnIndex].Name;

            if (columnName == "SelectRow")
            {
                var cell = dgvSalesQuotation.Rows[e.RowIndex].Cells["SelectRow"];
                bool current = cell.Value != null && (bool)cell.Value;
                cell.Value = !current;
                UpdateDeleteButtonState();
                return;
            }

            if (columnName == "PDF")
            {
                string pdfPath = dgvSalesQuotation.Rows[e.RowIndex].Cells["PdfPath"].Value?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(pdfPath))
                    return;

                if (!File.Exists(pdfPath))
                {
                    MessageBox.Show("Saved PDF file was not found.", "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }

            UpdateDeleteButtonState();
        }

        private void dgvSalesQuotation_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSalesQuotation.IsCurrentCellDirty)
                dgvSalesQuotation.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        private void SyncSearchBoxesWithGrid()
        {
            if (dgvSalesQuotation.Columns.Count == 0) return;

            SetSearchBox(txtSearchQuotationNo, "QuotationNo");
            SetSearchBox(txtSearchStatus, "Status");
            SetSearchBox(txtSerachCustomerName, "CustomerName");
        }
        private void SetSearchBox(TextBox txt, string columnName)
        {
            if (!dgvSalesQuotation.Columns.Contains(columnName)) return;

            Rectangle rect = dgvSalesQuotation.GetColumnDisplayRectangle(
                dgvSalesQuotation.Columns[columnName].Index,
                true
            );

            txt.Left = rect.Left + dgvSalesQuotation.Left + (SEARCH_GAP / 2);
            txt.Width = rect.Width - SEARCH_GAP;
        }
        private void salesquotes_Resize(object sender, EventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }
        private void dgvSalesQuotation_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }
        private void dgvSalesQuotation_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                SyncSearchBoxesWithGrid();
        }
        private void btnADD_Click(object sender, EventArgs e)
        {
            if (Parent is Panel parentPanel)
            {
                parentPanel.Controls.Remove(this);

                SalesQuote2ndpage frm = new SalesQuote2ndpage
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                parentPanel.Controls.Add(frm);
                frm.Show();
            }
        }

        private void btnModify_Click(object? sender, EventArgs e)
        {
            DataGridViewRow? selectedRow = GetSelectedQuotationRow();
            if (selectedRow == null)
            {
                MessageBox.Show("Please select one quotation to modify.", "Modify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string quotationNo = selectedRow.Cells["QuotationNo"].Value?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(quotationNo))
            {
                MessageBox.Show("Selected quotation number is missing.", "Modify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Parent is Panel parentPanel)
            {
                parentPanel.Controls.Remove(this);

                SalesQuote2ndpage frm = new SalesQuote2ndpage(quotationNo)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                parentPanel.Controls.Add(frm);
                frm.Show();
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = GetSelectedQuotationRows();
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one quotation to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                selectedRows.Count == 1
                    ? "Are you sure you want to delete this quotation?"
                    : "Are you sure you want to delete these quotations?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                con.Open();
                using SqlTransaction transaction = con.BeginTransaction();

                foreach (DataGridViewRow selectedRow in selectedRows)
                {
                    if (!int.TryParse(selectedRow.Cells["Quotation_ID"].Value?.ToString(), out int salesQuotationId))
                        continue;

                    string quotationNo = selectedRow.Cells["QuotationNo"].Value?.ToString() ?? string.Empty;

                    using SqlCommand detailsCmd = new SqlCommand(
                        @"DELETE FROM SALES_MASTER.dbo.SalesQuotationDetails
                          WHERE SalesQuotationId = @salesQuotationId", con, transaction);
                    detailsCmd.Parameters.AddWithValue("@salesQuotationId", salesQuotationId);
                    detailsCmd.ExecuteNonQuery();

                    using SqlCommand quotationCmd = new SqlCommand(
                        @"DELETE FROM SALES_MASTER.dbo.SalesQuotations
                          WHERE SalesQuotationId = @salesQuotationId", con, transaction);
                    quotationCmd.Parameters.AddWithValue("@salesQuotationId", salesQuotationId);
                    quotationCmd.ExecuteNonQuery();

                    DeleteQuotationDraftFile(quotationNo);
                }

                transaction.Commit();
                LoadSalesQuotations();

                MessageBox.Show(
                    selectedRows.Count == 1
                        ? "Quotation deleted successfully."
                        : "Selected quotations deleted successfully.",
                    "Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<DataGridViewRow> GetSelectedQuotationRows()
        {
            List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgvSalesQuotation.Rows)
            {
                bool isChecked = row.Cells["SelectRow"].Value != null && (bool)row.Cells["SelectRow"].Value;
                if (isChecked)
                    selectedRows.Add(row);
            }

            if (selectedRows.Count == 0 && dgvSalesQuotation.CurrentRow != null)
                selectedRows.Add(dgvSalesQuotation.CurrentRow);

            return selectedRows;
        }

        private DataGridViewRow? GetSelectedQuotationRow()
        {
            foreach (DataGridViewRow row in dgvSalesQuotation.Rows)
            {
                bool isChecked = row.Cells["SelectRow"].Value != null && (bool)row.Cells["SelectRow"].Value;
                if (isChecked)
                    return row;
            }

            return dgvSalesQuotation.CurrentRow;
        }

        private void dgvSalesQuotation_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateDeleteButtonState();
        }

        private void UpdateDeleteButtonState()
        {
            btnDelete.Enabled = GetSelectedQuotationRow() != null && dgvSalesQuotation.Rows.Count > 0;
        }

        private void DeleteQuotationDraftFile(string quotationNo)
        {
            if (string.IsNullOrWhiteSpace(quotationNo))
                return;

            char[] invalidChars = Path.GetInvalidFileNameChars();
            string safeFileName = new string(quotationNo.Select(ch => invalidChars.Contains(ch) ? '_' : ch).ToArray());
            string draftFilePath = Path.Combine(Application.StartupPath, "QuotationDrafts", safeFileName + ".json");

            if (File.Exists(draftFilePath))
                File.Delete(draftFilePath);
        }

        private sealed class SalesQuotationListItem
        {
            public int SalesQuotationId { get; set; }
            public string QuotationNo { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
            public int? CustomerId { get; set; }
            public string CustomerName { get; set; } = string.Empty;
            public string PdfPath { get; set; } = string.Empty;
        }
    }
}
