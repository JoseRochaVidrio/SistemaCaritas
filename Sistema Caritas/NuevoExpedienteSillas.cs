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
    public partial class NuevoExpedienteSillas : Form
    {
        public NuevoExpedienteSillas()
        {
            InitializeComponent();
        }
        
        private void NuevoExpedienteSillas_Load(object sender, EventArgs e)
        {
            float width_ratio = (Screen.PrimaryScreen.Bounds.Width / 800);
            float heigh_ratio = (Screen.PrimaryScreen.Bounds.Height / 600f);

            SizeF scale = new SizeF(width_ratio, heigh_ratio);

            this.Scale(scale);

            //And for font size
            foreach (Control control in this.Controls)
            {
                control.Font = new Font("Microsoft Sans Serif", Font.SizeInPoints * heigh_ratio * width_ratio);
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBESIL.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM SRTamanoTipo";

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
                DataRow Row = dTable.Rows[dTable.Rows.Count-1];
                string num = Row["IDFormatoSillas"].ToString();
                int autonum = Int32.Parse(num);
                label28.Text = (autonum + 1).ToString();
            }
            else
            {
                label28.Text = "1";
            }
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            pictureBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
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
            cmd.CommandText = String.Format("INSERT INTO SRTamanoTipo VALUES ('" + label28.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "', @0);");
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
            cmd.CommandText = String.Format("INSERT INTO SRDatosGenerales VALUES ('" + label28.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "', '" + textBox13.Text + "');");
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

            panel1.BringToFront();

            this.Controls.Clear();
            this.InitializeComponent();

            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBESIL.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM SRTamanoTipo";

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
                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string num = Row["IDFormatoSillas"].ToString();
                int autonum = Int32.Parse(num);
                label28.Text = (autonum + 1).ToString();
            }
            else
            {
                label28.Text = "1";
            }

        }
        void SaveImage(byte[] imagen)
        {
            
        }
        private void button10_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
           
            
            
        }       
        
    }
}
