using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class RawMaterial : Form
    {
        private const int SEARCH_GAP = 8;

        public RawMaterial()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void RawMaterial_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadRawMaterial();
            WireSearchEvents();
            EnableDoubleBuffering(this);

            // 🔥 alignment triggers
            dataGridViewemployee.ColumnWidthChanged += (s, ev) => AlignSearchBoxes();
            dataGridViewemployee.Scroll += (s, ev) =>
            {
                if (ev.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    AlignSearchBoxes();
            };
            this.Resize += (s, ev) => AlignSearchBoxes();
        }

        // ================= GRID SETUP =================
        private void SetupGrid()
        {
            dataGridViewemployee.SuspendLayout();
            dataGridViewemployee.Columns.Clear();
            dataGridViewemployee.Rows.Clear();

            dataGridViewemployee.AutoGenerateColumns = false;
            dataGridViewemployee.AllowUserToAddRows = false;
            dataGridViewemployee.AllowUserToResizeRows = false;
            dataGridViewemployee.ReadOnly = true;
            dataGridViewemployee.MultiSelect = false;
            dataGridViewemployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewemployee.RowHeadersVisible = false;
            dataGridViewemployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ===== STYLE =====
            dataGridViewemployee.BackgroundColor = Color.White;
            dataGridViewemployee.GridColor = Color.LightGray;
            dataGridViewemployee.BorderStyle = BorderStyle.FixedSingle;

            dataGridViewemployee.EnableHeadersVisualStyles = false;
            dataGridViewemployee.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridViewemployee.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewemployee.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            dataGridViewemployee.DefaultCellStyle.BackColor = Color.White;
            dataGridViewemployee.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewemployee.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridViewemployee.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewemployee.RowTemplate.Height = 26;

            // ===== COLUMNS =====
            dataGridViewemployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SrNo",
                HeaderText = "Sr No",
                FillWeight = 4
            });

            dataGridViewemployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaterialName",
                HeaderText = "Material Name",
                FillWeight = 14
            });

            dataGridViewemployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Location",
                HeaderText = "Location",
                FillWeight = 8
            });

            dataGridViewemployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                FillWeight = 8
            });

            dataGridViewemployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SubCategory",
                HeaderText = "Sub Category",
                FillWeight = 8
            });

            dataGridViewemployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Package",
                HeaderText = "Package",
                FillWeight = 6
            });

            dataGridViewemployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Balance",
                HeaderText = "Balance",
                FillWeight = 6
            });

            dataGridViewemployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalValue",
                HeaderText = "Total Value",
                FillWeight = 8
            });

            dataGridViewemployee.CellFormatting += dataGridViewemployee_CellFormatting;

            dataGridViewemployee.ResumeLayout(true);
        }

        // ================= LOAD DATA =================
        private void LoadRawMaterial()
        {
            dataGridViewemployee.Rows.Clear();

            using SqlConnection con =
                new SqlConnection(DBconection.GetConnectionString());

            using SqlCommand cmd = new SqlCommand(@"
SELECT
    m.Material_Name     AS MaterialName,
    m.Location          AS Location,
    c.Category_Name     AS Category,
    sc.Subcategory_Name AS SubCategory,
    p.Package_Name      AS Package,
    ISNULL(u.Balance,0)     AS Balance,
    ISNULL(u.Total_Value,0) AS TotalValue
FROM INVENTORY_MASTER.dbo.Material_Table m
INNER JOIN INVENTORY_MASTER.dbo.Type_Master t
    ON m.Type_ID = t.Type_ID
   AND t.Type_Name = 'RawMaterial'
LEFT JOIN INVENTORY_MASTER.dbo.Category_Master c
    ON m.Category_ID = c.Category_ID
LEFT JOIN INVENTORY_MASTER.dbo.Subcategory_Master sc
    ON m.Subcategory_ID = sc.Subcategory_ID
LEFT JOIN INVENTORY_MASTER.dbo.Package_Master p
    ON m.Package_ID = p.Package_ID
LEFT JOIN INVENTORY_MASTER.dbo.Usage_Table u
    ON u.Material_ID = m.Material_ID
   AND u.Usage_ID = (
        SELECT MAX(u2.Usage_ID)
        FROM INVENTORY_MASTER.dbo.Usage_Table u2
        WHERE u2.Material_ID = m.Material_ID
   )
ORDER BY m.Material_Name;
", con);

            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            int sr = 1;
            while (dr.Read())
            {
                dataGridViewemployee.Rows.Add(
                    sr++,
                    dr["MaterialName"],
                    dr["Location"],
                    dr["Category"],
                    dr["SubCategory"],
                    dr["Package"],
                    dr["Balance"],
                    dr["TotalValue"]
                );
            }

            AlignSearchBoxes();
        }

        // ================= SEARCH =================
        private void WireSearchEvents()
        {
            rawmsearchbyname.TextChanged += ApplySearch;
            rawmsearchbylocation.TextChanged += ApplySearch;
            rawmsearchbycategory.TextChanged += ApplySearch;
            rawmsearchbysubcat.TextChanged += ApplySearch;
            rawmsearchbypackage.TextChanged += ApplySearch;
        }

        private void ApplySearch(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewemployee.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                visible &= Contains(row, "MaterialName", rawmsearchbyname.Text);
                visible &= Contains(row, "Location", rawmsearchbylocation.Text);
                visible &= Contains(row, "Category", rawmsearchbycategory.Text);
                visible &= Contains(row, "SubCategory", rawmsearchbysubcat.Text);
                visible &= Contains(row, "Package", rawmsearchbypackage.Text);

                row.Visible = visible;
            }

            ReassignSrNo();
        }

        private bool Contains(DataGridViewRow row, string column, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return true;

            string value = row.Cells[column].Value?.ToString() ?? "";
            return value.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void ReassignSrNo()
        {
            int sr = 1;
            foreach (DataGridViewRow row in dataGridViewemployee.Rows)
            {
                if (row.IsNewRow || !row.Visible) continue;
                row.Cells["SrNo"].Value = sr++;
            }
        }

        // ================= SEARCH ALIGN =================
        private void AlignSearchBoxes()
        {
            if (dataGridViewemployee.Columns.Count == 0) return;

            SetSearchBox(rawmsearchbyname, "MaterialName");
            SetSearchBox(rawmsearchbylocation, "Location");
            SetSearchBox(rawmsearchbycategory, "Category");
            SetSearchBox(rawmsearchbysubcat, "SubCategory");
            SetSearchBox(rawmsearchbypackage, "Package");
        }

        private void SetSearchBox(TextBox txt, string columnName)
        {
            if (!dataGridViewemployee.Columns.Contains(columnName)) return;

            Rectangle rect = dataGridViewemployee.GetColumnDisplayRectangle(
                dataGridViewemployee.Columns[columnName].Index,
                true);

            txt.Left = rect.Left + dataGridViewemployee.Left + (SEARCH_GAP / 2);
            txt.Width = rect.Width - SEARCH_GAP;
        }

        // ================= BALANCE COLOR =================
        private void dataGridViewemployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewemployee.Columns[e.ColumnIndex].Name != "Balance")
                return;

            if (e.Value == null) return;

            int balance;
            if (!int.TryParse(e.Value.ToString(), out balance)) return;

            DataGridViewRow row = dataGridViewemployee.Rows[e.RowIndex];
            Color bg = balance <= 0 ? Color.LightCoral : Color.LightGreen;

            row.Cells["Balance"].Style.BackColor = bg;
            row.Cells["Balance"].Style.SelectionBackColor = bg;
            row.Cells["Balance"].Style.SelectionForeColor = Color.Black;
        }

        // ================= UTIL =================
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
    }
}
