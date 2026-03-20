using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class Salesquotes : Form
    {
        private const int SEARCH_GAP = 4;

        public Salesquotes()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private void salesquotes_Load(object sender, EventArgs e)
        {
            SetupGrid();
        }

        // ================= GRID SETUP ONLY =================
        private void SetupGrid()
        {
            dgvSalesQuotation.Columns.Clear();
            dgvSalesQuotation.Rows.Clear();

            dgvSalesQuotation.AutoGenerateColumns = false;

            // ===== STYLE SAME AS ALL MATERIAL =====
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

            // ===== CHECKBOX COLUMN =====
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn
            {
                Name = "SelectRow",
                HeaderText = "☑",
                Width = 30,
                FillWeight = 8
            };
            dgvSalesQuotation.Columns.Add(chk);

            // ===== HIDDEN ID =====
            dgvSalesQuotation.Columns.Add("Quotation_ID", "ID");
            dgvSalesQuotation.Columns["Quotation_ID"].Visible = false;

            // ===== MAIN COLUMNS =====
            dgvSalesQuotation.Columns.Add("SrNo", "Sr No");
            dgvSalesQuotation.Columns.Add("QuotationNo", "Quotation No");
            dgvSalesQuotation.Columns.Add("Status", "Status");
            dgvSalesQuotation.Columns.Add("CustomerName", "Customer Name");
            dgvSalesQuotation.Columns.Add("PDF", "PDF");

            // ===== READ ONLY =====
            foreach (DataGridViewColumn col in dgvSalesQuotation.Columns)
            {
                if (col.Name != "SelectRow")
                    col.ReadOnly = true;
            }
            // ===== FILL WEIGHT SET =====

            // Checkbox small
            dgvSalesQuotation.Columns["SelectRow"].FillWeight = 5;

            // Sr No small
            dgvSalesQuotation.Columns["SrNo"].FillWeight = 5;

            // Quotation No medium
            dgvSalesQuotation.Columns["QuotationNo"].FillWeight = 25;

            // Status medium small
            dgvSalesQuotation.Columns["Status"].FillWeight = 10;

            // Customer Name big
            dgvSalesQuotation.Columns["CustomerName"].FillWeight = 25;

            // PDF medium
            dgvSalesQuotation.Columns["PDF"].FillWeight = 5;
            SyncSearchBoxesWithGrid();

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

        // ================= CHECKBOX CLICK =================
        private void dgvSalesQuotation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvSalesQuotation.Columns[e.ColumnIndex].Name != "SelectRow")
                return;

            var cell = dgvSalesQuotation.Rows[e.RowIndex].Cells["SelectRow"];

            bool current = cell.Value != null && (bool)cell.Value;
            cell.Value = !current;
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
            if (this.Parent is Panel parentPanel)
            {
                // Remove current form
                parentPanel.Controls.Remove(this);

                // Open new form
                SalesQuote2ndpage frm = new SalesQuote2ndpage();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;

                parentPanel.Controls.Add(frm);
                frm.Show();
            }
        }

    }
}
