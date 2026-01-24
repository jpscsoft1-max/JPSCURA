using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPSCURA
{
    public class ComboBoxItem
    {
        public int Id { get; set; }        // EmpId / DepartmentId
        public int ExtraId { get; set; }   // RoleId (sirf Employee ke liye)
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}

