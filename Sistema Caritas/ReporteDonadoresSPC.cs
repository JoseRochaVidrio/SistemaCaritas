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
    public partial class ReporteDonadoresSPC : Form
    {
        
        string fecha1, nombre1, apoyo1;
        int edad1;
        public ReporteDonadoresSPC(string fecha)
        {
            InitializeComponent();
            fecha1 = fecha;
        }
        private void ReporteDonadoresSPC_Load(object sender, EventArgs e)
        {
            CrystalReport2 objRpt = new CrystalReport2();
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            String ConnStr = @"Data Source=" + appPath + @"\dbcar.s3db ;Version=3;";

            System.Data.SQLite.SQLiteConnection myConnection = new System.Data.SQLite.SQLiteConnection(ConnStr);

            String Query1 = "SELECT * FROM Donaciones Where Fecha = '" + fecha1 + "'";

            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(Query1, ConnStr);

            DataSet Ds = new DataSet();

            // here my_dt is the name of the DataTable which we 
            // created in the designer view.
            adapter.Fill(Ds, "my_dt");



            // Setting data source of our report object
            objRpt.SetDataSource(Ds);


            // Binding the crystalReportViewer with our report object. 
            this.crystalReportViewer1.ReportSource = objRpt;

            objRpt.Refresh();
        }
    }
}
