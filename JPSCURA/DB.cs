using System.Configuration;
using System.Windows.Forms;

namespace JPSCURA
{
    public static class DBconection
    {
        public static string GetConnectionString()
        {
            var cs = ConfigurationManager.ConnectionStrings["DBconection"];

            if (cs == null)
            {
                MessageBox.Show(
                    "Connection string 'DBconection' not found.\nCheck App.config.",
                    "Config Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return "";
            }

            return cs.ConnectionString;
        }
    }
}
