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

namespace fp
{
    public partial class Form6 : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.OneWorldAcademyConnectionString);
        string gender;
        public Form6()
        {
            InitializeComponent();
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Selection query implement
            conn.Open();
            string query = "Select * from Lecture_table where LectureId='" + kryptonComboBox1.SelectedItem.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            //////////////////////////////////////////////////////////////////////////////////////
            // Create a DataTable to store the retrieved data
            DataTable dt = new DataTable();
            // Create a SqlDataAdapter to fill the DataTable with data from the SQL command result
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            // Loop through each row in the DataTable
            foreach (DataRow dr in dt.Rows)
            {
                // Set various TextBoxes and other controls with data from the DataRow
                kryptonTextBox1.Text = dr["firstName"].ToString();
                kryptonTextBox2.Text = dr["lastName"].ToString();
                kryptonTextBox3.Text = dr["Email"].ToString();
                kryptonTextBox5.Text = dr["Address"].ToString();
                kryptonTextBox6.Text = dr["Mobile"].ToString();
                kryptonTextBox11.Text = dr["NIC"].ToString();
                kryptonTextBox8.Text = dr["Notes"].ToString();

                string gender = dr["Gender"].ToString();
                if (gender == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }

                dateTimePicker1.Value = Convert.ToDateTime(dr["DOB"]);
                dateTimePicker2.Value = Convert.ToDateTime(dr["RecruitedDate"]);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm = new Form3();
            frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm = new Form3();
            frm.Show();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            //Condition to Take the value of the radio button as a string
            if (radioButton1.Checked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            ///////////////////////////////////////////////////////////////////////////////
            ///

            //Make the insert query to add data to the database from the GUI
            string firstname = kryptonTextBox1.Text;
            string lastname = kryptonTextBox2.Text;
            string address = kryptonTextBox5.Text;
            string email = kryptonTextBox3.Text;
            string mobile = kryptonTextBox6.Text.Trim();
            string nic = kryptonTextBox11.Text;
            string Note = kryptonTextBox8.Text;

            if (string.IsNullOrWhiteSpace(kryptonComboBox1.Text) || kryptonComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please enter a lecturer ID and select a division.");
                return;
            }

            const string query = @"INSERT INTO Lecture_table
                (LectureId, firstName, lastName, DOB, Gender, Division, Address, Email, Mobile, RecruitedDate, NIC, Notes)
                VALUES (@LectureId, @firstName, @lastName, @DOB, @Gender, @Division, @Address, @Email, @Mobile, @RecruitedDate, @NIC, @Notes)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@LectureId", kryptonComboBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@firstName", firstname);
                cmd.Parameters.AddWithValue("@lastName", lastname);
                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Division", kryptonComboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@RecruitedDate", dateTimePicker2.Value.Date);
                cmd.Parameters.AddWithValue("@NIC", nic);
                cmd.Parameters.AddWithValue("@Notes", Note);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Register Successful!!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
