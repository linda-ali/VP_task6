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

namespace task6
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void display()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1H8VAPV;Initial Catalog=school;Integrated Security=True;Encrypt=False");
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from student" , conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void insert()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1H8VAPV;Initial Catalog=school;Integrated Security=True;Encrypt=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into student(id,name,age) values (@id,@name,@age)",conn);
                cmd.Parameters.AddWithValue("@id",textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", textBox3.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Inserted Successfully!");
            }
            else
            {
                MessageBox.Show("Please provide details.");
            }
        }

        private void delete()
        {
            if (textBox1.Text != "")
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1H8VAPV;Initial Catalog=school;Integrated Security=True;Encrypt=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from student where id=@id",conn);
                cmd.Parameters.AddWithValue("@id",textBox1.Text);
                cmd.ExecuteNonQuery ();
                conn.Close();
                MessageBox.Show("Record deleted successfully!");
            }
            else
            {
                MessageBox.Show("Please enter id to delete.");
            }
        }

        private void update()
        {
            if (textBox1.Text != "")
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1H8VAPV;Initial Catalog=school;Integrated Security=True;Encrypt=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("update student set name=@name, age=@age where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", textBox3.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record updated Successfully");
            }
            else
            {
                MessageBox.Show("please enter details to update");
            }
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            display();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            insert();
            display();
            clear();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            delete();
            display();
            clear();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            update();
            display();
            clear();
        }
    }
}
