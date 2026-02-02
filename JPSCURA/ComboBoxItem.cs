using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPSCURA
{
    public class ComboBoxItem
    {
        public int Id { get; set; }        // EmpId / DeptId
        public int ExtraId { get; set; }   // RoleId
        public string Text { get; set; }   // Display text
        public string EmpName { get; set; } // ✅ Real Employee Name

        public override string ToString()
        {
            return Text;
        }
    }
}

