using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kryptonTextBox2.UseSystemPasswordChar = true;
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }


        private void Login_Click(object sender, EventArgs e)
        {
            string username = kryptonTextBox1.Text;
            string password = kryptonTextBox2.Text;

            if ((username == "Admin") && (password == "admin123"))
            {
                this.Hide();
                Form3 frm = new Form3();

                frm.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials, Please check Username and Password and Try Again", "Invalid Login Details",MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
            }
            
        }

        private void clear_Click(object sender, EventArgs e)
        {
            kryptonTextBox1.Clear();
            kryptonTextBox2.Clear();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to exit?", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                kryptonTextBox2.UseSystemPasswordChar = false;
            }
            else
            {
                kryptonTextBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
