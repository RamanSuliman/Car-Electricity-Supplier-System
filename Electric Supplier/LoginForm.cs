using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Electric_Supplier
{
    public partial class LoginForm : Form
    {
        private MySqlConnection con;
        private string server;
        private string database;
        private string uid;
        private string password;
        int i;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text == "")
            {
                MessageBox.Show("You need to enter the access key first!");
                return;
            }
            i = 0;
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM user WHERE usr = 'Admin' AND pass = '" + txt_Password.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("It looks like you need to talk with Raman to grant the premission again.");
            }
            else
            {
                Welcome_Page pager = new Welcome_Page();
                this.Hide();
                pager.ShowDialog();
                this.Close();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txt_Password;
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
    }
}


/*private bool OpenConnection()
{

    try
    {
        connection.Open();
        return true;
    }
    catch (MySqlException ex)
    {
        switch (ex.Number)
        {
            case 0:
                MessageBox.Show("Cannot connect to server.  Contact administrator");
                break;

            case 1045:
                MessageBox.Show("Invalid username/password, please try again");
                break;
        }
        return false;
    }
}*/

//Close connection