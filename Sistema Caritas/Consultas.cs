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
using Sistema_Caritas;

namespace Caritas
{
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source="+appPath+@"\dbcar.s3db ;Version=3;";

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
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    
                    AllReport report = new AllReport();
                    report.Show();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    string fecha = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    int edad = Int32.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                    string apoyo = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    Rptpordonador donador = new Rptpordonador(fecha, nombre, edad, apoyo);
                    donador.Show();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    string fecha = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;
                    
                    ReporteDonadoresSPC donador = new ReporteDonadoresSPC(fecha);
                    donador.Show(); 
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    string apoyo = textBox2.Text;

                    ReporteDonadoresType donador = new ReporteDonadoresType(apoyo);
                    donador.Show();
 
                }
            }
            catch
            {
                MessageBox.Show("No hay ningun donador que mostrar.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\dbcar.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = null;
            if (comboBox2.SelectedIndex == 0)
            {
                DA = new SQLiteDataAdapter("select * from Donaciones Where Nombre Like '%" + textBox1.Text + "%'", con);
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                DA = new SQLiteDataAdapter("select * from Donaciones Where Apoyo Like '%" +textBox1.Text + "%'", con); 
            
            }
            else if (textBox1.Text.Length == 0)
            {
                DA = new SQLiteDataAdapter("select * from Donaciones", con);  
            }
            DA.Fill(DS, "Donaciones");
            dataGridView1.DataSource = DS.Tables["Donaciones"];
            con.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
            {
                dateTimePicker2.Visible = true;
                textBox2.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                dateTimePicker2.Visible = false;
                textBox2.Visible = true;
            }
            else
            {
                dateTimePicker2.Visible = false;
                textBox2.Visible = false;
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
            {
                dateTimePicker1.Visible = true;
                textBox1.Visible = false;
            }
            else
            {
                dateTimePicker1.Visible = false;
                textBox1.Visible = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\dbcar.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Donaciones Where Fecha Like '%" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year + "%'", con); 
            
            DA.Fill(DS, "Donaciones");
            dataGridView1.DataSource = DS.Tables["Donaciones"];
            con.Close();
            
        }
        
    }
}
