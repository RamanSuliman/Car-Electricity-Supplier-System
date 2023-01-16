using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Electric_Supplier
{
    public partial class PIN_Numbers : Form
    {
        TextBox tt;
        public PIN_Numbers()
        {
            InitializeComponent();
            this.TopMost = true;  // make the keyboard always in front of the other forms
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(400, 600);
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        private void PIN_Numbers_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        public void setTextBoxForOutput(TextBox t)
        {
            tt = t;  // 
        }

        private void button_Click(object sender, EventArgs e)
        {
            tt.Text += ((Button)sender).Text;
        }

        public void disableButtuns()
        {
            btn_0.Enabled = false;
            btn_1.Enabled = false;
            btn_2.Enabled = false;
            btn_3.Enabled = false;
            btn4.Enabled = false;
            btn_5.Enabled = false;
            btn_6.Enabled = false;
            btn_7.Enabled = false;
            btn_8.Enabled = false;
            btn_9.Enabled = false;
        }

        public void enableButtuns()
        {
            btn_0.Enabled = true;
            btn_1.Enabled = true;
            btn_2.Enabled = true;
            btn_3.Enabled = true;
            btn4.Enabled = true;
            btn_5.Enabled = true;
            btn_6.Enabled = true;
            btn_7.Enabled = true;
            btn_8.Enabled = true;
            btn_9.Enabled = true;
        }

        private void button_remove(object sender, EventArgs e)
        {
            tt.Clear();
        }

        private void move_one_out_Click(object sender, EventArgs e)
        {
            if (tt.TextLength != 0)
            {
                tt.Text = tt.Text.Substring(0, tt.Text.Length - 1);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
