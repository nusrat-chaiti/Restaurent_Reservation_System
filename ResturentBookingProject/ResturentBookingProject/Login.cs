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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = null;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-1RUO9UA5\\SQLEXPRESS;Initial Catalog=RestaurentReservationSystem;Integrated Security=True");
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
                            Form1 f1 = new Form1();
                            mf.ShowDialog();
                            this.Hide();

                        }
                        else
                        {
                            customerForm m = new customerForm();
                            m.ShowDialog();
                            this.Hide();

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
    }
}
