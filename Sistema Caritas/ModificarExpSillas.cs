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
    public partial class ModificarExpSillas : Form
    {
        public string idformatossillas;
        public ModificarExpSillas(string IDFormatoSillas)
        {
            InitializeComponent();
            idformatossillas = IDFormatoSillas;

            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBESIL.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM SRDatosGenerales where IDFormatoSillas = '"+idformatossillas+"'";

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
            label28.Text = Row["IDFormatoSillas"].ToString();
            dateTimePicker1.Value = DateTime.Parse(Row["Fecha"].ToString());
            dateTimePicker2.Value = DateTime.Parse(Row["Fechadenacimiento"].ToString());
            textBox1.Text = Row["Edad"].ToString();
            textBox2.Text = Row["Nombre"].ToString();
            comboBox1.SelectedIndex = comboBox1.FindStringExact(Row["Genero"].ToString());
            textBox3.Text = Row["ClinicaAsociacionMedica"].ToString();
            textBox4.Text = Row["Direccion"].ToString();
            textBox5.Text = Row["Ciudad"].ToString();
            textBox6.Text = Row["Estado"].ToString();
            textBox7.Text = Row["Pais"].ToString();
            textBox8.Text = Row["Telefono"].ToString();
            textBox9.Text = Row["Fax"].ToString();
            textBox10.Text = Row["Email"].ToString();
            textBox11.Text = Row["TipoDiscapacidad"].ToString();
            textBox12.Text = Row["Estatura"].ToString();
            textBox13.Text = Row["Peso"].ToString();

            //create the database query
            query = "SELECT * FROM SRTamanoTipo where IDFormatoSillas = '" + idformatossillas + "'";

            //create an OleDbDataAdapter to execute the query
            dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);

            Row = dTable.Rows[0];
            textBox14.Text = Row["Coronilla"].ToString();
            textBox15.Text = Row["Hombro"].ToString();
            textBox16.Text = Row["PiernaSuperior"].ToString();
            textBox17.Text = Row["PiernaInferior"].ToString();
            textBox18.Text = Row["Pecho"].ToString();
            textBox19.Text = Row["Cadera"].ToString();
            comboBox2.SelectedIndex = comboBox2.FindStringExact(Row["SentarseSinAyuda"].ToString());
            comboBox3.SelectedIndex = comboBox2.FindStringExact(Row["SoporteCabeza"].ToString());
            comboBox4.SelectedIndex = comboBox2.FindStringExact(Row["SoporteCuerpo"].ToString());
            
            System.Byte[] rdr = (System.Byte[])Row["Foto"];
            pictureBox2.Image = ByteToImage(rdr);
        }
        //public Image Base64ToImage(string base64String)
        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }
        private void ModificarExpSillas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            pictureBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
        }
        public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            byte[] pic = ImageToByte(pictureBox2.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);

            string conStringDatosUsuarios = @"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;";
            SQLiteConnection con = new SQLiteConnection(conStringDatosUsuarios);
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = String.Format("UPDATE SRTamanoTipo Set IDFormatoSillas = '" + idformatossillas + "',	Coronilla = '" + textBox14.Text + "',	Hombro = '" + textBox15.Text + "',	PiernaSuperior ='" + textBox16.Text + "',	PiernaInferior = '"+textBox17.Text+"',	Pecho = '"+textBox18.Text+"',	Cadera = '"+textBox19.Text+"',	SentarseSinAyuda = '"+comboBox2.Text+"',	SoporteCabeza = '"+comboBox3.Text+"',	SoporteCuerpo = '"+comboBox4.Text+"',	Foto =  @0 where IDFormatoSillas = '"+idformatossillas+"';");
            SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
            param.Value = pic;
            cmd.Parameters.Add(param);
            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc1)
            {
                MessageBox.Show(exc1.Message);
            }
            con.Close();

            //-----
            cmd.CommandText = String.Format("UPDATE SRDatosGenerales Set IDFormatoSillas = '" + idformatossillas + "', Fecha = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', FechadeNacimiento = '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', Edad = '" + textBox1.Text + "', Nombre = '" + textBox2.Text + "', Genero = '" + comboBox1.Text + "', ClinicaAsociacionMedica = '" + textBox3.Text + "', Direccion = '" + textBox4.Text + "', Ciudad = '" + textBox5.Text + "', Estado = '" + textBox6.Text + "', Pais = '" + textBox7.Text + "', Telefono = '" + textBox8.Text + "', Fax = '" + textBox9.Text + "', Email = '" + textBox10.Text + "', TipoDiscapacidad = '" + textBox11.Text + "', Estatura = '" + textBox12.Text + "', Peso = '" + textBox13.Text + "' where IDFormatoSillas = '" + idformatossillas + "';");
            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc1)
            {
                MessageBox.Show(exc1.Message);
            }
            con.Close();

            MessageBox.Show("Datos guardados con exito");
            panel1.BringToFront();
        }
    }
}
