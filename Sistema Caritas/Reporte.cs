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

namespace CaritasVentas
{
    public partial class Reporte : Form
    {
        string nventas = "";
        public Reporte(string NVenta)
        {
            InitializeComponent();
            nventas = NVenta;
        }

        private void Reporte_Load(object sender, EventArgs e)
        {

            
            

           
        }

        private void Reporte_Load_1(object sender, EventArgs e)
        {
            Sistema_Caritas.CrystalReport1 objRpt = new Sistema_Caritas.CrystalReport1();

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            String ConnStr = @"Data Source=" + appPath + @"\DBpinc.s3db ;Version=3;";

            System.Data.SQLite.SQLiteConnection myConnection = new System.Data.SQLite.SQLiteConnection(ConnStr);

            //String Query1 = "SELECT * FROM Ventashechas Where NVenta = '" + nventas + "'";
            String Query1 = "Select NVenta as NVenta, ArticuloID as ArticuloID, Nombrearticulo, Cantidad, Fecha as Fecha, Total as Total, Ventatotal as Ventatotal  FROM (SELECT * FROM Ventashechas, Ventas Where Ventashechas.NVenta = Ventas.NVenta) Where NVenta = '" + nventas + "'";
            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(Query1, ConnStr);

            DataSet Ds = new DataSet();
            // here my_dt is the name of the DataTable which we 
            // created in the designer view.
            adapter.Fill(Ds, "DataTable1");

            // Setting data source of our report object
            objRpt.SetDataSource(Ds);
            

            // Binding the crystalReportViewer with our report object. 

            this.crystalReportViewer2.ReportSource = objRpt;
        }
    }
}
