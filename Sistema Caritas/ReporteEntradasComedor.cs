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
    public partial class ReporteEntradasComedor : Form
    {
       
        public ReporteEntradasComedor()
        {
            InitializeComponent();
            
        }

        private void ReporteEntradasComedor_Load(object sender, EventArgs e)
        {
            CrystalReport5 objRpt = new CrystalReport5();
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            String ConnStr = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

            System.Data.SQLite.SQLiteConnection myConnection = new System.Data.SQLite.SQLiteConnection(ConnStr);

            String Query1 = "SELECT * FROM Entradas";

            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(Query1, ConnStr);

            DataSet Ds = new DataSet();

            // here my_dt is the name of the DataTable which we 
            // created in the designer view.
            adapter.Fill(Ds, "DataTable4");



            // Setting data source of our report object
            objRpt.SetDataSource(Ds);


            // Binding the crystalReportViewer with our report object. 
            this.crystalReportViewer1.ReportSource = objRpt;

            objRpt.Refresh();
        }
    }
}
