using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Insert
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=Crud_App;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into stu values(@id,@enrollment_no,@name,@semester)",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@enrollment_no", textBox1.Text);
            cmd.Parameters.AddWithValue("@name",textBox2.Text);
            cmd.Parameters.AddWithValue("@semester", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Saved Data:");
        }

        private void button2_Click(object sender, EventArgs e) //Update
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=Crud_App;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update stu set enrollment_no=@enrollment_no,name=@name,semester=@semester where id=@id",con);
            cmd.Parameters.AddWithValue("@enrollment_no", textBox1.Text);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@semester", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Updated Data:");
        }

        private void button3_Click(object sender, EventArgs e) //Delete
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=Crud_App;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete stu where id=@id",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted Data:");
        }

        private void button4_Click(object sender, EventArgs e) //Search
        {
            SqlConnection con = new SqlConnection("Data Source=KARAN\\SQLEXPRESS;Initial Catalog=Crud_App;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from stu", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;  

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
