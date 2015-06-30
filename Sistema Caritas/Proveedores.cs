using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace CaritasVentas
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "" && textBox16.Text != "")
            {
                
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                       new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBPInc.s3db ;Version=3;");

                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                //comando sql para insercion
                cmd.CommandText = "INSERT INTO Proveedor Values ('" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "')";

                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();

                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
            }
            else
            {
                MessageBox.Show("Faltaron campos por llenar");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                //create the database query
                string query = "SELECT * From Proveedor";

                //create an OleDbDataAdapter to execute the query
                System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                DataTable dTable = new DataTable();

                //fill the DataTable
                dAdapter.Fill(dTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dTable;
                dataGridView1.DataSource = bSource;
                dAdapter.Update(dTable);




                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                int i = 0;
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    i += c.Width;

                }
                dataGridView1.Width = i + dataGridView1.RowHeadersWidth + 2;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro que desea eliminar?", "Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resultado == DialogResult.Yes)
                {


                    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                    new System.Data.SQLite.SQLiteConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db");

                    System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = "Delete From Proveedor Where [Nombreproveedor] = '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();

                    appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    //create the connection string
                    string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                    //create the database query
                    string query = "Select * From Proveedor";

                    //create an OleDbDataAdapter to execute the query
                    System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                    //create a command builder
                    System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                    //create a DataTable to hold the query results
                    DataTable dTable = new DataTable();

                    //fill the DataTable
                    dAdapter.Fill(dTable);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dTable;
                    dataGridView1.DataSource = bSource;
                    dAdapter.Update(dTable);

                }
            }
            else
            {
                MessageBox.Show("Tiene que elegir un articulo para borrarlo");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //create the connection string
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

            //create the database query
            string query = "SELECT * From Proveedor Where Nombreproveedor like '%"+textBox1.Text+"%'";

            //create an OleDbDataAdapter to execute the query
            System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            DataTable dTable = new DataTable();

            //fill the DataTable
            dAdapter.Fill(dTable);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dTable;
            dataGridView1.DataSource = bSource;
            dAdapter.Update(dTable);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
