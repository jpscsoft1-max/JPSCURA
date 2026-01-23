using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPSCURA
{
    public static class ResponsiveHelper
    {
        public static void AdjustMaterialLayout(Form form)
        {
            if (form.Width < 1600)
            {
                foreach (Control c in form.Controls)
                {
                    if (c.Left > 1200)   // right column
                    {
                        c.Top += 220;   // push down
                        c.Left -= 700;  // bring to middle
                    }
                }
            }
        }
    }
}