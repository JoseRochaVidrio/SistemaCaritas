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
    public partial class ReporteSalidaSeleccionada : Form
    {
        Int64 numero;
        public ReporteSalidaSeleccionada(Int64 num)
        {
            InitializeComponent();
            numero = num;
        }
        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }
        private void ReporteSalidaSeleccionada_Load(object sender, EventArgs e)
        {
            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBBIT.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM Salidas where Numero = '" + numero + "'";

            //create an OleDbDataAdapter to execute the query
            System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            DataTable dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);



            DataRow Row = dTable.Rows[0];
            System.Byte[] rdr = (System.Byte[])Row["Huella"];
            Image imagen = ByteToImage(rdr);
            imagen.Save(appPath2 + @"\huella.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //--------------------------
            CrystalReport8 objRpt = new CrystalReport8();

            CrystalDecisions.Shared.ParameterValues RpDatos = new CrystalDecisions.Shared.ParameterValues();
            CrystalDecisions.Shared.ParameterDiscreteValue DsCC = new CrystalDecisions.Shared.ParameterDiscreteValue();
            CrystalDecisions.Shared.ParameterField paramField = new CrystalDecisions.Shared.ParameterField();
            paramField.Name = "Imagen";

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            String ConnStr = @"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;";

            System.Data.SQLite.SQLiteConnection myConnection = new System.Data.SQLite.SQLiteConnection(ConnStr);

            String Query1 = "SELECT * FROM Salidas where Numero = " + numero;

            //String Query1 = "Select * from SRDatosGenerales Where IDFormatoSillas = '"+idformatossillas+"'";

            //String Query1 = "Select * from SRTamanoTipo Where IDFormatoSillas = '"+idformatossillas+"'";

            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(Query1, ConnStr);

            DataSet Ds = new DataSet();

            // here my_dt is the name of the DataTable which we 
            // created in the designer view.
            adapter.Fill(Ds, "DataTable5");



            // Setting data source of our report object
            objRpt.SetDataSource(Ds);


            // Binding the crystalReportViewer with our report object. 

            this.crystalReportViewer1.ReportSource = objRpt;

            appPath = appPath + @"\huella.jpg";

            DsCC.Value = appPath;
            RpDatos.Add(DsCC);
            objRpt.DataDefinition.ParameterFields["Imagen"].ApplyCurrentValues(RpDatos);
            RpDatos.Clear();
            paramField.HasCurrentValue = true;
        }
    }
}
