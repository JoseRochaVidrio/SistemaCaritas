using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ExpedienteClinico
{
    public partial class VerExp : Form
    {
        int foliom;
        public VerExp(int folio, string nombre,string sexo,string estadocivil,int edad,string ocupacion, float peso, string religion,string TA,string tema,string FC, string FR,string enfermedadesfam,string areaafectada,string antecedentes, string habitos, string GPAC, string FUMFUP, string motivo, string cuadroclinico, string id, string estudios, string PX, string TX, string doctor, string CP, string SSA)
        {
            InitializeComponent();
            foliom = folio;
            textBox1.Text = nombre;
            comboBox1.SelectedIndex = comboBox1.FindString(sexo);
            comboBox2.SelectedIndex = comboBox2.FindString(estadocivil);
            textBox2.Text = edad.ToString();
            textBox4.Text = ocupacion;
            textBox6.Text = peso.ToString();
            textBox3.Text = religion;
            textBox5.Text = TA;
            textBox7.Text = tema;
            textBox8.Text = FC;
            textBox9.Text = FR;
            textBox10.Text = enfermedadesfam;
            comboBox3.SelectedIndex = comboBox3.FindString(areaafectada);
            textBox11.Text = antecedentes;
            textBox12.Text = folio.ToString();
            textBox13.Text = habitos;
            textBox14.Text = motivo;
            comboBox4.SelectedIndex = comboBox4.FindString(GPAC);
            comboBox5.SelectedIndex = comboBox5.FindString(FUMFUP);
            textBox15.Text = cuadroclinico;
            textBox17.Text = estudios;
            textBox16.Text = id;
            textBox18.Text = TX;
            textBox19.Text = PX;
            textBox20.Text = doctor;
            textBox21.Text = CP;
            textBox22.Text = SSA;
        }

        private void Ver_Load(object sender, EventArgs e)
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool edadp = textBox2.Text.All(Char.IsNumber);
            float pesov;
            bool pesop = float.TryParse(textBox6.Text, out pesov);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "" && textBox16.Text != "" && textBox17.Text != "" && textBox18.Text != "" && textBox19.Text != "" && textBox20.Text != "" && textBox21.Text != "" && textBox22.Text != "")
            {
                if (edadp == true)
                {
                    if (pesop == true)
                    {
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                               new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\EXCL.s3db ;Version=3;");

                        System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        //comando sql para insercion
                        cmd.CommandText = "UPDATE Expediente Set Nombre = '" + textBox1.Text + "' , Sexo = '" + comboBox1.Text + "', Edad = '" + textBox2.Text + "', Ocupacion = '" + textBox4.Text + "', Estadocivil = '" + comboBox2.Text + "', Religion = '" + textBox3.Text + "', TA = '" + textBox5.Text + "', Peso = '" + textBox6.Text + "', Tema = '" + textBox7.Text + "',FC = '" + textBox8.Text + "', FR = '" + textBox9.Text + "', EnfermedadesFamiliares = '" + textBox10.Text + "', AreaAfectada = '" + comboBox3.Text + "', Antecedentes = '" + textBox11.Text + "', Habitos = '"+textBox13.Text+"', GPAC = '"+comboBox4.Text+"', FUMFUP = '"+comboBox5.Text+"', Motivo = '"+textBox14.Text+"', CuadroClinico = '"+textBox15.Text+"', ID = '"+textBox16.Text+"', EstudiosSolicitados = '"+textBox17.Text+"', TX = '"+textBox18.Text+"', PX = '"+textBox19.Text+"', Doctor = '"+textBox20.Text+"', CP = '"+textBox21.Text+"', SSA = '"+textBox22.Text+"' Where Folio =" + foliom + "";

                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();

                        sqlConnection1.Close();
                        this.Close();


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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
