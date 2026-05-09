using System;
using System.Drawing;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class CompanyDetails : Form
    {
        public CompanyDetails()
        {
            InitializeComponent();

            // 🔥 IMPORTANT (scaling issue fix)
            this.AutoScaleMode = AutoScaleMode.None;

            // Events
            this.Load += CompanyDetails_Load;
            this.Resize += CompanyDetails_Resize;
        }

        private void CompanyDetails_Load(object sender, EventArgs e)
        {
            SetupUI();
            CenterPanel();
        }

        private void CompanyDetails_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void SetupUI()
        {
            // ✅ pnlContent settings
            pnlContent.Anchor = AnchorStyles.None;
            pnlContent.Dock = DockStyle.None;

            // ✅ QR image fix (cut issue)
            if (pictureBoxQR != null)
            {
                pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void CenterPanel()
        {
            if (pnlContent == null) return;

            int x = (this.ClientSize.Width - pnlContent.Width) / 2;
            int y = (this.ClientSize.Height - pnlContent.Height) / 2;

            // 🔥 Safety (negative na ho)
            if (x < 0) x = 0;
            if (y < 0) y = 0;

            pnlContent.Location = new Point(x, y);
        }
    }
}