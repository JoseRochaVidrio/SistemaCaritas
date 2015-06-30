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
    public partial class ModificarUsuario : Form
    {
        public ModificarUsuario()
        {
            InitializeComponent();
        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\DBUC.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select Nombre,Usuario,TipoDeUsuario from Usuarios", con);
            DA.Fill(DS, "Usuarios");
            dataGridView1.DataSource = DS.Tables["Usuarios"];
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
                dataGridView1.Left = 79;
            }
            else
            {
                dataGridView1.Width = i + dataGridView1.RowHeadersWidth + 2;
                dataGridView1.Left = 211;
            }

            try
            {
                ///create the connection string
                string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                ///create the connection string
                connString = @"Data Source= " + appPath2 + @"\DBUC.s3db ;Version=3;";
                string nombre = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string usuario = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string tipodeusuario = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                //create the database query
                string query = "SELECT * FROM Usuarios WHERE Nombre = '" + nombre + "' AND Usuario = '" + usuario + "' AND TipoDeUsuario = '" + tipodeusuario + "'";

                //create an OleDbDataAdapter to execute the query
                System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                DataTable dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                DataRow Row = dTable.Rows[0];
                string contrasena = Row["Contrasena"].ToString();

                textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = usuario;
                textBox3.Text = contrasena;
                textBox4.Text = contrasena;
                comboBox1.SelectedIndex = comboBox1.FindStringExact(tipodeusuario);
            }
            catch
            {
                textBox5.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.SelectedIndex = 1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox4.Text != "" && textBox3.Text != "" && textBox2.Text != "")
            {
                try
                {

                    ///create the connection string
                    string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                    ///create the connection string
                    string connString = @"Data Source= " + appPath2 + @"\DBUC.s3db ;Version=3;";
                    string nombre = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string usuario = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string tipodeusuario = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    //create the database query
                    string query = "SELECT * FROM Usuarios WHERE Nombre = '" + nombre + "' AND Usuario = '" + usuario + "' AND TipoDeUsuario = '" + tipodeusuario + "'";

                    //create an OleDbDataAdapter to execute the query
                    System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                    //create a command builder
                    System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                    //create a DataTable to hold the query results
                    DataTable dTable = new DataTable();
                    //fill the DataTable
                    dAdapter.Fill(dTable);
                    dAdapter.Update(dTable);


                    DataRow Row = dTable.Rows[0];
                    string ID = Row["ID"].ToString();


                    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                           new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBUC.s3db ;Version=3;");

                    System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    //comando sql para insercion
                    cmd.CommandText = "UPDATE Usuarios SET Nombre = '" + textBox5.Text + "', Usuario = '" + textBox2.Text + "', Contrasena = '" + textBox3.Text + "', TipoDeUsuario = '" + comboBox1.Text + "', FechaContrasena = '" + DateTime.Now.ToShortDateString() + "' WHERE ID = '" + ID + "'";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();
                    MessageBox.Show("Usuario modificado exitosamente");

                    appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    connString = @"Data Source=" + appPath + @"\DBUC.s3db ;Version=3;";

                    //create the database query
                    query = "select Nombre,Usuario,TipoDeUsuario from Usuarios";

                    //create an OleDbDataAdapter to execute the query
                    dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                    //create a command builder
                    cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                    //create a DataTable to hold the query results
                    dTable = new DataTable();

                    //fill the DataTable
                    dAdapter.Fill(dTable);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dTable;
                    dataGridView1.DataSource = bSource;
                    dAdapter.Update(dTable);
                }
                catch
                {
                    MessageBox.Show("No hay usuarios que modificar");
                }
            }
            else
            {
                MessageBox.Show("No puede dejar espacios en blanco");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                ///create the connection string
                string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                ///create the connection string
                string connString = @"Data Source= " + appPath2 + @"\DBUC.s3db ;Version=3;";
                string nombre = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string usuario = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string tipodeusuario = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                //create the database query
                string query = "SELECT * FROM Usuarios WHERE Nombre = '" + nombre + "' AND Usuario = '" + usuario + "' AND TipoDeUsuario = '" + tipodeusuario + "'";

                //create an OleDbDataAdapter to execute the query
                System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                DataTable dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                DataRow Row = dTable.Rows[0];
                string contrasena = Row["Contrasena"].ToString();

                textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = usuario;
                textBox3.Text = contrasena;
                textBox4.Text = contrasena;
                comboBox1.SelectedIndex = comboBox1.FindStringExact(tipodeusuario);
            }
            catch
            {
                textBox5.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.SelectedIndex = 1; 
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox3.Text != "")
            {
                if (textBox4.Text == textBox3.Text)
                {
                    label5.Text = "OK";
                    button1.Enabled = true;
                }
                else
                {
                    label5.Text = "No coinciden";
                    button1.Enabled = false;
                }
            }
            else
            {
                label5.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox3.Text != "")
            {
                if (textBox4.Text == textBox3.Text)
                {
                    label5.Text = "OK";
                    button1.Enabled = true;
                }
                else
                {
                    label5.Text = "No coinciden";
                    button1.Enabled = false;
                }
            }
            else
            {
                label5.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBUC.s3db";
                string query = "";

                query = "SELECT Nombre,Usuario,TipoDeUsuario from Usuarios WHERE Usuario LIKE '%" + textBox1.Text + "%'";

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

                if (dataGridView1.Rows.Count == 0)
                {
                    textBox5.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox1.SelectedIndex = 1; 
                }
            }
            else
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBUC.s3db";
                string query = "";

                query = "SELECT Nombre,Usuario,TipoDeUsuario from Usuarios";

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
    }
}
