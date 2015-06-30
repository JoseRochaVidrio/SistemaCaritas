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
using System.Diagnostics;
using Sistema_Caritas;
using Sistema_Caritas.ConvertidorMonetario;

namespace CaritasVentas
{
    public partial class Ventas : Form
    {
        Int64[] ArticiculoID;
            int[] cantidad;
            float[] total;
            int[] cantidadexistencia;
            string[] nombre;
        
        
        public Ventas()
        {
            InitializeComponent();
           

        }

        void Obj_FormClosed(object sender, FormClosedEventArgs e)
        {
            //cuando la forma del administrador cierre sesion aparecera de nuevo el login
            this.Enabled = true;
            if (admintrue == true)
            {
                if (origenaccion == "Button3")
                {
                    try
                    {

                        int indice = listBox1.SelectedIndex;
                        listBox1.Items.RemoveAt(indice);
                        listBox2.Items.RemoveAt(indice);
                        listBox3.Items.RemoveAt(indice);
                        listBox4.Items.RemoveAt(indice);
                        if (listBox1.Items.Count == 0)
                        {
                            label18.Text = "";
                        }
                        admintrue = false;
                    }
                    catch
                    {
                        MessageBox.Show("No hay ventas que borrar");
                        textBox1.Focus();
                    }
                }
                else if (origenaccion == "Button6")
                {

                    textBox4.Text = "";

                    textBox2.Text = "";
                    label6.Text = "";
                    label5.Text = "";
                    label18.Text = "0";
                    textBox3.Text = "";
                    label10.Text = "";
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox4.Items.Clear();

                    ct = 0;
                    for (int i = 0; i < cantidadexistenciatotal1.Length; i++)
                    {
                        cantidadexistenciatotal1[i] = 0;
                        cantidadexistenciatotal2[i] = 0;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBpinc.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM Ventas";

            //create an OleDbDataAdapter to execute the query
            System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            DataTable dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);


            if (dTable.Rows.Count != 0)
            {
                DataRow Row = dTable.Rows[dTable.Rows.Count-1];
                string num = Row["NVenta"].ToString();
                int autonum = Int32.Parse(num);
                textBox1.Text = (autonum + 1).ToString();
            }
            else
            {
                textBox1.Text = "1";
            }
            
            try
            {

                Sistema_Caritas.ConvertidorMonetario.CurrencyConvertor CC = new Sistema_Caritas.ConvertidorMonetario.CurrencyConvertor();
                label21.Text = CC.ConversionRate(Sistema_Caritas.ConvertidorMonetario.Currency.USD, Sistema_Caritas.ConvertidorMonetario.Currency.MXN).ToString();
                
           
            }
            catch
            {
                comboBox1.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                button5.Visible = false;
            }
            timer1.Enabled = true;
            
            
        }

       
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        int[] cantidadexistenciatotal1 = new int[100];
        int[] cantidadexistenciatotal2 = new int[100];
        int ct = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label10.Text = (float.Parse(label5.Text) * float.Parse(textBox3.Text)).ToString();
            }
            catch
            {
                label10.Text = "0";
            }

            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= "+appPath2+@"\DBpinc.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM Almacen Where ArticuloID = '" + textBox2.Text + "'";

            //create an OleDbDataAdapter to execute the query
            System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            DataTable dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);

            if (dTable.Rows.Count > 0)
            {
                DataRow Row = dTable.Rows[0];
                Int32 cantidadexistencia = Int32.Parse(Row["Cantidadexistencia"].ToString());
                Int32 checadordelimite;
                if (Int32.Parse(textBox3.Text) > cantidadexistencia)
                {
                    MessageBox.Show("Cantidad en existencia insuficiente");
                }
                else
                {
                    
                    if (textBox2.Text != "" && textBox3.Text != "0" && label10.Text != "")
                    {
                        int cantidadcompra = 0;
                        bool agregarmas = false;
                        int indiceaagregar = 0;
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            if (listBox1.Items[i].ToString() == textBox2.Text)
                            {
                                cantidadcompra = Int32.Parse(listBox2.Items[i].ToString());
                                agregarmas = true;
                                indiceaagregar = i;
                                break;
                            }
                        }
                        cantidadcompra += Int32.Parse(textBox3.Text);
                        int cantidadexistentes = Int32.Parse(Row["Cantidadexistencia"].ToString());
                        if (cantidadcompra <= cantidadexistentes)
                        {
                            if (agregarmas == true)
                            {
                                listBox2.Items[indiceaagregar] = Int32.Parse(listBox2.Items[indiceaagregar].ToString()) + Int32.Parse(textBox3.Text);
                                listBox3.Items[indiceaagregar] = Int32.Parse(listBox3.Items[indiceaagregar].ToString()) + Int32.Parse(label10.Text);
                            }
                            else
                            { 
                                listBox1.Items.Add(textBox2.Text);
                                listBox2.Items.Add(textBox3.Text);
                                listBox3.Items.Add(label10.Text);
                                listBox4.Items.Add(label12.Text);
                            }
                            cantidadexistenciatotal1[ct] = Int32.Parse(label6.Text);
                            cantidadexistenciatotal2[ct] = Int32.Parse(textBox3.Text);
                            float vtotal = 0.0F;
                            for (int i = 0; i < listBox3.Items.Count; i++)
                            {
                                vtotal += float.Parse(listBox3.Items[i].ToString());
                            }
                            label18.Text = vtotal.ToString();

                            appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                            ///create the connection string
                            connString = @"Data Source= " + appPath2 + @"\DBstk.s3db ;Version=3;";

                            //create the database query
                            query = "SELECT * FROM Existencia Where ArticuloID = '" + textBox2.Text + "'";

                            //create an OleDbDataAdapter to execute the query
                            dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                            //create a command builder
                            cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                            //create a DataTable to hold the query results
                            dTable = new DataTable();
                            //fill the DataTable
                            dAdapter.Fill(dTable);
                            dAdapter.Update(dTable);

                            if (dTable.Rows.Count > 0)
                            {
                                Row = dTable.Rows[0];
                                Int64 cantlimite = Int64.Parse(Row["Limite"].ToString());
                                string cantidadlista = listBox2.Items[listBox1.FindStringExact(textBox2.Text)].ToString();
                                checadordelimite = cantidadexistencia - Int32.Parse(cantidadlista);
                                if (cantlimite >= checadordelimite)
                                {
                                    MessageBox.Show("Quedan " + cantlimite.ToString() + " o menos en existencia del articulo " + label12.Text + "");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("La cantidad que quiere agregar sobrepasa la existencia del producto");
 
                        }
                    }
                    else
                    {
                        MessageBox.Show("Faltaron campos por llenar");
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltaron campos por llenar"); 
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            listBox3.SelectedIndex = listBox1.SelectedIndex;
            listBox4.SelectedIndex = listBox1.SelectedIndex;
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
            listBox3.SelectedIndex = listBox2.SelectedIndex;
            listBox4.SelectedIndex = listBox2.SelectedIndex;
        }

        private void listBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox3.SelectedIndex;
            listBox1.SelectedIndex = listBox3.SelectedIndex;
            listBox4.SelectedIndex = listBox3.SelectedIndex;
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox4.SelectedIndex;
            listBox3.SelectedIndex = listBox4.SelectedIndex;
            listBox1.SelectedIndex = listBox4.SelectedIndex;

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBpinc.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM Almacen Where ArticuloID = '"+textBox2.Text+"'";

            //create an OleDbDataAdapter to execute the query
            System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            DataTable dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);
            label6.Text = "";
            label5.Text = "";
            //textBox3.Text = "0";
            label10.Text = "";
            label12.Text = "";
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow Row = dTable.Rows[i];
                
                label6.Text = Row["Cantidadexistencia"].ToString();
                label5.Text = Row["Precioventa"].ToString();
                label12.Text = Row["Nombrearticulo"].ToString();
            }
        }

        
        

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            ArticiculoID = new Int64[listBox1.Items.Count];
            cantidad = new int[listBox1.Items.Count];
            total = new float[listBox1.Items.Count];
            cantidadexistencia = new int[listBox1.Items.Count];
            nombre = new string[listBox1.Items.Count];

            for (int cont = 0; cont < listBox1.Items.Count; cont++)
            {
                ArticiculoID[cont] = Int64.Parse(listBox1.Items[cont].ToString());
                cantidad[cont] = Int32.Parse(listBox2.Items[cont].ToString());
                total[cont] = float.Parse(listBox3.Items[cont].ToString());
                cantidadexistencia[cont] = cantidadexistenciatotal1[cont] - cantidadexistenciatotal2[cont];
                nombre[cont] = listBox4.Items[cont].ToString();
            }
            if (listBox1.Items.Count != 0)
            {
                float cambio = 0.0F;
                try
                {
                    cambio = float.Parse(textBox4.Text) - float.Parse(label18.Text);
                }
                catch
                {
                    cambio = -1;
                }
                if (cambio >= 0)
                {


                    float vtotal = 0.0F;
                    for (int i = 0; i < total.Length; i++)
                    {
                        vtotal += total[i];
                    }

                    try
                    {

                        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                               new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBPInc.s3db ;Version=3;");

                        System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        //comando sql para insercion

                        cmd.CommandText = "INSERT INTO Ventas Values ('" + Int32.Parse(textBox1.Text) + "', '" + vtotal + "', '" + DateTime.Now.ToShortDateString() + "')";

                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();

                        sqlConnection1.Close();

                        //ventas hechas
                        appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        sqlConnection1 =
                                               new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBPInc.s3db ;Version=3;");

                        cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;

                        for (int i = 0; i < ArticiculoID.Length; i++)
                        {
                            //comando sql para insercion
                            cmd.CommandText = "INSERT INTO Ventashechas Values ('" + Int32.Parse(textBox1.Text) + "', '" + ArticiculoID[i] + "', '" + nombre[i] + "', '" + cantidad[i] + "', '" + total[i] + "', '" + DateTime.Now.ToShortDateString() + "')";

                            cmd.Connection = sqlConnection1;

                            sqlConnection1.Open();
                            cmd.ExecuteNonQuery();

                            sqlConnection1.Close();

                            //comando sql para atualizar
                            cmd.CommandText = "UPDATE Almacen Set Cantidadexistencia = '" + cantidadexistencia[i] + "' Where ArticuloID = '" + ArticiculoID[i] + "'";

                            cmd.Connection = sqlConnection1;

                            sqlConnection1.Open();
                            cmd.ExecuteNonQuery();

                            sqlConnection1.Close();
                        }
                        DialogResult result = MessageBox.Show("Venta registrada exitosamente, su cambio es: $"+cambio.ToString()+" pesos , desea ver el documento de impresion?", "Impresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            Reporte reporte = new Reporte(textBox1.Text);
                            reporte.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
                            reporte.Show();
                        }
                        textBox1.Text = (Int64.Parse(textBox1.Text) + 1).ToString();
                        textBox2.Text = "";
                        label6.Text = "";
                        label5.Text = "";
                        textBox3.Text = "";
                        label10.Text = "";
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        listBox4.Items.Clear();
                        textBox4.Text = "";
                        label18.Text = "0";
                        ct = 0;
                        for (int i = 0; i < cantidadexistenciatotal1.Length; i++)
                        {
                            cantidadexistenciatotal1[i] = 0;
                            cantidadexistenciatotal2[i] = 0;
                        }
                    }
                    catch
                    {
                        int result;
                        bool accept = Int32.TryParse(textBox1.Text, out result);
                        if (accept == false)
                        {
                            MessageBox.Show("No ha introducido algun numero de venta o no es valido");
                        }
                        else
                        {
                            MessageBox.Show("El numero de venta ya ha sido tomado");
                        }
                    }





                }
                else
                {
                    MessageBox.Show("Cantidad a pagar insuficiente");
                }


            }
            else
            {
                MessageBox.Show("No hay ventas que registrar");
            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            origenaccion = "Button6";

            this.Enabled = false;
            this.BringToFront();
            AutentificacionAcciones autacc = new AutentificacionAcciones();
            autacc.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            autacc.AdminAvailable += new AutentificacionAcciones.AdminAvailableEventHandler(Frm2_AdminAvailable);
            autacc.FormClosed += new FormClosedEventHandler(Obj_FormClosed); //handler para saber si la forma admin se ha cerrado
            autacc.Show();


        }
        bool admintrue = false;
        private void Frm2_AdminAvailable(bool T)
        {
            admintrue = T;
        }
        string origenaccion = "";
        private void button3_Click(object sender, EventArgs e)
        {
            origenaccion = "Button3";
            this.Enabled = false;
            
            this.BringToFront();
            AutentificacionAcciones autacc = new AutentificacionAcciones();
            autacc.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            autacc.AdminAvailable += new AutentificacionAcciones.AdminAvailableEventHandler(Frm2_AdminAvailable);
            autacc.FormClosed += new FormClosedEventHandler(Obj_FormClosed); //handler para saber si la forma admin se ha cerrado
            autacc.Show();

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculadoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "calc.EXE";
            Process.Start(startInfo);
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                Sistema_Caritas.ConvertidorMonetario.CurrencyConvertor CC = new Sistema_Caritas.ConvertidorMonetario.CurrencyConvertor();
                if (comboBox1.SelectedIndex == 0)
                {
                    label21.Text = CC.ConversionRate(Sistema_Caritas.ConvertidorMonetario.Currency.USD, Sistema_Caritas.ConvertidorMonetario.Currency.MXN).ToString();
 
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    label21.Text = CC.ConversionRate(Sistema_Caritas.ConvertidorMonetario.Currency.EUR, Sistema_Caritas.ConvertidorMonetario.Currency.MXN).ToString();

                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    label21.Text = CC.ConversionRate(Sistema_Caritas.ConvertidorMonetario.Currency.GBP, Sistema_Caritas.ConvertidorMonetario.Currency.MXN).ToString();
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    label21.Text = CC.ConversionRate(Sistema_Caritas.ConvertidorMonetario.Currency.ARS, Sistema_Caritas.ConvertidorMonetario.Currency.MXN).ToString();
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    label21.Text = CC.ConversionRate(Sistema_Caritas.ConvertidorMonetario.Currency.PEN, Sistema_Caritas.ConvertidorMonetario.Currency.MXN).ToString();
                }
                else if (comboBox1.SelectedIndex == 5)
                {
                    label21.Text = CC.ConversionRate(Sistema_Caritas.ConvertidorMonetario.Currency.CAD, Sistema_Caritas.ConvertidorMonetario.Currency.MXN).ToString();
                }
                else if (comboBox1.SelectedIndex == 6)
                {
                    label21.Text = CC.ConversionRate(Sistema_Caritas.ConvertidorMonetario.Currency.COP, Sistema_Caritas.ConvertidorMonetario.Currency.MXN).ToString();
                }
                else if (comboBox1.SelectedIndex == 7)
                {
                    label21.Text = CC.ConversionRate(Sistema_Caritas.ConvertidorMonetario.Currency.CUP, Sistema_Caritas.ConvertidorMonetario.Currency.MXN).ToString();
                }
            }
            catch
            {
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.SelectedIndex = 0;
            }
            double cambio = double.Parse(label18.Text) / double.Parse(label21.Text);
            Cambio camb = new Cambio(cambio.ToString(), "Cambio de pesos a " + comboBox1.Text);
            camb.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            camb.Show();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                button2.PerformClick();
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

       

        private void listBox1_MouseHover_1(object sender, EventArgs e)
        {
            try
            {
                string articulo = listBox1.SelectedItem.ToString();
                toolTip1.SetToolTip(listBox1, articulo);
            }
            catch
            { }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                textBox2.Text = "";
                textBox2.Focus();
                
            }
            
        }

        

        

        

        

       
       


        

        
    }
}
