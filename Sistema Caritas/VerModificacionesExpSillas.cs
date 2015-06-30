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
    public partial class VerModificacionesExpSillas : Form
    {
        public VerModificacionesExpSillas()
        {
            InitializeComponent();
        }

        private void VerModificacionesExpSillas_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from SRDatosGenerales", con);
            DA.Fill(DS, "SRDatosGenerales");
            dataGridView1.DataSource = DS.Tables["SRDatosGenerales"];
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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string idformatosillas = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                ModificarExpSillas ver = new ModificarExpSillas(idformatosillas);
                ver.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
                ver.Show();
            }
            catch
            {
                MessageBox.Show("Error al seleccionar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerModificacionesExpSillas_Activated(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from SRDatosGenerales", con);
            DA.Fill(DS, "SRDatosGenerales");
            dataGridView1.DataSource = DS.Tables["SRDatosGenerales"];
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from SRDatosGenerales Where Nombre Like '%" + textBox1.Text + "%'", con);
            DA.Fill(DS, "SRDatosGenerales");
            dataGridView1.DataSource = DS.Tables["SRDatosGenerales"];
            con.Close();
        }
    }
}
