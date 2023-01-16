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
using MySql.Data.MySqlClient;

namespace Electric_Supplier
{
    public partial class PIN_Page : Form
    {
        PIN_Numbers numbers = new PIN_Numbers();
        private string username;
        private int timer = 61;
        private MySqlConnection con;
        private string server;
        private string database;
        private string uid;
        private string password;
        int i;
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public PIN_Page()
        {
            InitializeComponent();
        }

        private void PIN_Page_Load(object sender, EventArgs e)
        {
            //this.ActiveControl = txtPinNumber;
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();  // just some debugging to see which textbox has focus
            label2.Text = DateTime.Now.ToLongDateString();  // just some debugging to see which textbox has focus
            lblPlateName.Text = "Your Car Plate Number: " + username;
            reader = new SpeechSynthesizer();
            reader.Rate = -2;
            reader.Volume = 100;
            reader.SelectVoiceByHints(VoiceGender.Female);
            reader.SpeakAsync("Please enter your PIN number inside.");

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

        private void readOut_Click(Object sender, EventArgs e)
        {
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.Rate = -2;
            reader.Volume = 100;
            reader.SelectVoiceByHints(VoiceGender.Female);
            String values = label5.Text + " " + label4.Text;
            reader.SpeakAsync(values);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btn_PIN_Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPinNumber.Text))
            {
                MessageBox.Show("PIN not provided!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPinNumber.Focus();
                return;
            }
            try
            {
                i = 0;
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM user WHERE usr = '"+username+"' AND pass = '" + txtPinNumber.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                String plate = txtPinNumber.Text;
                if (i == 0)
                {
                    MessageBox.Show(plate + " is invalid.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPinNumber.Focus();
                    txtPinNumber.Clear();
                }
                else
                {
                    Charging_Details pageer = new Charging_Details();
                    reader.Dispose();
                    timer3.Enabled = false;
                    pageer.setUsername(username);
                    pageer.setPassword(plate);
                    numbers.Close();
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

        private void txtPinNumber_TextChanged(object sender, EventArgs e)
        {
            bool containsAnyLetter = txtPinNumber.Text.Length == 6;
            if (containsAnyLetter == true)
            {
                numbers.disableButtuns();
            }
            else
            {
                numbers.enableButtuns();
            }
        }

        private void textBox_GotFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;  // take a copy of the object reference for the particular textbox pressed

            if (numbers == null)  // check if the keyboard is already created
            {
                //numbers = new PIN_Numbers();   // no keyboard so create an instance of one
                numbers.FormClosed += delegate
                {
                    numbers = null;  // when the keyboard is closed, dispose of the keyboard instance
                    this.ActiveControl = label6; // when the keyboard is closed, reset focus to the dummy label else
                                                 // it will give focus to a textbox which would trigger the event to
                                                 // make another keyboard appear.
                };
            }
            numbers.setTextBoxForOutput(tb);  // tell the keyboard which textbox to send its characters too
            Point form_pt = new Point(368, 481);
            Point screen_pt = this.PointToScreen(form_pt);
            numbers.StartPosition = FormStartPosition.Manual;
            numbers.Location = screen_pt;
            numbers.Show(); // show the keyboard

            // keyboard.Left = this.Left + tb.Left + tb.Width + 30;  // re-position the keyboard form to be next to
            // keyboard.Top = this.Top + tb.Top + tb.Height + 11;    // the textbox that recieves its input.
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reader.Dispose();
            Welcome_Page firstPage = new Welcome_Page();
            this.Hide();
            numbers.Hide();
            firstPage.ShowDialog();
            this.Close();
            numbers.Close();
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
                numbers.Close();
                mg.ShowDialog();
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
