using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class InventoryTransaction : Form
    {

        private int _materialId;
        //public InventoryTransactionData TransactionData { get; private set; }
        public InventoryTransaction(int materialId)
        {
            InitializeComponent();
            _materialId = materialId;

            cmbSelect.Items.Clear();
            cmbSelect.Items.Add("Receipt");
            cmbSelect.Items.Add("Issued");
            cmbSelect.SelectedIndex = 0;
        }

        public InventoryTransaction()
        {
            InitializeComponent();
        }

        private void InventoryTransaction_Load(object sender, EventArgs e)
        {

            cmbSelect.Items.Clear();
            cmbSelect.Items.Add("Receipt");
            cmbSelect.Items.Add("Issued");
            cmbSelect.SelectedIndex = 0;
            txtRate.Enabled = true;
            ApplyUI();
        }

        private void cmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelect.Text == "Receipt")
            {
                lblQty.Text = "Receipt Qty";
            }
            else if (cmbSelect.Text == "Issued")
            {
                lblQty.Text = "Issued Qty";
            }
            ApplyUI();
        }

        private void ApplyUI()
        {
            if (cmbSelect.Text == "Issued")
            {
                txtRate.Enabled = false;   // 🔒 ONLY disable
            }
            else
            {
                txtRate.Enabled = true;    // 🔓 enable for Receipt
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Qty validation (common)
                if (!decimal.TryParse(txtQty.Text, out decimal qty) || qty <= 0)
                {
                    MessageBox.Show("Invalid Quantity");
                    return;
                }

                decimal rate = 0;

                // 2️⃣ Rate validation ONLY for Receipt
                if (cmbSelect.Text == "Receipt")
                {
                    if (!decimal.TryParse(txtRate.Text, out rate) || rate <= 0)
                    {
                        MessageBox.Show("Invalid Rate");
                        return;
                    }
                }

                decimal receipt = 0;
                decimal issued = 0;

                if (cmbSelect.Text == "Receipt")
                    receipt = qty;
                else if (cmbSelect.Text == "Issued")
                    issued = qty;
                else
                {
                    MessageBox.Show("Please select Receipt or Issued");
                    return;
                }
                // 🔒 BLOCK NEGATIVE BALANCE (ONLY FOR ISSUED)
                if (cmbSelect.Text == "Issued")
                {
                    decimal availableBalance = GetCurrentMaterialBalance(_materialId);

                    if (issued > availableBalance)
                    {
                        MessageBox.Show(
                            "Issued quantity cannot be greater than available balance.",
                            "Stock Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return; // ❌ STOP SAVE
                    }
                }


                using (SqlConnection con = new SqlConnection(DBconection.GetConnectionString()))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"
INSERT INTO INVENTORY_MASTER..Usage_Table
(Material_ID, Usage_Date, Particular,
 Receipt, Issued, Rate_Per_Qty, Balance, Total_Value)
VALUES
(@mid, @date, @part, @rec, @iss, @rate, 0, 0)", con);

                    cmd.Parameters.AddWithValue("@mid", _materialId);
                    cmd.Parameters.AddWithValue("@date", dtDate.Value);
                    cmd.Parameters.AddWithValue("@part", textparticular.Text.Trim());
                    cmd.Parameters.AddWithValue("@rec", receipt);
                    cmd.Parameters.AddWithValue("@iss", issued);
                    cmd.Parameters.AddWithValue("@rate", rate);

                    cmd.ExecuteNonQuery();
                }


                DialogResult = DialogResult.OK;
                Close();


            }
            catch (Exception ty)
            {
                MessageBox.Show(" " + ty);
            }
        }
            private decimal GetCurrentMaterialBalance(int materialId)
        {
            using SqlConnection con = new SqlConnection(DBconection.GetConnectionString());
            SqlCommand cmd = new SqlCommand(@"
        SELECT ISNULL(SUM(Receipt - Issued), 0)
        FROM INVENTORY_MASTER..Usage_Table
        WHERE Material_ID = @mid", con);

            cmd.Parameters.AddWithValue("@mid", materialId);
            con.Open();

            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        
        private void NumericWithDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Allow control keys (Backspace)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow only ONE decimal point
            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;

            // Block everything else
            e.Handled = true;
        }

        private void textparticular_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow letters, space and backspace
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetter(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true; // block input
            }
        }
    }
}
