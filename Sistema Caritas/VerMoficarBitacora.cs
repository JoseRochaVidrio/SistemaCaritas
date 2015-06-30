using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Sistema_Caritas
{
    public partial class VerMoficarBitacora : Form
    {
        Int64 numero;
        string entradasalida;
        public VerMoficarBitacora(Int64 num, string es)
        {
            InitializeComponent();
            numero = num;
            entradasalida = es;
        }

        private void VerMoficarBitacora_Load(object sender, EventArgs e)
        {
            if (entradasalida == "Entradas")
            {
                panel1.BringToFront();
                string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                ///create the connection string
                string connString = @"Data Source= " + appPath2 + @"\DBBIT.s3db ;Version=3;";

                //create the database query
                string query = "SELECT * FROM Entradas where Numero = " + numero;

                //create an OleDbDataAdapter to execute the query
                System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                DataTable dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                if (dTable.Rows.Count != 0)
                {
                    DataRow Row = dTable.Rows[0];
                    string num = Row["Numero"].ToString();
                    int autonum = Int32.Parse(num);
                    label1.Text = (autonum).ToString();
                    textBox1.Text = Row["Entrantes"].ToString();
                    textBox2.Text = Row["Descripcion"].ToString();
                    textBox3.Text = Row["Cantidad"].ToString();
                    textBox4.Text = Row["Peso"].ToString();
                    textBox5.Text = Row["Equivalentes"].ToString();
                    textBox6.Text = Row["Notas"].ToString();
                    textBox7.Text = Row["Procedencia"].ToString();
                    comboBox1.SelectedIndex = comboBox1.FindStringExact(Row["Utilidad"].ToString());
                    textBox8.Text = Row["Responsable"].ToString();

                }
                else
                {

                }

            }
            else
            {
                panel2.BringToFront();
                string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                ///create the connection string
                string connString = @"Data Source= " + appPath2 + @"\DBBIT.s3db ;Version=3;";

                //create the database query
                string query = "SELECT * FROM Salidas where Numero = " + numero;

                //create an OleDbDataAdapter to execute the query
                System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                DataTable dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                if (dTable.Rows.Count != 0)
                {
                    DataRow Row = dTable.Rows[0];
                    string num = Row["Numero"].ToString();
                    int autonum = Int32.Parse(num);
                    label12.Text = (autonum).ToString();
                    textBox9.Text = Row["Salida"].ToString();
                    textBox11.Text = Row["Descripcion"].ToString();
                    textBox12.Text = Row["Cantidad"].ToString();
                    textBox14.Text = Row["Peso"].ToString();
                    textBox16.Text = Row["Equivalentes"].ToString();
                    textBox15.Text = Row["Nota"].ToString();
                    textBox13.Text = Row["TipoDeApoyo"].ToString();
                    textBox10.Text = Row["Responsable"].ToString();

                }
                else
                {

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cantidad;
            if (int.TryParse(textBox3.Text, out cantidad))
            {
                float peso;
                if (float.TryParse(textBox4.Text, out peso))
                {
                    try
                    {
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                               new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;");

                        System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        //comando sql para insercion
                        cmd.CommandText = "UPDATE Entradas Set Entrantes = '" + textBox1.Text + "' , Descripcion = '" + textBox2.Text + "', Cantidad = '" + textBox3.Text + "', Peso = '" + textBox4.Text + "', Equivalentes = '" + textBox5.Text + "', Notas = '" + textBox6.Text + "', Procedencia = '" + textBox7.Text + "', Utilidad = '" + comboBox1.Text + "', Responsable = '" + textBox8.Text + "' where Numero = " + label1.Text;

                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();

                        sqlConnection1.Close();

                        MessageBox.Show("Modificaciones realizadas con exito.");
                    }
                    catch
                    {
                        MessageBox.Show("Surgio un error, verifique sus campos de nuevo.");
                    }
                }
                else
                {
                    MessageBox.Show("Revise de nuevo su campo de peso, solo se permiten numeros flotantes.");
                }
            }
            else
            {
                MessageBox.Show("Revise de nuevo su campo de cantidad, solo se permiten numeros.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int cantidad;
            if (int.TryParse(textBox12.Text, out cantidad))
            {
                float peso;
                if (float.TryParse(textBox14.Text, out peso))
                {
                    try
                    {
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                               new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;");

                        System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        //comando sql para insercion
                        cmd.CommandText = "UPDATE Salidas Set Salida = '" + textBox9.Text + "' , Descripcion = '" + textBox11.Text + "', Cantidad = '" + textBox12.Text + "', Peso = '" + textBox14.Text + "', Equivalentes = '" + textBox16.Text + "', Nota = '" + textBox15.Text + "', TipoDeApoyo = '" + textBox13.Text + "', Responsable = '" + textBox10.Text + "' where Numero = " + label12.Text;

                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();

                        sqlConnection1.Close();

                        MessageBox.Show("Modificaciones realizadas con exito.");
                    }
                    catch
                    {
                        MessageBox.Show("Surgio un error, verifique sus campos de nuevo.");
                    }
                }
                else
                {
                    MessageBox.Show("Revise de nuevo su campo de peso, solo se permiten numeros flotantes.");
                }
            }
            else
            {
                MessageBox.Show("Revise de nuevo su campo de cantidad, solo se permiten numeros.");
            }
        }
    }
}
