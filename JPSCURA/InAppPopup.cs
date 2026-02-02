using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class InAppPopup : Form
    {
        private System.Windows.Forms.Timer autoCloseTimer;
        private bool autoClose;

        public InAppPopup(string message, Color bgColor, bool autoClosePopup, int autoCloseMs = 3000)
        {
            InitializeComponent();

            lblMessage.Text = message;
            BackColor = bgColor;
            autoClose = autoClosePopup;

            Load += InAppPopup_Load;

            if (autoClose)
            {
                autoCloseTimer = new System.Windows.Forms.Timer();
                autoCloseTimer.Interval = autoCloseMs;
                autoCloseTimer.Tick += (s, e) =>
                {
                    autoCloseTimer.Stop();
                    Close();
                };
            }
        }

        private void InAppPopup_Load(object sender, EventArgs e)
        {
            var screen = Screen.PrimaryScreen.WorkingArea;

            Left = screen.Right - Width - 20;
            Top = screen.Bottom - Height - 20;

            if (autoClose)
                autoCloseTimer.Start();
        }
    }
}


