using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPSCURA
{
    public partial class AddOrderForm : Form
    {
        public AddOrderForm()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void panelWOaddorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            cmbStatus.DataSource = null;

            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.Clear();
            cmbStatus.Items.Insert(0, "-Select Status-");
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Future Order");
            cmbStatus.Items.Add("Order In Process");
            cmbStatus.Items.Add("Finsihed Order");
            cmbStatus.SelectedIndex = 0;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
