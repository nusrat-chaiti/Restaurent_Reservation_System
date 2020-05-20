using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ResturentBookingProject
{
    public partial class CustomerForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-S4IG9P3M\\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True");
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show();
        }
        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Food", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String x ="";
            SqlDataAdapter sda = new SqlDataAdapter("select * from TableInfo where TableStatus='"+x+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView2.Rows[n].Cells[1].Value = dr[1].ToString();
                //dataGridView2.Rows[n].Cells[2].Value = dr[2].ToString();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm f1 = new LoginForm();
            f1.ShowDialog();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_MouseClick_1(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String tableid = textBox2.Text.ToString();
                long ti = Int64.Parse(tableid);
                String status = textBox3.Text.ToString();
                String qry = "update TableInfo set TableStatus='" + status + "' where TableId=" + tableid + "";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show(" Thank You!! Your table is booked successfully");
                else
                    MessageBox.Show("Sorry! Booking Failed.Try Again");
                Show();
                con.Close();


            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is" + exp.ToString());

            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Food where FoodName like '%" + textBox1.Text.ToString() + "%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
            }
            con.Close();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);

        }
    }
}
