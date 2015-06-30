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
    public partial class BajaExp : Form
    {
        public BajaExp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        int folio, edad;
        string nombre, sexo, estadocivil;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                folio = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                sexo = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                edad = Int32.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                estadocivil = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();


                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                       new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\EXCL.s3db ;Version=3;");

                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                //comando sql para insercion
                cmd.CommandText = "DELETE FROM Expediente WHERE [Folio] = " + folio + " AND [Nombre] = '" + nombre + "' AND [Sexo] = '" + sexo + "' AND [Edad] = " + edad + " AND [Estadocivil] = '" + estadocivil + "'";

                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();
                MessageBox.Show("Expediente eliminado exitosamente");
            }
            catch
            {
                MessageBox.Show("No se pueden borrar datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Baja_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\EXCL.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Expediente", con);
            DA.Fill(DS, "Expediente");
            dataGridView1.DataSource = DS.Tables["Expediente"];
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
            }
            else
            {
                dataGridView1.Width = i + dataGridView1.RowHeadersWidth + 2;
            }
        }
    }
}
