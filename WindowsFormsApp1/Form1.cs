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
   
    public partial class Form1 : Form
    {
        

            public Form1()
            {
                InitializeComponent();
            }
         
        private void label1_Click(object sender, EventArgs e)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {
                Form frm = new Form3();
                frm.Show();
                this.Hide();

            }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 bd = new Class1();
            var login = textBox1.Text;
            var password = textBox2.Text;


            SqlDataAdapter adapter = new SqlDataAdapter();//для работы с БД
            DataTable table = new DataTable();//для работы с БД

            //ниже объект позволяющий прописать команду для выборки данных из БД
            //@ul и @up заглушки, на их место можно вписать сразу переменный, но тогда команда будет менее безопасна
            SqlCommand command = new SqlCommand("select * from reg where login = @ul and password = @up", bd.getConnection());

            command.Parameters.Add("@ul", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("@up", SqlDbType.VarChar).Value = password;
            //прописываем команду которую хотим выполнить:
            adapter.SelectCommand = command;
            // все полученные данные трансформируем внутрь объекта table:
            adapter.Fill(table);

            if (textBox1.Text == "admin")
            {
                Form4 frm4 = new Form4();
                frm4.Show();
                this.Hide();
            }
            else if (table.Rows.Count > 0)
            {
                MessageBox.Show("Добро Пожаловать!");
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }

            
          
        }

            private void button3_Click(object sender, EventArgs e)
            {
                Form frm = new Form2();
                frm.Show();
                this.Hide();
            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {
            textBox2.PasswordChar='*';
            }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
