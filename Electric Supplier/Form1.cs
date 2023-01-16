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
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace Electric_Supplier
{
    public partial class Form1 : Form
    {
        Keyboard keyboard = new Keyboard();
        private int timer = 61;
        TextBox tb;
        private MySqlConnection con;
        private string server;
        private string database;
        private string uid;
        private string password;
        int i;
        public Form1()
        {
            InitializeComponent();
        }
        SpeechSynthesizer reader = new SpeechSynthesizer();

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
        private void readOut_Click(Object sender, EventArgs e)
        {
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.Rate = -2;
            reader.Volume = 100;
            reader.SelectVoiceByHints(VoiceGender.Female);
            String values = label3.Text + " " + label2.Text;
            reader.SpeakAsync(values);
        }

        private void textBox_GotFocus(Object sender, EventArgs e)
        {
            tb = (TextBox)sender;  // take a copy of the object reference for the particular textbox pressed
            if (keyboard == null)  // check if the keyboard is already created
            {
                //keyboard = new Keyboard();   // no keyboard so create an instance of one
                keyboard.FormClosed += delegate
                {
                    keyboard = null;  // when the keyboard is closed, dispose of the keyboard instance
                    this.ActiveControl = label4; // when the keyboard is closed, reset focus to the dummy label else
                                                 // it will give focus to a textbox which would trigger the event to
                                                 // make another keyboard appear.
                };
            }
            keyboard.setTextBoxForOutput(tb);  // tell the keyboard which textbox to send its characters too
            Point form_pt = new Point(175, 534);
            Point screen_pt = this.PointToScreen(form_pt);
            keyboard.StartPosition = FormStartPosition.Manual;
            keyboard.Location = screen_pt;
            keyboard.Show(); // show the keyboard

           // keyboard.Left = this.Left + tb.Left + tb.Width + 30;  // re-position the keyboard form to be next to
           // keyboard.Top = this.Top + tb.Top + tb.Height + 11;    // the textbox that recieves its input.
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtPlateNumber;    // when the form loads, direct focus to a label so that a textbox 
                                            // doesn't get focus by default and trigger the GotFocus event (which
                                            // would show the keyboard before we needed it)
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();  // just some debugging to see which textbox has focus
            label5.Text = DateTime.Now.ToLongDateString();  // just some debugging to see which textbox has focus
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.Rate = -2;
            reader.Volume = 100;
            reader.SelectVoiceByHints(VoiceGender.Female);
            reader.SpeakAsync("Please enter your plate number inside the box");

            this.ActiveControl = txtPlateNumber;
            server = "aee953.poseidon.salford.ac.uk";
            database = "aee953_raman";
            uid = "aee953";
            password = "1FGvEVP9YwLBUFP";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            con = new MySqlConnection(connectionString);
            con.Open();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_Plate_Submit.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlateNumber.Text))
            {
                MessageBox.Show("Your box is empty.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlateNumber.Focus();
                return;
            }
            try
            {
                i = 0;
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM user WHERE usr = '"+txtPlateNumber.Text+"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                String plate = txtPlateNumber.Text;
                if (i == 0)
                {
                    MessageBox.Show(plate + " is invalid.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPlateNumber.Focus();
                    txtPlateNumber.Clear();
                }
                else
                {
                    PIN_Page pageer = new PIN_Page();
                    reader.Dispose();
                    lblResult.Visible = true;
                    lblResult.Text = plate + " is valid plate number!";
                    timer3.Enabled = false;
                    pageer.setUsername(plate);
                    keyboard.Close();
                    this.Hide();
                    pageer.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Leave_TextBox(object sender, EventArgs e)
        {
                keyboard.Hide();
        }

        private void txtPlateNumber_TextChanged(object sender, EventArgs e)
        { 
            if (txtPlateNumber.Text.Length == 9)
            {
                keyboard.disabling();
                label4.Visible = true;
            }
            else
            {
                keyboard.enabling();
                label4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome_Page mg = new Welcome_Page();
            this.Hide();
            mg.ShowDialog();
            this.Close();
            keyboard.Close();
        }

        private void label1_Click(object sender, EventArgs e)
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
                keyboard.Close();
                mg.ShowDialog();
                this.Close();
            }
        }

    }
}
