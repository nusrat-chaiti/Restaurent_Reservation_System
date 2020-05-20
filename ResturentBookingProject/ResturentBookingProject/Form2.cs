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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-S4IG9P3M\\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String foodName= textBox1.Text.ToString();
                String foodId= textBox2.Text.ToString();
                long id= Int64.Parse(foodId);
                String price= textBox3.Text.ToString();
                long pri= Int64.Parse(price);
                String qry="insert into Food values('"+foodName+"',"+id+","+pri+")";
      
                SqlCommand sc= new SqlCommand(qry,con);
                int i= sc.ExecuteNonQuery();
                if(i>=1)
                    MessageBox.Show("New item is inserted successfully");
                else
                    MessageBox.Show("New item did not insert");
                Show();
                con.Close();


            } catch(System.Exception exp){
                MessageBox.Show("Error is"+exp.ToString());

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String foodName = textBox1.Text.ToString();
   
                String qry = "delete from Food where FoodName='"+ foodName+"'";

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

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void Show()
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String foodName = textBox1.Text.ToString();
                String foodId = textBox2.Text.ToString();
                long id = Int64.Parse(foodId);
                String price = textBox3.Text.ToString();
                long pri = Int64.Parse(price);
                String qry = "update Food set FoodId=" + id + ",Price=" + pri + " where FoodName='" + foodName + "'";

                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show(" Item is updated successfully");
                else
                    MessageBox.Show("Item did not update");
                Show();
                con.Close();


            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is" + exp.ToString());

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Food where FoodName like '%"+textBox4.Text.ToString()+"%'", con);
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
