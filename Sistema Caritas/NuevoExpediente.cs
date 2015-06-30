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

namespace ExpedienteClinico
{
    public partial class NuevoExpediente : Form
    {
        public NuevoExpediente()
        {
            InitializeComponent();
        }

        private void NuevoExpediente_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            pictureBox1.Image = Image.FromFile(appPath + @"\body1.jpg");
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool foliop = textBox12.Text.All(Char.IsNumber);
            bool folionon = false;
            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);

            //create the connection string
            string connString = @"Data Source=" + appPath2 + @"\EXCL.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM Expediente";

            //create an OleDbDataAdapter to execute the query
            System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            DataTable dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);

            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow Row = dTable.Rows[i];

                if (textBox12.Text == Row["Folio"].ToString())
                {
                    folionon = true;
                    break;
                }
            }


            bool edadp = textBox2.Text.All(Char.IsNumber);
            float pesov;
            bool pesop = float.TryParse(textBox6.Text, out pesov);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "" && textBox16.Text != "" && textBox17.Text != "" && textBox18.Text != "" && textBox19.Text != "" && textBox20.Text != "" && textBox21.Text != "" && textBox22.Text != "")
            {
                if (edadp == true)
                {
                    if (pesop == true)
                    {
                        if (folionon == false)
                        {
                            if (foliop == true)
                            {
                                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                                System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                                       new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\EXCL.s3db ;Version=3;");

                                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                                cmd.CommandType = System.Data.CommandType.Text;
                                //comando sql para insercion
                                cmd.CommandText = "INSERT INTO Expediente (Folio, Nombre, Sexo, Edad, Ocupacion, Estadocivil, Religion, TA, Peso, Tema,FC, FR, EnfermedadesFamiliares, AreaAfectada, Antecedentes, Habitos,GPAC,FUMFUP,Motivo, CuadroClinico, ID, EstudiosSolicitados, TX, PX, Doctor, CP, SSA) VALUES ('" + textBox12.Text + "','" + textBox1.Text + "', '" + comboBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + comboBox2.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + comboBox3.Text + "', '" + textBox11.Text + "', '"+textBox13.Text+"', '"+comboBox4.Text+"', '"+comboBox5.Text+"', '"+textBox14.Text+"', '"+textBox15.Text+"', '"+textBox16.Text+"', '"+textBox17.Text+"', '"+textBox18.Text+"', '"+textBox19.Text+"', '"+textBox20.Text+"', '"+textBox21.Text+"', '"+textBox22.Text+"')";

                                cmd.Connection = sqlConnection1;

                                sqlConnection1.Open();
                                cmd.ExecuteNonQuery();

                                sqlConnection1.Close();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Solo introduzca numeros en el folio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Ya existe un expediente con el mismo folio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Solo introduzca numeros en el peso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Solo introduzca numeros en la edad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ha dejado campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                pictureBox1.Image = Image.FromFile(appPath + @"\body1.jpg");
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                pictureBox1.Image = Image.FromFile(appPath + @"\body2.jpg");
            }
        }
    }
}
