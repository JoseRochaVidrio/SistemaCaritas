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
    public partial class EliminarExpedienteSillas : Form
    {
        public EliminarExpedienteSillas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EliminarExpedienteSillas_Load(object sender, EventArgs e)
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
            string idformatosilla = "";

            try
            {

                idformatosilla = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                       new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;");

                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                //comando sql para borrar
                cmd.CommandText = "DELETE FROM SRDatosGenerales WHERE [IDFormatoSillas] = " + idformatosilla;

                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();

                //comando sql para borrar
                cmd.CommandText = "DELETE FROM SRTamanoTipo WHERE [IDFormatoSillas] = " + idformatosilla;

                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();


                MessageBox.Show("Expediente eliminado exitosamente");

                appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string connString = @"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;";

                //create the database query
                string query = "select * from SRDatosGenerales";

                //create an OleDbDataAdapter to execute the query
                System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                DataTable dTable = new DataTable();

                //fill the DataTable
                dAdapter.Fill(dTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dTable;
                dataGridView1.DataSource = bSource;
                dAdapter.Update(dTable);

            }
            catch
            {
                MessageBox.Show("No se pueden borrar datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
