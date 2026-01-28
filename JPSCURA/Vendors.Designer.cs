namespace JPSCURA
{
    partial class Vendors
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
            panelContentvendor = new Panel();
            panelCard = new Panel();
            panelContent = new Panel();
            panelContentvendor.SuspendLayout();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelContentvendor
            // 
            panelContentvendor.BackColor = Color.FromArgb(83, 144, 204);
            panelContentvendor.Controls.Add(panelCard);
            panelContentvendor.Dock = DockStyle.Fill;
            panelContentvendor.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelContentvendor.Location = new Point(0, 0);
            panelContentvendor.Name = "panelContentvendor";
            panelContentvendor.Size = new Size(1213, 699);
            panelContentvendor.TabIndex = 0;
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.FromArgb(83, 144, 204);
            panelCard.Controls.Add(panelContent);
            panelCard.Dock = DockStyle.Fill;
            panelCard.Location = new Point(0, 0);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(1213, 699);
            panelCard.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1213, 699);
            panelContent.TabIndex = 0;
            // 
            // Vendors
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 699);
            Controls.Add(panelContentvendor);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Vendors";
            Text = "Vendors";
           
            panelContentvendor.ResumeLayout(false);
            panelCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContentvendor;
        private Panel panelCard;
        private Panel panelContent;
    }
}