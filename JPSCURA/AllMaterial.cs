using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;


namespace JPSCURA
{
    public partial class AllMaterial : Form
    {


        private int selectedMaterialId = 0;
        private const int SEARCH_GAP = 4; // space between search boxes
        private HashSet<int> selectedMaterialIds = new HashSet<int>();
        private Dictionary<int, int> materialOriginalIndex = new();
        private bool _isBulkClearing = false;

        private int GetOrCreateId(
        SqlConnection con,
        string selectSql,
        string insertSql,
        string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Master value cannot be empty");

            using SqlCommand sel = new SqlCommand(selectSql, con);
            sel.Parameters.AddWithValue("@val", value.Trim());

            object res = sel.ExecuteScalar();
            if (res != null)
                return Convert.ToInt32(res);

            using SqlCommand ins = new SqlCommand(insertSql, con);
            ins.Parameters.AddWithValue("@val", value.Trim());
            return Convert.ToInt32(ins.ExecuteScalar());
        }


        private FormWindowState _lastState;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (WindowState == FormWindowState.Minimized)
                _lastState = WindowState;

            if (_lastState == FormWindowState.Minimized &&
                WindowState == FormWindowState.Normal)
            {
                this.SuspendLayout();
                this.ResumeLayout(true);
            }
        }





        public AllMaterial()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void AllMaterial_Load(object sender, EventArgs e)
        {

            // ===== MAIN TABLE SELECTION =====
            DgvMainTable.MultiSelect = true;
            DgvMainTable.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DgvMainTable.MultiSelect = false;

            DgvMainTable.ClearSelection();

            // ===== 2nd TABLE SELECTION =====
            dgv2ndTable.MultiSelect = true;
            dgv2ndTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv2ndTable.ClearSelection();

            panelMainContent.Dock = DockStyle.Fill;
            panel2ndTable.Dock = DockStyle.Fill;

            panelMainContent.BackColor = Color.White;
            panel2ndTable.BackColor = Color.White;

            DgvMainTable.Dock = DockStyle.Fill;
            dgv2ndTable.Dock = DockStyle.Fill;

            btnAddNew.Visible = false;


            LoadMainGrid();
            EnableDoubleBuffering(this);
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

        private void ApplyMultiSearch(object sender, EventArgs e)
        {
            string material = txtSearchMaterial.Text.Trim();
            string type = txtSearchType.Text.Trim();
            string location = txtSearchLocation.Text.Trim();
            string category = txtSearchCategory.Text.Trim();
            string subCategory = txtSearchSubCategory.Text.Trim();
            string package = txtSearchPackage.Text.Trim();

            foreach (DataGridViewRow row in DgvMainTable.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = true;

                // ===== Material =====
                if (!string.IsNullOrEmpty(material))
                {
                    string cellValue = row.Cells["Material"].Value?.ToString() ?? "";
                    visible &= cellValue.IndexOf(material, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                // ===== Type =====
                if (!string.IsNullOrEmpty(type))
                {
                    string cellValue = row.Cells["Type"].Value?.ToString() ?? "";
                    visible &= cellValue.StartsWith(type, StringComparison.OrdinalIgnoreCase);
                }

                // ===== Location =====
                if (!string.IsNullOrEmpty(location))
                {
                    string cellValue = row.Cells["Location"].Value?.ToString() ?? "";
                    visible &= cellValue.StartsWith(location, StringComparison.OrdinalIgnoreCase);
                }

                // ===== Category =====
                if (!string.IsNullOrEmpty(category))
                {
                    string cellValue = row.Cells["Category"].Value?.ToString() ?? "";
                    visible &= cellValue.StartsWith(category, StringComparison.OrdinalIgnoreCase);
                }

                // ===== Sub Category =====
                if (!string.IsNullOrEmpty(subCategory))
                {
                    string cellValue = row.Cells["SubCategory"].Value?.ToString() ?? "";
                    visible &= cellValue.StartsWith(subCategory, StringComparison.OrdinalIgnoreCase);
                }

                // ===== Package =====
                if (!string.IsNullOrEmpty(package))
                {
                    string cellValue = row.Cells["Package"].Value?.ToString() ?? "";
                    visible &= cellValue.StartsWith(package, StringComparison.OrdinalIgnoreCase);
                }

                int materialId = Convert.ToInt32(row.Cells["Material_ID"].Value);

                bool isSelected = selectedMaterialIds.Contains(materialId);

                // Selected rows → ALWAYS visible
                row.Visible = visible || isSelected;
                MoveSelectedRowsToTop();


            }
        }
        private void MoveSelectedRowsToTop()
        {
            var selectedRows = DgvMainTable.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow &&
                    selectedMaterialIds.Contains(
                        Convert.ToInt32(r.Cells["Material_ID"].Value)))
                .ToList();

            foreach (var row in selectedRows)
            {
                DgvMainTable.Rows.Remove(row);
                DgvMainTable.Rows.Insert(0, row);
                row.Cells["SelectRow"].Value = true;
            }
        }


        private void SyncSearchBoxesWithGrid()
        {
            if (DgvMainTable.Columns.Count == 0) return;

            SetSearchBox(txtSearchMaterial, "Material");
            SetSearchBox(txtSearchType, "Type");
            SetSearchBox(txtSearchLocation, "Location");
            SetSearchBox(txtSearchCategory, "Category");
            SetSearchBox(txtSearchSubCategory, "SubCategory");
            SetSearchBox(txtSearchPackage, "Package");
        }

        private void SetSearchBox(TextBox txt, string columnName)
        {
            if (!DgvMainTable.Columns.Contains(columnName)) return;

            Rectangle rect = DgvMainTable.GetColumnDisplayRectangle(
                DgvMainTable.Columns[columnName].Index,
                true
            );

            txt.Left = rect.Left + DgvMainTable.Left + (SEARCH_GAP / 2);
            txt.Width = rect.Width - SEARCH_GAP;
        }



        // ================= MAIN GRID =================
        private void LoadMainGrid()
        {
            // 🔥 FLICKER + LAG FIX
            this.SuspendLayout();
            DgvMainTable.SuspendLayout();

            try
            {
                // ===== RESET GRID =====
                DgvMainTable.Rows.Clear();
                DgvMainTable.Columns.Clear();
                DgvMainTable.AutoGenerateColumns = false;

                btnBack.Visible = false;
                panelSearch.Visible = true;
                panel2ndtableTopContent.Visible = false;

                // ===== BASIC STYLE =====
                DgvMainTable.BackgroundColor = Color.White;
                DgvMainTable.GridColor = Color.White;
                DgvMainTable.RowHeadersVisible = false;
                DgvMainTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvMainTable.EnableHeadersVisualStyles = false;

                DgvMainTable.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);
                DgvMainTable.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                DgvMainTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                DgvMainTable.DefaultCellStyle.Font =
                    new Font("Segoe UI", 9, FontStyle.Regular);
                DgvMainTable.DefaultCellStyle.BackColor = Color.White;
                DgvMainTable.DefaultCellStyle.ForeColor = Color.Black;
                DgvMainTable.DefaultCellStyle.SelectionBackColor = Color.White;
                DgvMainTable.DefaultCellStyle.SelectionForeColor = Color.Black;

                // ===== DISABLE RESIZE =====
                DgvMainTable.AllowUserToResizeColumns = false;
                DgvMainTable.AllowUserToResizeRows = false;
                DgvMainTable.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                // ===== CHECKBOX COLUMN =====
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn
                {
                    Name = "SelectRow",
                    HeaderText = "",
                    Width = 30,
                    FillWeight = 1,
                    FalseValue = false,
                    TrueValue = true
                };
                DgvMainTable.Columns.Add(chk);

                // ===== DATA COLUMNS =====
                DgvMainTable.Columns.Add("Material_ID", "ID");
                DgvMainTable.Columns["Material_ID"].Visible = false;

                DgvMainTable.Columns.Add("SrNo", "Sr No");
                DgvMainTable.Columns.Add("Material", "Material Name");
                DgvMainTable.Columns.Add("Type", "Types Of Material");
                DgvMainTable.Columns.Add("Location", "Location");
                DgvMainTable.Columns.Add("Category", "Category");
                DgvMainTable.Columns.Add("SubCategory", "Sub Category");
                DgvMainTable.Columns.Add("Package", "Package");
                DgvMainTable.Columns.Add("Balance", "Balance");
                DgvMainTable.Columns.Add("TotalValue", "Total Value");
                DgvMainTable.Columns.Add("MinThreshold", "MinThreshold");
                DgvMainTable.Columns.Add("MaxThreshold", "MaxThreshold");

                DgvMainTable.Columns["MinThreshold"].Visible = false;
                DgvMainTable.Columns["MaxThreshold"].Visible = false;

                ApplyGridLines(DgvMainTable);

                // ===== COLUMN WIDTH =====
                DgvMainTable.Columns["SrNo"].FillWeight = 2;
                DgvMainTable.Columns["Material"].FillWeight = 15;
                DgvMainTable.Columns["Type"].FillWeight = 5;
                DgvMainTable.Columns["Location"].FillWeight = 5;
                DgvMainTable.Columns["Category"].FillWeight = 5;
                DgvMainTable.Columns["SubCategory"].FillWeight = 5;
                DgvMainTable.Columns["Package"].FillWeight = 5;
                DgvMainTable.Columns["Balance"].FillWeight = 5;
                DgvMainTable.Columns["TotalValue"].FillWeight = 5;

                // ===== DB LOAD =====
                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                using SqlCommand cmd = new SqlCommand(@"
SELECT 
    m.Material_ID,
    m.Material_Name,
    ISNULL(t.Type_Name,'') AS Material_Type,
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
LEFT JOIN INVENTORY_MASTER..Category_Master c 
    ON m.Category_ID = c.Category_ID
LEFT JOIN INVENTORY_MASTER..Subcategory_Master s 
    ON m.Subcategory_ID = s.Subcategory_ID
LEFT JOIN INVENTORY_MASTER..Package_Master p 
    ON m.Package_ID = p.Package_ID
LEFT JOIN INVENTORY_MASTER..Type_Master t 
    ON m.Type_ID = t.Type_ID
LEFT JOIN INVENTORY_MASTER..Usage_Table u 
    ON m.Material_ID = u.Material_ID

GROUP BY 
    m.Material_ID,
    m.Material_Name,
    t.Type_Name,
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
                    DgvMainTable.Rows.Add(
                        false,
                        dr["Material_ID"],
                        sr++,
                        dr["Material_Name"],
                        dr["Material_Type"],
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

                // ===== STORE ORIGINAL ORDER =====
                materialOriginalIndex.Clear();
                for (int i = 0; i < DgvMainTable.Rows.Count; i++)
                {
                    if (DgvMainTable.Rows[i].IsNewRow) continue;

                    int materialId = Convert.ToInt32(
                        DgvMainTable.Rows[i].Cells["Material_ID"].Value);

                    materialOriginalIndex[materialId] = i;
                }

                SyncSearchBoxesWithGrid();
            }
            finally
            {
                // 🔥 RESUME UI
                DgvMainTable.ResumeLayout(true);
                this.ResumeLayout(true);
            }
        }


        // ================= DOUBLE CLICK =================
        private void DgvMainTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (DgvMainTable.Rows[e.RowIndex].Cells["Material_ID"].Value == null)
                return;

            selectedMaterialId = Convert.ToInt32(
                DgvMainTable.Rows[e.RowIndex].Cells["Material_ID"].Value);

            if (selectedMaterialId <= 0)
                return;

            panelMainContent.Visible = false;
            panel2ndTable.Visible = true;
            btnAddNew.Visible = true;
            btnBack.Visible = true;
            panel2ndtableTopContent.Visible = true;
            LoadUsageGrid();
        }


        private void ApplyGridLines(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.LightGray;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;

            dgv.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        // ================= USAGE GRID =================

        private void LoadUsageGrid()
        {
            // Safety: material must be selected
            if (selectedMaterialId <= 0)
                return;

            dgv2ndTable.SuspendLayout();

            dgv2ndTable.Rows.Clear();
            dgv2ndTable.Columns.Clear();
            dgv2ndTable.AutoGenerateColumns = false;

            // ===== BASIC GRID SETUP =====
            dgv2ndTable.ReadOnly = false;
            dgv2ndTable.EditMode = DataGridViewEditMode.EditOnEnter;

            dgv2ndTable.BackgroundColor = Color.White;
            dgv2ndTable.GridColor = Color.LightGray;

            dgv2ndTable.DefaultCellStyle.BackColor = Color.White;
            dgv2ndTable.DefaultCellStyle.ForeColor = Color.Black;
            dgv2ndTable.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv2ndTable.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv2ndTable.EnableHeadersVisualStyles = false;
            dgv2ndTable.RowHeadersVisible = false;
            dgv2ndTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv2ndTable.AllowUserToResizeColumns = false;
            dgv2ndTable.AllowUserToResizeRows = false;

            dgv2ndTable.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            foreach (DataGridViewColumn col in dgv2ndTable.Columns)
            {
                col.Resizable = DataGridViewTriState.False;
            }


            // ===== COLUMNS =====
            dgv2ndTable.Columns.Add("Usage_ID", "ID");
            dgv2ndTable.Columns["Usage_ID"].Visible = false;

            dgv2ndTable.Columns.Add("Date", "Date");
            dgv2ndTable.Columns.Add("Voucher", "Voucher / Bill No");
            dgv2ndTable.Columns.Add("Particular", "Particular");
            dgv2ndTable.Columns.Add("Receipt", "Receipt");
            dgv2ndTable.Columns.Add("Issued", "Issued");
            dgv2ndTable.Columns.Add("Rate", "Rate");
            dgv2ndTable.Columns.Add("Balance", "Balance");
            dgv2ndTable.Columns.Add("TotalValue", "Total Value");
            ApplyGridLines(dgv2ndTable);



            // ===== READONLY COLUMNS =====
            dgv2ndTable.Columns["Receipt"].ReadOnly = true;
            dgv2ndTable.Columns["Issued"].ReadOnly = true;
            dgv2ndTable.Columns["Balance"].ReadOnly = true;
            dgv2ndTable.Columns["TotalValue"].ReadOnly = true;
            dgv2ndTable.Columns["Voucher"].ReadOnly = true;
            dgv2ndTable.Columns["Date"].ReadOnly = true;
            dgv2ndTable.Columns["Particular"].ReadOnly = true;

            // ===== DB LOAD =====
            using (SqlConnection con = new SqlConnection(DBconection.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT *
        FROM INVENTORY_MASTER..Usage_Table
        WHERE Material_ID = @mid
        ORDER BY Usage_ID", con))
            {
                cmd.Parameters.AddWithValue("@mid", selectedMaterialId);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int usageId = dr["Usage_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Usage_ID"]);
                        string date = dr["Usage_Date"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(dr["Usage_Date"]).ToString("dd-MM-yyyy");

                        string voucher = dr["V_NO_And_B_NO"]?.ToString() ?? "";
                        string particular = dr["Particular"]?.ToString() ?? "";

                        decimal receipt = dr["Receipt"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Receipt"]);
                        decimal issued = dr["Issued"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Issued"]);
                        decimal rate = dr["Rate_Per_Qty"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Rate_Per_Qty"]);
                        decimal balance = dr["Balance"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Balance"]);
                        decimal total = dr["Total_Value"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Total_Value"]);

                        dgv2ndTable.Rows.Add(
                            usageId,
                            date,
                            voucher,
                            particular,
                            receipt,
                            issued,
                            issued > 0 ? "--" : rate.ToString("0.00"),
                            balance,
                            total
                        );
                    }
                }
            }

            // ===== RATE RULES =====
            foreach (DataGridViewRow row in dgv2ndTable.Rows)
            {
                if (row.IsNewRow) continue;

                decimal receipt = row.Cells["Receipt"].Value == null
                    ? 0
                    : Convert.ToDecimal(row.Cells["Receipt"].Value);

                decimal issued = row.Cells["Issued"].Value == null
                    ? 0
                    : Convert.ToDecimal(row.Cells["Issued"].Value);

                string particular = row.Cells["Particular"].Value?.ToString() ?? "";

                // Default: lock rate
                row.Cells["Rate"].ReadOnly = true;
                row.Cells["Rate"].Style.BackColor = Color.White;

                // Only Opening receipt can edit rate
                if (particular == "Opening" && receipt > 0 && issued == 0)
                {
                    row.Cells["Rate"].ReadOnly = false;
                }

                // Issued rows show --
                if (issued > 0)
                {
                    row.Cells["Rate"].Value = "--";
                }
            }

            foreach (DataGridViewRow row in dgv2ndTable.Rows)
            {
                if (row.IsNewRow) continue;

                decimal receipt = row.Cells["Receipt"].Value == null
                    ? 0
                    : Convert.ToDecimal(row.Cells["Receipt"].Value);

                decimal issued = row.Cells["Issued"].Value == null
                    ? 0
                    : Convert.ToDecimal(row.Cells["Issued"].Value);

                // Default style
                row.Cells["Rate"].Style.BackColor = Color.White;
                row.Cells["Rate"].Style.ForeColor = Color.Black;

                // 🔹 RECEIPT → Rate ENABLE
                if (receipt > 0 && issued == 0)
                {
                    row.Cells["Rate"].ReadOnly = false;

                    // if rate was --
                    if (row.Cells["Rate"].Value?.ToString() == "--")
                        row.Cells["Rate"].Value = "0.00";
                }
                // 🔹 ISSUED → Rate DISABLE
                else if (issued > 0)
                {
                    row.Cells["Rate"].ReadOnly = true;
                    row.Cells["Rate"].Value = "--";
                }
            }

            dgv2ndTable.ResumeLayout();
        }










        // ================= RATE CHANGE =================
        private void dgv2ndTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv2ndTable.Columns[e.ColumnIndex].Name != "Rate") return;

            DataGridViewRow row = dgv2ndTable.Rows[e.RowIndex];

            if (!decimal.TryParse(row.Cells["Rate"].Value?.ToString(), out decimal rate))
                return;

            // store real value
            row.Cells["Rate"].Value = rate;


            decimal balance = Convert.ToDecimal(row.Cells["Balance"].Value);
            decimal totalValue = rate * balance;

            row.Cells["TotalValue"].Value = totalValue;

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            SqlCommand cmd = new SqlCommand(@"
UPDATE INVENTORY_MASTER..Usage_Table
SET Rate_Per_Qty=@rate,
    Total_Value=@total
WHERE Usage_ID=@id", con);

            cmd.Parameters.AddWithValue("@rate", rate);
            cmd.Parameters.AddWithValue("@total", totalValue);
            cmd.Parameters.AddWithValue("@id", row.Cells["Usage_ID"].Value);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        private void dgv2ndTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv2ndTable.IsCurrentCellDirty)
                dgv2ndTable.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }




        // ================= FIFO =================
        private void ApplyFIFO(int materialId)
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            con.Open();

            // 1️⃣ Read all usage rows
            SqlCommand cmd = new SqlCommand(@"
SELECT Usage_ID, Receipt, Issued, Rate_Per_Qty
FROM INVENTORY_MASTER..Usage_Table
WHERE Material_ID = @mid
ORDER BY Usage_Date, Usage_ID", con);

            cmd.Parameters.AddWithValue("@mid", materialId);

            SqlDataReader dr = cmd.ExecuteReader();

            // FIFO layers (qty, rate)
            Queue<(decimal qty, decimal rate)> fifo = new();

            List<(int id, decimal balQty, decimal balVal)> updates = new();

            decimal runningQty = 0;
            decimal runningValue = 0;

            while (dr.Read())
            {
                int usageId = Convert.ToInt32(dr["Usage_ID"]);
                decimal receipt = Convert.ToDecimal(dr["Receipt"]);
                decimal issued = Convert.ToDecimal(dr["Issued"]);
                decimal rate = Convert.ToDecimal(dr["Rate_Per_Qty"]);

                // ✅ Receipt → add new FIFO layer
                if (receipt > 0 && rate > 0)
                {
                    fifo.Enqueue((receipt, rate));
                    runningQty += receipt;
                    runningValue += receipt * rate;
                }

                // ✅ Issued → consume FIFO layers
                if (issued > 0)
                {
                    decimal issueQty = issued;

                    if (issueQty > runningQty)
                    {
                        MessageBox.Show(
                            "Issued quantity cannot be greater than available stock.",
                            "Stock Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        dr.Close();
                        return;
                    }

                    while (issueQty > 0 && fifo.Count > 0)
                    {
                        var layer = fifo.Dequeue();

                        if (layer.qty <= issueQty)
                        {
                            // consume full layer
                            issueQty -= layer.qty;
                            runningQty -= layer.qty;
                            runningValue -= layer.qty * layer.rate;
                        }
                        else
                        {
                            // consume partial layer
                            fifo.Enqueue((layer.qty - issueQty, layer.rate));
                            runningQty -= issueQty;
                            runningValue -= issueQty * layer.rate;
                            issueQty = 0;
                        }
                    }
                }

                // safety
                if (runningQty < 0) runningQty = 0;
                if (runningValue < 0) runningValue = 0;

                updates.Add((usageId, runningQty, runningValue));
            }

            dr.Close();

            // 2️⃣ Update balances
            foreach (var u in updates)
            {
                SqlCommand upd = new SqlCommand(@"
UPDATE INVENTORY_MASTER..Usage_Table
SET Balance = @bal,
    Total_Value = @val
WHERE Usage_ID = @id", con);

                upd.Parameters.AddWithValue("@bal", u.balQty);
                upd.Parameters.AddWithValue("@val", u.balVal);
                upd.Parameters.AddWithValue("@id", u.id);

                upd.ExecuteNonQuery();
            }
        }




        // ================= ADD NEW =================
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            InventoryTransaction frm = new InventoryTransaction(selectedMaterialId);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ApplyFIFO(selectedMaterialId);
                LoadUsageGrid();
                //LoadMainGrid();
                panelMainContent.Visible = false;
                panel2ndTable.Visible = true;
                panel2ndtableTopContent.Visible = true;

                btnAddNew.Visible = true;
                btnBack.Visible = true;
            }
        }

        // ================= BACK =================
        private async void btnBack_Click(object sender, EventArgs e)
        {
            // 🔥 get Home form (parent)
            Home home = this.ParentForm as Home;
            if (home == null) return;

            await home.RunWithLoadingAsync(async () =>
            {
                // 🔒 freeze UI changes inside loading

                panel2ndTable.Visible = false;
                panelMainContent.Visible = true;
                btnAddNew.Visible = false;

                panel2ndtableTopContent.Visible = false;
                panelSearch.Visible = true;

                // 🔥 DB + GRID reload during loading
                LoadMainGrid();

                await Task.Yield(); // allow paint
            }, 1000
            );
        }


        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{

        //    string searchText = txtSearch.Text.Trim();

        //    if (string.IsNullOrWhiteSpace(searchText))
        //    {
        //        foreach (DataGridViewRow row in DgvMainTable.Rows)
        //        {
        //            if (!row.IsNewRow)
        //                row.Visible = true;
        //        }
        //        return;
        //    }

        //    foreach (DataGridViewRow row in DgvMainTable.Rows)
        //    {
        //        if (row.IsNewRow) continue;

        //        bool visible =
        //            // 🔹 Material Name → flexible
        //            row.Cells["Material"].Value.ToString()
        //                .IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0

        //            // 🔹 Prefix based (SMART SEARCH)
        //            || row.Cells["Location"].Value.ToString()
        //                .StartsWith(searchText, StringComparison.OrdinalIgnoreCase)

        //            || row.Cells["Category"].Value.ToString()
        //                .StartsWith(searchText, StringComparison.OrdinalIgnoreCase)

        //            || row.Cells["SubCategory"].Value.ToString()
        //                .StartsWith(searchText, StringComparison.OrdinalIgnoreCase)

        //            || row.Cells["Types Of Material"].Value.ToString()
        //                .StartsWith(searchText, StringComparison.OrdinalIgnoreCase)

        //            || row.Cells["Package"].Value.ToString()
        //                .StartsWith(searchText, StringComparison.OrdinalIgnoreCase);

        //        row.Visible = visible;
        //    }
        //}




        private void dgv2ndTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.Value != null && e.Value.ToString() == "0")
            //{
            //    e.Value = "--";
            //    e.FormattingApplied = true;
            //}
            if (e.Value != null && e.Value.ToString() == "0")
            {
                e.Value = "--";
                e.FormattingApplied = true;
            }

        }





        private void dgv2ndTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv2ndTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void dgv2ndTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgv2ndTable.Columns[e.ColumnIndex].Name == "Rate")
            {
                if (dgv2ndTable.Rows[e.RowIndex].Cells["Rate"].ReadOnly)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "Inventory_Report.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            ExportToExcel_ClosedXML(sfd.FileName);
        }
        private void ExportToExcel_ClosedXML(string filePath)
        {
            using (var wb = new XLWorkbook())
            {
                // ================= SHEET 1 : ALL MATERIALS =================
                var wsMain = wb.Worksheets.Add("All Materials");
                ExportGridViewToSheet(wsMain, DgvMainTable);

                // ================= SHEET 2 : MATERIAL USAGE =================
                if (panel2ndTable.Visible && dgv2ndTable.Rows.Count > 0)
                {
                    var wsUsage = wb.Worksheets.Add("Material Usage");
                    ExportGridViewToSheet(wsUsage, dgv2ndTable);
                }

                wb.SaveAs(filePath);
            }

            var result = MessageBox.Show(
       "Excel exported successfully ✔\n\nDo you want to open the file?",
       "Export",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Information
   );

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }

        }

        private void ExportGridViewToSheet(IXLWorksheet ws, DataGridView dgv)

        {
            int colIndex = 1;

            // ===== HEADERS =====
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (!col.Visible || col.Name == "SelectRow") continue;

                ws.Cell(1, colIndex).Value = col.HeaderText;
                ws.Cell(1, colIndex).Style.Font.Bold = true;
                ws.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.LightGray;
                ws.Cell(1, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                colIndex++;
            }

            bool anyChecked = dgv.Rows
                .Cast<DataGridViewRow>()
                .Any(r => Convert.ToBoolean(r.Cells["SelectRow"].Value));

            int rowIndex = 2;
            int excelSrNo = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow || !row.Visible)
                    continue;

                bool isChecked = Convert.ToBoolean(row.Cells["SelectRow"].Value);

                // 
                if (anyChecked && !isChecked)
                    continue;

                colIndex = 1;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (!col.Visible || col.Name == "SelectRow")
                        continue;

                    // 
                    if (col.Name == "SrNo")
                    {
                        ws.Cell(rowIndex, colIndex).Value = excelSrNo;
                    }
                    else
                    {
                        ws.Cell(rowIndex, colIndex).Value =
                            row.Cells[col.Name].Value?.ToString() ?? "";
                    }

                    colIndex++;
                }

                excelSrNo++;   // 👈 Sr No increase
                rowIndex++;
            }

            ws.Columns().AdjustToContents();
        }





        private void AllMaterial_Resize(object sender, EventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }

        private void DgvMainTable_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SyncSearchBoxesWithGrid();
        }

        private void DgvMainTable_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                SyncSearchBoxesWithGrid();
        }

        private void DgvMainTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (DgvMainTable.Columns[e.ColumnIndex].Name != "SelectRow")
                return;

            var cell = DgvMainTable.Rows[e.RowIndex].Cells["SelectRow"];

            bool current = cell.Value != null && (bool)cell.Value;
            cell.Value = !current;

        }

        private void dgv2ndTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dgv2ndTable.Rows[e.RowIndex].Selected = true;
        }

        private void DgvMainTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvMainTable.IsCurrentCellDirty)
            {
                DgvMainTable.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvMainTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_isBulkClearing) return;
            if (e.RowIndex < 0) return;
            if (DgvMainTable.Columns[e.ColumnIndex].Name != "SelectRow") return;

            int materialId = Convert.ToInt32(
                DgvMainTable.Rows[e.RowIndex].Cells["Material_ID"].Value);

            bool isChecked = Convert.ToBoolean(
                DgvMainTable.Rows[e.RowIndex].Cells["SelectRow"].Value);

            if (isChecked)
                selectedMaterialIds.Add(materialId);
            else
                selectedMaterialIds.Remove(materialId);

            ReorderRows();

        }
        private void ReorderRows()
        {
            var checkedRows = new List<DataGridViewRow>();
            var uncheckedRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in DgvMainTable.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = Convert.ToBoolean(row.Cells["SelectRow"].Value);

                if (isChecked)
                    checkedRows.Add(row);
                else
                    uncheckedRows.Add(row);
            }

            // 🔹 Checked rows → original order preserved
            checkedRows = checkedRows
                .OrderBy(r =>
                    materialOriginalIndex[
                        Convert.ToInt32(r.Cells["Material_ID"].Value)])
                .ToList();

            // 🔹 Unchecked rows → original order preserved
            uncheckedRows = uncheckedRows
                .OrderBy(r =>
                    materialOriginalIndex[
                        Convert.ToInt32(r.Cells["Material_ID"].Value)])
                .ToList();

            DgvMainTable.SuspendLayout();
            DgvMainTable.Rows.Clear();

            foreach (var r in checkedRows)
                DgvMainTable.Rows.Add(r);

            foreach (var r in uncheckedRows)
                DgvMainTable.Rows.Add(r);

            DgvMainTable.ResumeLayout();
        }

        private void DgvMainTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvMainTable.Columns[e.ColumnIndex].Name != "Balance")
                return;

            DataGridViewRow row = DgvMainTable.Rows[e.RowIndex];

            int balance = Convert.ToInt32(row.Cells["Balance"].Value);
            int min = Convert.ToInt32(row.Cells["MinThreshold"].Value);
            int max = Convert.ToInt32(row.Cells["MaxThreshold"].Value);

            Color bg;

            // 🟢 ENOUGH STOCK
            if (balance > max)
            {
                bg = Color.LightGreen;
                row.Cells["Balance"].ToolTipText = "Enough stock, no need to order";
            }
            // 🔴 LOW STOCK
            else if (balance < min)
            {
                bg = Color.LightCoral;
                row.Cells["Balance"].ToolTipText = "Low stock, need to order";
            }
            // 🟡 WARNING
            else
            {
                int warningLevel = min + (int)((max - min) * 0.3);

                if (balance <= warningLevel)
                {
                    bg = Color.Khaki;
                    row.Cells["Balance"].ToolTipText = "Stock is getting low";
                }
                else
                {
                    bg = Color.White;
                    row.Cells["Balance"].ToolTipText = "";
                }
            }

            // ✅ APPLY COLOR
            row.Cells["Balance"].Style.BackColor = bg;

            // 🔥 MOST IMPORTANT LINE
            row.Cells["Balance"].Style.SelectionBackColor = bg;
            row.Cells["Balance"].Style.SelectionForeColor = Color.Black;

        }
        private void RestoreOriginalOrder()
        {
            var rows = DgvMainTable.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .OrderBy(r =>
                    materialOriginalIndex[
                        Convert.ToInt32(r.Cells["Material_ID"].Value)])
                .ToList();

            DgvMainTable.SuspendLayout();
            DgvMainTable.Rows.Clear();

            foreach (var row in rows)
                DgvMainTable.Rows.Add(row);

            DgvMainTable.ResumeLayout();
        }
        public void ClearAllMaterialSelection()
        {
            _isBulkClearing = true;
            selectedMaterialIds.Clear();

            foreach (DataGridViewRow row in DgvMainTable.Rows)
            {
                if (row.IsNewRow) continue;
                row.Cells["SelectRow"].Value = false;
            }

            RestoreOriginalOrder();
            DgvMainTable.ResumeLayout();
            _isBulkClearing = false;
        }

        private void DgvMainTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // agar checkbox column nahi hai → selection block
            if (DgvMainTable.Columns[e.ColumnIndex].Name != "SelectRow")
            {
                DgvMainTable.ClearSelection();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
                ImportFromExcel_AllInOne(ofd.FileName);
        }
        private void ImportFromExcel_AllInOne(string filePath)
        {
            try
            {
                using var wb = new XLWorkbook(filePath);
                var ws = wb.Worksheet(1);

                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                con.Open();

                int row = 2;

                while (!ws.Cell(row, 1).IsEmpty())
                {
                    // ================= READ EXCEL =================
                    string materialName = ws.Cell(row, 1).GetString().Trim();
                    string type = ws.Cell(row, 2).GetString().Trim();
                    string location = ws.Cell(row, 3).GetString().Trim();
                    string category = ws.Cell(row, 4).GetString().Trim();
                    string subCategory = ws.Cell(row, 5).GetString().Trim();
                    string package = ws.Cell(row, 6).GetString().Trim();

                    DateTime usageDate;
                    if (!DateTime.TryParse(ws.Cell(row, 7).GetString(), out usageDate))
                        usageDate = DateTime.Now;

                    string voucher = ws.Cell(row, 8).GetString().Trim();
                    string particular = ws.Cell(row, 9).GetString().Trim();

                    decimal receipt = 0, issued = 0, rate = 0;
                    int min = 0, max = 0;

                    decimal.TryParse(ws.Cell(row, 10).GetString(), out receipt);
                    decimal.TryParse(ws.Cell(row, 11).GetString(), out issued);
                    decimal.TryParse(ws.Cell(row, 12).GetString(), out rate);
                    int.TryParse(ws.Cell(row, 13).GetString(), out min);
                    int.TryParse(ws.Cell(row, 14).GetString(), out max);

                    // ================= MASTER AUTO CREATE =================
                    int typeId = GetOrCreateId(
                        con,
                        "SELECT Type_ID FROM INVENTORY_MASTER..Type_Master WHERE Type_Name=@val",
                        "INSERT INTO INVENTORY_MASTER..Type_Master (Type_Name) OUTPUT INSERTED.Type_ID VALUES (@val)",
                        type);

                    int catId = GetOrCreateId(
                        con,
                        "SELECT Category_ID FROM INVENTORY_MASTER..Category_Master WHERE Category_Name=@val",
                        "INSERT INTO INVENTORY_MASTER..Category_Master (Category_Name) OUTPUT INSERTED.Category_ID VALUES (@val)",
                        category);

                    // 🔥 SUBCATEGORY WITH CATEGORY_ID (IMPORTANT)
                    int subId;
                    using (SqlCommand chk = new SqlCommand(
                        @"SELECT Subcategory_ID 
                  FROM INVENTORY_MASTER..Subcategory_Master
                  WHERE Subcategory_Name=@name AND Category_ID=@catId", con))
                    {
                        chk.Parameters.AddWithValue("@name", subCategory);
                        chk.Parameters.AddWithValue("@catId", catId);

                        object res = chk.ExecuteScalar();
                        if (res != null)
                        {
                            subId = Convert.ToInt32(res);
                        }
                        else
                        {
                            using SqlCommand ins = new SqlCommand(
                                @"INSERT INTO INVENTORY_MASTER..Subcategory_Master
                          (Subcategory_Name, Category_ID)
                          OUTPUT INSERTED.Subcategory_ID
                          VALUES (@name, @catId)", con);

                            ins.Parameters.AddWithValue("@name", subCategory);
                            ins.Parameters.AddWithValue("@catId", catId);

                            subId = Convert.ToInt32(ins.ExecuteScalar());
                        }
                    }

                    int pkgId;

                    // 🔍 check package under same subcategory
                    using (SqlCommand chkPkg = new SqlCommand(
                        @"SELECT Package_ID
      FROM INVENTORY_MASTER..Package_Master
      WHERE Package_Name=@name AND Subcategory_ID=@subId", con))
                    {
                        chkPkg.Parameters.AddWithValue("@name", package);
                        chkPkg.Parameters.AddWithValue("@subId", subId);

                        object res = chkPkg.ExecuteScalar();

                        if (res != null)
                        {
                            pkgId = Convert.ToInt32(res);
                        }
                        else
                        {
                            using SqlCommand insPkg = new SqlCommand(
                                @"INSERT INTO INVENTORY_MASTER..Package_Master
              (Package_Name, Subcategory_ID)
              OUTPUT INSERTED.Package_ID
              VALUES (@name, @subId)", con);

                            insPkg.Parameters.AddWithValue("@name", package);
                            insPkg.Parameters.AddWithValue("@subId", subId);

                            pkgId = Convert.ToInt32(insPkg.ExecuteScalar());
                        }
                    }


                    // ================= MATERIAL INSERT =================
                    int materialId;
                    using (SqlCommand chkMat = new SqlCommand(
                        "SELECT Material_ID FROM INVENTORY_MASTER..Material_Table WHERE Material_Name=@name", con))
                    {
                        chkMat.Parameters.AddWithValue("@name", materialName);
                        object res = chkMat.ExecuteScalar();

                        if (res != null)
                        {
                            materialId = Convert.ToInt32(res);
                        }
                        else
                        {
                            using SqlCommand insMat = new SqlCommand(@"
INSERT INTO INVENTORY_MASTER..Material_Table
(Material_Name, Type_ID, Location, Category_ID, Subcategory_ID, Package_ID, MinThreshold, MaxThreshold)
OUTPUT INSERTED.Material_ID
VALUES
(@name,@type,@loc,@cat,@sub,@pkg,@min,@max)", con);

                            insMat.Parameters.AddWithValue("@name", materialName);
                            insMat.Parameters.AddWithValue("@type", typeId);
                            insMat.Parameters.AddWithValue("@loc", location);
                            insMat.Parameters.AddWithValue("@cat", catId);
                            insMat.Parameters.AddWithValue("@sub", subId);
                            insMat.Parameters.AddWithValue("@pkg", pkgId);
                            insMat.Parameters.AddWithValue("@min", min);
                            insMat.Parameters.AddWithValue("@max", max);

                            materialId = Convert.ToInt32(insMat.ExecuteScalar());
                        }
                    }

                    // ================= USAGE INSERT =================
                    decimal balance = receipt - issued;
                    if (balance < 0) balance = 0;

                    decimal totalValue = balance * rate;

                    using SqlCommand insUsage = new SqlCommand(@"
INSERT INTO INVENTORY_MASTER..Usage_Table
(Material_ID, Usage_Date, V_NO_And_B_NO, Particular,
 Receipt, Issued, Rate_Per_Qty, Balance, Total_Value)
VALUES
(@mid,@date,@vno,@part,
 @rec,@iss,@rate,@bal,@total)", con);

                    insUsage.Parameters.AddWithValue("@mid", materialId);
                    insUsage.Parameters.AddWithValue("@date", usageDate);
                    insUsage.Parameters.AddWithValue("@vno", voucher);
                    insUsage.Parameters.AddWithValue("@part", particular);
                    insUsage.Parameters.AddWithValue("@rec", receipt);
                    insUsage.Parameters.AddWithValue("@iss", issued);
                    insUsage.Parameters.AddWithValue("@rate", rate);
                    insUsage.Parameters.AddWithValue("@bal", balance);
                    insUsage.Parameters.AddWithValue("@total", totalValue);

                    insUsage.ExecuteNonQuery();


                    // ================= FIFO =================
                    ApplyFIFO(materialId);

                    row++;
                }

                LoadMainGrid();
                MessageBox.Show("Import completed successfully ✔", "Import");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}



