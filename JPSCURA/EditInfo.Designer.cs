namespace JPSCURA
{
    partial class EditInfo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMainEditInfo = new Panel();
            panelCard = new Panel();
            tblProfile = new TableLayoutPanel();
            txtIFSC = new TextBox();
            lblIFSc = new Label();
            txtDepartment = new TextBox();
            txtRole = new TextBox();
            txtBloodGroup = new TextBox();
            txtBankAcc = new TextBox();
            txtAddress = new TextBox();
            txtAadhar = new TextBox();
            txtEmail = new TextBox();
            txtAltContact = new TextBox();
            txtContact = new TextBox();
            txtName = new TextBox();
            lblEmpCode = new Label();
            lblConatct = new Label();
            lblALTNo = new Label();
            lblNAme = new Label();
            lblEmail = new Label();
            lblAaddhar = new Label();
            lblAddress = new Label();
            lblAccNo = new Label();
            lblBloodGroup = new Label();
            lblRole = new Label();
            lblDepartment = new Label();
            txtEmpCode = new TextBox();
            panelHeader = new Panel();
            btnSaveUSer = new Button();
            lblEditProfile = new Label();
            panelMainEditInfo.SuspendLayout();
            panelCard.SuspendLayout();
            tblProfile.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainEditInfo
            // 
            panelMainEditInfo.BackColor = Color.FromArgb(83, 144, 204);
            panelMainEditInfo.Controls.Add(panelCard);
            panelMainEditInfo.Controls.Add(panelHeader);
            panelMainEditInfo.Dock = DockStyle.Fill;
            panelMainEditInfo.Location = new Point(0, 0);
            panelMainEditInfo.Name = "panelMainEditInfo";
            panelMainEditInfo.Size = new Size(1372, 675);
            panelMainEditInfo.TabIndex = 0;
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(tblProfile);
            panelCard.Dock = DockStyle.Fill;
            panelCard.Location = new Point(0, 55);
            panelCard.Margin = new Padding(40);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(1372, 620);
            panelCard.TabIndex = 0;
            // 
            // tblProfile
            // 
            tblProfile.ColumnCount = 4;
            tblProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tblProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tblProfile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblProfile.Controls.Add(txtIFSC, 1, 6);
            tblProfile.Controls.Add(lblIFSc, 0, 6);
            tblProfile.Controls.Add(txtDepartment, 3, 5);
            tblProfile.Controls.Add(txtRole, 1, 5);
            tblProfile.Controls.Add(txtBloodGroup, 3, 4);
            tblProfile.Controls.Add(txtBankAcc, 1, 4);
            tblProfile.Controls.Add(txtAddress, 1, 3);
            tblProfile.Controls.Add(txtAadhar, 3, 2);
            tblProfile.Controls.Add(txtEmail, 1, 2);
            tblProfile.Controls.Add(txtAltContact, 3, 1);
            tblProfile.Controls.Add(txtContact, 1, 1);
            tblProfile.Controls.Add(txtName, 3, 0);
            tblProfile.Controls.Add(lblEmpCode, 0, 0);
            tblProfile.Controls.Add(lblConatct, 0, 1);
            tblProfile.Controls.Add(lblALTNo, 2, 1);
            tblProfile.Controls.Add(lblNAme, 2, 0);
            tblProfile.Controls.Add(lblEmail, 0, 2);
            tblProfile.Controls.Add(lblAaddhar, 2, 2);
            tblProfile.Controls.Add(lblAddress, 0, 3);
            tblProfile.Controls.Add(lblAccNo, 0, 4);
            tblProfile.Controls.Add(lblBloodGroup, 2, 4);
            tblProfile.Controls.Add(lblRole, 0, 5);
            tblProfile.Controls.Add(lblDepartment, 2, 5);
            tblProfile.Controls.Add(txtEmpCode, 1, 0);
            tblProfile.Dock = DockStyle.Fill;
            tblProfile.Location = new Point(0, 0);
            tblProfile.Name = "tblProfile";
            tblProfile.Padding = new Padding(30);
            tblProfile.RowCount = 8;
            tblProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tblProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tblProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tblProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tblProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tblProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tblProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tblProfile.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tblProfile.Size = new Size(1372, 620);
            tblProfile.TabIndex = 0;
            // 
            // txtIFSC
            // 
            txtIFSC.BackColor = Color.White;
            txtIFSC.BorderStyle = BorderStyle.None;
            txtIFSC.Dock = DockStyle.Fill;
            txtIFSC.Location = new Point(251, 328);
            txtIFSC.Name = "txtIFSC";
            txtIFSC.ReadOnly = true;
            txtIFSC.Size = new Size(431, 16);
            txtIFSC.TabIndex = 26;
            // 
            // lblIFSc
            // 
            lblIFSc.AutoSize = true;
            lblIFSc.Dock = DockStyle.Fill;
            lblIFSc.FlatStyle = FlatStyle.Flat;
            lblIFSc.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIFSc.Location = new Point(33, 325);
            lblIFSc.Name = "lblIFSc";
            lblIFSc.Size = new Size(212, 45);
            lblIFSc.TabIndex = 25;
            lblIFSc.Text = "IFSC Code";
            lblIFSc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDepartment
            // 
            txtDepartment.BackColor = Color.White;
            txtDepartment.BorderStyle = BorderStyle.None;
            txtDepartment.Dock = DockStyle.Fill;
            txtDepartment.Location = new Point(906, 283);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.ReadOnly = true;
            txtDepartment.Size = new Size(433, 16);
            txtDepartment.TabIndex = 24;
            // 
            // txtRole
            // 
            txtRole.BackColor = Color.White;
            txtRole.BorderStyle = BorderStyle.None;
            txtRole.Dock = DockStyle.Fill;
            txtRole.Location = new Point(251, 283);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(431, 16);
            txtRole.TabIndex = 23;
            // 
            // txtBloodGroup
            // 
            txtBloodGroup.BackColor = Color.White;
            txtBloodGroup.BorderStyle = BorderStyle.None;
            txtBloodGroup.Dock = DockStyle.Fill;
            txtBloodGroup.Location = new Point(906, 238);
            txtBloodGroup.Name = "txtBloodGroup";
            txtBloodGroup.ReadOnly = true;
            txtBloodGroup.Size = new Size(433, 16);
            txtBloodGroup.TabIndex = 22;
            // 
            // txtBankAcc
            // 
            txtBankAcc.BackColor = Color.White;
            txtBankAcc.BorderStyle = BorderStyle.None;
            txtBankAcc.Dock = DockStyle.Fill;
            txtBankAcc.Location = new Point(251, 238);
            txtBankAcc.Name = "txtBankAcc";
            txtBankAcc.ReadOnly = true;
            txtBankAcc.Size = new Size(431, 16);
            txtBankAcc.TabIndex = 21;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.None;
            tblProfile.SetColumnSpan(txtAddress, 3);
            txtAddress.Dock = DockStyle.Fill;
            txtAddress.Location = new Point(251, 168);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(1088, 64);
            txtAddress.TabIndex = 18;
            // 
            // txtAadhar
            // 
            txtAadhar.BackColor = Color.White;
            txtAadhar.BorderStyle = BorderStyle.None;
            txtAadhar.Dock = DockStyle.Fill;
            txtAadhar.Location = new Point(906, 123);
            txtAadhar.Name = "txtAadhar";
            txtAadhar.ReadOnly = true;
            txtAadhar.Size = new Size(433, 16);
            txtAadhar.TabIndex = 17;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(251, 123);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(431, 16);
            txtEmail.TabIndex = 16;
            // 
            // txtAltContact
            // 
            txtAltContact.BorderStyle = BorderStyle.None;
            txtAltContact.Dock = DockStyle.Fill;
            txtAltContact.Location = new Point(906, 78);
            txtAltContact.Name = "txtAltContact";
            txtAltContact.Size = new Size(433, 16);
            txtAltContact.TabIndex = 15;
            // 
            // txtContact
            // 
            txtContact.BorderStyle = BorderStyle.None;
            txtContact.Dock = DockStyle.Fill;
            txtContact.Location = new Point(251, 78);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(431, 16);
            txtContact.TabIndex = 14;
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.None;
            txtName.Dock = DockStyle.Fill;
            txtName.Location = new Point(906, 33);
            txtName.Name = "txtName";
            txtName.Size = new Size(433, 16);
            txtName.TabIndex = 13;
            // 
            // lblEmpCode
            // 
            lblEmpCode.AutoSize = true;
            lblEmpCode.Dock = DockStyle.Fill;
            lblEmpCode.FlatStyle = FlatStyle.Flat;
            lblEmpCode.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmpCode.Location = new Point(33, 30);
            lblEmpCode.Name = "lblEmpCode";
            lblEmpCode.Size = new Size(212, 45);
            lblEmpCode.TabIndex = 0;
            lblEmpCode.Text = "EMP Code";
            lblEmpCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblConatct
            // 
            lblConatct.AutoSize = true;
            lblConatct.Dock = DockStyle.Fill;
            lblConatct.FlatStyle = FlatStyle.Flat;
            lblConatct.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConatct.Location = new Point(33, 75);
            lblConatct.Name = "lblConatct";
            lblConatct.Size = new Size(212, 45);
            lblConatct.TabIndex = 1;
            lblConatct.Text = "Contact No";
            lblConatct.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblALTNo
            // 
            lblALTNo.AutoSize = true;
            lblALTNo.Dock = DockStyle.Fill;
            lblALTNo.FlatStyle = FlatStyle.Flat;
            lblALTNo.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblALTNo.Location = new Point(688, 75);
            lblALTNo.Name = "lblALTNo";
            lblALTNo.Size = new Size(212, 45);
            lblALTNo.TabIndex = 2;
            lblALTNo.Text = "ALT Contact No";
            lblALTNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNAme
            // 
            lblNAme.AutoSize = true;
            lblNAme.Dock = DockStyle.Fill;
            lblNAme.FlatStyle = FlatStyle.Flat;
            lblNAme.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNAme.Location = new Point(688, 30);
            lblNAme.Name = "lblNAme";
            lblNAme.Size = new Size(212, 45);
            lblNAme.TabIndex = 3;
            lblNAme.Text = "Name";
            lblNAme.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.FlatStyle = FlatStyle.Flat;
            lblEmail.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(33, 120);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(212, 45);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAaddhar
            // 
            lblAaddhar.AutoSize = true;
            lblAaddhar.Dock = DockStyle.Fill;
            lblAaddhar.FlatStyle = FlatStyle.Flat;
            lblAaddhar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAaddhar.Location = new Point(688, 120);
            lblAaddhar.Name = "lblAaddhar";
            lblAaddhar.Size = new Size(212, 45);
            lblAaddhar.TabIndex = 5;
            lblAaddhar.Text = "Aadhar Card No";
            lblAaddhar.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Dock = DockStyle.Fill;
            lblAddress.FlatStyle = FlatStyle.Flat;
            lblAddress.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddress.Location = new Point(33, 165);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(212, 70);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Address";
            lblAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAccNo
            // 
            lblAccNo.AutoSize = true;
            lblAccNo.Dock = DockStyle.Fill;
            lblAccNo.FlatStyle = FlatStyle.Flat;
            lblAccNo.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccNo.Location = new Point(33, 235);
            lblAccNo.Name = "lblAccNo";
            lblAccNo.Size = new Size(212, 45);
            lblAccNo.TabIndex = 8;
            lblAccNo.Text = "Account No";
            lblAccNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBloodGroup
            // 
            lblBloodGroup.AutoSize = true;
            lblBloodGroup.Dock = DockStyle.Fill;
            lblBloodGroup.FlatStyle = FlatStyle.Flat;
            lblBloodGroup.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBloodGroup.Location = new Point(688, 235);
            lblBloodGroup.Name = "lblBloodGroup";
            lblBloodGroup.Size = new Size(212, 45);
            lblBloodGroup.TabIndex = 9;
            lblBloodGroup.Text = "Blood Group";
            lblBloodGroup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Dock = DockStyle.Fill;
            lblRole.FlatStyle = FlatStyle.Flat;
            lblRole.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.Location = new Point(33, 280);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(212, 45);
            lblRole.TabIndex = 10;
            lblRole.Text = "Role";
            lblRole.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Dock = DockStyle.Fill;
            lblDepartment.FlatStyle = FlatStyle.Flat;
            lblDepartment.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartment.Location = new Point(688, 280);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(212, 45);
            lblDepartment.TabIndex = 11;
            lblDepartment.Text = "Department";
            lblDepartment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmpCode
            // 
            txtEmpCode.BackColor = Color.White;
            txtEmpCode.BorderStyle = BorderStyle.None;
            txtEmpCode.Dock = DockStyle.Fill;
            txtEmpCode.Location = new Point(251, 33);
            txtEmpCode.Name = "txtEmpCode";
            txtEmpCode.ReadOnly = true;
            txtEmpCode.Size = new Size(431, 16);
            txtEmpCode.TabIndex = 12;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(83, 144, 204);
            panelHeader.Controls.Add(btnSaveUSer);
            panelHeader.Controls.Add(lblEditProfile);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1372, 55);
            panelHeader.TabIndex = 1;
            // 
            // btnSaveUSer
            // 
            btnSaveUSer.Cursor = Cursors.Hand;
            btnSaveUSer.Dock = DockStyle.Right;
            btnSaveUSer.FlatAppearance.BorderSize = 0;
            btnSaveUSer.FlatStyle = FlatStyle.Flat;
            btnSaveUSer.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveUSer.Location = new Point(1282, 0);
            btnSaveUSer.Name = "btnSaveUSer";
            btnSaveUSer.Size = new Size(90, 55);
            btnSaveUSer.TabIndex = 0;
            btnSaveUSer.Text = "Save";
            btnSaveUSer.Click += btnSaveUSer_Click;
            // 
            // lblEditProfile
            // 
            lblEditProfile.Cursor = Cursors.Hand;
            lblEditProfile.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblEditProfile.Image = Properties.Resources.edit_profile;
            lblEditProfile.ImageAlign = ContentAlignment.TopLeft;
            lblEditProfile.Location = new Point(12, 10);
            lblEditProfile.Name = "lblEditProfile";
            lblEditProfile.Size = new Size(119, 34);
            lblEditProfile.TabIndex = 1;
            lblEditProfile.Text = "Edit Profile";
            lblEditProfile.TextAlign = ContentAlignment.MiddleRight;
            lblEditProfile.Click += lblEditProfile_Click;
            // 
            // EditInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1372, 675);
            Controls.Add(panelMainEditInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditInfo";
            Text = "EditInfo";
            Load += EditInfo_Load;
            panelMainEditInfo.ResumeLayout(false);
            panelCard.ResumeLayout(false);
            tblProfile.ResumeLayout(false);
            tblProfile.PerformLayout();
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // 🔒 REQUIRED DECLARATIONS (ERROR FIX)
        private System.Windows.Forms.Panel panelMainEditInfo;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TableLayoutPanel tblProfile;
        private System.Windows.Forms.Button btnSaveUSer;
        private System.Windows.Forms.Label lblEditProfile;
        private Label lblAccNo;
        private Label lblEmpCode;
        private Label lblConatct;
        private Label lblALTNo;
        private Label lblNAme;
        private Label lblEmail;
        private Label lblAaddhar;
        private Label lblAddress;
        private Label lblBloodGroup;
        private Label lblRole;
        private Label lblDepartment;
        private TextBox txtDepartment;
        private TextBox txtRole;
        private TextBox txtBloodGroup;
        private TextBox txtBankAcc;
        private TextBox txtAddress;
        private TextBox txtAadhar;
        private TextBox txtEmail;
        private TextBox txtAltContact;
        private TextBox txtContact;
        private TextBox txtName;
        private TextBox txtEmpCode;
        private TextBox txtIFSC;
        private Label lblIFSc;
    }
}
