﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "terminalDataSet.Glavn". При необходимости она может быть перемещена или удалена.
            this.glavnTableAdapter.Fill(this.terminalDataSet.Glavn);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Storage for the order ID value.
        private int parsedOrderID;

        /// <summary>
        /// Verifies that an order ID is present and contains valid characters.
        /// </summary>
        private bool IsCustomerNameValid()
        {
            // Check for input in the Order ID text box.
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please specify the Order ID.");
                return false;
            }

            // Check for characters other than integers.
            else if (Regex.IsMatch(textBox1.Text, @"^\D*$"))
            {
                // Show message and clear input.
                MessageBox.Show("Customer ID must contain only numbers.");
                textBox1.Clear();
                return false;
            }
            else
            {
                // Convert the text in the text box to an integer to send to the database.
                parsedOrderID = Int32.Parse(textBox1.Text);
                return true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (IsCustomerNameValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    // Define a t-SQL query string that has a parameter for orderID.
                    const string sql = "SELECT * FROM Glavn WHERE id = @id";

                    // Create a SqlCommand object.
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        // Define the @orderID parameter and set its value.
                        sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar));
                        sqlCommand.Parameters["@id"].Value = parsedOrderID;

                        try
                        {
                            connection.Open();

                            // Run the query by calling ExecuteReader().
                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                // Create a data table to hold the retrieved data.
                                DataTable dataTable = new DataTable();

                                // Load the data from SqlDataReader into the data table.
                                dataTable.Load(dataReader);

                                // Display the data from the data table in the data grid view.
                                this.dataGridView1.DataSource = dataTable;

                                // Close the SqlDataReader.
                                dataReader.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("The requested order could not be loaded into the form.");
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}

  

