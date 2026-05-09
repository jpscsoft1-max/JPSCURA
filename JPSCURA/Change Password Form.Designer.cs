namespace JPSCURA
{
    partial class Change_Password_Form
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
            pnlRequests = new Panel();
            dgvChangePassRequest = new DataGridView();
            panelSearchRequests = new Panel();
            txtSearchEmpName = new TextBox();
            txtSearchUsername = new TextBox();
            txtSearchStatus = new TextBox();
            pnlRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChangePassRequest).BeginInit();
            panelSearchRequests.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRequests
            // 
            pnlRequests.BackColor = Color.White;
            pnlRequests.Controls.Add(dgvChangePassRequest);
            pnlRequests.Controls.Add(panelSearchRequests);
            pnlRequests.Dock = DockStyle.Fill;
            pnlRequests.Location = new Point(0, 0);
            pnlRequests.Name = "pnlRequests";
            pnlRequests.Size = new Size(1280, 741);
            pnlRequests.TabIndex = 0;
            // 
            // dgvChangePassRequest
            // 
            dgvChangePassRequest.BackgroundColor = Color.White;
            dgvChangePassRequest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChangePassRequest.Dock = DockStyle.Fill;
            dgvChangePassRequest.Location = new Point(0, 50);
            dgvChangePassRequest.Name = "dgvChangePassRequest";
            dgvChangePassRequest.Size = new Size(1280, 691);
            dgvChangePassRequest.TabIndex = 1;
            // 
            // panelSearchRequests
            // 
            panelSearchRequests.BackColor = Color.FromArgb(83, 144, 204);
            panelSearchRequests.Controls.Add(txtSearchStatus);
            panelSearchRequests.Controls.Add(txtSearchUsername);
            panelSearchRequests.Controls.Add(txtSearchEmpName);
            panelSearchRequests.Dock = DockStyle.Top;
            panelSearchRequests.Location = new Point(0, 0);
            panelSearchRequests.Name = "panelSearchRequests";
            panelSearchRequests.Size = new Size(1280, 50);
            panelSearchRequests.TabIndex = 0;
            // 
            // txtSearchEmpName
            // 
            txtSearchEmpName.Location = new Point(378, 14);
            txtSearchEmpName.Name = "txtSearchEmpName";
            txtSearchEmpName.PlaceholderText = "   Search By EMP Name";
            txtSearchEmpName.Size = new Size(100, 23);
            txtSearchEmpName.TabIndex = 10;
            // 
            // txtSearchUsername
            // 
            txtSearchUsername.Location = new Point(484, 14);
            txtSearchUsername.Name = "txtSearchUsername";
            txtSearchUsername.PlaceholderText = "   Search By User Name";
            txtSearchUsername.Size = new Size(100, 23);
            txtSearchUsername.TabIndex = 11;
            // 
            // txtSearchStatus
            // 
            txtSearchStatus.Location = new Point(590, 14);
            txtSearchStatus.Name = "txtSearchStatus";
            txtSearchStatus.PlaceholderText = "   Search By status";
            txtSearchStatus.Size = new Size(100, 23);
            txtSearchStatus.TabIndex = 12;
            // 
            // Change_Password_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 741);
            Controls.Add(pnlRequests);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Change_Password_Form";
            Text = "Change_Password_Form";
            Load += Change_Password_Form_Load;
            pnlRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChangePassRequest).EndInit();
            panelSearchRequests.ResumeLayout(false);
            panelSearchRequests.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRequests;
        private Panel panelSearchRequests;
        private DataGridView dgvChangePassRequest;
        private TextBox txtSearchRole;
        private TextBox txtSearchDepartment;
        private TextBox txtSearchContact;
        private TextBox txtSearchEmpName;
        private TextBox txtSearchStatus;
        private TextBox txtSearchUsername;
    }
}