using System.Windows.Forms;
using System.Windows.Controls.Occ;

namespace WorldGen.Forms.TestForm
{
    public partial class Form2 : Form
    {

        private System.Windows.Controls.Occ.DataGrid dg;

        public Form2()
        {
            InitializeComponent();

            dg = new System.Windows.Controls.Occ.DataGrid();
            
            dg.ItemsSource = new Recordset()

        }
    }
}
