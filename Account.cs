using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATMproject
{
    public partial class Account: Form
    {
        public Account()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gunes\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        private void loginbtn_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if(accnumtxt.Text == "" || nametxt.Text ==""  || lnametxt.Text == "" || addresstxt.Text =="" || occupationtxt.Text ==""  || phonetxt.Text =="" || pintxt.Text =="")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AccountTbl values('"+accnumtxt.Text+"','"+nametxt.Text+"','"+lnametxt.Text+"','"+dobdate.Value.Date+"','"+phonetxt.Text+"','"+addresstxt.Text+"','"+educationcb.SelectedItem.ToString()+"','"+occupationtxt.Text+"','"+pintxt.Text+"','"+bal+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Succesfully!");
                    Con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
