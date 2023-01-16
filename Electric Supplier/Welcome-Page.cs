using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electric_Supplier
{
    public partial class Welcome_Page : Form
    {
        public Welcome_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There are two options:" + Environment.NewLine + Environment.NewLine + 
                "Charging Slow: Is basic option there won't be fees." + Environment.NewLine +
                "Charging Fast: Will cost you an additional £8.20." + Environment.NewLine + Environment.NewLine +
                "The noraml charge is £5.00 per hour.", "Cost Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Welcome_Page_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Start(object sender, EventArgs e)
        {
            Form1 mainPage = new Form1();
            this.Hide();
            mainPage.ShowDialog();
            this.Close();
        }
    }
}
