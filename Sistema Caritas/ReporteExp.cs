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
using Sistema_Caritas;

namespace ExpedienteClinico
{
    public partial class ReporteExp : Form
    {
        int foliom;
        string areaaf;
        public ReporteExp(int folio, string areaafectada)
        {
            InitializeComponent();
            foliom = folio;
            areaaf = areaafectada;
        }

        private void Reporte_Load(object sender, EventArgs e)
        {


            CrystalReport3 objRpt = new CrystalReport3();
            CrystalDecisions.Shared.ParameterValues RpDatos = new CrystalDecisions.Shared.ParameterValues();
            CrystalDecisions.Shared.ParameterDiscreteValue DsCC = new CrystalDecisions.Shared.ParameterDiscreteValue();
            CrystalDecisions.Shared.ParameterField paramField = new CrystalDecisions.Shared.ParameterField();
            paramField.Name = "Imagen";


            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            String ConnStr = @"Data Source=" + appPath + @"\EXCL.s3db ;Version=3;";

            System.Data.SQLite.SQLiteConnection myConnection = new System.Data.SQLite.SQLiteConnection(ConnStr);

            String Query1 = "SELECT * FROM Expediente Where Folio = '" + foliom + "'";

            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(Query1, ConnStr);

            DataSet Ds = new DataSet();

            // here my_dt is the name of the DataTable which we 
            // created in the designer view.
            adapter.Fill(Ds, "DataTable2");



            // Setting data source of our report object
            objRpt.SetDataSource(Ds);


            // Binding the crystalReportViewer with our report object. 

            this.crystalReportViewer1.ReportSource = objRpt;
            if (areaaf == "Frente")
            {
                appPath = Path.GetDirectoryName(Application.ExecutablePath);
                appPath = appPath + @"\body1.jpg";
            }
            else if (areaaf == "Espalda")
            {
                appPath = Path.GetDirectoryName(Application.ExecutablePath);
                appPath = appPath + @"\body2.jpg";
            }
            DsCC.Value = appPath;
            RpDatos.Add(DsCC);
            objRpt.DataDefinition.ParameterFields["Imagen"].ApplyCurrentValues(RpDatos);
            RpDatos.Clear();
            paramField.HasCurrentValue = true;
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
