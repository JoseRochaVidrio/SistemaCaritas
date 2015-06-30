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
    public partial class ConsultasBitacoraComedor : Form
    {
        public ConsultasBitacoraComedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteEntradasComedor rptentradas = new ReporteEntradasComedor();
            rptentradas.MdiParent = Bienvenida.ActiveForm;
            rptentradas.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReporteSalidasBitacoraComedor rptsalidas = new ReporteSalidasBitacoraComedor();
            rptsalidas.MdiParent = Bienvenida.ActiveForm;
            rptsalidas.Show();
        }

        private void ConsultasBitacoraComedor_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Entradas", con);
            DA.Fill(DS, "Entradas");
            dataGridView1.DataSource = DS.Tables["Entradas"];
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



            DS = new DataSet();
            con = new SQLiteConnection(connString);
            con.Open();
            DA = new SQLiteDataAdapter("select * from Salidas", con);
            DA.Fill(DS, "Salidas");
            dataGridView2.DataSource = DS.Tables["Salidas"];
            con.Close();

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            i = 0;
            foreach (DataGridViewColumn c in dataGridView2.Columns)
            {
                i += c.Width;

            }
            if ((i + dataGridView2.RowHeadersWidth + 2) > 616)
            {
                dataGridView2.Width = 616;
            }
            else
            {
                dataGridView2.Width = i + dataGridView2.RowHeadersWidth + 2;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                panel1.BringToFront();
                label1.Text = "Buscador por entrantes";
            }
            else
            {
                panel2.BringToFront();
                label1.Text = "Buscador por salidas";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteEntradaSeleccionada rptentselect = new ReporteEntradaSeleccionada(Int64.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                rptentselect.MdiParent = Bienvenida.ActiveForm;
                rptentselect.Show();
            }
            catch
            {
                MessageBox.Show("No hay ninguna entrada por seleccionar"); 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteSalidaSeleccionada rptsalselect = new ReporteSalidaSeleccionada(Int64.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()));
                rptsalselect.MdiParent = Bienvenida.ActiveForm;
                rptsalselect.Show();
            }
            catch
            {
                MessageBox.Show("No hay ninguna salida por seleccionar");
            }
        }
    }
}
