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
    public partial class ReporteSalidasBitacoraComedor : Form
    {
        public ReporteSalidasBitacoraComedor()
        {
            InitializeComponent();
        }

        private void ReporteSalidasBitacoraComedor_Load(object sender, EventArgs e)
        {
            CrystalReport6 objRpt = new CrystalReport6();
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            String ConnStr = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

            System.Data.SQLite.SQLiteConnection myConnection = new System.Data.SQLite.SQLiteConnection(ConnStr);

            String Query1 = "SELECT * FROM Salidas";

            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(Query1, ConnStr);

            DataSet Ds = new DataSet();

            // here my_dt is the name of the DataTable which we 
            // created in the designer view.
            adapter.Fill(Ds, "DataTable5");



            // Setting data source of our report object
            objRpt.SetDataSource(Ds);


            // Binding the crystalReportViewer with our report object. 
            this.crystalReportViewer1.ReportSource = objRpt;

            objRpt.Refresh();
        }
    }
}
