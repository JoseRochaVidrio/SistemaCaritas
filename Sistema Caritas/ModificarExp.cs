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
    public partial class ModificarExp : Form
    {
        public ModificarExp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int folio = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string sexo = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string estadocivil = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                int edad = Int32.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                string ocupacion = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                float peso = float.Parse(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
                string religion = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string TA = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string tema = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                string FC = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                string FR = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                string enfermedadesfam = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                string areaafectada = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                string antecedentes = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                string habitos = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                string GPAC = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                string FUMFUP = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                string motivo = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                string cuadroclinico = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                string ID = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                string estudios = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
                string TX = dataGridView1.SelectedRows[0].Cells[22].Value.ToString();
                string PX = dataGridView1.SelectedRows[0].Cells[23].Value.ToString();
                string doctor = dataGridView1.SelectedRows[0].Cells[24].Value.ToString();
                string CP = dataGridView1.SelectedRows[0].Cells[25].Value.ToString();
                string ssa = dataGridView1.SelectedRows[0].Cells[26].Value.ToString();
                VerExp ver = new VerExp(folio, nombre, sexo, estadocivil, edad, ocupacion, peso, religion, TA, tema, FC, FR, enfermedadesfam, areaafectada, antecedentes, habitos, GPAC, FUMFUP, motivo, cuadroclinico, ID, estudios, PX, TX, doctor, CP, ssa);
                ver.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
                ver.Show();
            }
            catch
            {
                MessageBox.Show("Error al seleccionar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Modificar_Load(object sender, EventArgs e)
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

        private void Modificar_Activated(object sender, EventArgs e)
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\EXCL.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Expediente Where Nombre Like '%" + textBox1.Text + "%'", con);
            DA.Fill(DS, "Expediente");
            dataGridView1.DataSource = DS.Tables["Expediente"];
            con.Close();
        }
    }
}
