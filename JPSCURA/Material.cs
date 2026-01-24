using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.Word;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class Material : Form
    {
        //string conStr = @"Server=DESKTOP-7VC276D;
        //                  Database=INVENTORY_MASTER;
        //                  User Id=jpscube;
        //                  Password=jpsc@1289;
        //                  TrustServerCertificate=True;";
        private bool _isLoadingCategory = false;
        private DataTable _mainTable;

        public Material()
        {
            InitializeComponent();
            //ResolutionScaler.ApplyScaling(this);
            //ResponsiveHelper.AdjustMaterialLayout(this);
        }


        // ================= SAFE COMBO VALUE =================
        private int GetComboValueSafe(ComboBox cmb)
        {
            if (cmb.SelectedValue == null)
                return 0;

            if (cmb.SelectedValue is DataRowView drv)
                return Convert.ToInt32(drv.Row[0]);

            return Convert.ToInt32(cmb.SelectedValue);
        }

        // ================= FORM LOAD =================
        private void Material_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadTypes();
            cmbMaterialSubCategory.DataSource = null;
            cmbPackage.DataSource = null;
            cmbMaterialCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterialSubCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPackage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypesOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        // ================= LOAD CATEGORY =================
        private void LoadCategory()
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT Category_ID, Category_Name FROM INVENTORY_MASTER..Category_Master ORDER BY Category_Name", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            InsertSelectAndAddNew(dt, "Category_ID", "Category_Name");

            cmbMaterialCategory.DataSource = dt;
            cmbMaterialCategory.DisplayMember = "Category_Name";
            cmbMaterialCategory.ValueMember = "Category_ID";
        }

        // ================= LOAD TYPES =================
        private void LoadTypes()
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT Type_ID, Type_Name FROM INVENTORY_MASTER..Type_Master ORDER BY Type_Name", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            InsertSelectAndAddNew(dt, "Type_ID", "Type_Name");

            cmbTypesOfCategory.DataSource = dt;
            cmbTypesOfCategory.DisplayMember = "Type_Name";
            cmbTypesOfCategory.ValueMember = "Type_ID";
        }

        // ================= LOAD SUB CATEGORY =================
        private void LoadSubCategoryByCategory(int categoryId)
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT Subcategory_ID, Subcategory_Name FROM INVENTORY_MASTER..Subcategory_Master WHERE Category_ID=@cid ORDER BY Subcategory_Name",
                con);

            da.SelectCommand.Parameters.AddWithValue("@cid", categoryId);

            DataTable dt = new DataTable();
            da.Fill(dt);

            InsertSelectAndAddNew(dt, "Subcategory_ID", "Subcategory_Name");

            cmbMaterialSubCategory.DataSource = dt;
            cmbMaterialSubCategory.DisplayMember = "Subcategory_Name";
            cmbMaterialSubCategory.ValueMember = "Subcategory_ID";
        }

        // ================= LOAD PACKAGE =================
        private void LoadPackageBySubCategory(int subId)
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT Package_ID, Package_Name FROM INVENTORY_MASTER..Package_Master WHERE Subcategory_ID=@sid ORDER BY Package_Name",
                con);

            da.SelectCommand.Parameters.AddWithValue("@sid", subId);

            DataTable dt = new DataTable();
            da.Fill(dt);

            InsertSelectAndAddNew(dt, "Package_ID", "Package_Name");

            cmbPackage.DataSource = dt;
            cmbPackage.DisplayMember = "Package_Name";
            cmbPackage.ValueMember = "Package_ID";
        }

        // ================= CATEGORY CHANGE =================
        private void cmbMaterialCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingCategory) return;

            int catId = GetComboValueSafe(cmbMaterialCategory);

            if (catId == -1)
            {
                AddNewCategory();
                return;
            }

            if (catId > 0)
                LoadSubCategoryByCategory(catId);
        }

        private void cmbMaterialSubCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int subId = GetComboValueSafe(cmbMaterialSubCategory);

            if (subId == -1)
            {
                AddNewSubCategory();
                return;
            }

            if (subId > 0)
                LoadPackageBySubCategory(subId);
        }

        // ================= ADD MATERIAL =================
        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaterialName.Text) ||
                string.IsNullOrWhiteSpace(txtReceipt.Text))
            {
                MessageBox.Show("Material Name and Receipt are required");
                return;
            }

            if (!decimal.TryParse(txtReceipt.Text, out decimal receipt))
            {
                MessageBox.Show("Invalid Receipt value");
                return;
            }
            decimal rate = 0;

            // rate is OPTIONAL
            if (!string.IsNullOrWhiteSpace(txtRate.Text))
            {
                if (!decimal.TryParse(txtRate.Text, out rate))
                {
                    MessageBox.Show("Invalid Rate value");
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Location is required");
                txtLocation.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtParticular.Text))
            {
                MessageBox.Show("Particular is required");
                txtParticular.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtvoucherorbillno.Text))
            {
                MessageBox.Show("Voucher/Bill No is required");
                txtvoucherorbillno.Focus();
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtMinThreshold.Text) &&
    !int.TryParse(txtMinThreshold.Text, out _))
            {
                MessageBox.Show("Invalid Min Threshold");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtMaxThreshold.Text) &&
                !int.TryParse(txtMaxThreshold.Text, out _))
            {
                MessageBox.Show("Invalid Max Threshold");
                return;
            }

            decimal totalValue = receipt * rate;

                int catId = GetComboValueSafe(cmbMaterialCategory);
                int subId = GetComboValueSafe(cmbMaterialSubCategory);
                int pkgId = GetComboValueSafe(cmbPackage);
                int typeId = GetComboValueSafe(cmbTypesOfCategory);

                if (catId <= 0 || subId <= 0 || pkgId <= 0 || typeId <= 0)
                {
                    MessageBox.Show("Please select Category, SubCategory, Package and Type");
                    return;
                }

                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                con.Open();

                // 1️⃣ INSERT MATERIAL
                SqlCommand cmdMat = new SqlCommand(@"
INSERT INTO INVENTORY_MASTER..Material_Table
(Material_Name, Category_ID, Subcategory_ID, Package_ID, Type_ID, Location, MinThreshold, MaxThreshold)
OUTPUT INSERTED.Material_ID
VALUES
(@name,@cat,@sub,@pkg,@type,@loc,@min,@max)", con);

                cmdMat.Parameters.AddWithValue("@name", txtMaterialName.Text.Trim());
                cmdMat.Parameters.AddWithValue("@cat", catId);
                cmdMat.Parameters.AddWithValue("@sub", subId);
                cmdMat.Parameters.AddWithValue("@pkg", pkgId);
                cmdMat.Parameters.AddWithValue("@type", typeId);
                cmdMat.Parameters.AddWithValue("@loc", txtLocation.Text.Trim());
            cmdMat.Parameters.AddWithValue("@min",
    string.IsNullOrWhiteSpace(txtMinThreshold.Text) ? 0 : Convert.ToInt32(txtMinThreshold.Text));

            cmdMat.Parameters.AddWithValue("@max",
                string.IsNullOrWhiteSpace(txtMaxThreshold.Text) ? 0 : Convert.ToInt32(txtMaxThreshold.Text));


            int materialId = Convert.ToInt32(cmdMat.ExecuteScalar());

                // 2️⃣ INSERT OPENING STOCK
                SqlCommand cmdOpen = new SqlCommand(@"
INSERT INTO INVENTORY_MASTER..Usage_Table
(Material_ID, Usage_Date, Particular, Receipt, Issued, Rate_Per_Qty, Balance, Total_Value, V_NO_And_B_NO)
VALUES

(@mid, @dt, @part, @rec, 0, @rate, @bal, @total, @vno)", con);

                cmdOpen.Parameters.AddWithValue("@mid", materialId);
                cmdOpen.Parameters.AddWithValue("@dt", dtOpeningDate.Value);
                cmdOpen.Parameters.AddWithValue("@part", txtParticular.Text.Trim());
                cmdOpen.Parameters.AddWithValue("@rec", receipt);
                cmdOpen.Parameters.AddWithValue("@rate", rate);
                cmdOpen.Parameters.AddWithValue("@total", totalValue);
                cmdOpen.Parameters.AddWithValue("@bal", receipt);
                cmdOpen.Parameters.AddWithValue("@vno", txtvoucherorbillno.Text.Trim());

                cmdOpen.ExecuteNonQuery();

                MessageBox.Show("Material added successfully");
                ClearForm();

            }
        

        // ================= RECEIPT → BALANCE =================
        private void txtReceipt_TextChanged(object sender, EventArgs e)
        {
            txtBalance.Text = txtReceipt.Text;
        }

        // ================= ADD NEW HELPERS =================
        private void AddNewCategory()
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter Category Name");
            if (string.IsNullOrWhiteSpace(name)) return;

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            SqlCommand cmd = new SqlCommand(
       "INSERT INTO INVENTORY_MASTER..Category_Master (Category_Name)\r\nOUTPUT INSERTED.Category_ID\r\nVALUES (@n)", con);

            cmd.Parameters.AddWithValue("@n", name);
            con.Open();
            int newCategoryId = Convert.ToInt32(cmd.ExecuteScalar());

            _isLoadingCategory = true;
            LoadCategory();
            cmbMaterialCategory.SelectedValue = newCategoryId;
            LoadSubCategoryByCategory(newCategoryId);

            _isLoadingCategory = false;

            //cmbMaterialCategory.SelectedIndex = cmbMaterialCategory.Items.Count - 1;
        }

        private void AddNewSubCategory()
        {
            int catId = GetComboValueSafe(cmbMaterialCategory);
            if (catId <= 0) return;

            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter Sub Category Name");
            if (string.IsNullOrWhiteSpace(name)) return;

            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO INVENTORY_MASTER..Subcategory_Master (Category_ID, Subcategory_Name)\r\nOUTPUT INSERTED.Subcategory_ID\r\nVALUES (@c,@n)\r\n", con);
            cmd.Parameters.AddWithValue("@c", catId);
            cmd.Parameters.AddWithValue("@n", name);
            con.Open();
            int newSubId = Convert.ToInt32(cmd.ExecuteScalar());
            LoadSubCategoryByCategory(catId);
            cmbMaterialSubCategory.SelectedValue = newSubId;


            //LoadSubCategoryByCategory(catId);
            //cmbMaterialSubCategory.SelectedIndex = cmbMaterialSubCategory.Items.Count - 1;

        }

        // ================= CLEAR =================
        private void ClearForm()
        {
            txtMaterialName.Clear();
            txtReceipt.Clear();
            txtBalance.Clear();
            txtvoucherorbillno.Clear();
            txtParticular.Clear();
            txtLocation.Clear();
            txtRate.Clear();
            txtMaxThreshold.Clear();
            txtMinThreshold.Clear();

            cmbMaterialCategory.SelectedIndex = 0;
            cmbMaterialSubCategory.DataSource = null;
            cmbPackage.DataSource = null;
            cmbTypesOfCategory.SelectedIndex = 0;
            //cmbMaterialSubCategory.SelectedIndex = 0;
            //cmbPackage.SelectedIndex=0;

            dtOpeningDate.Value = DateTime.Today;
        }
        private void ClearAllFields()
        {
            // TextBoxes
            txtMaterialName.Clear();
            txtLocation.Clear();
            txtvoucherorbillno.Clear();
            txtParticular.Clear();
            txtReceipt.Clear();
            txtBalance.Clear();
            txtRate.Clear();

            // ComboBoxes (SAFE)
            if (cmbMaterialCategory.Items.Count > 0)
                cmbMaterialCategory.SelectedIndex = 0;

            cmbMaterialSubCategory.DataSource = null;
            cmbPackage.DataSource = null;

            if (cmbTypesOfCategory.Items.Count > 0)
                cmbTypesOfCategory.SelectedIndex = 0;

            // Date
            dtOpeningDate.Value = DateTime.Today;

            txtMaterialName.Focus();
        }


        // ================= UTIL =================
        private void InsertSelectAndAddNew(DataTable dt, string idCol, string nameCol)
        {
            DataRow select = dt.NewRow();
            select[idCol] = 0;
            select[nameCol] = "-- Select --";
            dt.Rows.InsertAt(select, 0);

            DataRow add = dt.NewRow();
            add[idCol] = -1;
            add[nameCol] = "➕ Add New...";
            dt.Rows.InsertAt(add, 1);
        }

        // ================= PACKAGE ADD =================
        private void cmbPackage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pkgId = GetComboValueSafe(cmbPackage);

            if (pkgId == -1)
            {
                string pkg = Microsoft.VisualBasic.Interaction.InputBox("Enter Package Name");
                if (string.IsNullOrWhiteSpace(pkg)) return;

                int subId = GetComboValueSafe(cmbMaterialSubCategory);
                if (subId <= 0) return;

                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO INVENTORY_MASTER..Package_Master (Subcategory_ID, Package_Name)\r\nOUTPUT INSERTED.Package_ID\r\nVALUES (@s,@p)\r\n", con);
                cmd.Parameters.AddWithValue("@s", subId);
                cmd.Parameters.AddWithValue("@p", pkg);
                con.Open();
                int newPkgId = Convert.ToInt32(cmd.ExecuteScalar());
                LoadPackageBySubCategory(subId);
                cmbPackage.SelectedValue = newPkgId;


                //LoadPackageBySubCategory(subId);
                //cmbPackage.SelectedIndex = cmbPackage.Items.Count - 1;
            }
        }

        // ================= TYPE ADD =================
        private void cmbTypesOfCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int typeId = GetComboValueSafe(cmbTypesOfCategory);

            if (typeId == -1)
            {
                string type = Microsoft.VisualBasic.Interaction.InputBox("Enter Type");
                if (string.IsNullOrWhiteSpace(type)) return;

                using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO INVENTORY_MASTER..Type_Master (Type_Name)\r\nOUTPUT INSERTED.Type_ID\r\nVALUES (@t)\r\n", con);
                cmd.Parameters.AddWithValue("@t", type);
                con.Open();
                int newTypeId = Convert.ToInt32(cmd.ExecuteScalar());
                LoadTypes();
                cmbTypesOfCategory.SelectedValue = newTypeId;


                //LoadTypes();
                //cmbPackage.SelectedIndex = cmbPackage.Items.Count - 1;
            }
        }

        private void txtReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtRate.Text.Trim(), out decimal rate) || rate <= 0)
            {
                MessageBox.Show("Rate is empty or invalid. Cannot export.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            if (!decimal.TryParse(txtReceipt.Text.Trim(), out decimal receipt) || receipt <= 0)
            {
                MessageBox.Show("Receipt quantity is invalid.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            string folderPath = @"E:\JPSCURA_Inventory";
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(
                folderPath,
                $"Inventory_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx");

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Inventory");

                // ===== HEADERS =====
                ws.Cell(1, 1).Value = "Material Name";
                ws.Cell(1, 2).Value = "Category";
                ws.Cell(1, 3).Value = "Sub Category";
                ws.Cell(1, 4).Value = "Type";
                ws.Cell(1, 5).Value = "Location";
                ws.Cell(1, 6).Value = "Package";
                ws.Cell(1, 7).Value = "Opening Date";
                ws.Cell(1, 8).Value = "Voucher / Bill No";
                ws.Cell(1, 9).Value = "Particular";
                ws.Cell(1, 10).Value = "Receipt Qty";
                ws.Cell(1, 11).Value = "Rate";
                ws.Cell(1, 12).Value = "Total Value";

                // Header style
                ws.Range(1, 1, 1, 12).Style.Font.Bold = true;
                ws.Range(1, 1, 1, 12).Style.Fill.BackgroundColor = XLColor.LightGray;

                // ===== DATA =====
                ws.Cell(2, 1).Value = txtMaterialName.Text;
                ws.Cell(2, 2).Value = cmbMaterialCategory.Text;
                ws.Cell(2, 3).Value = cmbMaterialSubCategory.Text;
                ws.Cell(2, 4).Value = cmbTypesOfCategory.Text;
                ws.Cell(2, 5).Value = txtLocation.Text;
                ws.Cell(2, 6).Value = cmbPackage.Text;
                ws.Cell(2, 7).Value = dtOpeningDate.Value.ToString("dd-MM-yyyy");
                ws.Cell(2, 8).Value = txtvoucherorbillno.Text;
                ws.Cell(2, 9).Value = txtParticular.Text;
                ws.Cell(2, 10).Value = receipt;
                ws.Cell(2, 11).Value = rate;

                // 🔥 EXCEL FORMULA (AUTO CALCULATION)
                ws.Cell(2, 12).FormulaA1 = "=J2*K2";

                ws.Columns().AdjustToContents();

                wb.SaveAs(filePath);
            }

            MessageBox.Show(
                $"Excel exported successfully!\n\n{filePath}",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void txtMinThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtMaxThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        //private void ShowLoading()
        //{
        //    pnlLoading.Visible = true;
        //    pnlLoading.BringToFront();
        //    Application.DoEvents(); // force UI refresh
        //}

        //private void HideLoading()
        //{
        //    pnlLoading.Visible = false;
        //}

    }

}
