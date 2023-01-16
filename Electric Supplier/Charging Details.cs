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
    public partial class Charging_Details : Form
    {
        private PictureBox pic;
        private string username;
        private int timer = 61;
        private double amount = 0.0;
        private string duration = "";
        private string password;
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public Charging_Details()
        {
            InitializeComponent();
        }

        private void hover_Over(object sender, EventArgs e)
        {
            lblHoverMessage.Visible = true;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            lblHoverMessage.Visible = false;
        }

        private void btn_1_MouseHover(object sender, EventArgs e)
        {
            Button btno = (Button)sender;
            btno.BackColor = Color.Red;
        }

        private void btn_1_MouseLeave(object sender, EventArgs e)
        {
            Button btno = (Button)sender;
            btno.BackColor = Color.Transparent;
        }

        private void storeImage(object sender)
        {
            PictureBox btno = (PictureBox)sender;
            pic = btno;
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            int numba = 0;
            Button btno = (Button)sender;
            pic_0.Visible = false;
            if (btno == btn_1)
            {
                numba = 1;
                pic_1.Visible = true;
                storeImage(pic_1);
            }
            else if (btno == btn_2)
            {
                numba = 2;
                pic_2.Visible = true;
                storeImage(pic_2);
            }
            else if (btno == btn_3)
            {
                numba = 3;
                pic_3.Visible = true;
                storeImage(pic_3);
            }
            else if (btno == btn_4)
            {
                numba = 4;
                pic_4.Visible = true;
                storeImage(pic_4);
            }
            else if (btno == btn_5)
            {
                numba = 5;
                pic_5.Visible = true;
                storeImage(pic_5);
            }
            else if (btno == btn_6)
            {
                numba = 6;
                pic_6.Visible = true;
                storeImage(pic_6);
            }
            else if (btno == btn_7)
            {
                numba = 7;
                pic_7.Visible = true;
                storeImage(pic_7);
            }
            else if (btno == btn_8)
            {
                numba = 8;
                pic_8.Visible = true;
                storeImage(pic_8);
            }
            else if (btno == btn_9)
            {
                numba = 9;
                pic_9.Visible = true;
                storeImage(pic_9);
            }
            else if (btno == btn_10)
            {
                numba = 10;
                pic_10.Visible = true;
                storeImage(pic_10);
            }
            else
            {
                pic_0.Visible = true;
            }
            speakUp("Please select a charging level fast or slow.");
            lbl_bay.Text = "Bay selected: " + numba;
            panel_Main.Enabled = false;
            pictureBox6.BackColor = Color.Transparent;
            panel_Main.BackColor = Color.LightGray;
            panel_Disable2.BackColor = Color.White;
            panel_Disable2.Enabled = true;
        }

        private void Charging_Details_Load(object sender, EventArgs e)
        {
            this.ActiveControl = pictureBox6;
            pictureBox6.BackColor = Color.White;
            panel_Disable2.Enabled = false;
            panel_Disable3.Enabled = false;
            panel_Main.BackColor = Color.White;
            timer1.Start();
            label14.Text = DateTime.Now.ToLongTimeString();  // just some debugging to see which textbox has focus
            label15.Text = DateTime.Now.ToLongDateString();  // just some debugging to see which textbox has focus
            lblPlateName.Text = "Your Car Plate Number: " + username;
            speakUp("Please select a parking bay to park in between 1 to 10.");
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Fast_Click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            if (pressed == btn_Fast)
            {
                lbl_ChSpeedd.Text = "Speed: Fast";
                amount += 8.20;
            }
            else if (pressed == btn_Slow)
            {
                lbl_ChSpeedd.Text = "Speed: Slow";
            }
            speakUp("Please select charging duration 2 or 8 hours period.");
            panel_Disable2.Enabled = false;
            panel_Disable3.Enabled = true;
            panel_Disable2.BackColor = Color.LightGray;
            panel_Disable3.BackColor = Color.White;
        }

        private void btn_duration_click(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            if (pressed == btn_TwoHours)
            {
                lbl_ChDuration.Text = "Duration: 2 Hours";
                duration = "2";
            }
            else if (pressed == btn_8Hours)
            {
                lbl_ChDuration.Text = "Duration: 8 Hours";
                duration = "8";
            }
            speakUp("Now click on clear input buttun to delete and re-fill everything again or click on next buttun to move on.");
        }

        private void btn_clearOptions_Click(object sender, EventArgs e)
        {
            speakUp("Please select a parking bay to park in between 1 to 10.");
            lbl_ChDuration.Text = "Duration: None";
            lbl_ChSpeedd.Text = "Speed: None";
            lbl_bay.Text = "Bay selected: None";
            panel_Disable2.Enabled = false;
            panel_Disable3.Enabled = false;
            panel_Main.Enabled = true;
            panel_Disable2.BackColor = Color.LightGray; 
            panel_Disable3.BackColor = Color.LightGray;
            panel_Main.BackColor = Color.White;
            amount = 0.0;
            duration = "";
            pictureBox6.BackColor = Color.White;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox8.BackColor = Color.Transparent;
            if (pic != null)
            {
                pic.Visible = false;
                pic_0.Visible = true;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            reader.Dispose();
            Welcome_Page mg = new Welcome_Page();
            this.Hide();
            mg.ShowDialog();
            this.Close();
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
            if (lbl_ChDuration.Text == "Duration: 8 Hours" || lbl_ChDuration.Text == "Duration: 2 Hours")
            {
                reader.Dispose();
                timer3.Enabled = false;
                btn_clearOptions.Enabled = false;
                panel_Disable3.Enabled = false;
                Payment_Method paymentMethod = new Payment_Method();
                paymentMethod.total(amount,duration);
                paymentMethod.setUsername(username);
                paymentMethod.setPassword(password);
                this.Hide();
                paymentMethod.ShowDialog();
                this.Close();
            }
            else 
            {
                MessageBox.Show("You must fill in all required options first in order to move on.", "Invaild Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel_Main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pic_1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
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

        private void lbl_ChDuration_Click(object sender, EventArgs e)
        {

        }
    }
}
