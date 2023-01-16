using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

namespace Electric_Supplier
{
    public partial class Payment_Method : Form
    {
        SpeechSynthesizer reader = new SpeechSynthesizer();
        double lastCost = 0.0;
        private string username;
        private int timer = 61;
        private string password;
        public Payment_Method()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void check_Click(object sender, EventArgs e)
        {
            if (ck_Card.Checked == true)
            {
                ck_Account.Enabled = false;
                p_Account.Enabled = false;
                p_Card.Enabled = true;
                lbl_Payment.Text = "Payment Method: Card";
            }
            else if (ck_Account.Checked == true)
            {
                ck_Card.Enabled = false;
                p_Card.Enabled = false;
                ck_1.Enabled = true;
                ck_2.Enabled = true;
                ck_3.Enabled = true;
                p_Account.Enabled = true;
                lbl_Payment.Text = "Payment Method: Account";
            }
            else 
            {
                ck_Card.Checked = false;
                ck_Card.Checked = false;
                ck_Card.Enabled = true;
                ck_Account.Enabled = true;
                ck_1.Checked = false;
                ck_2.Checked = false;
                ck_3.Checked = false;
                ck_4.Checked = false;
            }
        }

        private void btn_clearOptions_Click(object sender, EventArgs e)
        {
            ck_Account.Enabled = true;
            ck_Card.Checked = false;
            ck_Account.Checked = false;
            p_Account.Enabled = false;
            ck_Card.Enabled = true;
            p_Card.Enabled = false;
            ck_1.Checked = false;
            ck_2.Checked = false;
            ck_3.Checked = false;
            ck_4.Checked = false;
            label3.Visible = false;
            lbl_Payment.Text = "Payment Method: None";
        }

        private void ck_4_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_1.Checked == false || ck_2.Checked == false || ck_3.Checked == false)
            {
                ck_4.Checked = false;
                label3.Visible = true;
            }
            else 
            {
                ck_1.Enabled = false;
                ck_2.Enabled = false;
                ck_3.Enabled = false;
            }
        }

        private void Payment_Method_Load(object sender, EventArgs e)
        {
            p_Account.Enabled = false;
            p_Card.Enabled = false;
            timer1.Start();
            label14.Text = DateTime.Now.ToLongTimeString();  // just some debugging to see which textbox has focus
            label15.Text = DateTime.Now.ToLongDateString();  // just some debugging to see which textbox has focus
            //lblPlateName.Text = "Your Car Plate Number: " + username;
            speakUp("Please select a payment method by choosing one of two given options.");
            lbl_Total.Text = "Total Amount: $" + lastCost;
            lblPlateName.Text = "Your Car Plate Number: " + username;
            label4.Text = "Account User : " + username;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void speakUp(string messgae)
        {
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.Rate = -3;
            reader.Volume = 100;
            reader.SelectVoiceByHints(VoiceGender.Female);
            reader.SpeakAsync(messgae);
        }

        private void checkBox_Hover(object sender, EventArgs e)
        {
            CheckBox ba = (CheckBox)sender;
            if (ba == ck_Account)
            {
                ck_Account.ForeColor = Color.White;
            }
            else if (ba == ck_Card)
            {
                ck_Card.ForeColor = Color.White;
            }
        }

        private void ck_Account_MouseLeave(object sender, EventArgs e)
        {
            CheckBox ba = (CheckBox)sender;
            if (ba == ck_Account)
            {
                ck_Account.ForeColor = Color.Black;
            }
            else if (ba == ck_Card)
            {
                ck_Card.ForeColor = Color.Black;
            }
        }

        private void ck_4_Leave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            reader.Dispose();
            Welcome_Page mg = new Welcome_Page();
            this.Hide();
            mg.ShowDialog();
            this.Close();
        }

        public void total(double amount, string duration)
        {
            double normallCost = 5;
            double finialCost = normallCost + amount;
            if (duration == "2")
            {
                lastCost = (int)finialCost * 2;
            }
            else if (duration == "8")
            {
                lastCost = finialCost * 8;
            }
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ck_Card.Checked == true || ck_4.Checked == true)
            {
                reader.Dispose();
                timer3.Enabled = false;
                Progress_Bar proPage = new Progress_Bar();
                proPage.setPassword(password);
                proPage.setUsername(username);
                this.Hide();
                proPage.ShowDialog();
                this.Close();
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer--;
            timerHolder.Text = timer.ToString();
            if (timerHolder.Text == "0")
            {
                timer3.Enabled = false;
                Welcome_Page mg = new Welcome_Page();
                this.Hide();
                mg.ShowDialog();
                this.Close();
            }
        }

        private void ck_Card_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ck_Account_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
