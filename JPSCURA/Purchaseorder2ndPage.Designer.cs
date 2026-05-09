namespace JPSCURA
{
    partial class Purchaseorder2ndPage
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
            pnlMainContent = new Panel();
            pnlButton = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlleftPO = new Panel();
            pnlrightPO = new Panel();
            btnClearPO = new Button();
            txtCity = new TextBox();
            txtBuyersreferenceanddate = new TextBox();
            lblreferncedate = new Label();
            txtkindattname = new TextBox();
            txtState = new TextBox();
            lblKingAttn = new Label();
            lblCustomerAddress = new Label();
            txtPinCode = new TextBox();
            dtQuotationDate = new DateTimePicker();
            txtAddressLine1 = new TextBox();
            lblquotationdate = new Label();
            txtAddressLine2 = new TextBox();
            cmbselectvendor = new ComboBox();
            lblSelectVendor = new Label();
            txtShipCity = new TextBox();
            txtPANNo = new TextBox();
            txtShipState = new TextBox();
            txtShipPinCode = new TextBox();
            txtShipAddressLine2 = new TextBox();
            rdoPAN = new RadioButton();
            txtShipAddressLine1 = new TextBox();
            rdoGST = new RadioButton();
            lblCustShippingaddress = new Label();
            cmbgst = new ComboBox();
            lblGST = new Label();
            txtQuotationNo = new TextBox();
            lblQuotationNo = new Label();
            pnlMainContent.SuspendLayout();
            pnlButton.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlleftPO.SuspendLayout();
            pnlrightPO.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMainContent
            // 
            pnlMainContent.Controls.Add(pnlButton);
            pnlMainContent.Controls.Add(tableLayoutPanel1);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1370, 788);
            pnlMainContent.TabIndex = 0;
            // 
            // pnlButton
            // 
            pnlButton.Controls.Add(btnClearPO);
            pnlButton.Dock = DockStyle.Top;
            pnlButton.Location = new Point(0, 350);
            pnlButton.Name = "pnlButton";
            pnlButton.Size = new Size(1370, 50);
            pnlButton.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pnlleftPO, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlrightPO, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1370, 350);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlleftPO
            // 
            pnlleftPO.Controls.Add(txtCity);
            pnlleftPO.Controls.Add(lblSelectVendor);
            pnlleftPO.Controls.Add(txtBuyersreferenceanddate);
            pnlleftPO.Controls.Add(cmbselectvendor);
            pnlleftPO.Controls.Add(lblreferncedate);
            pnlleftPO.Controls.Add(txtAddressLine2);
            pnlleftPO.Controls.Add(txtkindattname);
            pnlleftPO.Controls.Add(lblquotationdate);
            pnlleftPO.Controls.Add(txtState);
            pnlleftPO.Controls.Add(txtAddressLine1);
            pnlleftPO.Controls.Add(lblKingAttn);
            pnlleftPO.Controls.Add(dtQuotationDate);
            pnlleftPO.Controls.Add(lblCustomerAddress);
            pnlleftPO.Controls.Add(txtPinCode);
            pnlleftPO.Dock = DockStyle.Fill;
            pnlleftPO.Location = new Point(3, 3);
            pnlleftPO.Name = "pnlleftPO";
            pnlleftPO.Size = new Size(679, 344);
            pnlleftPO.TabIndex = 0;
            // 
            // pnlrightPO
            // 
            pnlrightPO.Controls.Add(txtShipCity);
            pnlrightPO.Controls.Add(txtPANNo);
            pnlrightPO.Controls.Add(txtShipState);
            pnlrightPO.Controls.Add(txtShipPinCode);
            pnlrightPO.Controls.Add(txtShipAddressLine2);
            pnlrightPO.Controls.Add(rdoPAN);
            pnlrightPO.Controls.Add(txtShipAddressLine1);
            pnlrightPO.Controls.Add(rdoGST);
            pnlrightPO.Controls.Add(lblCustShippingaddress);
            pnlrightPO.Controls.Add(cmbgst);
            pnlrightPO.Controls.Add(lblGST);
            pnlrightPO.Controls.Add(txtQuotationNo);
            pnlrightPO.Controls.Add(lblQuotationNo);
            pnlrightPO.Dock = DockStyle.Fill;
            pnlrightPO.Location = new Point(688, 3);
            pnlrightPO.Name = "pnlrightPO";
            pnlrightPO.Size = new Size(679, 344);
            pnlrightPO.TabIndex = 1;
            // 
            // btnClearPO
            // 
            btnClearPO.Anchor = AnchorStyles.Top;
            btnClearPO.BackColor = Color.ForestGreen;
            btnClearPO.Cursor = Cursors.Hand;
            btnClearPO.FlatAppearance.BorderSize = 0;
            btnClearPO.FlatAppearance.MouseDownBackColor = Color.Red;
            btnClearPO.FlatAppearance.MouseOverBackColor = Color.Red;
            btnClearPO.FlatStyle = FlatStyle.Flat;
            btnClearPO.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearPO.ForeColor = Color.SeaShell;
            btnClearPO.Location = new Point(615, 11);
            btnClearPO.Margin = new Padding(3, 2, 3, 2);
            btnClearPO.Name = "btnClearPO";
            btnClearPO.Size = new Size(141, 29);
            btnClearPO.TabIndex = 32;
            btnClearPO.Text = "Clear";
            btnClearPO.UseVisualStyleBackColor = false;
            // 
            // txtCity
            // 
            txtCity.BackColor = SystemColors.Window;
            txtCity.Location = new Point(248, 267);
            txtCity.Margin = new Padding(3, 2, 3, 2);
            txtCity.Multiline = true;
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "   Enter City";
            txtCity.ReadOnly = true;
            txtCity.RightToLeft = RightToLeft.No;
            txtCity.Size = new Size(410, 21);
            txtCity.TabIndex = 60;
            // 
            // txtBuyersreferenceanddate
            // 
            txtBuyersreferenceanddate.Location = new Point(248, 153);
            txtBuyersreferenceanddate.Name = "txtBuyersreferenceanddate";
            txtBuyersreferenceanddate.PlaceholderText = "    Reference Note";
            txtBuyersreferenceanddate.Size = new Size(410, 23);
            txtBuyersreferenceanddate.TabIndex = 54;
            // 
            // lblreferncedate
            // 
            lblreferncedate.AutoSize = true;
            lblreferncedate.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblreferncedate.ForeColor = Color.White;
            lblreferncedate.Location = new Point(9, 155);
            lblreferncedate.Name = "lblreferncedate";
            lblreferncedate.Size = new Size(233, 19);
            lblreferncedate.TabIndex = 53;
            lblreferncedate.Text = "Buyer's Reference And Date :";
            // 
            // txtkindattname
            // 
            txtkindattname.Location = new Point(248, 113);
            txtkindattname.Name = "txtkindattname";
            txtkindattname.PlaceholderText = "   Concerned Person Name";
            txtkindattname.Size = new Size(410, 23);
            txtkindattname.TabIndex = 52;
            // 
            // txtState
            // 
            txtState.BackColor = SystemColors.Window;
            txtState.Location = new Point(248, 293);
            txtState.Margin = new Padding(3, 2, 3, 2);
            txtState.Multiline = true;
            txtState.Name = "txtState";
            txtState.PlaceholderText = "   Enter State";
            txtState.ReadOnly = true;
            txtState.RightToLeft = RightToLeft.No;
            txtState.Size = new Size(410, 21);
            txtState.TabIndex = 59;
            // 
            // lblKingAttn
            // 
            lblKingAttn.AutoSize = true;
            lblKingAttn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKingAttn.ForeColor = Color.White;
            lblKingAttn.Location = new Point(9, 115);
            lblKingAttn.Name = "lblKingAttn";
            lblKingAttn.Size = new Size(175, 19);
            lblKingAttn.TabIndex = 51;
            lblKingAttn.Text = "Kind Attention Name :";
            // 
            // lblCustomerAddress
            // 
            lblCustomerAddress.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerAddress.ForeColor = Color.White;
            lblCustomerAddress.Location = new Point(9, 190);
            lblCustomerAddress.Name = "lblCustomerAddress";
            lblCustomerAddress.Size = new Size(170, 23);
            lblCustomerAddress.TabIndex = 55;
            lblCustomerAddress.Text = "Billing Address :";
            lblCustomerAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPinCode
            // 
            txtPinCode.BackColor = SystemColors.Window;
            txtPinCode.Location = new Point(248, 242);
            txtPinCode.Margin = new Padding(3, 2, 3, 2);
            txtPinCode.Multiline = true;
            txtPinCode.Name = "txtPinCode";
            txtPinCode.PlaceholderText = "   Enter Pin Code";
            txtPinCode.ReadOnly = true;
            txtPinCode.RightToLeft = RightToLeft.No;
            txtPinCode.Size = new Size(410, 21);
            txtPinCode.TabIndex = 58;
            // 
            // dtQuotationDate
            // 
            dtQuotationDate.Location = new Point(248, 67);
            dtQuotationDate.Name = "dtQuotationDate";
            dtQuotationDate.Size = new Size(410, 23);
            dtQuotationDate.TabIndex = 50;
            // 
            // txtAddressLine1
            // 
            txtAddressLine1.BackColor = SystemColors.Window;
            txtAddressLine1.Location = new Point(248, 192);
            txtAddressLine1.Margin = new Padding(3, 2, 3, 2);
            txtAddressLine1.Multiline = true;
            txtAddressLine1.Name = "txtAddressLine1";
            txtAddressLine1.PlaceholderText = "   Address Line 1";
            txtAddressLine1.ReadOnly = true;
            txtAddressLine1.RightToLeft = RightToLeft.No;
            txtAddressLine1.Size = new Size(410, 21);
            txtAddressLine1.TabIndex = 56;
            // 
            // lblquotationdate
            // 
            lblquotationdate.AutoSize = true;
            lblquotationdate.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblquotationdate.ForeColor = Color.White;
            lblquotationdate.Location = new Point(9, 71);
            lblquotationdate.Name = "lblquotationdate";
            lblquotationdate.Size = new Size(142, 19);
            lblquotationdate.TabIndex = 49;
            lblquotationdate.Text = "Quoatation Date :";
            // 
            // txtAddressLine2
            // 
            txtAddressLine2.BackColor = SystemColors.Window;
            txtAddressLine2.Location = new Point(248, 217);
            txtAddressLine2.Margin = new Padding(3, 2, 3, 2);
            txtAddressLine2.Multiline = true;
            txtAddressLine2.Name = "txtAddressLine2";
            txtAddressLine2.PlaceholderText = "   Address Line 2";
            txtAddressLine2.ReadOnly = true;
            txtAddressLine2.RightToLeft = RightToLeft.No;
            txtAddressLine2.Size = new Size(410, 21);
            txtAddressLine2.TabIndex = 57;
            // 
            // cmbselectvendor
            // 
            cmbselectvendor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbselectvendor.FormattingEnabled = true;
            cmbselectvendor.Location = new Point(248, 30);
            cmbselectvendor.Name = "cmbselectvendor";
            cmbselectvendor.Size = new Size(410, 23);
            cmbselectvendor.TabIndex = 48;
            // 
            // lblSelectVendor
            // 
            lblSelectVendor.AutoSize = true;
            lblSelectVendor.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectVendor.ForeColor = Color.White;
            lblSelectVendor.Location = new Point(9, 30);
            lblSelectVendor.Name = "lblSelectVendor";
            lblSelectVendor.Size = new Size(145, 19);
            lblSelectVendor.TabIndex = 47;
            lblSelectVendor.Text = "Select Customer :";
            // 
            // txtShipCity
            // 
            txtShipCity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipCity.BackColor = SystemColors.Window;
            txtShipCity.Location = new Point(227, 269);
            txtShipCity.Margin = new Padding(3, 2, 3, 2);
            txtShipCity.Multiline = true;
            txtShipCity.Name = "txtShipCity";
            txtShipCity.PlaceholderText = "   Enter City";
            txtShipCity.ReadOnly = true;
            txtShipCity.RightToLeft = RightToLeft.No;
            txtShipCity.Size = new Size(410, 21);
            txtShipCity.TabIndex = 63;
            // 
            // txtPANNo
            // 
            txtPANNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPANNo.Location = new Point(227, 115);
            txtPANNo.Name = "txtPANNo";
            txtPANNo.PlaceholderText = "   PAN No";
            txtPANNo.Size = new Size(410, 23);
            txtPANNo.TabIndex = 57;
            // 
            // txtShipState
            // 
            txtShipState.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipState.BackColor = SystemColors.Window;
            txtShipState.Location = new Point(227, 295);
            txtShipState.Margin = new Padding(3, 2, 3, 2);
            txtShipState.Multiline = true;
            txtShipState.Name = "txtShipState";
            txtShipState.PlaceholderText = "   Enter State";
            txtShipState.ReadOnly = true;
            txtShipState.RightToLeft = RightToLeft.No;
            txtShipState.Size = new Size(410, 21);
            txtShipState.TabIndex = 62;
            // 
            // txtShipPinCode
            // 
            txtShipPinCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipPinCode.BackColor = SystemColors.Window;
            txtShipPinCode.Location = new Point(227, 244);
            txtShipPinCode.Margin = new Padding(3, 2, 3, 2);
            txtShipPinCode.Multiline = true;
            txtShipPinCode.Name = "txtShipPinCode";
            txtShipPinCode.PlaceholderText = "   Enter Pin Code";
            txtShipPinCode.ReadOnly = true;
            txtShipPinCode.RightToLeft = RightToLeft.No;
            txtShipPinCode.Size = new Size(410, 21);
            txtShipPinCode.TabIndex = 61;
            // 
            // txtShipAddressLine2
            // 
            txtShipAddressLine2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipAddressLine2.BackColor = SystemColors.Window;
            txtShipAddressLine2.Location = new Point(227, 219);
            txtShipAddressLine2.Margin = new Padding(3, 2, 3, 2);
            txtShipAddressLine2.Multiline = true;
            txtShipAddressLine2.Name = "txtShipAddressLine2";
            txtShipAddressLine2.PlaceholderText = "   Address Line 2";
            txtShipAddressLine2.ReadOnly = true;
            txtShipAddressLine2.RightToLeft = RightToLeft.No;
            txtShipAddressLine2.Size = new Size(410, 21);
            txtShipAddressLine2.TabIndex = 60;
            // 
            // rdoPAN
            // 
            rdoPAN.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rdoPAN.AutoSize = true;
            rdoPAN.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdoPAN.ForeColor = Color.White;
            rdoPAN.Location = new Point(135, 115);
            rdoPAN.Name = "rdoPAN";
            rdoPAN.Size = new Size(86, 23);
            rdoPAN.TabIndex = 56;
            rdoPAN.TabStop = true;
            rdoPAN.Text = "PAN No";
            rdoPAN.UseVisualStyleBackColor = true;
            // 
            // txtShipAddressLine1
            // 
            txtShipAddressLine1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtShipAddressLine1.BackColor = SystemColors.Window;
            txtShipAddressLine1.Location = new Point(227, 194);
            txtShipAddressLine1.Margin = new Padding(3, 2, 3, 2);
            txtShipAddressLine1.Multiline = true;
            txtShipAddressLine1.Name = "txtShipAddressLine1";
            txtShipAddressLine1.PlaceholderText = "   Address Line 1";
            txtShipAddressLine1.ReadOnly = true;
            txtShipAddressLine1.RightToLeft = RightToLeft.No;
            txtShipAddressLine1.Size = new Size(410, 21);
            txtShipAddressLine1.TabIndex = 59;
            // 
            // rdoGST
            // 
            rdoGST.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rdoGST.AutoSize = true;
            rdoGST.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rdoGST.ForeColor = Color.White;
            rdoGST.Location = new Point(43, 115);
            rdoGST.Name = "rdoGST";
            rdoGST.Size = new Size(86, 23);
            rdoGST.TabIndex = 55;
            rdoGST.TabStop = true;
            rdoGST.Text = "GST No";
            rdoGST.UseVisualStyleBackColor = true;
            // 
            // lblCustShippingaddress
            // 
            lblCustShippingaddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCustShippingaddress.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustShippingaddress.ForeColor = Color.White;
            lblCustShippingaddress.Location = new Point(43, 192);
            lblCustShippingaddress.Name = "lblCustShippingaddress";
            lblCustShippingaddress.Size = new Size(170, 23);
            lblCustShippingaddress.TabIndex = 58;
            lblCustShippingaddress.Text = "Shipping Address :";
            lblCustShippingaddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbgst
            // 
            cmbgst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbgst.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbgst.FormattingEnabled = true;
            cmbgst.Location = new Point(227, 73);
            cmbgst.Name = "cmbgst";
            cmbgst.Size = new Size(410, 23);
            cmbgst.TabIndex = 54;
            // 
            // lblGST
            // 
            lblGST.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGST.AutoSize = true;
            lblGST.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGST.ForeColor = Color.White;
            lblGST.Location = new Point(42, 75);
            lblGST.Name = "lblGST";
            lblGST.Size = new Size(52, 19);
            lblGST.TabIndex = 53;
            lblGST.Text = "GST :";
            // 
            // txtQuotationNo
            // 
            txtQuotationNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtQuotationNo.Location = new Point(227, 29);
            txtQuotationNo.Name = "txtQuotationNo";
            txtQuotationNo.PlaceholderText = "   Quotation No";
            txtQuotationNo.Size = new Size(410, 23);
            txtQuotationNo.TabIndex = 52;
            // 
            // lblQuotationNo
            // 
            lblQuotationNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblQuotationNo.AutoSize = true;
            lblQuotationNo.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuotationNo.ForeColor = Color.White;
            lblQuotationNo.Location = new Point(42, 32);
            lblQuotationNo.Name = "lblQuotationNo";
            lblQuotationNo.Size = new Size(129, 19);
            lblQuotationNo.TabIndex = 51;
            lblQuotationNo.Text = "Quoatation No :";
            // 
            // Purchaseorder2ndPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(83, 144, 204);
            ClientSize = new Size(1370, 788);
            Controls.Add(pnlMainContent);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Purchaseorder2ndPage";
            Text = "Purchaseorder2ndPage";
            pnlMainContent.ResumeLayout(false);
            pnlButton.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlleftPO.ResumeLayout(false);
            pnlleftPO.PerformLayout();
            pnlrightPO.ResumeLayout(false);
            pnlrightPO.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMainContent;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlleftPO;
        private Panel pnlrightPO;
        private Panel pnlButton;
        private Button btnClearPO;
        private TextBox txtCity;
        private Label lblSelectVendor;
        private TextBox txtBuyersreferenceanddate;
        private ComboBox cmbselectvendor;
        private Label lblreferncedate;
        private TextBox txtAddressLine2;
        private TextBox txtkindattname;
        private Label lblquotationdate;
        private TextBox txtState;
        private TextBox txtAddressLine1;
        private Label lblKingAttn;
        private DateTimePicker dtQuotationDate;
        private Label lblCustomerAddress;
        private TextBox txtPinCode;
        private TextBox txtShipCity;
        private TextBox txtPANNo;
        private TextBox txtShipState;
        private TextBox txtShipPinCode;
        private TextBox txtShipAddressLine2;
        private RadioButton rdoPAN;
        private TextBox txtShipAddressLine1;
        private RadioButton rdoGST;
        private Label lblCustShippingaddress;
        private ComboBox cmbgst;
        private Label lblGST;
        private TextBox txtQuotationNo;
        private Label lblQuotationNo;
    }
}