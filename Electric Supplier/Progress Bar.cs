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
    public partial class Progress_Bar : Form
    {
        int num = 0;
        int timer = 61;
        private string password;
        private string username;
        public Progress_Bar()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
               
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            num++;
            label1.Text = num.ToString();
            if (label1.Text == "5")
            {
                p1.Visible = true;
            }
            else if (label1.Text == "10")
            {
                p2.Visible = true;
                p1.BackColor = Color.Black;
            }
            else if (label1.Text == "15")
            {
                p3.Visible = true;
                p2.BackColor = Color.Black;
            }
            else if (label1.Text == "20")
            {
                p4.Visible = true;
                p3.BackColor = Color.Black;
            }
            else if (label1.Text == "25")
            {
                p5.Visible = true;
                p4.BackColor = Color.Black;
            }
            else if (label1.Text == "30")
            {
                p6.Visible = true;
                p5.BackColor = Color.Black;
            }
            else if (label1.Text == "35")
            {
                p7.Visible = true;
                p6.BackColor = Color.Black;
            }
            else if (label1.Text == "40")
            {
                p8.Visible = true;
                p7.BackColor = Color.Black;
            }
            else if (label1.Text == "45")
            {
                p9.Visible = true;
                p8.BackColor = Color.Black;
            }
            else if (label1.Text == "50")
            {
                p10.Visible = true;
                p9.BackColor = Color.Black;
            }
            else if (label1.Text == "55")
            {
                p11.Visible = true;
                p10.BackColor = Color.Black;
            }
            else if (label1.Text == "60")
            {
                p12.Visible = true;
                p11.BackColor = Color.Black;
            }
            else if (label1.Text == "65")
            {
                p13.Visible = true;
                p12.BackColor = Color.Black;
            }
            else if (label1.Text == "70")
            {
                p14.Visible = true;
                p13.BackColor = Color.Black;
            }
            else if (label1.Text == "75")
            {
                p15.Visible = true;
                p14.BackColor = Color.Black;
            }
            else if (label1.Text == "80")
            {
                p16.Visible = true;
                p15.BackColor = Color.Black;
            }
            else if (label1.Text == "85")
            {
                p17.Visible = true;
                p16.BackColor = Color.Black;
            }
            else if (label1.Text == "90")
            {
                p18.Visible = true;
                p17.BackColor = Color.Black;
            }
            else if (label1.Text == "95")
            {
                p19.Visible = true;
                p18.BackColor = Color.Black;
            }
            else if (label1.Text == "100")
            {
                p20.Visible = true;
                p19.BackColor = Color.Black;
            }
            else if (label1.Text == "105")
            {
                p21.Visible = true;
                p20.BackColor = Color.Black;
            }
            else if (label1.Text == "110")
            {
                p22.Visible = true;
                p21.BackColor = Color.Black;
            }
            else if (label1.Text == "115")
            {
                p23.Visible = true;
                p22.BackColor = Color.Black;
            }
            else if (label1.Text == "120")
            {
                p24.Visible = true;
                p23.BackColor = Color.Black;
            }
            else if (label1.Text == "125")
            {
                p25.Visible = true;
                p24.BackColor = Color.Black;
            }
            else if (label1.Text == "130")
            {
                p26.Visible = true;
                p25.BackColor = Color.Black;
            }
            else if (label1.Text == "135")
            {
                p27.Visible = true;
                p26.BackColor = Color.Black;
            }
            else if (label1.Text == "140")
            {
                p28.Visible = true;
                p27.BackColor = Color.Black;
            }
            else if (label1.Text == "145")
            {
                p29.Visible = true;
                p28.BackColor = Color.Black;
            }
            else if (label1.Text == "150")
            {
                p30.Visible = true;
                p29.BackColor = Color.Black;
            }
            else if (label1.Text == "155")
            {
                p31.Visible = true;
                p30.BackColor = Color.Black;
            }

            if (label1.Text == "160")
            {
                p31.BackColor = Color.Black;
                timer1.Enabled = false;
                timer3.Enabled = false;
                panel4.Enabled = false;
                DialogResult result = MessageBox.Show("Charging completed!" + Environment.NewLine + Environment.NewLine + "Press 'OK' to end current session 🙂.",
                    "Electrics Transfered", MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (result == DialogResult.OK || result != DialogResult.OK)
                {
                    Welcome_Page mg = new Welcome_Page();
                    this.Hide();
                    mg.ShowDialog();
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            timer1.Enabled = true;
            this.timer1.Start();
        }

        private void Progress_Bar_Load(object sender, EventArgs e)
        {
            label2.Text =  password;
            timer2.Start();
            label14.Text = DateTime.Now.ToLongTimeString();  // just some debugging to see which textbox has focus
            label15.Text = DateTime.Now.ToLongDateString();  // just some debugging to see which textbox has focus
                                                             

            lblPlateName.Text = "Your Car Plate Number: " + username;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer3.Enabled = false;
            DoubleCheckPIN checkPINs = new DoubleCheckPIN();
            checkPINs.setPassword(password);
            checkPINs.passFormValue(this);
            checkPINs.ShowDialog();
        }

        public void closeMe()
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            pressed.BackColor = Color.LightBlue;
            pressed.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            pressed.BackColor = Color.Black;
            pressed.ForeColor = Color.White;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToLongTimeString();
            timer2.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public String ifImageIsOn()
        {
            if (p1.Visible == true)
            {
                return "Yes";          
            }
            return "No";
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer--;
            sessionTimer.Text = timer.ToString();
            if (sessionTimer.Text == "10")
            {
                sessionTimer.ForeColor = Color.Red;
            }
            else if (sessionTimer.Text == "0")
            {
                timer3.Enabled = false;
                Welcome_Page mg = new Welcome_Page();
                this.Hide();
                mg.ShowDialog();
                this.Close();
            }
        }
    }
}
