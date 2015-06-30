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
    public partial class ReporteSillasR : Form
    {
        public string idformatossillas;
        public ReporteSillasR(string IDFormatoSilla)
        {
            InitializeComponent();
            idformatossillas = IDFormatoSilla;
        }
        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }
        private void ReporteSillasR_Load(object sender, EventArgs e)
        {
            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBESIL.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM SRTamanoTipo where IDFormatoSillas = '"+idformatossillas+"'";

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
            System.Byte[] rdr = (System.Byte[])Row["Foto"];
            Image imagen = ByteToImage(rdr);
            imagen.Save(appPath2 + @"\perfil.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //--------------------------
            CrystalReport4 objRpt = new CrystalReport4();

            CrystalDecisions.Shared.ParameterValues RpDatos = new CrystalDecisions.Shared.ParameterValues();
            CrystalDecisions.Shared.ParameterDiscreteValue DsCC = new CrystalDecisions.Shared.ParameterDiscreteValue();
            CrystalDecisions.Shared.ParameterField paramField = new CrystalDecisions.Shared.ParameterField();
            paramField.Name = "Imagen";

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            String ConnStr = @"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;";

            System.Data.SQLite.SQLiteConnection myConnection = new System.Data.SQLite.SQLiteConnection(ConnStr);

            String Query1 = "SELECT SRDatosGenerales.IDFormatoSillas as IDFormatoSillas, Fecha,	FechadeNacimiento, Edad, Nombre, Genero, ClinicaAsociacionMedica, Direccion, Ciudad, Estado, Pais, Telefono, Fax, Email, TipoDiscapacidad, Estatura, Peso, Coronilla, Hombro, PiernaSuperior, PiernaInferior, Pecho, Cadera, SentarseSinAyuda, SoporteCabeza, SoporteCuerpo, Foto  FROM SRDatosGenerales, SRTamanoTipo Where SRDatosGenerales.IDFormatoSillas = '" + idformatossillas + "' AND SRTamanoTipo.IDFormatoSillas = '"+idformatossillas+"'";

            //String Query1 = "Select * from SRDatosGenerales Where IDFormatoSillas = '"+idformatossillas+"'";

            //String Query1 = "Select * from SRTamanoTipo Where IDFormatoSillas = '"+idformatossillas+"'";

            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(Query1, ConnStr);

            DataSet Ds = new DataSet();

            // here my_dt is the name of the DataTable which we 
            // created in the designer view.
            adapter.Fill(Ds, "DataTable3");



            // Setting data source of our report object
            objRpt.SetDataSource(Ds);


            // Binding the crystalReportViewer with our report object. 

            this.crystalReportViewer1.ReportSource = objRpt;

            appPath = appPath + @"\perfil.jpg";

            DsCC.Value = appPath;
            RpDatos.Add(DsCC);
            objRpt.DataDefinition.ParameterFields["Imagen"].ApplyCurrentValues(RpDatos);
            RpDatos.Clear();
            paramField.HasCurrentValue = true;

            
        }
    }
}
