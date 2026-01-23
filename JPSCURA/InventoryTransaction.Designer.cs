namespace JPSCURA
{
    partial class InventoryTransaction
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
            panelPOPUP = new Panel();
            txtQty = new TextBox();
            lblQty = new Label();
            btnOK = new Button();
            txtRate = new TextBox();
            lblRate = new Label();
            cmbSelect = new ComboBox();
            lblSelect = new Label();
            textparticular = new TextBox();
            labelParticular = new Label();
            dtDate = new DateTimePicker();
            lblDate = new Label();
            panelPOPUP.SuspendLayout();
            SuspendLayout();
            // 
            // panelPOPUP
            // 
            panelPOPUP.BackColor = Color.RoyalBlue;
            panelPOPUP.Controls.Add(txtQty);
            panelPOPUP.Controls.Add(lblQty);
            panelPOPUP.Controls.Add(btnOK);
            panelPOPUP.Controls.Add(txtRate);
            panelPOPUP.Controls.Add(lblRate);
            panelPOPUP.Controls.Add(cmbSelect);
            panelPOPUP.Controls.Add(lblSelect);
            panelPOPUP.Controls.Add(textparticular);
            panelPOPUP.Controls.Add(labelParticular);
            panelPOPUP.Controls.Add(dtDate);
            panelPOPUP.Controls.Add(lblDate);
            panelPOPUP.Dock = DockStyle.Fill;
            panelPOPUP.Location = new Point(0, 0);
            panelPOPUP.Margin = new Padding(3, 2, 3, 2);
            panelPOPUP.Name = "panelPOPUP";
            panelPOPUP.Size = new Size(452, 290);
            panelPOPUP.TabIndex = 0;
            // 
            // txtQty
            // 
            txtQty.Location = new Point(114, 148);
            txtQty.Margin = new Padding(3, 2, 3, 2);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(196, 23);
            txtQty.TabIndex = 10;
            txtQty.KeyPress += NumericWithDecimal_KeyPress;
            // 
            // lblQty
            // 
            lblQty.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQty.ForeColor = Color.White;
            lblQty.Location = new Point(17, 152);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(92, 17);
            lblQty.TabIndex = 9;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.DodgerBlue;
            btnOK.Cursor = Cursors.Hand;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(114, 235);
            btnOK.Margin = new Padding(3, 2, 3, 2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(82, 22);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // txtRate
            // 
            txtRate.Location = new Point(114, 188);
            txtRate.Margin = new Padding(3, 2, 3, 2);
            txtRate.Name = "txtRate";
            txtRate.PlaceholderText = "   Enter Rate";
            txtRate.Size = new Size(196, 23);
            txtRate.TabIndex = 7;
            txtRate.KeyPress += NumericWithDecimal_KeyPress;
            // 
            // lblRate
            // 
            lblRate.AutoSize = true;
            lblRate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRate.ForeColor = Color.White;
            lblRate.Location = new Point(17, 188);
            lblRate.Name = "lblRate";
            lblRate.Size = new Size(49, 18);
            lblRate.TabIndex = 6;
            lblRate.Text = "Rate :";
            // 
            // cmbSelect
            // 
            cmbSelect.FormattingEnabled = true;
            cmbSelect.Items.AddRange(new object[] { "Reciept", "Issued" });
            cmbSelect.Location = new Point(114, 104);
            cmbSelect.Margin = new Padding(3, 2, 3, 2);
            cmbSelect.Name = "cmbSelect";
            cmbSelect.Size = new Size(196, 23);
            cmbSelect.TabIndex = 5;
            cmbSelect.SelectedIndexChanged += cmbSelect_SelectedIndexChanged;
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSelect.ForeColor = Color.White;
            lblSelect.Location = new Point(17, 107);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(60, 18);
            lblSelect.TabIndex = 4;
            lblSelect.Text = "Select :";
            // 
            // textparticular
            // 
            textparticular.Location = new Point(114, 63);
            textparticular.Margin = new Padding(3, 2, 3, 2);
            textparticular.Name = "textparticular";
            textparticular.PlaceholderText = "   Write Particular";
            textparticular.Size = new Size(196, 23);
            textparticular.TabIndex = 3;
            textparticular.KeyPress += textparticular_KeyPress;
            // 
            // labelParticular
            // 
            labelParticular.AutoSize = true;
            labelParticular.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelParticular.ForeColor = Color.White;
            labelParticular.Location = new Point(17, 63);
            labelParticular.Name = "labelParticular";
            labelParticular.Size = new Size(82, 18);
            labelParticular.TabIndex = 2;
            labelParticular.Text = "Particular :";
            // 
            // dtDate
            // 
            dtDate.Format = DateTimePickerFormat.Short;
            dtDate.Location = new Point(114, 13);
            dtDate.Margin = new Padding(3, 2, 3, 2);
            dtDate.Name = "dtDate";
            dtDate.Size = new Size(196, 23);
            dtDate.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(17, 14);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(50, 18);
            lblDate.TabIndex = 0;
            lblDate.Text = "Date :";
            // 
            // InventoryTransaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(452, 290);
            Controls.Add(panelPOPUP);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "InventoryTransaction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InventoryTransaction";
            Load += InventoryTransaction_Load;
            panelPOPUP.ResumeLayout(false);
            panelPOPUP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelPOPUP;
        private Label lblDate;
        private TextBox txtRate;
        private Label lblRate;
        private ComboBox cmbSelect;
        private Label lblSelect;
        private TextBox textparticular;
        private Label labelParticular;
        private DateTimePicker dtDate;
        private Button btnOK;
        private TextBox txtQty;
        private Label lblQty;
    }
}