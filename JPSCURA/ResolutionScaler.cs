using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPSCURA
{
    public static class ResolutionScaler
    {
        private static float scaleX;
        private static float scaleY;

        public static void ApplyScaling(Form form, int designWidth = 1920, int designHeight = 1080)
        {
            float currentWidth = Screen.PrimaryScreen.Bounds.Width;
            float currentHeight = Screen.PrimaryScreen.Bounds.Height;

            scaleX = currentWidth / designWidth;
            scaleY = currentHeight / designHeight;

            ScaleControl(form);
        }

        private static void ScaleControl(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.Left = (int)(c.Left * scaleX);
                c.Top = (int)(c.Top * scaleY);
                c.Width = (int)(c.Width * scaleX);
                c.Height = (int)(c.Height * scaleY);

                // Scale font
                c.Font = new Font(
                    c.Font.FontFamily,
                    c.Font.Size * Math.Min(scaleX, scaleY),
                    c.Font.Style
                );

                if (c.HasChildren)
                    ScaleControl(c);
            }
        }
    }
}
