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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-S4IG9P3M\\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String tableId = textBox1.Text.ToString();
                long id = Int64.Parse(tableId);
                String noOfChairs = textBox2.Text.ToString();
                long noc = Int64.Parse(noOfChairs);
                String status = textBox3.Text.ToString();
                String qry = "insert into TableInfo values("+tableId+","+noOfChairs+",'" + status + "')";

                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("New Table is inserted successfully");
                else
                    MessageBox.Show("New Table did not insert");
                Show();
                con.Close();


            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is" + exp.ToString());

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String tableid = textBox1.Text.ToString();
                long id = Int64.Parse(tableid);
                String qry = "delete from TableInfo where TableId=" + tableid + "";

                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show("Deleted successfully");
                }
                else
                    MessageBox.Show("Deletion failed");
                Show();
                con.Close();


            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is" + exp.ToString());

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String tableid = textBox1.Text.ToString();
                long ti = Int64.Parse(tableid);
                String noofchairs= textBox2.Text.ToString();
                long noc= Int64.Parse(noofchairs);
                String status = textBox3.Text.ToString();
                String qry = "update TableInfo set TableStatus='" + status + "',NumOfChairs=" + noc + " where TableId=" + tableid + "";

                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show(" Table is updated successfully");
                else
                    MessageBox.Show("Table did not update");
                Show();
                con.Close();


            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is" + exp.ToString());

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerHome f1 = new ManagerHome();
            f1.ShowDialog();
        }

        void Show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from TableInfo", con);
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            String ab = textBox4.Text.ToString();
     
            SqlDataAdapter sda = new SqlDataAdapter("select * from TableInfo where TableId like '%" + ab + "%'", con);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm f1 = new LoginForm();
            f1.ShowDialog();
        }
    }
}
