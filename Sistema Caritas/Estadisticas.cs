using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace Sistema_Caritas
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
        }
        string appPath = "";
        System.Data.SQLite.SQLiteCommand cmd;
        string appPath2 = "";
        string connString = "";
        string query = "";
        System.Data.SQLite.SQLiteDataAdapter dAdapter;
        System.Data.SQLite.SQLiteCommandBuilder cBuilder;
        DataTable dTable;
        System.Data.SQLite.SQLiteConnection sqlConnection1;
        private void Estadisticas_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chart1.Legends.Count == 0)
            {
                Legend Legend1 = new Legend();
                Legend1.Position.Auto = true;
                chart1.Legends.Add(Legend1);
            }
            if (chart1.Series["Default"].IsValueShownAsLabel == true)
            {
                chart1.Series["Default"].IsValueShownAsLabel = false;
            }

            appPath = Path.GetDirectoryName(Application.ExecutablePath);
            sqlConnection1 =
                                   new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBESIL.s3db ;Version=3;");

            cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            ////

            appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            connString = @"Data Source= " + appPath2 + @"\DBESIL.s3db ;Version=3;";

            if (comboBox1.SelectedIndex == 0) //datos fisicos de la vivienda
            {
                //create the database query
                query = "Select COUNT(Noencuesta)as Noencuesta FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);

                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string Numeroencuesta = Row["Noencuesta"].ToString();
                int Numeroencuestaint = Int32.Parse(Numeroencuesta);

                //create the database query
                query = "SELECT COUNT(SituacionVivienda)as SituacionVivienda FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where SituacionVivienda like '%Propia%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string propia = Row["SituacionVivienda"].ToString();
                float apropia = float.Parse(propia);

                //create the database query
                query = "SELECT COUNT(SituacionVivienda)as SituacionVivienda FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where SituacionVivienda like '%Prestada%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string prestada = Row["SituacionVivienda"].ToString();
                float aprestada = float.Parse(prestada);

                //create the database query
                query = "SELECT COUNT(SituacionVivienda)as SituacionVivienda FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where SituacionVivienda like '%Rentada%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string rentada = Row["SituacionVivienda"].ToString();
                float arentada = float.Parse(rentada);

                //create the database query
                query = "SELECT COUNT(SituacionVivienda)as SituacionVivienda FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where SituacionVivienda like '%Otros%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string otros = Row["SituacionVivienda"].ToString();
                float aotros = float.Parse(otros);

                // Populate series data
                double[] yValues = { apropia, aprestada, arentada, aotros };
                string[] xValues = { "Propia: " + apropia, "Prestada: " + aprestada, "Rentada: " + arentada, "Otros: "+aotros };
                chart1.Series["Default"].Points.DataBindXY(xValues, yValues);


                // Set Doughnut chart type
                chart1.Series["Default"].ChartType = SeriesChartType.Pie;


                chart1.Series["Default"]["CollectedThresholdUsePercent"] = "true";

                // Set labels style
                chart1.Series["Default"]["PieLabelStyle"] = "Inside";

                // Set Doughnut radius percentage
                chart1.Series["Default"]["DoughnutRadius"] = "70";

                // Explode data point with label "Italy"
                chart1.Series["Default"].Points[1]["Exploded"] = "true";

                // Enable 3D
                chart1.ChartAreas["Default"].Area3DStyle.Enable3D = false;

                // Set drawing style
                chart1.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

                label5.Text = "Resultados mostrados de " + Numeroencuesta + " encuestas, de las fechas de " + dateTimePicker1.Value.ToShortDateString() + " a " + dateTimePicker2.Value.ToShortDateString();
            

            }


            if (comboBox1.SelectedIndex == 1) //servicios publicos
            {

                //create the database query
                query = "Select COUNT(Noencuesta)as Noencuesta FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd")+"'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);

                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string Numeroencuesta = Row["Noencuesta"].ToString();
                int Numeroencuestaint = Int32.Parse(Numeroencuesta);

                //create the database query
                query = "SELECT COUNT(ServiciosPublicos)as ServiciosPublicos FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where ServiciosPublicos like '%Agua%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string agua = Row["ServiciosPublicos"].ToString();
                float autoagua = float.Parse(agua);

                //create the database query
                query = "SELECT COUNT(ServiciosPublicos)as ServiciosPublicos FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where ServiciosPublicos like '%Luz Electrica%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string luz = Row["ServiciosPublicos"].ToString();
                float autoluz = float.Parse(luz);



                //create the database query
                query = "SELECT COUNT(ServiciosPublicos)as ServiciosPublicos FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where ServiciosPublicos like '%Drenaje%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string drenaje = Row["ServiciosPublicos"].ToString();
                float autodrenaje = float.Parse(luz);

                // Populate series data
                double[] yValues = { autoagua, autoluz, autodrenaje };
                string[] xValues = { "Agua: " + autoagua, "Luz Electrica: " + autoluz, "Drenaje: " + autodrenaje };
                chart1.Series["Default"].Points.DataBindXY(xValues, yValues);


                // Set Doughnut chart type
                chart1.Series["Default"].ChartType = SeriesChartType.Pie;


                chart1.Series["Default"]["CollectedThresholdUsePercent"] = "true";

                // Set labels style
                chart1.Series["Default"]["PieLabelStyle"] = "Inside";

                // Set Doughnut radius percentage
                chart1.Series["Default"]["DoughnutRadius"] = "70";

                // Explode data point with label "Italy"
                chart1.Series["Default"].Points[1]["Exploded"] = "true";

                // Enable 3D
                chart1.ChartAreas["Default"].Area3DStyle.Enable3D = false;

                // Set drawing style
                chart1.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

                label5.Text = "Resultados mostrados de " + Numeroencuesta + " encuestas, de las fechas de " + dateTimePicker1.Value.ToShortDateString() + " a " + dateTimePicker2.Value.ToShortDateString();
            }

            if (comboBox1.SelectedIndex == 2) //datos de los materiales de las paredes
            {
                //create the database query
                query = "Select COUNT(Noencuesta)as Noencuesta FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);

                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string Numeroencuesta = Row["Noencuesta"].ToString();
                int Numeroencuestaint = Int32.Parse(Numeroencuesta);

                //create the database query
                query = "SELECT COUNT(Paredes)as Paredes FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Paredes like '%Lamina%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string lamina = Row["Paredes"].ToString();
                float alamina = float.Parse(lamina);

                //create the database query
                query = "SELECT COUNT(Paredes)as Paredes FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Paredes like '%Carton%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string carton = Row["Paredes"].ToString();
                float acarton = float.Parse(carton);

                //create the database query
                query = "SELECT COUNT(Paredes)as Paredes FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Paredes like '%Block%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string block = Row["Paredes"].ToString();
                float ablock = float.Parse(block);

                //create the database query
                query = "SELECT COUNT(Paredes)as Paredes FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Paredes like '%Madera%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string madera = Row["Paredes"].ToString();
                float amadera = float.Parse(madera);

                //create the database query
                query = "SELECT COUNT(Paredes)as Paredes FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Paredes like '%Pedaceria%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string pedaceria = Row["Paredes"].ToString();
                float apedaceria = float.Parse(pedaceria);

                // Populate series data
                double[] yValues = { alamina, acarton, ablock, amadera, apedaceria };
                string[] xValues = { "Lamina: " + alamina, "Carton: " + acarton, "Block: " + ablock, "Madera: " + amadera, "Pedaceria: "+apedaceria };
                chart1.Series["Default"].Points.DataBindXY(xValues, yValues);


                // Set Doughnut chart type
                chart1.Series["Default"].ChartType = SeriesChartType.Pie;


                chart1.Series["Default"]["CollectedThresholdUsePercent"] = "true";

                // Set labels style
                chart1.Series["Default"]["PieLabelStyle"] = "Inside";

                // Set Doughnut radius percentage
                chart1.Series["Default"]["DoughnutRadius"] = "70";

                // Explode data point with label "Italy"
                chart1.Series["Default"].Points[1]["Exploded"] = "true";

                // Enable 3D
                chart1.ChartAreas["Default"].Area3DStyle.Enable3D = false;

                // Set drawing style
                chart1.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

                label5.Text = "Resultados mostrados de " + Numeroencuesta + " encuestas, de las fechas de " + dateTimePicker1.Value.ToShortDateString() + " a " + dateTimePicker2.Value.ToShortDateString();


            }

            if (comboBox1.SelectedIndex == 3) //datos de los materiales de piso
            {
                //create the database query
                query = "Select COUNT(Noencuesta)as Noencuesta FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);

                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string Numeroencuesta = Row["Noencuesta"].ToString();
                int Numeroencuestaint = Int32.Parse(Numeroencuesta);

                //create the database query
                query = "SELECT COUNT(Piso)as Piso FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Piso like '%Cemento%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string cemento = Row["Piso"].ToString();
                float acemento = float.Parse(cemento);

                //create the database query
                query = "SELECT COUNT(Piso)as Piso FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Piso like '%Mosaico%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string mosaico = Row["Piso"].ToString();
                float amosaico = float.Parse(mosaico);

                //create the database query
                query = "SELECT COUNT(Piso)as Piso FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Piso like '%Tierra%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string tierra = Row["Piso"].ToString();
                float atierra = float.Parse(tierra);



                // Populate series data
                double[] yValues = { acemento, amosaico, atierra };
                string[] xValues = { "Cemento: " + acemento, "Mosaico: " + amosaico, "Tierra: " + atierra };
                chart1.Series["Default"].Points.DataBindXY(xValues, yValues);


                // Set Doughnut chart type
                chart1.Series["Default"].ChartType = SeriesChartType.Pie;


                chart1.Series["Default"]["CollectedThresholdUsePercent"] = "true";

                // Set labels style
                chart1.Series["Default"]["PieLabelStyle"] = "Inside";

                // Set Doughnut radius percentage
                chart1.Series["Default"]["DoughnutRadius"] = "70";

                // Explode data point with label "Italy"
                chart1.Series["Default"].Points[1]["Exploded"] = "true";

                // Enable 3D
                chart1.ChartAreas["Default"].Area3DStyle.Enable3D = false;

                // Set drawing style
                chart1.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

                label5.Text = "Resultados mostrados de " + Numeroencuesta + " encuestas, de las fechas de " + dateTimePicker1.Value.ToShortDateString() + " a " + dateTimePicker2.Value.ToShortDateString();


            }

            if (comboBox1.SelectedIndex == 4) //datos de los materiales de las Techo
            {
                //create the database query
                query = "Select COUNT(Noencuesta)as Noencuesta FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);

                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string Numeroencuesta = Row["Noencuesta"].ToString();
                int Numeroencuestaint = Int32.Parse(Numeroencuesta);

                //create the database query
                query = "SELECT COUNT(Techo)as Techo FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Techo like '%Concreto%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string concreto = Row["Techo"].ToString();
                float aconcreto = float.Parse(concreto);

                //create the database query
                query = "SELECT COUNT(Techo)as Techo FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Techo like '%Madera%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string madera = Row["Techo"].ToString();
                float amadera = float.Parse(madera);

                //create the database query
                query = "SELECT COUNT(Techo)as Techo FROM (Select * FROM (SELECT * FROM DatosVivienda, Observaciones Where DatosVivienda.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where Techo like '%Lamina%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string lamina = Row["Techo"].ToString();
                float alamina = float.Parse(lamina);



                // Populate series data
                double[] yValues = { aconcreto, amadera, alamina };
                string[] xValues = { "Concreto: " + aconcreto, "Madera: " + amadera, "Lamina: " + alamina };
                chart1.Series["Default"].Points.DataBindXY(xValues, yValues);


                // Set Doughnut chart type
                chart1.Series["Default"].ChartType = SeriesChartType.Pie;


                chart1.Series["Default"]["CollectedThresholdUsePercent"] = "true";

                // Set labels style
                chart1.Series["Default"]["PieLabelStyle"] = "Inside";

                // Set Doughnut radius percentage
                chart1.Series["Default"]["DoughnutRadius"] = "70";

                // Explode data point with label "Italy"
                chart1.Series["Default"].Points[1]["Exploded"] = "true";

                // Enable 3D
                chart1.ChartAreas["Default"].Area3DStyle.Enable3D = false;

                // Set drawing style
                chart1.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

                label5.Text = "Resultados mostrados de " + Numeroencuesta + " encuestas, de las fechas de " + dateTimePicker1.Value.ToShortDateString() + " a " + dateTimePicker2.Value.ToShortDateString();


            }

            if (comboBox1.SelectedIndex == 5) //datos de las Instituciones Medicas
            {
                //create the database query
                query = "Select COUNT(Noencuesta)as Noencuesta FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);

                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string Numeroencuesta = Row["Noencuesta"].ToString();
                int Numeroencuestaint = Int32.Parse(Numeroencuesta);

                //create the database query
                query = "SELECT COUNT(InstitucionMedica)as InstitucionMedica FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where InstitucionMedica like '%IMSS%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string IMSS = Row["InstitucionMedica"].ToString();
                float aIMSS = float.Parse(IMSS);

                //create the database query
                query = "SELECT COUNT(InstitucionMedica)as InstitucionMedica FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where InstitucionMedica like '%ISSTE%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string isste = Row["InstitucionMedica"].ToString();
                float aisste = float.Parse(isste);

                //create the database query
                query = "SELECT COUNT(InstitucionMedica)as InstitucionMedica FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where InstitucionMedica like '%HOSPITAL CIVIL%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string hospitalcivil = Row["InstitucionMedica"].ToString();
                float ahospitalcivil = float.Parse(hospitalcivil);

                //create the database query
                query = "SELECT COUNT(InstitucionMedica)as InstitucionMedica FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where InstitucionMedica like '%CENTRO DE SALUD%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string centrodesalud = Row["InstitucionMedica"].ToString();
                float acentrodesalud = float.Parse(centrodesalud);

                //create the database query
                query = "SELECT COUNT(InstitucionMedica)as InstitucionMedica FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where InstitucionMedica like '%DISPENSARIO%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string dispensario = Row["InstitucionMedica"].ToString();
                float adispensario = float.Parse(dispensario);

                //create the database query
                query = "SELECT COUNT(InstitucionMedica)as InstitucionMedica FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where InstitucionMedica like '%HOSPITAL GENERAL%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string hospitalgeneral = Row["InstitucionMedica"].ToString();
                float ahospitalgeneral = float.Parse(hospitalgeneral);

                //create the database query
                query = "SELECT COUNT(InstitucionMedica)as InstitucionMedica FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where InstitucionMedica like '%HOSPITAL PEDIATRICO%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string hospitalpediatrico = Row["InstitucionMedica"].ToString();
                float ahospitalpediatrico = float.Parse(hospitalpediatrico);


                // Populate series data
                double[] yValues = { aIMSS, aisste, ahospitalcivil, acentrodesalud, adispensario, ahospitalgeneral, ahospitalpediatrico };
                string[] xValues = { "IMSS: " + aIMSS, "ISSTE: " + aisste, "Hospital Civil: " + ahospitalcivil, "Centro de Salud " + acentrodesalud, "Dispensario: " + adispensario, "Hospital General: " + ahospitalgeneral, "Hospital Pediatrico: " + ahospitalpediatrico };
                chart1.Series["Default"].Points.DataBindXY(xValues, yValues);


                // Set Doughnut chart type
                chart1.Series["Default"].ChartType = SeriesChartType.Pie;


                chart1.Series["Default"]["CollectedThresholdUsePercent"] = "true";

                // Set labels style
                chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

                // Set Doughnut radius percentage
                chart1.Series["Default"]["DoughnutRadius"] = "70";

                // Explode data point with label "Italy"
                chart1.Series["Default"].Points[1]["Exploded"] = "true";

                // Enable 3D
                chart1.ChartAreas["Default"].Area3DStyle.Enable3D = false;

                // Set drawing style
                chart1.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

                

                label5.Text = "Resultados mostrados de " + Numeroencuesta + " encuestas, de las fechas de " + dateTimePicker1.Value.ToShortDateString() + " a " + dateTimePicker2.Value.ToShortDateString();


            }

            if (comboBox1.SelectedIndex == 6) //datos de los materiales de las Enfermedades Frecuentes
            {
                //create the database query
                query = "Select COUNT(Noencuesta)as Noencuesta FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);

                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string Numeroencuesta = Row["Noencuesta"].ToString();
                int Numeroencuestaint = Int32.Parse(Numeroencuesta);

                //create the database query
                query = "SELECT COUNT(EnfermedadesFrecuentes)as EnfermedadesFrecuentes FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where EnfermedadesFrecuentes like '%Gastrointestinales%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string gastrointestinales = Row["EnfermedadesFrecuentes"].ToString();
                float agastrointestinales = float.Parse(gastrointestinales);

                //create the database query
                query = "SELECT COUNT(EnfermedadesFrecuentes)as EnfermedadesFrecuentes FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where EnfermedadesFrecuentes like '%Respiratorias%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string respiratorias = Row["EnfermedadesFrecuentes"].ToString();
                float arespiratorias = float.Parse(respiratorias);

                //create the database query
                query = "SELECT COUNT(EnfermedadesFrecuentes)as EnfermedadesFrecuentes FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where EnfermedadesFrecuentes like '%Piel%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string piel = Row["EnfermedadesFrecuentes"].ToString();
                float apiel = float.Parse(piel);

                //create the database query
                query = "SELECT COUNT(EnfermedadesFrecuentes)as EnfermedadesFrecuentes FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where EnfermedadesFrecuentes like '%Huesos%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string huesos = Row["EnfermedadesFrecuentes"].ToString();
                float ahuesos = float.Parse(huesos);

                //create the database query
                query = "SELECT COUNT(EnfermedadesFrecuentes)as EnfermedadesFrecuentes FROM (Select * FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "') where EnfermedadesFrecuentes like '%Otros%'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);


                Row = dTable.Rows[dTable.Rows.Count - 1];
                string otros = Row["EnfermedadesFrecuentes"].ToString();
                float aotros = float.Parse(otros);



                // Populate series data
                double[] yValues = { agastrointestinales, arespiratorias, apiel, ahuesos, aotros };
                string[] xValues = { "Gastrointestinales: " + agastrointestinales, "Respiratorias: " + arespiratorias, "Piel: " + apiel, "Huesos: " + ahuesos, "Otros: " + aotros };
                chart1.Series["Default"].Points.DataBindXY(xValues, yValues);


                // Set Doughnut chart type
                chart1.Series["Default"].ChartType = SeriesChartType.Pie;


                chart1.Series["Default"]["CollectedThresholdUsePercent"] = "true";

                // Set labels style
                chart1.Series["Default"]["PieLabelStyle"] = "Outside";

                // Set Doughnut radius percentage
                chart1.Series["Default"]["DoughnutRadius"] = "70";

                // Explode data point with label "Italy"
                chart1.Series["Default"].Points[1]["Exploded"] = "true";

                // Enable 3D
                chart1.ChartAreas["Default"].Area3DStyle.Enable3D = false;

                // Set drawing style
                chart1.Series["Default"]["PieDrawingStyle"] = "SoftEdge";
                chart1.Legends.RemoveAt(0);
                label5.Text = "Resultados mostrados de " + Numeroencuesta + " encuestas, de las fechas de " + dateTimePicker1.Value.ToShortDateString() + " a " + dateTimePicker2.Value.ToShortDateString();


            }


            if (comboBox1.SelectedIndex == 7) //datos de los materiales de las Enfermedades Frecuentes
            {
                //create the database query
                query = "Select COUNT(Noencuesta)as Noencuesta FROM (SELECT * FROM ServicioMedico, Observaciones Where ServicioMedico.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);

                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string Numeroencuesta = Row["Noencuesta"].ToString();
                int Numeroencuestaint = Int32.Parse(Numeroencuesta);


                //create the database query
                query = "Select * FROM (SELECT * FROM EgresosMensuales, Observaciones Where EgresosMensuales.Noencuesta = Observaciones.Noencuesta) Where Fecha BETWEEN '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";

                //create an OleDbDataAdapter to execute the query
                dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                //create a command builder
                cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                //create a DataTable to hold the query results
                dTable = new DataTable();
                //fill the DataTable
                dAdapter.Fill(dTable);
                dAdapter.Update(dTable);

                int[] promediogastos = new int[7];

                for (int j = 0; j < dTable.Rows.Count; j++)
                {

                    Row = dTable.Rows[j];
                    string gastosfamiliares = Row["GastosFamiliares"].ToString();

                    string test = gastosfamiliares;

                    string[] test1 = StringSplitHelper.SplitNonQuoted(test, ',');

                    for (int i = 0; i < test1.Length; i++)
                    {
                        Match match = Regex.Match(test1[i], @"(\d+)");
                        if (match.Success)
                        {
                            int numero = int.Parse(match.Groups[1].Value);
                            test1[i] = numero.ToString();
                            promediogastos[i] = promediogastos[i] + Int32.Parse(test1[i]);
                        }
                    }

                }

                for (int k = 0; k < 7; k++)
                {
                    promediogastos[k] = promediogastos[k] / 7;
                }

                // initialize an array of doubles for Y values
                double[] yval = { promediogastos[0], promediogastos[1], promediogastos[2], promediogastos[3], promediogastos[4], promediogastos[5], promediogastos[6] };

                // initialize an array of strings for X values
                string[] xval = { "Alimentacion", "Renta", "Vestuario", "Educacion", "Transporte", "Agua", "Luz" };

                // bind the arrays to the X and Y values of data points in the "ByArray" series
                chart1.Series["Default"].Points.DataBindXY(xval, yval);

                // Set series chart type
                chart1.Series["Default"].ChartType = SeriesChartType.Column;

                // Set series point width
                chart1.Series["Default"]["PointWidth"] = "0.6";

                // Show data points labels
                chart1.Series["Default"].IsValueShownAsLabel = true;

                // Set data points label style
                chart1.Series["Default"]["BarLabelStyle"] = "Center";

                // Display chart as 3D
                chart1.ChartAreas[0].Area3DStyle.Enable3D = false;

                // Draw the chart as embossed
                chart1.Series["Default"]["DrawingStyle"] = "Default";
                chart1.Legends.RemoveAt(0);

                label5.Text = "Resultados mostrados de " + Numeroencuesta + " encuestas, de las fechas de " + dateTimePicker1.Value.ToShortDateString() + " a " + dateTimePicker2.Value.ToShortDateString();


            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            doc = new System.Drawing.Printing.PrintDocument();

            doc.PrintPage += this.printDocument1_PrintPage;
            PrintPreviewDialog ppdlg = new PrintPreviewDialog();
            ppdlg.Document = doc;
            ((Form)ppdlg).WindowState = FormWindowState.Maximized;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            System.Drawing.Icon ico = new System.Drawing.Icon(appPath + @"\Img\caritasico.ico");
            ((Form)ppdlg).Icon = ico;
            ppdlg.ShowDialog();
        }
        Bitmap[] bitmapas = new Bitmap[25];
        System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            e.Graphics.DrawString(comboBox1.Text, new Font("Arial", 16), new SolidBrush(Color.Black), e.MarginBounds.Width / 2, 40);

            Bitmap bmp = new Bitmap(this.chart1.Width, this.chart1.Height);
            this.chart1.DrawToBitmap(bmp, new Rectangle(0, 0, this.chart1.Width, this.chart1.Height));
            

            Bitmap bmp2 = new Bitmap(400, 350);
            Graphics graph = Graphics.FromImage(bmp2);
            graph.InterpolationMode = InterpolationMode.High;
            graph.CompositingQuality = CompositingQuality.HighQuality;
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            graph.DrawImage(bmp, new Rectangle(0, 0, 400, 350));

            e.Graphics.DrawImage((Image)bmp2, x, y);

            e.Graphics.DrawString(label5.Text, new Font("Arial", 16), new SolidBrush(Color.Black), 25, y + 480);
            
        }
        public int bitnum = 0;
        public int bitnum2 = 0;
        float x1 = 0F, y1 = 0F;
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            for (bitnum = 0; bitnum < 2; bitnum++)
            {
                try
                {
                    comboBox1.SelectedIndex = bitnum2;

                    button1.PerformClick();


                    float x = e.MarginBounds.Left;
                    float y = e.MarginBounds.Top;
                    Bitmap bmp = new Bitmap(this.chart1.Width, this.chart1.Height);
                    e.Graphics.DrawString(comboBox1.Text, new Font("Arial", 16), new SolidBrush(Color.Black), e.MarginBounds.Width/2, y1+40);

                    this.chart1.DrawToBitmap(bmp, new Rectangle(0, 0, this.chart1.Width, this.chart1.Height));


                    Bitmap bmp2 = new Bitmap(400, 350);
                    Graphics graph = Graphics.FromImage(bmp2);
                    graph.InterpolationMode = InterpolationMode.High;
                    graph.CompositingQuality = CompositingQuality.HighQuality;
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    graph.DrawImage(bmp, new Rectangle(0, 0, 400, 350));

                    e.Graphics.DrawImage((Image)bmp2, x, y + y1);

                    bitmapas[bitnum] = bmp2;
                    y1 = y1 + 400;
                    bitnum2++;
                }
                catch
                {
                    break;
                }
                
            }
            if (y1 < e.MarginBounds.Height)
            {
                if (bitnum2 < 8)
                {
                    e.Graphics.DrawString(label5.Text, new Font("Arial", 16), new SolidBrush(Color.Black), 10, y1 + 40);

                    //Has more pages??
                    e.HasMorePages = true;
                    y1 = 0F;
                }
                if (bitnum2 == 8)
                {
                    e.Graphics.DrawString(label5.Text, new Font("Arial", 16), new SolidBrush(Color.Black), 10, y1 + 80);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doc = new System.Drawing.Printing.PrintDocument();
            if (bitnum2 >= 8)
            {
                bitnum2 = 0;
                y1 = 0;
                bitnum = 0;
                
            }
            doc.PrintPage += this.printDocument2_PrintPage;

            
            PrintPreviewDialog ppdlg = new PrintPreviewDialog();
            ppdlg.Document = doc;
            ((Form)ppdlg).WindowState = FormWindowState.Maximized;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            System.Drawing.Icon ico = new System.Drawing.Icon(appPath + @"\Img\caritasico.ico");
            ((Form)ppdlg).Icon = ico;
            ppdlg.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }

    public static class StringSplitHelper
    {

        public static string[] SplitNonQuoted(this string str, char separator)
        {
            if (string.IsNullOrEmpty(str)) return new string[] { };
            if (separator == '\"') throw new ArgumentException("Separator cannot be a quotation mark", "separator");
            List<string> fields = new List<string>();
            bool inQuotes = false;
            StringBuilder sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c == '\"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == separator)
                {
                    if (inQuotes)
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        fields.Add(sb.ToString());
                        sb.Length = 0;
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            fields.Add(sb.ToString());
            sb.Length = 0;
            return fields.ToArray();
        }
    }
}
