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

namespace ResturentBookingProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string query = null;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-S4IG9P3M\\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True");
            query = "select * from loginInfo where username='" + this.textBox1.Text.Trim() + "'and password='" + this.textBox2.Text.Trim() + "'";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbItemValue = comboBox1.SelectedItem.ToString();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["usertype"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("you are logged in as " + dt.Rows[i][2]);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            ManagerHome mh = new ManagerHome();
                            this.Hide();
                            mh.ShowDialog();
                            

                        }
                        else
                        {
                            CustomerForm m = new CustomerForm();
                            this.Hide();
                            m.ShowDialog();
                            

                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("error");
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);


        }
    }
}
