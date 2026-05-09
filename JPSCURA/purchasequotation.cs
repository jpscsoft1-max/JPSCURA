using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace JPSCURA
{
    public partial class purchasequotation : Form
    {
        string selectedFilePath = "";
        private const int SEARCH_GAP = 4;

        public purchasequotation()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void purchasequotation_Load(object sender, EventArgs e)
        {
            SetupGridUI();
            LoadVendorDropdown();
            LoadGrid();

            txtFileName.ReadOnly = true;
            txtFileName.TabStop = false;
            txtFileName.Cursor = Cursors.Default;
            cmbVendorName.DropDownStyle = ComboBoxStyle.DropDownList;

            txtFileName.GotFocus += (s, e) =>
            {
                this.ActiveControl = btnAttach; 
            };

            txtSearchQuotationNo.TextChanged += (s, ev) => ApplySearch();
            txtSearchQuotationDate.TextChanged += (s, ev) => ApplySearch();
            txtSearchVendors.TextChanged += (s, ev) => ApplySearch();

            this.Shown += (s, ev) => SyncSearchBoxes();
            this.Shown += (s, e) => CenterControlsInPanel();
        }

        // ================= VENDOR DROPDOWN =================
        private void LoadVendorDropdown()
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());

            SqlDataAdapter da = new SqlDataAdapter(@"
SELECT Vendor_Id, Vendor_Name 
FROM PURCHASE_MASTER.dbo.Vendors 
ORDER BY Vendor_Name", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            // 🔥 Add default option
            DataRow dr = dt.NewRow();
            dr["Vendor_Id"] = 0;
            dr["Vendor_Name"] = "Select Vendor ";
            dt.Rows.InsertAt(dr, 0);

            cmbVendorName.DataSource = dt;
            cmbVendorName.DisplayMember = "Vendor_Name";
            cmbVendorName.ValueMember = "Vendor_Id";

            cmbVendorName.SelectedIndex = 0;

            // 🔥 Important
            cmbVendorName.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        // ================= GRID DESIGN =================
        private void SetupGridUI()
        {
            dgvPurchaseQuotation.BackgroundColor = Color.White;
            dgvPurchaseQuotation.BorderStyle = BorderStyle.FixedSingle;
            dgvPurchaseQuotation.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPurchaseQuotation.GridColor = Color.LightGray;

            dgvPurchaseQuotation.RowHeadersVisible = false;
            dgvPurchaseQuotation.EnableHeadersVisualStyles = false;

            dgvPurchaseQuotation.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPurchaseQuotation.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvPurchaseQuotation.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPurchaseQuotation.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvPurchaseQuotation.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvPurchaseQuotation.DefaultCellStyle.BackColor = Color.White;
            dgvPurchaseQuotation.DefaultCellStyle.ForeColor = Color.Black;
            dgvPurchaseQuotation.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPurchaseQuotation.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvPurchaseQuotation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPurchaseQuotation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPurchaseQuotation.AllowUserToAddRows = false;
            dgvPurchaseQuotation.ReadOnly = true;
            dgvPurchaseQuotation.AllowUserToResizeColumns = false;
            dgvPurchaseQuotation.AllowUserToResizeRows = false;
            dgvPurchaseQuotation.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        // ================= LOAD GRID =================
        private void LoadGrid()
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());

            SqlDataAdapter da = new SqlDataAdapter(@"
SELECT 
    pq.PurchaseQuotationId,
    pq.QuotationNo   AS [Quotation No],
    pq.QuotationDate AS [Date],
    v.Vendor_Name    AS [Vendor Name],
    pq.QuotationFilePath
FROM PURCHASE_MASTER.dbo.PurchaseQuotations pq
LEFT JOIN PURCHASE_MASTER.dbo.Vendors v 
    ON pq.VendorId = v.Vendor_Id
ORDER BY pq.PurchaseQuotationId DESC", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            // SrNo DataTable mein add karo
            dt.Columns.Add("SrNo", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["SrNo"] = i + 1;

            dgvPurchaseQuotation.DataSource = dt;

            // View button column add karo (ek baar)
            if (!dgvPurchaseQuotation.Columns.Contains("View"))
            {
                dgvPurchaseQuotation.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "View",
                    HeaderText = "File",
                    Text = "View",
                    UseColumnTextForButtonValue = true,
                    FillWeight = 15
                });
            }

            // Hidden columns
            dgvPurchaseQuotation.Columns["PurchaseQuotationId"].Visible = false;
            dgvPurchaseQuotation.Columns["QuotationFilePath"].Visible = false;

            // Column header text
            dgvPurchaseQuotation.Columns["SrNo"].HeaderText = "Sr No";

            // FillWeight
            dgvPurchaseQuotation.Columns["SrNo"].FillWeight = 5;
            dgvPurchaseQuotation.Columns["Quotation No"].FillWeight = 25;
            dgvPurchaseQuotation.Columns["Date"].FillWeight = 20;
            dgvPurchaseQuotation.Columns["Vendor Name"].FillWeight = 35;
            dgvPurchaseQuotation.Columns["View"].FillWeight = 15;
            ApplyColumnOrder();

            SyncSearchBoxes();
            dgvPurchaseQuotation.DataBindingComplete += (s, e) => ApplyColumnOrder();
        }

        
        private void ApplyColumnOrder()
        {
            

            dgvPurchaseQuotation.Columns["SrNo"].DisplayIndex = 0;
            dgvPurchaseQuotation.Columns["Quotation No"].DisplayIndex = 1;
            dgvPurchaseQuotation.Columns["Date"].DisplayIndex = 2;
            dgvPurchaseQuotation.Columns["Vendor Name"].DisplayIndex = 3;

            dgvPurchaseQuotation.Columns["View"].DisplayIndex =
                dgvPurchaseQuotation.Columns.Count - 1; 
        }

        // ================= ATTACH FILE =================
        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "PDF Files (*.pdf)|*.pdf" };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = ofd.FileName;
                txtFileName.Text = Path.GetFileName(selectedFilePath);
            }
        }

        // ================= SUBMIT =================
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dtQuotationDate.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Please enter valid date", "Invalid Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuotationNo.Text))
            {
                MessageBox.Show("Please enter Quotation No.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbVendorName.SelectedValue == null || Convert.ToInt32(cmbVendorName.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a Vendor.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please attach a PDF file.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vendorId = Convert.ToInt32(cmbVendorName.SelectedValue);

            string folderPath = Path.Combine(Application.StartupPath, "Uploads", "Quotations");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string newFileName = Guid.NewGuid() + Path.GetExtension(selectedFilePath);
            string destinationPath = Path.Combine(folderPath, newFileName);
            string relativePath = Path.Combine("Uploads", "Quotations", newFileName);

            File.Copy(selectedFilePath, destinationPath, true);

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());

            SqlCommand cmd = new SqlCommand(@"
INSERT INTO PURCHASE_MASTER.dbo.PurchaseQuotations
    (QuotationNo, QuotationDate, VendorId, QuotationFilePath)
VALUES
    (@no, @date, @vendor, @path)", con);

            cmd.Parameters.AddWithValue("@no", txtQuotationNo.Text.Trim());
            cmd.Parameters.AddWithValue("@date", dtQuotationDate.Value);
            cmd.Parameters.AddWithValue("@vendor", vendorId);
            cmd.Parameters.AddWithValue("@path", relativePath);

            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved..!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadGrid();
        }

        // ================= View =================
        private void dgvPurchaseQuotation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPurchaseQuotation.Columns[e.ColumnIndex].Name == "View")
            {
                string relativePath = dgvPurchaseQuotation.Rows[e.RowIndex]
                    .Cells["QuotationFilePath"].Value?.ToString();

                if (string.IsNullOrEmpty(relativePath))
                {
                    MessageBox.Show("No file attached.");
                    return;
                }

                string fullPath = Path.Combine(Application.StartupPath, relativePath);

                if (File.Exists(fullPath))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = fullPath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("File not found on disk.");
                }
            }
        }

        // ================= SEARCH =================
        private void ApplySearch()
        {
            string q = txtSearchQuotationNo.Text.ToLower();
            string d = txtSearchQuotationDate.Text.ToLower();
            string v = txtSearchVendors.Text.ToLower();

            // 🔥 Selection hatao pehle (IMPORTANT)
            dgvPurchaseQuotation.ClearSelection();
            dgvPurchaseQuotation.CurrentCell = null;

            foreach (DataGridViewRow row in dgvPurchaseQuotation.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                if (!string.IsNullOrEmpty(q))
                    visible &= row.Cells["Quotation No"].Value?.ToString()
                        .ToLower().Contains(q) == true;

                if (!string.IsNullOrEmpty(d))
                    visible &= row.Cells["Date"].Value?.ToString()
                        .ToLower().Contains(d) == true;

                if (!string.IsNullOrEmpty(v))
                    visible &= row.Cells["Vendor Name"].Value?.ToString()
                        .ToLower().Contains(v) == true;

                row.Visible = visible;
            }
        }

        // ================= SEARCH ALIGN =================
        private void SyncSearchBoxes()
        {
            SetSearchBox(txtSearchQuotationNo, "Quotation No");
            SetSearchBox(txtSearchQuotationDate, "Date");
            SetSearchBox(txtSearchVendors, "Vendor Name");
        }

        private void SetSearchBox(TextBox txt, string col)
        {
            if (!dgvPurchaseQuotation.Columns.Contains(col)) return;

            Rectangle r = dgvPurchaseQuotation.GetColumnDisplayRectangle(
                dgvPurchaseQuotation.Columns[col].Index, true);

            Point screenPoint = dgvPurchaseQuotation.PointToScreen(new Point(r.Left, r.Top));
            Point parentPoint = txt.Parent.PointToClient(screenPoint);

            txt.Left = parentPoint.X + (SEARCH_GAP / 2);
            txt.Width = r.Width - SEARCH_GAP;
        }

        private void dgvPurchaseQuotation_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
            => SyncSearchBoxes();

        private void dgvPurchaseQuotation_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                SyncSearchBoxes();
        }

        private void purchasequotation_Resize(object sender, EventArgs e)
            => SyncSearchBoxes();

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            txtQuotationNo.Clear();
            txtFileName.Clear();
            selectedFilePath = "";
            cmbVendorName.SelectedIndex = -1;
            cmbVendorName.Text = "Select Vendor ";
            dtQuotationDate.Value = DateTime.Now;
        }

        private void CenterControlsInPanel()
        {
            int spacing = 15;

            Control[] controls = new Control[]
            {
        txtFileName,
        btnAttach,
        btnSubmit,
        btnClear
            };

            
            pnlQuotationButton.SuspendLayout();

            int totalWidth = controls.Sum(c => c.Width) + (spacing * (controls.Length - 1));

            int startX = (pnlQuotationButton.ClientSize.Width - totalWidth) / 2;

            foreach (Control ctrl in controls)
            {
                ctrl.Location = new Point(
                    startX,
                    (pnlQuotationButton.ClientSize.Height - ctrl.Height) / 2
                );
                 
                startX += ctrl.Width + spacing;
            }

            pnlQuotationButton.ResumeLayout();
        }
        private void pnlQuotationButton_Resize(object sender, EventArgs e)
        {
            CenterControlsInPanel();
        }
    }
}