using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class SemiFinishedGoods : Form
    {
        private const int SEARCH_GAP = 4;

        public SemiFinishedGoods()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void SemiFinishedGoods_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadSemiFinishedGoodsGrid();
            WireSearchEvents();
            BeginInvoke(new Action(SyncSearchBoxesWithGrid));
        }

        // ================= GRID SETUP =================
        private void SetupGrid()
        {
            dgv.SuspendLayout();

            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.EnableHeadersVisualStyles = false;

            // ===== SAME STYLE AS ALL MATERIAL =====
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
                new Font("Segoe UI", 9, FontStyle.Regular);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            dgv.Columns.Clear();

            // ===== VISIBLE COLUMNS =====
            dgv.Columns.Add("srno", "Sr No");
            dgv.Columns.Add("materialname", "Material Name");
            dgv.Columns.Add("location", "Location");
            dgv.Columns.Add("category", "Category");
            dgv.Columns.Add("subcategory", "Sub Category");
            dgv.Columns.Add("package", "Package");
            dgv.Columns.Add("balance", "Balance");
            dgv.Columns.Add("totalvalue", "Total Value");

            // ===== HIDDEN (FOR LOGIC) =====
            dgv.Columns.Add("minthreshold", "MinThreshold");
            dgv.Columns.Add("maxthreshold", "MaxThreshold");
            dgv.Columns["minthreshold"].Visible = false;
            dgv.Columns["maxthreshold"].Visible = false;

            // ===== WIDTH RATIO =====
            dgv.Columns["srno"].FillWeight = 5;
            dgv.Columns["materialname"].FillWeight = 22;
            dgv.Columns["location"].FillWeight = 14;
            dgv.Columns["category"].FillWeight = 14;
            dgv.Columns["subcategory"].FillWeight = 16;
            dgv.Columns["package"].FillWeight = 10;
            dgv.Columns["balance"].FillWeight = 9;
            dgv.Columns["totalvalue"].FillWeight = 10;

            dgv.ColumnHeadersHeight = 35;

            // ===== EVENTS =====
            dgv.RowPostPaint += dgv_RowPostPaint;
            dgv.ColumnWidthChanged += dgv_ColumnWidthChanged;
            dgv.Scroll += dgv_Scroll;
            dgv.CellFormatting += dgv_CellFormatting;

            dgv.ResumeLayout();
        }

        // ================= SR NO =================
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["srno"].Value = e.RowIndex + 1;
        }

        // ================= SEARCH SYNC =================
        private void SyncSearchBoxesWithGrid()
        {
            SetSearchBox(txtMaterialname, "materialname");
            SetSearchBox(txtLocation, "location");
            SetSearchBox(txtcategory, "category");
            SetSearchBox(txtsubcategory, "subcategory");
            SetSearchBox(txtpackage, "package");
        }

        private void SetSearchBox(TextBox txt, string columnName)
        {
            if (!dgv.Columns.Contains(columnName)) return;

            Rectangle rect = dgv.GetColumnDisplayRectangle(
                dgv.Columns[columnName].Index, false);

            txt.Left = panelTopMenu.Left + rect.Left + (SEARCH_GAP / 2);
            txt.Width = rect.Width - SEARCH_GAP;
            txt.Top = panelTopMenu.Height - txt.Height - 6;
        }

        // ================= DATA LOAD (ONLY SEMI FINISHED) =================
        private void LoadSemiFinishedGoodsGrid()
        {
            dgv.SuspendLayout();
            dgv.Rows.Clear();

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

WHERE t.Type_Name = 'Semi-Finished Goods'

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
                dgv.Rows.Add(
                    sr++,
                    dr["Material_Name"],
                    dr["Location"],
                    dr["Category_Name"],
                    dr["Subcategory_Name"],
                    dr["Package_Name"],
                    dr["Balance"],
                    dr["TotalValue"],
                    dr["MinThreshold"],
                    dr["MaxThreshold"]
                );
            }

            dgv.ResumeLayout();
            BeginInvoke(new Action(SyncSearchBoxesWithGrid));
        }

        // ================= BALANCE COLOR LOGIC (SAME AS ALL MATERIAL) =================
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name != "balance")
                return;

            DataGridViewRow row = dgv.Rows[e.RowIndex];

            int balance = Convert.ToInt32(row.Cells["balance"].Value);
            int min = Convert.ToInt32(row.Cells["minthreshold"].Value);
            int max = Convert.ToInt32(row.Cells["maxthreshold"].Value);

            Color bg;

            if (balance > max)
            {
                bg = Color.LightGreen;
                row.Cells["balance"].ToolTipText = "Enough stock, no need to order";
            }
            else if (balance < min)
            {
                bg = Color.LightCoral;
                row.Cells["balance"].ToolTipText = "Low stock, need to order";
            }
            else
            {
                int warningLevel = min + (int)((max - min) * 0.3);
                bg = balance <= warningLevel ? Color.Khaki : Color.White;
            }

            row.Cells["balance"].Style.BackColor = bg;
            row.Cells["balance"].Style.SelectionBackColor = bg;
            row.Cells["balance"].Style.SelectionForeColor = Color.Black;
        }

        // ================= MULTI SEARCH =================
        private void WireSearchEvents()
        {
            txtMaterialname.TextChanged += Search_TextChanged;
            txtLocation.TextChanged += Search_TextChanged;
            txtcategory.TextChanged += Search_TextChanged;
            txtsubcategory.TextChanged += Search_TextChanged;
            txtpackage.TextChanged += Search_TextChanged;
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                visible &= row.Cells["materialname"].Value.ToString()
                    .IndexOf(txtMaterialname.Text, StringComparison.OrdinalIgnoreCase) >= 0;

                visible &= row.Cells["location"].Value.ToString()
                    .IndexOf(txtLocation.Text, StringComparison.OrdinalIgnoreCase) >= 0;

                visible &= row.Cells["category"].Value.ToString()
                    .IndexOf(txtcategory.Text, StringComparison.OrdinalIgnoreCase) >= 0;

                visible &= row.Cells["subcategory"].Value.ToString()
                    .IndexOf(txtsubcategory.Text, StringComparison.OrdinalIgnoreCase) >= 0;

                visible &= row.Cells["package"].Value.ToString()
                    .IndexOf(txtpackage.Text, StringComparison.OrdinalIgnoreCase) >= 0;

                row.Visible = visible;
            }
        }

        // ================= RESIZE / SCROLL =================
        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }

        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                SyncSearchBoxesWithGrid();
        }

        private void SemiFinishedGoods_Resize(object sender, EventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }
    }
}
