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
    public partial class ModificarEntradaSalidaBitacora : Form
    {
        public ModificarEntradaSalidaBitacora()
        {
            InitializeComponent();
        }

        private void ModificarEntradaSalidaBitacora_Load(object sender, EventArgs e)
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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string connString = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

                DataSet DS = new DataSet();
                SQLiteConnection con = new SQLiteConnection(connString);
                con.Open();
                SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Entradas Where Entrantes Like '%" + textBox1.Text + "%'", con);
                DA.Fill(DS, "Entradas");
                dataGridView1.DataSource = DS.Tables["Entradas"];
                con.Close();
            }
            else
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string connString = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

                DataSet DS = new DataSet();
                SQLiteConnection con = new SQLiteConnection(connString);
                con.Open();
                SQLiteDataAdapter DA = new SQLiteDataAdapter("select * from Salidas Where Salida Like '%" + textBox1.Text + "%'", con);
                DA.Fill(DS, "Salidas");
                dataGridView2.DataSource = DS.Tables["Salidas"];
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VerMoficarBitacora vermod = null;
                if (comboBox1.SelectedIndex == 0)
                {
                    Int64 numero = Int64.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    vermod = new VerMoficarBitacora(numero, comboBox1.Text);
                }
                else
                {
                    Int64 numero = Int64.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    vermod = new VerMoficarBitacora(numero, comboBox1.Text);
                }
                vermod.MdiParent = Bienvenida.ActiveForm;
                vermod.Show();
            }
            catch { MessageBox.Show("No hay ninguna Entrada para modificar."); }
        }

        private void ModificarEntradaSalidaBitacora_Activated(object sender, EventArgs e)
        {
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                VerMoficarBitacora vermod = null;
                if (comboBox1.SelectedIndex == 0)
                {
                    Int64 numero = Int64.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    vermod = new VerMoficarBitacora(numero, comboBox1.Text);
                }
                else
                {
                    Int64 numero = Int64.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    vermod = new VerMoficarBitacora(numero, comboBox1.Text);
                }
                vermod.MdiParent = Bienvenida.ActiveForm;
                vermod.Show();
            }
            catch
            {
                MessageBox.Show("No hay ninguna salida por modificar.");
            }
        }
    }
}
