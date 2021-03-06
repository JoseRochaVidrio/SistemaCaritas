﻿using System;
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
    public partial class ConsultaEncuestas : Form
    {
        public ConsultaEncuestas()
        {
            InitializeComponent();
        }

        private void ConsultaEncuestas_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string connString = @"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;";

            DataSet DS = new DataSet();
            SQLiteConnection con = new SQLiteConnection(connString);
            con.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from DatosGenerales", con);
            DA.Fill(DS, "DatosGenerales");
            dataGridView1.DataSource = DS.Tables["DatosGenerales"];
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
            SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from DatosGenerales Where Nombre Like '%" + textBox1.Text + "%'", con);
            DA.Fill(DS, "DatosGenerales");
            dataGridView1.DataSource = DS.Tables["DatosGenerales"];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteEncuesta reporte = new ReporteEncuesta();
                reporte.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
                reporte.Show();
            }
            catch
            {
                MessageBox.Show("Error al ver el documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
