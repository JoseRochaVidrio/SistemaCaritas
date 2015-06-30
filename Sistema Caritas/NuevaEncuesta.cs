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
    public partial class NuevaEncuesta : Form
    {
        public NuevaEncuesta()
        {
            InitializeComponent();
        }

        string appPath="";
        System.Data.SQLite.SQLiteCommand cmd;
        string appPath2 = "";
        string connString="";
        string query = "";
        System.Data.SQLite.SQLiteDataAdapter dAdapter;
        System.Data.SQLite.SQLiteCommandBuilder cBuilder;
        DataTable dTable;
        System.Data.SQLite.SQLiteConnection sqlConnection1;

        private void NuevaEncuesta_Load(object sender, EventArgs e)
        {
            appPath = Path.GetDirectoryName(Application.ExecutablePath);
            sqlConnection1 =
                                   new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;");

            cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            ////

            appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            connString = @"Data Source= " + appPath2 + @"\DBESIL.s3db ;Version=3;";

            //create the database query
            query = "SELECT * FROM DatosGenerales";

            //create an OleDbDataAdapter to execute the query
            dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);


            if (dTable.Rows.Count != 0)
            {
                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string num = Row["Noencuesta"].ToString();
                int autonum = Int32.Parse(num);
                label2.Text = (autonum + 1).ToString();
            }
            else
            {
                label2.Text = "1";
            }

        }

        public void mensajeparacerrarventanas()
        {
            DialogResult dialogResult = MessageBox.Show("Seguro?", "Esta seguro que desea salir?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        int contadordefamilia = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            contadordefamilia++;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            comboBox6.Visible = true;
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contadordefamilia++;
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            comboBox7.Visible = true;
            comboBox8.Visible = true;
            comboBox9.Visible = true;
            button2.Visible = false;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            contadordefamilia++;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = true;
            textBox22.Visible = true;
            comboBox10.Visible = true;
            comboBox11.Visible = true;
            comboBox12.Visible = true;
            button3.Visible = false;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            contadordefamilia++;
            textBox23.Visible = true;
            textBox24.Visible = true;
            textBox25.Visible = true;
            textBox26.Visible = true;
            comboBox13.Visible = true;
            comboBox14.Visible = true;
            comboBox15.Visible = true;
            button4.Visible = false;
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            contadordefamilia++;
            textBox27.Visible = true;
            textBox28.Visible = true;
            textBox29.Visible = true;
            textBox30.Visible = true;
            comboBox16.Visible = true;
            comboBox17.Visible = true;
            comboBox18.Visible = true;
            button5.Visible = false;
            button6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            contadordefamilia++;
            textBox31.Visible = true;
            textBox32.Visible = true;
            textBox33.Visible = true;
            textBox34.Visible = true;
            comboBox19.Visible = true;
            comboBox20.Visible = true;
            comboBox21.Visible = true;
            button6.Visible = false;
            button7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            contadordefamilia++;
            textBox35.Visible = true;
            textBox36.Visible = true;
            textBox37.Visible = true;
            textBox38.Visible = true;
            comboBox22.Visible = true;
            comboBox23.Visible = true;
            comboBox24.Visible = true;
            button7.Visible = false;
        }

        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox25.SelectedIndex >= 3)
            {
                textBox39.Visible = true;
            }
            else
            {
                textBox39.Visible = false;
            }
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            mensajeparacerrarventanas();
        }
        
        private void button18_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mensajeparacerrarventanas();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mensajeparacerrarventanas();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            mensajeparacerrarventanas();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //comando sql para insercion en datos generales
            cmd.CommandText = "INSERT INTO DatosGenerales VALUES ( '" +label2.Text+"', '"+textBox1.Text+"', '"+textBox3.Text+"', '"+textBox4.Text+"', '"+textBox45.Text+"', '"+textBox5.Text+"', '"+textBox6.Text+"', '"+textBox2.Text+"')";

            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();

            for (int i = 0; i <= contadordefamilia; i++)
            {
                if (i == 1)
                {
                    //comando sql para insercion del cuadro familiar
                    cmd.CommandText = "INSERT INTO CuadroFamiliar VALUES ( '" + label2.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "')";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();
                }
                else if (i == 2)
                {
                    //comando sql para insercion del cuadro familiar
                    cmd.CommandText = "INSERT INTO CuadroFamiliar VALUES ( '" + label2.Text + "', '" + textBox14.Text + "', '" + textBox13.Text + "', '" + comboBox6.Text + "', '" + comboBox5.Text + "', '" + comboBox4.Text + "', '" + textBox12.Text + "', '" + textBox11.Text + "')";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close(); 
                }
                else if (i == 3)
                {
                    //comando sql para insercion del cuadro familiar
                    cmd.CommandText = "INSERT INTO CuadroFamiliar VALUES ( '" + label2.Text + "', '" + textBox18.Text + "', '" + textBox17.Text + "', '" + comboBox9.Text + "', '" + comboBox8.Text + "', '" + comboBox7.Text + "', '" + textBox16.Text + "', '" + textBox15.Text + "')";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();
                }
                else if (i == 4)
                {
                    //comando sql para insercion del cuadro familiar
                    cmd.CommandText = "INSERT INTO CuadroFamiliar VALUES ( '" + label2.Text + "', '" + textBox22.Text + "', '" + textBox21.Text + "', '" + comboBox12.Text + "', '" + comboBox11.Text + "', '" + comboBox10.Text + "', '" + textBox20.Text + "', '" + textBox19.Text + "')";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close(); 
                }
                else if (i == 5)
                {
                    //comando sql para insercion del cuadro familiar
                    cmd.CommandText = "INSERT INTO CuadroFamiliar VALUES ( '" + label2.Text + "', '" + textBox26.Text + "', '" + textBox25.Text + "', '" + comboBox15.Text + "', '" + comboBox14.Text + "', '" + comboBox13.Text + "', '" + textBox24.Text + "', '" + textBox23.Text + "')";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();
 
                }
                else if (i == 6)
                {
                    //comando sql para insercion del cuadro familiar
                    cmd.CommandText = "INSERT INTO CuadroFamiliar VALUES ( '" + label2.Text + "', '" + textBox30.Text + "', '" + textBox29.Text + "', '" + comboBox18.Text + "', '" + comboBox17.Text + "', '" + comboBox16.Text + "', '" + textBox28.Text + "', '" + textBox27.Text + "')";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();
                }
                else if (i == 7)
                {
                    //comando sql para insercion del cuadro familiar
                    cmd.CommandText = "INSERT INTO CuadroFamiliar VALUES ( '" + label2.Text + "', '" + textBox34.Text + "', '" + textBox33.Text + "', '" + comboBox21.Text + "', '" + comboBox20.Text + "', '" + comboBox19.Text + "', '" + textBox32.Text + "', '" + textBox31.Text + "')";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();
                }
                else if (i == 8)
                {
                    //comando sql para insercion del cuadro familiar
                    cmd.CommandText = "INSERT INTO CuadroFamiliar VALUES ( '" + label2.Text + "', '" + textBox38.Text + "', '" + textBox37.Text + "', '" + comboBox24.Text + "', '" + comboBox23.Text + "', '" + comboBox22.Text + "', '" + textBox36.Text + "', '" + textBox35.Text + "')";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();
                }
            }
            string situacionvivienda = "";
            if (comboBox25.SelectedIndex == 0)
            {
                situacionvivienda = comboBox25.Text;
            }
            else if (comboBox25.SelectedIndex == 1)
            {
                situacionvivienda = comboBox25.Text;
            }
            else if (comboBox25.SelectedIndex == 2)
            {
                situacionvivienda = comboBox25.Text + " " + textBox39.Text;
            }
            else if (comboBox25.SelectedIndex == 3)
            {
                situacionvivienda = comboBox25.Text + " " + textBox39.Text; 
            }

            string ServiciosPublicos = "";
            if (checkedListBox1.GetItemChecked(0))
            {
                ServiciosPublicos = checkedListBox1.Items[0].ToString();
            }

            if (checkedListBox1.GetItemChecked(1))
            {
                if (ServiciosPublicos != "")
                {
                    ServiciosPublicos += ", ";
                }
                ServiciosPublicos += checkedListBox1.Items[1].ToString();
            }

            if (checkedListBox1.GetItemChecked(2))
            {
                if (ServiciosPublicos != "")
                {
                    ServiciosPublicos += ", ";
                }
                ServiciosPublicos += checkedListBox1.Items[2].ToString();
            }

            string paredes = "";
            if (checkedListBox2.GetItemChecked(0))
            {
                paredes = checkedListBox2.Items[0].ToString();
            }

            if (checkedListBox2.GetItemChecked(1))
            {
                if (paredes != "")
                {
                    paredes += ", ";
                }
                paredes += checkedListBox2.Items[1].ToString();
            }

            if (checkedListBox2.GetItemChecked(2))
            {
                if (paredes != "")
                {
                    paredes += ", ";
                }
                paredes += checkedListBox2.Items[2].ToString();
            }

            if (checkedListBox2.GetItemChecked(3))
            {
                if (paredes != "")
                {
                    paredes += ", ";
                }
                paredes += checkedListBox2.Items[3].ToString();
            }

            if (checkedListBox2.GetItemChecked(4))
            {
                if (paredes != "")
                {
                    paredes += ", ";
                }
                paredes += checkedListBox2.Items[4].ToString();
            }

            string piso = "";
            if (checkedListBox3.GetItemChecked(0))
            {
                piso = checkedListBox3.Items[0].ToString();
            }

            if (checkedListBox3.GetItemChecked(1))
            {
                if (piso != "")
                {
                    piso += ", ";
                }
                piso += checkedListBox3.Items[1].ToString();
            }

            if (checkedListBox3.GetItemChecked(2))
            {
                if (piso != "")
                {
                    piso += ", ";
                }
                piso += checkedListBox3.Items[2].ToString();
            }

            string techo = "";
            if (checkedListBox4.GetItemChecked(0))
            {
                techo = checkedListBox4.Items[0].ToString();
            }

            if (checkedListBox4.GetItemChecked(1))
            {
                if (techo != "")
                {
                    techo += ", ";
                }
                techo += checkedListBox4.Items[1].ToString();
            }

            if (checkedListBox4.GetItemChecked(2))
            {
                if (techo != "")
                {
                    techo += ", ";
                }
                techo += checkedListBox4.Items[2].ToString();
            }

            string cuartos = "";
            cuartos = label25.Text + " " + textBox41.Text + ", " + label26.Text + " " + textBox42.Text + ", " + label27.Text + " " + textBox43.Text + ", " + label28.Text + " " + textBox44.Text;

            //comando sql para insertar datos de la vivienda
            cmd.CommandText = "INSERT INTO DatosVivienda VALUES ( '" + label2.Text + "', '" + situacionvivienda + "', '" + ServiciosPublicos + "', '" + paredes + "', '" + piso + "', '" + techo + "', '" + textBox40.Text + "', '" + cuartos + "')";

            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();

            string enfermedadesfrecuentes = "";
            if (checkedListBox5.GetItemChecked(0))
            {
                enfermedadesfrecuentes = checkedListBox5.Items[0].ToString();
            }

            if (checkedListBox5.GetItemChecked(1))
            {
                if (enfermedadesfrecuentes != "")
                {
                    enfermedadesfrecuentes += ", ";
                }
                enfermedadesfrecuentes += checkedListBox5.Items[1].ToString();
            }

            if (checkedListBox5.GetItemChecked(2))
            {
                if (enfermedadesfrecuentes != "")
                {
                    enfermedadesfrecuentes += ", ";
                }
                enfermedadesfrecuentes += checkedListBox5.Items[2].ToString();
            }

            if (checkedListBox5.GetItemChecked(3))
            {
                if (enfermedadesfrecuentes != "")
                {
                    enfermedadesfrecuentes += ", ";
                }
                enfermedadesfrecuentes += checkedListBox5.Items[3].ToString();
            }

            if (checkedListBox5.GetItemChecked(4))
            {
                if (enfermedadesfrecuentes != "")
                {
                    enfermedadesfrecuentes += ", ";
                }
                enfermedadesfrecuentes += checkedListBox5.Items[4].ToString();
            }

            //comando sql para insertar datos al servicio medico
            cmd.CommandText = "INSERT INTO ServicioMedico VALUES ( '" + label2.Text + "', '" +comboBox26.Text+"', '"+enfermedadesfrecuentes+"')";

            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();


            string gastosfamiliares = "";
            gastosfamiliares = label34.Text + " " + textBox46.Text + ", " + label35.Text + " " + textBox47.Text + ", " + label36.Text + " " + textBox48.Text + ", " + label37.Text + " " + textBox49.Text + ", " + label38.Text + " " + textBox50.Text + ", " + label40.Text + " " + textBox51.Text + ", " + label41.Text + " " + textBox52.Text;


            //comando sql para insertar datos a los egresos mensuales
            cmd.CommandText = "INSERT INTO EgresosMensuales VALUES ( '" + label2.Text + "', '" + gastosfamiliares + "')";

            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();

            //comando sql para insertar datos a las observaciones
            cmd.CommandText = "INSERT INTO Observaciones VALUES ( '" + label2.Text + "', '" + richTextBox1.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox53.Text + "')";

            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();

            sqlConnection1.Close();

            MessageBox.Show("Datos Guardados con exito");
            
            panel1.BringToFront();

            this.Controls.Clear();
            this.InitializeComponent();

            appPath = Path.GetDirectoryName(Application.ExecutablePath);
            sqlConnection1 =
                                   new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;");

            cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            ////

            appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            connString = @"Data Source= " + appPath2 + @"\DBESIL.s3db ;Version=3;";

            //create the database query
            query = "SELECT * FROM DatosGenerales";

            //create an OleDbDataAdapter to execute the query
            dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);


            if (dTable.Rows.Count != 0)
            {
                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string num = Row["Noencuesta"].ToString();
                int autonum = Int32.Parse(num);
                label2.Text = (autonum + 1).ToString();
            }
            else
            {
                label2.Text = "1";
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            contadordefamilia++;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            button19.Visible = false;
            button1.Visible = true;

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (contadordefamilia == 1)
            {
                contadordefamilia--;
                button19.Visible = true;
                textBox10.Visible = false;
                textBox9.Visible = false;
                comboBox3.Visible = false;
                comboBox2.Visible = false;
                comboBox1.Visible = false;
                textBox8.Visible = false;
                textBox7.Visible = false;
            }
            else if (contadordefamilia == 2)
            {
                contadordefamilia--;
                button1.Visible = true;
                textBox14.Visible = false;
                textBox13.Visible = false;
                comboBox6.Visible = false;
                comboBox5.Visible = false;
                comboBox4.Visible = false;
                textBox12.Visible = false;
                textBox11.Visible = false;
            }
            else if (contadordefamilia == 3)
            {
                contadordefamilia--;
                button2.Visible = true;
                textBox18.Visible = false;
                textBox17.Visible = false;
                comboBox9.Visible = false;
                comboBox8.Visible = false;
                comboBox7.Visible = false;
                textBox16.Visible = false;
                textBox15.Visible = false;
            }
            else if (contadordefamilia == 4)
            {
                contadordefamilia--;
                button3.Visible = true;
                textBox22.Visible = false;
                textBox21.Visible = false;
                comboBox12.Visible = false;
                comboBox11.Visible = false;
                comboBox10.Visible = false;
                textBox20.Visible = false;
                textBox19.Visible = false;
            }
            else if (contadordefamilia == 5)
            {
                contadordefamilia--;
                button4.Visible = true;
                textBox26.Visible = false;
                textBox25.Visible = false;
                comboBox15.Visible = false;
                comboBox14.Visible = false;
                comboBox13.Visible = false;
                textBox24.Visible = false;
                textBox23.Visible = false;

            }
            else if (contadordefamilia == 6)
            {
                contadordefamilia--;
                button5.Visible = true;
                textBox30.Visible = false;
                textBox29.Visible = false;
                comboBox18.Visible = false;
                comboBox17.Visible = false;
                comboBox16.Visible = false;
                textBox28.Visible = false;
                textBox27.Visible = false;
            }
            else if (contadordefamilia == 7)
            {
                contadordefamilia--;
                button6.Visible = true;
                textBox34.Visible = false;
                textBox33.Visible = false;
                comboBox21.Visible = false;
                comboBox20.Visible = false;
                comboBox19.Visible = false;
                textBox32.Visible = false;
                textBox31.Visible = false;
            }
            else if (contadordefamilia == 8)
            {
                contadordefamilia--;
                button7.Visible = true;
                textBox38.Visible = false;
                textBox37.Visible = false;
                comboBox24.Visible = false;
                comboBox23.Visible = false;
                comboBox22.Visible = false;
                textBox36.Visible = false;
                textBox35.Visible = false;
            }
        }

        
    }
}
