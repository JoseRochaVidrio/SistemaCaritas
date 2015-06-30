using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SQLite;
using System.IO;


namespace Caritas
{
    public partial class Altas : Form
    {
        public Altas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (edadesnumero == true)
                {
                    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                           new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\dbcar.s3db ;Version=3;");

                    System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    //comando sql para insercion
                    cmd.CommandText = "INSERT INTO Donaciones VALUES ( '" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '"+textBox4.Text+"')";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();

                    MessageBox.Show("Donacion guardada con exito");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("Verifique los campos de edad, solo se aceptan numeros");
                }
            }
            else
            {
                MessageBox.Show("No se puede registrar la donacion ya que existen campos en blanco");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
