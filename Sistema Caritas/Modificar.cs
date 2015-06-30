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

namespace Caritas
{
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string fecha, nombre, apoyo;
        int edad;
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //create the connection string
            string connString = @"Data Source=" + appPath + @"\dbcar.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM Donaciones Where Nombre = '"+textBox1.Text+"' AND Edad = '"+textBox2.Text+"' AND Apoyo = '"+textBox3.Text+"'";
            
            //create an OleDbDataAdapter to execute the query
            SQLiteDataAdapter dAdapter = new SQLiteDataAdapter(query, connString);
            
            //create a command builder
            SQLiteCommandBuilder cBuilder = new SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            DataTable dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);
            try
            {
                DataRow Row = dTable.Rows[0];

                fecha = Row["Fecha"].ToString();
                nombre = Row["Nombre"].ToString();
                edad = Int32.Parse(Row["Edad"].ToString());
                apoyo = Row["Apoyo"].ToString();

                if (Row["Nombre"] != null)
                {
                    textBox1.Enabled = false;
                    button2.Enabled = true;
                    button1.Enabled = false;

                }
                else
                {
                    MessageBox.Show("No se encontro al donador");
                }
            }
            catch 
            {
                MessageBox.Show("No se encontro al donador");
            }*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                bool edadesnumero = true;
                try
                {
                    Int32.Parse(textBox2.Text);
                }
                catch
                {
                    edadesnumero = false;
                }
                if (edadesnumero == true)
                {
                    try
                    {
                        fecha = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        edad = Int32.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                        apoyo = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();


                        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                               new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\dbcar.s3db ;Version=3;");

                        System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        //comando sql para insercion
                        cmd.CommandText = "UPDATE Donaciones SET Nombre = '" + textBox1.Text + "', Edad = '" + textBox2.Text + "', Apoyo ='" + textBox3.Text + "', Comunidad = '"+textBox4.Text+"' WHERE Nombre='" + nombre + "' AND Edad='" + edad + "' AND Apoyo = '" + apoyo + "'";

                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();

                        sqlConnection1.Close();

                        MessageBox.Show("Cambios guardados con exito");

                        appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        string connString = @"Data Source=" + appPath + @"\dbcar.s3db ;Version=3;";

                        //create the database query
                        string query = "select * from Donaciones";

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
                        MessageBox.Show("No se ha seleccionado ninguna donacion para modificar");
                    }
                }
                else
                {
                    MessageBox.Show("Solo se aceptan numeros en el campo de edad");
                }
            }
            else
            {
                MessageBox.Show("No se pueden guardar los cambios ya que hay campos en blanco");
            }
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\dbcar.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Donaciones", con);
            DA.Fill(DS, "Donaciones");
            dataGridView1.DataSource = DS.Tables["Donaciones"];
            con.Close();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            int i = 0;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                i += c.Width;

            }
            if ((i + dataGridView1.RowHeadersWidth + 2) > 621)
            {
                dataGridView1.Width = 621;
            }
            else
            {
                dataGridView1.Width = i + dataGridView1.RowHeadersWidth + 2;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
