using ComponentFactory.Krypton.Toolkit;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace fp
{
    public partial class Form5 : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.OneWorldAcademyConnectionString);
        public Form5()
        {
            InitializeComponent();
        }
        private void refresh()
        {
            Form5 form = new Form5();
            this.Hide();
            form.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                kryptonTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Course_id"].FormattedValue.ToString();
                kryptonTextBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Course_name"].FormattedValue.ToString();
                kryptonComboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Course_type"].FormattedValue.ToString();
                kryptonTextBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Lecture"].FormattedValue.ToString();
                kryptonTextBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Course_charge"].FormattedValue.ToString();
            }
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            loadtable();
            
            kryptonButton3.Hide();
        }

        private void loadtable()
        {
            conn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * FROM Coursetable", conn);
            DataTable datatable = new DataTable();
            sqlDa.Fill(datatable);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = datatable;
            conn.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Coursetable SET Course_type=@Course_type,Course_name=@Course_name,Lecture=@Lecture,Course_charge=@Course_charge WHERE Course_id=@Course_id", conn);

            // Set parameters with values for the SQL query
         
            sqlCommand.Parameters.AddWithValue("@Course_id", kryptonTextBox1.Text);
            sqlCommand.Parameters.AddWithValue("@Course_name", kryptonTextBox2.Text);
            sqlCommand.Parameters.AddWithValue("@Course_type", kryptonComboBox1.Text);
            sqlCommand.Parameters.AddWithValue("@Lecture", kryptonTextBox3.Text);
            sqlCommand.Parameters.AddWithValue("@Course_charge", kryptonTextBox4.Text);
 
            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                conn.Close();
                refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            kryptonTextBox1.Enabled = true;
            kryptonComboBox1.Enabled = true;
            kryptonTextBox2.Enabled = true;
            kryptonTextBox3.Enabled = true;
            kryptonTextBox4.Enabled = true;
            kryptonTextBox1.Clear();
            kryptonTextBox2.Clear();
            kryptonTextBox3.Clear();
            kryptonTextBox4.Clear();
            kryptonButton1.Hide();
            kryptonButton3.Show();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            
            int course_charge;
            if (!int.TryParse(kryptonTextBox4.Text, out course_charge) || kryptonComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a course type and enter a valid course charge.");
                return;
            }

            const string query = @"INSERT INTO Coursetable (Course_id, Course_type, Course_name, Lecture, Course_charge)
                                   VALUES (@Course_id, @Course_type, @Course_name, @Lecture, @Course_charge)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Course_id", kryptonTextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Course_type", kryptonComboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Course_name", kryptonTextBox2.Text);
                cmd.Parameters.AddWithValue("@Lecture", kryptonTextBox3.Text);
                cmd.Parameters.AddWithValue("@Course_charge", course_charge);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Addition Successful!!", "New Course", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            loadtable();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            kryptonTextBox1.Enabled = true;
            kryptonTextBox2.Enabled = true;
            kryptonTextBox3.Enabled = true;
            kryptonTextBox4.Enabled = true;
            kryptonComboBox1.Enabled = true;
            kryptonTextBox1.Clear();
            kryptonTextBox2.Clear();
            kryptonTextBox3.Clear();
            kryptonTextBox4.Clear();
        }

        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
