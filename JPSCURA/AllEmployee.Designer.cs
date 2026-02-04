namespace JPSCURA
{
    partial class AllEmployee
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
            panelEmployee = new Panel();
            dgvEmployee = new DataGridView();
            panelSearchEmp = new Panel();
            txtSearchRole = new TextBox();
            txtSearchDepartment = new TextBox();
            txtSearchContact = new TextBox();
            txtSearchEmpName = new TextBox();
            txtSearchEmpCode = new TextBox();
            panelEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            panelSearchEmp.SuspendLayout();
            SuspendLayout();
            // 
            // panelEmployee
            // 
            panelEmployee.Controls.Add(dgvEmployee);
            panelEmployee.Controls.Add(panelSearchEmp);
            panelEmployee.Dock = DockStyle.Fill;
            panelEmployee.Location = new Point(0, 0);
            panelEmployee.Name = "panelEmployee";
            panelEmployee.Size = new Size(1280, 741);
            panelEmployee.TabIndex = 0;
            // 
            // dgvEmployee
            // 
            dgvEmployee.BackgroundColor = Color.White;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvEmployee.DefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployee.Dock = DockStyle.Fill;
            dgvEmployee.Location = new Point(0, 50);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.Size = new Size(1280, 691);
            dgvEmployee.TabIndex = 1;
            dgvEmployee.CellDoubleClick += dgvEmployee_CellDoubleClick;
            dgvEmployee.CellFormatting += dgvEmployee_CellFormatting;
            dgvEmployee.ColumnWidthChanged += dgvEmployee_ColumnWidthChanged;
            dgvEmployee.RowPostPaint += dgvEmployee_RowPostPaint;
            dgvEmployee.Scroll += dgvEmployee_Scroll;
            // 
            // panelSearchEmp
            // 
            panelSearchEmp.BackColor = Color.FromArgb(83, 144, 204);
            panelSearchEmp.Controls.Add(txtSearchRole);
            panelSearchEmp.Controls.Add(txtSearchDepartment);
            panelSearchEmp.Controls.Add(txtSearchContact);
            panelSearchEmp.Controls.Add(txtSearchEmpName);
            panelSearchEmp.Controls.Add(txtSearchEmpCode);
            panelSearchEmp.Dock = DockStyle.Top;
            panelSearchEmp.Location = new Point(0, 0);
            panelSearchEmp.Name = "panelSearchEmp";
            panelSearchEmp.Size = new Size(1280, 50);
            panelSearchEmp.TabIndex = 0;
            // 
            // txtSearchRole
            // 
            txtSearchRole.Location = new Point(895, 12);
            txtSearchRole.Name = "txtSearchRole";
            txtSearchRole.PlaceholderText = "   Search By Role";
            txtSearchRole.Size = new Size(100, 23);
            txtSearchRole.TabIndex = 9;
            // 
            // txtSearchDepartment
            // 
            txtSearchDepartment.Location = new Point(789, 12);
            txtSearchDepartment.Name = "txtSearchDepartment";
            txtSearchDepartment.PlaceholderText = "   Search By Department";
            txtSearchDepartment.Size = new Size(100, 23);
            txtSearchDepartment.TabIndex = 8;
            // 
            // txtSearchContact
            // 
            txtSearchContact.Location = new Point(683, 12);
            txtSearchContact.Name = "txtSearchContact";
            txtSearchContact.PlaceholderText = "   Search By Contact";
            txtSearchContact.Size = new Size(100, 23);
            txtSearchContact.TabIndex = 7;
            // 
            // txtSearchEmpName
            // 
            txtSearchEmpName.Location = new Point(577, 12);
            txtSearchEmpName.Name = "txtSearchEmpName";
            txtSearchEmpName.PlaceholderText = "   Search By EMP Name";
            txtSearchEmpName.Size = new Size(100, 23);
            txtSearchEmpName.TabIndex = 6;
            // 
            // txtSearchEmpCode
            // 
            txtSearchEmpCode.Location = new Point(471, 12);
            txtSearchEmpCode.Name = "txtSearchEmpCode";
            txtSearchEmpCode.PlaceholderText = "   Search By EMP Code";
            txtSearchEmpCode.Size = new Size(100, 23);
            txtSearchEmpCode.TabIndex = 5;
            // 
            // AllEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 741);
            Controls.Add(panelEmployee);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AllEmployee";
            Text = "AllEmployee";
            Load += AllEmployee_Load;
            Resize += AllEmployee_Resize;
            panelEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            panelSearchEmp.ResumeLayout(false);
            panelSearchEmp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEmployee;
        private Panel panelSearchEmp;
        private TextBox textBox1;
        private TextBox txtSearchMaterial;
        private TextBox textBox10;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox txtSearchEmpCode;
        private DataGridView dgvEmployee;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox txtSearchRole;
        private TextBox txtSearchDepartment;
        private TextBox txtSearchContact;
        private TextBox txtSearchEmpName;
    }
}