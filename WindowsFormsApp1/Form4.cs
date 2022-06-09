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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private DataSet dataSet = null;
        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "terminalDataSet.Glavn". При необходимости она может быть перемещена или удалена.
            this.glavnTableAdapter.Fill(this.terminalDataSet.Glavn);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Class1 bd = new Class1();
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"id LIKE '%{textBox1.Text}%'";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(id.Text, poezd.Text, time.Text, stan.Text);
            id.Text = ""; // clear
            poezd.Text = "";
            time.Text = "";
            stan.Text = "";
        }
    }
}
