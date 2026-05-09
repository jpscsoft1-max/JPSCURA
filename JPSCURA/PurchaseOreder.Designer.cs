namespace JPSCURA
{
    partial class PurchaseOreder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlPurchaseOrder = new Panel();
            panel1 = new Panel();
            txtSerachVendorName = new TextBox();
            txtSearchStatus = new TextBox();
            txtSearchPO = new TextBox();
            btnModifyPO = new Button();
            btnADDPO = new Button();
            btnDeletePO = new Button();
            dataGridView1 = new DataGridView();
            pnlPurchaseOrder.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pnlPurchaseOrder
            // 
            pnlPurchaseOrder.Controls.Add(dataGridView1);
            pnlPurchaseOrder.Controls.Add(panel1);
            pnlPurchaseOrder.Dock = DockStyle.Fill;
            pnlPurchaseOrder.Location = new Point(0, 0);
            pnlPurchaseOrder.Name = "pnlPurchaseOrder";
            pnlPurchaseOrder.Size = new Size(1386, 677);
            pnlPurchaseOrder.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(83, 144, 204);
            panel1.Controls.Add(btnDeletePO);
            panel1.Controls.Add(txtSerachVendorName);
            panel1.Controls.Add(txtSearchStatus);
            panel1.Controls.Add(txtSearchPO);
            panel1.Controls.Add(btnModifyPO);
            panel1.Controls.Add(btnADDPO);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1386, 50);
            panel1.TabIndex = 0;
            // 
            // txtSerachVendorName
            // 
            txtSerachVendorName.Location = new Point(749, 14);
            txtSerachVendorName.Name = "txtSerachVendorName";
            txtSerachVendorName.PlaceholderText = "   Search By Customer Name";
            txtSerachVendorName.Size = new Size(100, 23);
            txtSerachVendorName.TabIndex = 23;
            // 
            // txtSearchStatus
            // 
            txtSearchStatus.Location = new Point(643, 14);
            txtSearchStatus.Name = "txtSearchStatus";
            txtSearchStatus.PlaceholderText = "   Search By Status";
            txtSearchStatus.Size = new Size(100, 23);
            txtSearchStatus.TabIndex = 22;
            // 
            // txtSearchPO
            // 
            txtSearchPO.Location = new Point(537, 14);
            txtSearchPO.Name = "txtSearchPO";
            txtSearchPO.PlaceholderText = "   Search By Quotation Number";
            txtSearchPO.Size = new Size(100, 23);
            txtSearchPO.TabIndex = 21;
            // 
            // btnModifyPO
            // 
            btnModifyPO.Cursor = Cursors.Hand;
            btnModifyPO.Dock = DockStyle.Left;
            btnModifyPO.FlatAppearance.BorderSize = 0;
            btnModifyPO.FlatStyle = FlatStyle.Flat;
            btnModifyPO.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModifyPO.Image = Properties.Resources.development;
            btnModifyPO.ImageAlign = ContentAlignment.MiddleLeft;
            btnModifyPO.Location = new Point(90, 0);
            btnModifyPO.Name = "btnModifyPO";
            btnModifyPO.Size = new Size(107, 50);
            btnModifyPO.TabIndex = 2;
            btnModifyPO.Text = "Modify";
            btnModifyPO.TextAlign = ContentAlignment.MiddleRight;
            btnModifyPO.UseVisualStyleBackColor = true;
            // 
            // btnADDPO
            // 
            btnADDPO.Cursor = Cursors.Hand;
            btnADDPO.Dock = DockStyle.Left;
            btnADDPO.FlatAppearance.BorderSize = 0;
            btnADDPO.FlatStyle = FlatStyle.Flat;
            btnADDPO.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnADDPO.Image = Properties.Resources.addition;
            btnADDPO.ImageAlign = ContentAlignment.MiddleLeft;
            btnADDPO.Location = new Point(0, 0);
            btnADDPO.Name = "btnADDPO";
            btnADDPO.Size = new Size(90, 50);
            btnADDPO.TabIndex = 1;
            btnADDPO.Text = "ADD";
            btnADDPO.TextAlign = ContentAlignment.MiddleRight;
            btnADDPO.UseVisualStyleBackColor = true;
            // 
            // btnDeletePO
            // 
            btnDeletePO.Cursor = Cursors.Hand;
            btnDeletePO.Dock = DockStyle.Right;
            btnDeletePO.FlatAppearance.BorderSize = 0;
            btnDeletePO.FlatStyle = FlatStyle.Flat;
            btnDeletePO.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeletePO.Image = Properties.Resources.trash;
            btnDeletePO.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeletePO.Location = new Point(1279, 0);
            btnDeletePO.Name = "btnDeletePO";
            btnDeletePO.Size = new Size(107, 50);
            btnDeletePO.TabIndex = 24;
            btnDeletePO.Text = "Delete";
            btnDeletePO.TextAlign = ContentAlignment.MiddleRight;
            btnDeletePO.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Size = new Size(1386, 627);
            dataGridView1.TabIndex = 1;
            // 
            // PurchaseOreder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1386, 677);
            Controls.Add(pnlPurchaseOrder);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PurchaseOreder";
            Text = "PurchaseOreder";
            pnlPurchaseOrder.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPurchaseOrder;
        private Panel panel1;
        private Button btnADDPO;
        private Button btnModifyPO;
        private TextBox txtSerachVendorName;
        private TextBox txtSearchStatus;
        private TextBox txtSearchPO;
        private Button btnDeletePO;
        private DataGridView dataGridView1;
    }
}