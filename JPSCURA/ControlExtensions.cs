using System.Reflection;
using System.Windows.Forms;

namespace JPSCURA
{
    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            PropertyInfo prop =
                typeof(Control).GetProperty(
                    "DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance);

            prop?.SetValue(control, enable, null);
        }
    }
}
