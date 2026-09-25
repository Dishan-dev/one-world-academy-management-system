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

namespace fp
{
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.OneWorldAcademyConnectionString);
        public Form3()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm = new Form4();
            frm.Show();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            

            


        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

            conn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * FROM student_table", conn);
            DataTable datatable = new DataTable();
            sqlDa.Fill(datatable);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = datatable;
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text == "Reg_No")
            {
                SqlDataAdapter ada = new SqlDataAdapter("SELECT regNo,firstName,lastName,email,mobile FROM student_table WHERE regNo like '" + textBox1.Text + "%'", conn);
                DataTable datatable = new DataTable();
                ada.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            else if (kryptonComboBox1.Text == "Firstname")
            {
                SqlDataAdapter ada = new SqlDataAdapter("SELECT regNo,firstName,lastName,Email,Mobile,Course FROM student_table WHERE firstName like '" + textBox1.Text + "%'", conn);
                DataTable datatable = new DataTable();
                ada.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            else if (kryptonComboBox1.Text == "Lastname")
            {
                SqlDataAdapter ada = new SqlDataAdapter("SELECT regNo,firstName,lastName,Email,Mobile,Course FROM student_table WHERE lastName like '" + textBox1.Text + "%'", conn);
                DataTable datatable = new DataTable();
                ada.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            else if (kryptonComboBox1.Text == "Course")
            {
                SqlDataAdapter ada = new SqlDataAdapter("SELECT regNo,firstName,lastName,Email,Mobile,Course FROM student_table WHERE Course like '" + textBox1.Text + "%'", conn);
                DataTable datatable = new DataTable();
                ada.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form = new Form5();
            form.Show();
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
