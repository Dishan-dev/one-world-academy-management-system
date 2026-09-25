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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.WebRequestMethods;
using ComponentFactory.Krypton.Toolkit;
using System.CodeDom;
using System.Web.UI.Design;
using System.Collections;

namespace fp
{
    public partial class Form2 : Form
    {   
        //Connection
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.OneWorldAcademyConnectionString);
        
        //Variable declare
        string g;
        string value;
       

        public Form2()
        {
            InitializeComponent();
            combobox();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            


        }

        //Create a comboBox Method to Fetch data to the combo box drop down from the database

        private void combobox()
        {   
            //declarevariable sql and assign the Select query to it
            string sql = "Select regNo from student_table";

            //From the ADO.NET library, Use the SqlCommand class and make a instance or a variable called cmd from new SqlCommand
            //Then bind sql query variable and conn which is the connection variable to cmd
            //purpose of this cmd instance is The we can use this instance in future, where database need to be in 

            SqlCommand cmd = new SqlCommand(sql, conn);

            //This sqldatareader class is Used to read data which are get from the database
            //reader is the varibale/instance from the sqldatareader class, by using this we can conjunct with database related classes and methods
            SqlDataReader reader;

            try
            {   
                //Open the connection
                conn.Open();

                //Excute the reader with support of the cmd instance which is maked ealier by conn and sql, Then that readed data fetch to the reader variable
                reader = cmd.ExecuteReader();

                while(reader.Read())   //By using the built-in Read() method, Read the Data of the reader variable row by row, from the while this reading execute till the end of the all the rows
                {
                    string regno = reader.GetString(0);
                    //Declare a regno variable and assign the 0 th index value which is The 1st column of the database table

                    kryptonComboBox1.Items.Add(regno);
                    //Finally Add those data to the combox dropdown items by this Items.add method 
                }
                conn.Close();

            }catch(Exception ex)
            {   
                //Handle any error of the try block code and display the error in a message box
                MessageBox.Show(ex.Message);
            }

            /////////////////////////////////////////////////////////////////////////////
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }



        private void kryptonButton2_Click_1(object sender, EventArgs e) //Register Button Code
        {
            
            //Condition to Take the value of the radio button as a string
            if (radioButton1.Checked == true)
            {
                g = "Male";
            }
            else
            {
                g = "Female";
            }
            ///////////////////////////////////////////////////////////////////////////////
            ///


            //Make the insert query to add data to the database from the GUI
            string firstname = kryptonTextBox1.Text;
            string lastname = kryptonTextBox2.Text;
            string address = kryptonTextBox5.Text;
            string email = kryptonTextBox3.Text;
            string mobile = kryptonTextBox6.Text.Trim();
            string home = kryptonTextBox7.Text.Trim();
            string parentname = kryptonTextBox10.Text;
            string nic = kryptonTextBox11.Text;
            string contactno = kryptonTextBox8.Text.Trim();

            if (string.IsNullOrWhiteSpace(kryptonComboBox1.Text) || kryptonComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please enter a registration number and select a course.");
                return;
            }

            const string query = @"INSERT INTO student_table
                (regNo, firstName, lastName, DOB, Gender, Course, Address, Email, Mobile, Home, ParentName, NIC, ContactNo)
                VALUES (@regNo, @firstName, @lastName, @DOB, @Gender, @Course, @Address, @Email, @Mobile, @Home, @ParentName, @NIC, @ContactNo)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@regNo", kryptonComboBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@firstName", firstname);
                cmd.Parameters.AddWithValue("@lastName", lastname);
                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Gender", g);
                cmd.Parameters.AddWithValue("@Course", kryptonComboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@Home", home);
                cmd.Parameters.AddWithValue("@ParentName", parentname);
                cmd.Parameters.AddWithValue("@NIC", nic);
                cmd.Parameters.AddWithValue("@ContactNo", contactno);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Register Successful!!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
            
        }
        ///////////////////////////////////////////////////////////////////////////////////
        


        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)   //Gain data from the database according to the selection of the combo box item
        {   

            //Selection query implement
            conn.Open();
            string query = "Select * from student_table where regNo='" + kryptonComboBox1.SelectedItem.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query,conn);
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
                kryptonTextBox5.Text = dr["address"].ToString();               
                kryptonTextBox6.Text = dr["Mobile"].ToString();
                kryptonTextBox7.Text = dr["Home"].ToString();
                kryptonTextBox10.Text = dr["ParentName"].ToString();
                kryptonTextBox11.Text = dr["NIC"].ToString();
                kryptonTextBox8.Text = dr["ContactNo"].ToString();

                string gender = dr["Gender"].ToString();
                if (gender == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }

                dateTimePicker1.Value = Convert.ToDateTime(dr["dob"]);
            }
         

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oneWorldAcademyDataSet1.regtable' table. You can move, or remove it, as needed.
            this.regtableTableAdapter1.Fill(this.oneWorldAcademyDataSet1.regtable);
            // TODO: This line of code loads data into the 'oneWorldAcademyDataSet.regtable' table. You can move, or remove it, as needed.
            this.regtableTableAdapter.Fill(this.oneWorldAcademyDataSet.regtable);

        }

        private void regtableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            kryptonComboBox1.ResetText();
            kryptonTextBox1.Clear();
            kryptonTextBox2.Clear();

            dateTimePicker1.Value = DateTime.Now;

            if (radioButton1.Checked)
            {
                radioButton1.Checked = false;
            }
            else if (radioButton2.Checked)
            {
                radioButton2.Checked = false;
            }
            kryptonTextBox3.Clear();
            kryptonTextBox4.Clear();    
            kryptonTextBox5.Clear();
            kryptonTextBox6.Clear();
            kryptonTextBox7.Clear();
            kryptonTextBox8.Clear();
            kryptonTextBox10.Clear();
            kryptonTextBox11.Clear();
            kryptonTextBox12.Clear();

            
        }

        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            // Create a SqlCommand for the UPDATE operation
            SqlCommand sqlCommand = new SqlCommand("UPDATE student_table SET firstName =@firstName,lastName=@lastName,DOB=@DOB,Gender=@Gender,Address=@Address,Email=@Email,Mobile=@Mobile,Home=@Home,ParentName=@ParentName,NIC=@NIC,ContactNo=@ContactNo WHERE regNo=@regNo", conn);

            // Set parameters with values for the SQL query
            sqlCommand.Parameters.AddWithValue("@regNo", kryptonComboBox1.SelectedItem);
            sqlCommand.Parameters.AddWithValue("@firstName", kryptonTextBox1.Text);
            sqlCommand.Parameters.AddWithValue("@lastName", kryptonTextBox2.Text);
            sqlCommand.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
            if (radioButton1.Checked == true)
            {
                value = "Male";
            }
            else
            {
                value = "Female";
            }
            sqlCommand.Parameters.AddWithValue("@Gender", value);
            sqlCommand.Parameters.AddWithValue("@Address", kryptonTextBox5.Text);
            sqlCommand.Parameters.AddWithValue("@Email", kryptonTextBox3.Text);
            sqlCommand.Parameters.AddWithValue("@Mobile", kryptonTextBox6.Text);
            sqlCommand.Parameters.AddWithValue("@Home", kryptonTextBox7.Text);
            sqlCommand.Parameters.AddWithValue("@ParentName", kryptonTextBox10.Text);
            sqlCommand.Parameters.AddWithValue("@NIC", kryptonTextBox11.Text);
            sqlCommand.Parameters.AddWithValue("@ContactNo", kryptonTextBox8.Text);
            

            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!!!","Updated",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            refresh();

        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void kryptonLinkLabel2_LinkClicked(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure, Do you really want to exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void refresh()
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a register number first.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure, Do you really want to Delete...?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            const string del_query = "DELETE FROM student_table WHERE regNo = @regNo";
            using (SqlCommand sqlCommand = new SqlCommand(del_query, conn))
            {
                sqlCommand.Parameters.AddWithValue("@regNo", kryptonComboBox1.SelectedItem.ToString());
                try
                {
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            refresh();
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }
    }
}
