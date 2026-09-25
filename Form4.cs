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
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.OneWorldAcademyConnectionString);
        public Form4()
        {
            InitializeComponent();
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form = new Form6();
            form.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * FROM Lecture_Table", conn);
                DataTable datatable = new DataTable();
                sqlDa.Fill(datatable);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = datatable;
                conn.Close();
            }
            catch 
            {
                this.Hide();
                Form6 form = new Form6();
                form.Show();
            }
            
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Form5 form = new Form5();
            form.Show();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text == "Lecture_ID")
            {
                SqlDataAdapter ada = new SqlDataAdapter("SELECT LectureId,firstName,lastName,email,mobile FROM Lecture_table WHERE LectureId like '" + textBox1.Text + "%'", conn);
                DataTable datatable = new DataTable();
                ada.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            else if (kryptonComboBox1.Text == "Firstname")
            {
                SqlDataAdapter ada = new SqlDataAdapter("SELECT LectureId,firstName,lastName,Email,Mobile,Division FROM Lecture_table WHERE firstName like '" + textBox1.Text + "%'", conn);
                DataTable datatable = new DataTable();
                ada.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            else if (kryptonComboBox1.Text == "Lastname")
            {
                SqlDataAdapter ada = new SqlDataAdapter("SELECT LectureId,firstName,lastName,Email,Mobile,Division FROM Lecture_table WHERE lastName like '" + textBox1.Text + "%'", conn);
                DataTable datatable = new DataTable();
                ada.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
            else if (kryptonComboBox1.Text == "Division")
            {
                SqlDataAdapter ada = new SqlDataAdapter("SELECT LectureId,firstName,lastName,Email,Mobile,Division FROM Lecture_table WHERE Division like '" + textBox1.Text + "%'", conn);
                DataTable datatable = new DataTable();
                ada.Fill(datatable);
                dataGridView1.DataSource = datatable;
            }
        }
    }
}
