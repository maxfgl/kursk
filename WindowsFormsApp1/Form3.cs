using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Class1 bd = new Class1();

            var login = textBox1.Text;
            var password = textBox2.Text;
            string yootoo = $"insert into reg (login,password) values('{login}','{password}')";
            SqlCommand command = new SqlCommand  (yootoo, bd.getConnection());

            bd.openConnection();
            
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Пользователь создан!");
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Сорян пользователь не создан!(");
                }
                bd.closeConnection();
          


        }

       

    private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       

                
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

