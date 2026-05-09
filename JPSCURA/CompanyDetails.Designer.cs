namespace JPSCURA
{
    partial class CompanyDetails
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
            pnlMianCpmpanyDeatils = new Panel();
            pnlContent = new Panel();
            pictureBoxQR = new PictureBox();
            pnlMianCpmpanyDeatils.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).BeginInit();
            SuspendLayout();
            // 
            // pnlMianCpmpanyDeatils
            // 
            pnlMianCpmpanyDeatils.BackColor = Color.White;
            pnlMianCpmpanyDeatils.Controls.Add(pnlContent);
            pnlMianCpmpanyDeatils.Dock = DockStyle.Fill;
            pnlMianCpmpanyDeatils.Location = new Point(0, 0);
            pnlMianCpmpanyDeatils.Name = "pnlMianCpmpanyDeatils";
            pnlMianCpmpanyDeatils.Size = new Size(1273, 704);
            pnlMianCpmpanyDeatils.TabIndex = 0;
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContent.Controls.Add(pictureBoxQR);
            pnlContent.Location = new Point(436, 152);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(400, 400);
            pnlContent.TabIndex = 0;
            // 
            // pictureBoxQR
            // 
            pictureBoxQR.Dock = DockStyle.Fill;
            pictureBoxQR.Image = Properties.Resources.QR1Code;
            pictureBoxQR.Location = new Point(0, 0);
            pictureBoxQR.Name = "pictureBoxQR";
            pictureBoxQR.Size = new Size(400, 400);
            pictureBoxQR.TabIndex = 0;
            pictureBoxQR.TabStop = false;
            // 
            // CompanyDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1273, 704);
            Controls.Add(pnlMianCpmpanyDeatils);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CompanyDetails";
            Text = "CompanyDetails";
            pnlMianCpmpanyDeatils.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMianCpmpanyDeatils;
        private Panel pnlContent;
        private PictureBox pictureBoxQR;
    }
}