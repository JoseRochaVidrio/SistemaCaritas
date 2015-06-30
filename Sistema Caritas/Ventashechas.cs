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
    public partial class Ventashechas : Form
    {
        public Ventashechas()
        {
            InitializeComponent();
        }

        private void Ventashechas_Load(object sender, EventArgs e)
        {
            


            
            dataGridView2.Left = 247; 
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //create the connection string
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

            //create the database query
            string query = "SELECT * From Ventas";

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




            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            int j = 0;
            foreach (DataGridViewColumn c in dataGridView2.Columns)
            {
                j += c.Width;

            }
            dataGridView2.Width = j + dataGridView2.RowHeadersWidth + 2;


            

        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            dataGridView1.Left = 153; 
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //create the connection string
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

            //create the database query
            string query = "SELECT * From Ventashechas Where NVenta = '"+dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+"'";

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
            button5.Visible = true;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dataGridView1.Left = 247;
                
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                //create the database query
                string query = "SELECT * From Ventas Where NVenta = '" + textBox1.Text + "'";

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
            else
            {
                dataGridView1.Left = 247; 
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                //create the database query
                string query = "SELECT * From Ventas";

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

     

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro que desea eliminar toda la venta?", "Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resultado == DialogResult.Yes)
                {

                    

                    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                    new System.Data.SQLite.SQLiteConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db");

                    System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = "Delete From Ventas Where [NVenta] = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();

                    cmd.CommandText = "Delete From Ventashechas Where [NVenta] = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();

                    appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    //create the connection string
                    string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";
                    dataGridView1.Left = 247; 
                    //create the database query
                    string query = "Select * From Ventas";

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
                MessageBox.Show("Tiene que elegir una venta para eliminarlo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Reporte report = new Reporte(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                report.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
                report.Show();
            }
            catch
            {
                MessageBox.Show("No hay ventas que reportar");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                dataGridView2.Left = 247;

                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                //create the database query
                string query = "SELECT * From Ventas Where NVenta = '" + textBox2.Text + "'";

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




                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                int i = 0;
                foreach (DataGridViewColumn c in dataGridView2.Columns)
                {
                    i += c.Width;

                }
                dataGridView2.Width = i + dataGridView2.RowHeadersWidth + 2;
            }
            else
            {
                dataGridView2.Left = 247;
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                //create the database query
                string query = "SELECT * From Ventas";

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




                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                int i = 0;
                foreach (DataGridViewColumn c in dataGridView2.Columns)
                {
                    i += c.Width;

                }
                dataGridView2.Width = i + dataGridView2.RowHeadersWidth + 2;
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            dataGridView2.Left = 153;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //create the connection string
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

            //create the database query
            string query = "SELECT * From Ventashechas Where NVenta = '" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "'";

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




            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            int i = 0;
            foreach (DataGridViewColumn c in dataGridView2.Columns)
            {
                i += c.Width;

            }
            dataGridView2.Width = i + dataGridView2.RowHeadersWidth + 2;
            button4.Visible = true;
        }

        private void dataGridView2_MouseHover(object sender, EventArgs e)
        {
            
       
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Left = 247;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //create the connection string
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

            //create the database query
            string query = "SELECT * From Ventas";

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




            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            int j = 0;
            foreach (DataGridViewColumn c in dataGridView2.Columns)
            {
                j += c.Width;

            }
            dataGridView2.Width = j + dataGridView2.RowHeadersWidth + 2;
            button4.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Left = 247;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //create the connection string
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

            //create the database query
            string query = "SELECT * From Ventas";

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

            button5.Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                dataGridView1.Left = 247;
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                //create the database query
                string query = "SELECT * From Ventas";

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
            else if (tabControl1.SelectedIndex == 0)
            {
                dataGridView2.Left = 247;
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                //create the database query
                string query = "SELECT * From Ventas";

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




                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                int i = 0;
                foreach (DataGridViewColumn c in dataGridView2.Columns)
                {
                    i += c.Width;

                }
                dataGridView2.Width = i + dataGridView2.RowHeadersWidth + 2;
            }
        }

        
    }
}
