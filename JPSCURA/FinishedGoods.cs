using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class FinishedGoods : Form
    {
        private const int SEARCH_GAP = 4;

        public FinishedGoods()
        {
            InitializeComponent();
        }

        // ================= GRID SETUP =================
        private void SetupGrid()
        {
            dgvFinishedGoods.SuspendLayout();

            dgvFinishedGoods.AllowUserToAddRows = false;
            dgvFinishedGoods.ReadOnly = true;
            dgvFinishedGoods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinishedGoods.MultiSelect = false;

            dgvFinishedGoods.RowHeadersVisible = false;
            dgvFinishedGoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFinishedGoods.EnableHeadersVisualStyles = false;

            // ===== SAME STYLE AS ALL MATERIAL =====
            dgvFinishedGoods.BackgroundColor = Color.White;
            dgvFinishedGoods.GridColor = Color.LightGray;
            dgvFinishedGoods.BorderStyle = BorderStyle.FixedSingle;
            dgvFinishedGoods.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvFinishedGoods.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgvFinishedGoods.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvFinishedGoods.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvFinishedGoods.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgvFinishedGoods.DefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Regular);
            dgvFinishedGoods.DefaultCellStyle.BackColor = Color.White;
            dgvFinishedGoods.DefaultCellStyle.ForeColor = Color.Black;
            dgvFinishedGoods.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvFinishedGoods.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvFinishedGoods.AllowUserToResizeColumns = false;
            dgvFinishedGoods.AllowUserToResizeRows = false;
            dgvFinishedGoods.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            dgvFinishedGoods.Columns.Clear();

            // ===== VISIBLE COLUMNS =====
            dgvFinishedGoods.Columns.Add("srno", "Sr No");
            dgvFinishedGoods.Columns.Add("materialname", "Material Name");
            dgvFinishedGoods.Columns.Add("location", "Location");
            dgvFinishedGoods.Columns.Add("category", "Category");
            dgvFinishedGoods.Columns.Add("subcategory", "Sub Category");
            dgvFinishedGoods.Columns.Add("package", "Package");
            dgvFinishedGoods.Columns.Add("balance", "Balance");
            dgvFinishedGoods.Columns.Add("totalvalue", "Total Value");

            // ===== HIDDEN COLUMNS (FOR LOGIC) =====
            dgvFinishedGoods.Columns.Add("minthreshold", "MinThreshold");
            dgvFinishedGoods.Columns.Add("maxthreshold", "MaxThreshold");
            dgvFinishedGoods.Columns["minthreshold"].Visible = false;
            dgvFinishedGoods.Columns["maxthreshold"].Visible = false;

            // ===== COLUMN WIDTH RATIO =====
            dgvFinishedGoods.Columns["srno"].FillWeight = 5;
            dgvFinishedGoods.Columns["materialname"].FillWeight = 22;
            dgvFinishedGoods.Columns["location"].FillWeight = 14;
            dgvFinishedGoods.Columns["category"].FillWeight = 14;
            dgvFinishedGoods.Columns["subcategory"].FillWeight = 16;
            dgvFinishedGoods.Columns["package"].FillWeight = 10;
            dgvFinishedGoods.Columns["balance"].FillWeight = 9;
            dgvFinishedGoods.Columns["totalvalue"].FillWeight = 10;

            dgvFinishedGoods.ColumnHeadersHeight = 35;

            // ===== EVENTS =====
            dgvFinishedGoods.RowPostPaint += dgvFinishedGoods_RowPostPaint;
            dgvFinishedGoods.ColumnWidthChanged += dgvFinishedGoods_ColumnWidthChanged;
            dgvFinishedGoods.Scroll += dgvFinishedGoods_Scroll;
            dgvFinishedGoods.CellFormatting += dgvFinishedGoods_CellFormatting;

            dgvFinishedGoods.ResumeLayout();
        }

        // ================= SR NO =================
        private void dgvFinishedGoods_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvFinishedGoods.Rows[e.RowIndex].Cells["srno"].Value = e.RowIndex + 1;
        }

        // ================= SEARCH SYNC =================
        private void SyncSearchBoxesWithGrid()
        {
            if (dgvFinishedGoods.Columns.Count == 0) return;

            this.SuspendLayout();

            SetSearchBox(txtMaterialname, "materialname");
            SetSearchBox(txtLocation, "location");
            SetSearchBox(txtcategory, "category");
            SetSearchBox(txtsubcategory, "subcategory");
            SetSearchBox(txtpackage, "package");

            this.ResumeLayout();
        }

        private void SetSearchBox(TextBox txt, string columnName)
        {
            if (!dgvFinishedGoods.Columns.Contains(columnName)) return;

            Rectangle rect = dgvFinishedGoods.GetColumnDisplayRectangle(
                dgvFinishedGoods.Columns[columnName].Index, false);

            txt.Left = panelTopMenu.Left + rect.Left + (SEARCH_GAP / 2);
            txt.Width = rect.Width - SEARCH_GAP;
            txt.Top = panelTopMenu.Height - txt.Height - 6;
        }

        // ================= FORM LOAD =================
        private void FinishedGoods_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadFinishedGoodsGrid();
            BeginInvoke(new Action(SyncSearchBoxesWithGrid));
        }

        private void FinishedGoods_Resize(object sender, EventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }

        private void dgvFinishedGoods_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }

        private void dgvFinishedGoods_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                SyncSearchBoxesWithGrid();
        }

        // ================= DATA LOAD =================
        private void LoadFinishedGoodsGrid()
        {
            dgvFinishedGoods.SuspendLayout();

            try
            {
                dgvFinishedGoods.Rows.Clear();

                using SqlConnection con =
                    new SqlConnection(DBconection.GetConnectionString());

                using SqlCommand cmd = new SqlCommand(@"
SELECT 
    m.Material_Name,
    m.Location,
    ISNULL(c.Category_Name,'') AS Category_Name,
    ISNULL(s.Subcategory_Name,'') AS Subcategory_Name,
    ISNULL(p.Package_Name,'') AS Package_Name,

    ISNULL(m.MinThreshold,0) AS MinThreshold,
    ISNULL(m.MaxThreshold,0) AS MaxThreshold,

    CASE 
        WHEN SUM(ISNULL(u.Receipt,0) - ISNULL(u.Issued,0)) < 0 
        THEN 0
        ELSE SUM(ISNULL(u.Receipt,0) - ISNULL(u.Issued,0))
    END AS Balance,

    SUM(ISNULL(u.Total_Value,0)) AS TotalValue

FROM INVENTORY_MASTER..Material_Table m
INNER JOIN INVENTORY_MASTER..Type_Master t
    ON m.Type_ID = t.Type_ID

LEFT JOIN INVENTORY_MASTER..Category_Master c 
    ON m.Category_ID = c.Category_ID
LEFT JOIN INVENTORY_MASTER..Subcategory_Master s 
    ON m.Subcategory_ID = s.Subcategory_ID
LEFT JOIN INVENTORY_MASTER..Package_Master p 
    ON m.Package_ID = p.Package_ID
LEFT JOIN INVENTORY_MASTER..Usage_Table u 
    ON m.Material_ID = u.Material_ID

WHERE t.Type_Name = 'Finished Goods'

GROUP BY 
    m.Material_Name,
    m.Location,
    c.Category_Name,
    s.Subcategory_Name,
    p.Package_Name,
    m.MinThreshold,
    m.MaxThreshold

ORDER BY m.Material_Name
", con);

                con.Open();
                using SqlDataReader dr = cmd.ExecuteReader();

                int sr = 1;
                while (dr.Read())
                {
                    dgvFinishedGoods.Rows.Add(
                        sr++,
                        dr["Material_Name"],
                        dr["Location"],
                        dr["Category_Name"],
                        dr["Subcategory_Name"],
                        dr["Package_Name"],
                        dr["Balance"],
                        dr["TotalValue"],
                        dr["MinThreshold"],   // hidden
                        dr["MaxThreshold"]    // hidden
                    );
                }
            }
            finally
            {
                dgvFinishedGoods.ResumeLayout();
            }

            BeginInvoke(new Action(SyncSearchBoxesWithGrid));
        }

        // ================= SAME BALANCE LOGIC AS ALL MATERIAL =================
        private void dgvFinishedGoods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvFinishedGoods.Columns[e.ColumnIndex].Name != "balance")
                return;

            DataGridViewRow row = dgvFinishedGoods.Rows[e.RowIndex];

            int balance = Convert.ToInt32(row.Cells["balance"].Value);
            int min = Convert.ToInt32(row.Cells["minthreshold"].Value);
            int max = Convert.ToInt32(row.Cells["maxthreshold"].Value);

            Color bg;

            // 🟢 ENOUGH STOCK
            if (balance > max)
            {
                bg = Color.LightGreen;
                row.Cells["balance"].ToolTipText = "Enough stock, no need to order";
            }
            // 🔴 LOW STOCK
            else if (balance < min)
            {
                bg = Color.LightCoral;
                row.Cells["balance"].ToolTipText = "Low stock, need to order";
            }
            // 🟡 WARNING
            else
            {
                int warningLevel = min + (int)((max - min) * 0.3);

                if (balance <= warningLevel)
                {
                    bg = Color.Khaki;
                    row.Cells["balance"].ToolTipText = "Stock is getting low";
                }
                else
                {
                    bg = Color.White;
                    row.Cells["balance"].ToolTipText = "";
                }
            }

            row.Cells["balance"].Style.BackColor = bg;
            row.Cells["balance"].Style.SelectionBackColor = bg;
            row.Cells["balance"].Style.SelectionForeColor = Color.Black;
        }

        private void ApplyMultiSearch()
        {
            string material = txtMaterialname.Text.Trim();
            string location = txtLocation.Text.Trim();
            string category = txtcategory.Text.Trim();
            string subCategory = txtsubcategory.Text.Trim();
            string package = txtpackage.Text.Trim();

            foreach (DataGridViewRow row in dgvFinishedGoods.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                // ===== Material Name =====
                if (!string.IsNullOrEmpty(material))
                {
                    string cellValue = row.Cells["materialname"].Value?.ToString() ?? "";
                    visible &= cellValue.IndexOf(material, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // ===== Location =====
                if (!string.IsNullOrEmpty(location))
                {
                    string cellValue = row.Cells["location"].Value?.ToString() ?? "";
                    visible &= cellValue.IndexOf(location, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // ===== Category =====
                if (!string.IsNullOrEmpty(category))
                {
                    string cellValue = row.Cells["category"].Value?.ToString() ?? "";
                    visible &= cellValue.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // ===== Sub Category =====
                if (!string.IsNullOrEmpty(subCategory))
                {
                    string cellValue = row.Cells["subcategory"].Value?.ToString() ?? "";
                    visible &= cellValue.IndexOf(subCategory, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // ===== Package =====
                if (!string.IsNullOrEmpty(package))
                {
                    string cellValue = row.Cells["package"].Value?.ToString() ?? "";
                    visible &= cellValue.IndexOf(package, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                row.Visible = visible;
            }
        }

        private void txtMaterialname_TextChanged(object sender, EventArgs e)
        {
            ApplyMultiSearch();
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            ApplyMultiSearch();
        }

        private void txtcategory_TextChanged(object sender, EventArgs e)
        {
            ApplyMultiSearch();
        }

        private void txtsubcategory_TextChanged(object sender, EventArgs e)
        {
            ApplyMultiSearch();
        }

        private void txtpackage_TextChanged(object sender, EventArgs e)
        {
            ApplyMultiSearch();
        }
    }
}