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
    public partial class Keyboard : Form
    {

        TextBox tt;

        public Keyboard()
        {
            InitializeComponent();
            this.TopMost = true;  // make the keyboard always in front of the other forms
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(400,10);
        }

        public void setTextBoxForOutput(TextBox t)
        {
            tt = t;  // 
        }

        private void button_Click(object sender, EventArgs e)
        {
            tt.Text += ((Button)sender).Text;
        }

        private void Keyboard_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button38;
            myButtons.Add(button1);
            myButtons.Add(button2);
            myButtons.Add(button3);
            myButtons.Add(button4);
            myButtons.Add(button5);
            myButtons.Add(button6);
            myButtons.Add(button7);
            myButtons.Add(button8);
            myButtons.Add(button9);
            myButtons.Add(button10);
            myButtons.Add(button11);
            myButtons.Add(button12);
            myButtons.Add(button13);
            myButtons.Add(button14);
            myButtons.Add(button15);
            myButtons.Add(button16);
            myButtons.Add(button17);
            myButtons.Add(button18);
            myButtons.Add(button19);
            myButtons.Add(button20);
            myButtons.Add(button21);
            myButtons.Add(button22);
            myButtons.Add(button23);
            myButtons.Add(button24);
            myButtons.Add(button25);
            myButtons.Add(button26);
            myButtons.Add(button27);
            myButtons.Add(button28);
            myButtons.Add(button29);
            myButtons.Add(button30);
            myButtons.Add(button31);
            myButtons.Add(button32);
            myButtons.Add(button33);
            myButtons.Add(button34);
            myButtons.Add(button35);
            myButtons.Add(button36);
            myButtons.Add(button37);
            myButtons.Add(button38);
            myButtons.Add(button39);
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (tt.Text.Length != 0)
            {
                tt.Text = tt.Text.Substring(0, tt.Text.Length - 1);
            }
           
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tt.Clear();
        }

        private void btn_Increase_Size(object sender, EventArgs e)
        {
            sendera(button1);
            sendera(button2);
            sendera(button3);
            sendera(button4);
            sendera(button5);
            sendera(button6);
            sendera(button7);
            sendera(button8);
            sendera(button9);
            sendera(button10);
            sendera(button11);
            sendera(button12);
            sendera(button13);
            sendera(button14);
            sendera(button16);
            sendera(button17);
            sendera(button18);
            sendera(button19);
            sendera(button21);
            sendera(button23);
            sendera(button20);
            sendera(button25);
            sendera(button22);
            sendera(button26);
            sendera(button15);
            sendera(button27);
            sendera(button28);
            sendera(button29);
            sendera(button30);
            sendera(button31);
            sendera(button32);
            sendera(button33);
            sendera(button34);
            sendera(button35);
            sendera(button36);
            sendera(button39);
        }

        private void sendera(object sender)
        {
            Button button = (Button)sender;
            if (button.Font.Size <= 16)
            {
                float counter = button.Font.Size;
                counter += 1;
                button.Font = new Font(button.Font.Name, counter, button.Font.Style, button.Font.Unit);
            }
        }

        private void btn_dECREASE_Size(object sender, EventArgs e)
        {
            sendera2(button1);
            sendera2(button2);
            sendera2(button3);
            sendera2(button4);
            sendera2(button5);
            sendera2(button6);
            sendera2(button7);
            sendera2(button8);
            sendera2(button9);
            sendera2(button10);
            sendera2(button11);
            sendera2(button12);
            sendera2(button13);
            sendera2(button14);
            sendera2(button16);
            sendera2(button17);
            sendera2(button18);
            sendera2(button19);
            sendera2(button21);
            sendera2(button23);
            sendera2(button20);
            sendera2(button25);
            sendera2(button22);
            sendera2(button26);
            sendera2(button15);
            sendera2(button27);
            sendera2(button28);
            sendera2(button29);
            sendera2(button30);
            sendera2(button31);
            sendera2(button32);
            sendera2(button33);
            sendera2(button34);
            sendera2(button35);
            sendera2(button36);
            sendera2(button39);
        }

        private void sendera2(object sender)
        {
            Button button = (Button)sender;
            if (button.Font.Size >= 9)
            {
                float counter = button.Font.Size;
                counter -= 1;
                button.Font = new Font(button.Font.Name, counter, button.Font.Style, button.Font.Unit);
            }
        }


        private void changeColor_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (this.BackColor == Color.Crimson)
            {
                this.BackColor = Color.Black;
            }
            else if (this.BackColor == Color.Black)
            {
                this.BackColor = Color.Crimson;
            }
        }
        private List<Button> myButtons = new List<Button>();
        public void disabling()
        {
            foreach (Button btn in myButtons)
            {
                btn.Enabled = false;
            }
        }

        public void enabling()
        {
            foreach (Button btn in myButtons)
            {
                btn.Enabled = true;
            }
        }
    }
}
