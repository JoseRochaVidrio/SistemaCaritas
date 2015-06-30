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

namespace Sistema_Caritas
{
    public partial class EliminarEntradaSalidaBitacora : Form
    {
        public EliminarEntradaSalidaBitacora()
        {
            InitializeComponent();
        }

        private void EliminarEntradaSalidaBitacora_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Entradas", con);
            DA.Fill(DS, "Entradas");
            dataGridView1.DataSource = DS.Tables["Entradas"];
            con.Close();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            int i = 0;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                i += c.Width;

            }
            if ((i + dataGridView1.RowHeadersWidth + 2) > 616)
            {
                dataGridView1.Width = 616;
            }
            else
            {
                dataGridView1.Width = i + dataGridView1.RowHeadersWidth + 2;
            }

            

            DS = new DataSet();
            con = new SQLiteConnection(connString);
            con.Open();
            DA = new SQLiteDataAdapter("select * from Salidas", con);
            DA.Fill(DS, "Salidas");
            dataGridView2.DataSource = DS.Tables["Salidas"];
            con.Close();

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            i = 0;
            foreach (DataGridViewColumn c in dataGridView2.Columns)
            {
                i += c.Width;

            }
            if ((i + dataGridView2.RowHeadersWidth + 2) > 616)
            {
                dataGridView2.Width = 616;
            }
            else
            {
                dataGridView2.Width = i + dataGridView2.RowHeadersWidth + 2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                panel1.BringToFront();
                label1.Text = "Buscador por entrantes";
            }
            else
            {
                panel2.BringToFront();
                label1.Text = "Buscador por salidas";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                string numero;
                try
                {

                    numero = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                           new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;");

                    System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    //comando sql para borrar
                    cmd.CommandText = "DELETE FROM Entradas WHERE [Numero] = " + numero;

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();




                    MessageBox.Show("Entrada eliminada exitosamente");

                    appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    string connString = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

                    //create the database query
                    string query = "select * from Entradas";

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
                catch
                {
                    MessageBox.Show("No se pueden borrar datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                string numero;
                try
                {

                    numero = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                           new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;");

                    System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    //comando sql para borrar
                    cmd.CommandText = "DELETE FROM Salidas WHERE [Numero] = " + numero;

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();




                    MessageBox.Show("Salida eliminada exitosamente");

                    appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    string connString = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

                    //create the database query
                    string query = "select * from Salidas";

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
                    dataGridView2.DataSource = bSource;
                    dAdapter.Update(dTable);

                }
                catch
                {
                    MessageBox.Show("No se pueden borrar datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string connString = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

                DataSet DS = new DataSet();
                SQLiteConnection con = new SQLiteConnection(connString);
                con.Open();
                SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Entradas Where Entrantes Like '%" + textBox1.Text + "%'", con);
                DA.Fill(DS, "Entradas");
                dataGridView1.DataSource = DS.Tables["Entradas"];
                con.Close();
            }
            else
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string connString = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

                DataSet DS = new DataSet();
                SQLiteConnection con = new SQLiteConnection(connString);
                con.Open();
                SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Salidas Where Salida Like '%" + textBox1.Text + "%'", con);
                DA.Fill(DS, "Salidas");
                dataGridView1.DataSource = DS.Tables["Salidas"];
                con.Close();
            }
        }
    }
}
