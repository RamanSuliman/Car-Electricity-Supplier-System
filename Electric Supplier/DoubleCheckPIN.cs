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
    public partial class DoubleCheckPIN : Form
    {
        private string password;
        private Progress_Bar progressBar;
        public DoubleCheckPIN()
        {
            InitializeComponent();
        }

        private void btn_8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (progressBar.ifImageIsOn() == "Yes")
            {
                progressBar.timer1.Enabled = true;
            }
            else
            {
                progressBar.timer3.Enabled = true;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string passwordG = textBox1.Text;
            if (passwordG == password)
            {
                progressBar.closeMe();
                Welcome_Page mg = new Welcome_Page();
                this.Hide();
                mg.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect, try again.");
                textBox1.Clear();
                textBox1.Focus();
            }
            
        }

        private void btn_6_Click(object sender, EventArgs e)
        {

        }

        public void passFormValue(Progress_Bar progressBar)
        {
            this.progressBar = progressBar;
        }

        public void setTextBoxForOutput(TextBox t)
        {
            textBox1 = t;  
        }
        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
        }

        private void textBox_GotFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;  // take a copy of the object reference for the particular textbox pressed
            this.setTextBoxForOutput(tb);  // tell the keyboard which textbox to send its characters too
        }
        private void DoubleCheckPIN_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
        }

        private void clear(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void remove(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool containsAnyLetter = textBox1.Text.Length == 6;
            if (containsAnyLetter == true)
            {
                this.disableButtuns();
            }
            else
            {
                this.enableButtuns();
            }
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
    }
}
