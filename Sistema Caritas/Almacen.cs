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
using BarcodeLib;

namespace CaritasVentas
{
    public partial class Almacen : Form
    {
        public Almacen()
        {
            InitializeComponent();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int cant = 0;
            bool cantidad = Int32.TryParse(textBox6.Text, out cant);
            float vent = 0.0F;
            bool venta = float.TryParse(textBox7.Text, out vent);
            float comp = 0.0F;
            bool compra = float.TryParse(textBox8.Text, out comp);

            if (textBox1.Text != "" && cantidad == true && compra == true && venta == true)
            {
                try
                {

                    bool existeprov = false;
                    ///create the connection string
                    string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                    ///create the connection string
                    string connString = @"Data Source= " + appPath2 + @"\DBpinc.s3db ;Version=3;";

                    //create the database query
                    string query = "SELECT * FROM Proveedor Where Nombreproveedor = '" + textBox5.Text + "'";

                    //create an OleDbDataAdapter to execute the query
                    System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                    //create a command builder
                    System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                    //create a DataTable to hold the query results
                    DataTable dTable = new DataTable();
                    //fill the DataTable
                    dAdapter.Fill(dTable);
                    dAdapter.Update(dTable);

                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        DataRow Row = dTable.Rows[i];

                        if (Row["Nombreproveedor"].ToString() == textBox5.Text)
                        {
                            existeprov = true;
                        }
                    }

                    if (existeprov == true)
                    {

                        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                               new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBPInc.s3db ;Version=3;");

                        System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;

                        //comando sql para insercion
                        cmd.CommandText = "INSERT INTO Almacen Values ('" + Int64.Parse(textBox4.Text) + "', '" + textBox1.Text + "', '" + float.Parse(textBox7.Text) + "', '" + float.Parse(textBox8.Text) + "', '" + Int32.Parse(textBox6.Text) + "' ,'" + textBox5.Text + "', '" + DateTime.Now.ToShortDateString() + "')";

                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();

                        sqlConnection1.Close();


                        sqlConnection1 = new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBstk.s3db ;Version=3;");
                        cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.CommandText = "INSERT INTO Existencia Values('"+Int64.Parse(textBox4.Text)+"', '"+Int64.Parse(textBox13.Text)+"')";
                        cmd.Connection = sqlConnection1;
                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();
                        sqlConnection1.Close();

                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox1.Text = "";
                        textBox13.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("El Proveedor Especificado no existe");
                    }


                }
                catch
                {
                    MessageBox.Show("Ya existe un articulo con esa ID");
                }
            }
            else
            {
                if (textBox1.Text != "")
                {
                    MessageBox.Show("No ha desginado un nombre para el articulo"); 
                }
                else if (cantidad == false)
                {
                    MessageBox.Show("La cantidad puesta no es valida");
                }
                else if (compra == false)
                {
                    MessageBox.Show("La cantidad puesta no es valida en el campo de compra"); 
                }
                else if (venta == false)
                {
                    MessageBox.Show("La cantidad puesta no es valida en el campo de venta"); 
                }
 
            }
        }

        
        int cantidadtotal = 0;
        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {
            ///create the connection string
            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBpinc.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM Almacen Where ArticuloID = '" + textBox12.Text + "'";

            //create an OleDbDataAdapter to execute the query
            System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            DataTable dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);

            label27.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";

            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow Row = dTable.Rows[i];

                label27.Text = Row["Cantidadexistencia"].ToString();
                cantidadtotal = Int32.Parse(Row["Cantidadexistencia"].ToString());
                textBox10.Text = Row["Precioventa"].ToString();
                textBox9.Text = Row["Preciocompra"].ToString();
            }

            ///create the connection string
            appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            connString = @"Data Source= " + appPath2 + @"\DBstk.s3db ;Version=3;";

            //create the database query
            query = "SELECT * FROM Existencia Where ArticuloID = '" + textBox12.Text + "'";

            //create an OleDbDataAdapter to execute the query
            dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);
                        
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow Row = dTable.Rows[i];

                textBox14.Text = Row["Limite"].ToString();
            }

        }
        private void button4_Click_1(object sender, EventArgs e)
        {

            int result;
            bool accept = Int32.TryParse(textBox11.Text, out result);
            if (accept == true && textBox10.Text != "" && textBox9.Text != "" && textBox12.Text != "")
            {
                cantidadtotal += Int32.Parse(textBox11.Text);


                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                       new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBPInc.s3db ;Version=3;");

                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                //comando sql para insercion
                cmd.CommandText = "UPDATE Almacen Set Fechaadquisicion = '" + DateTime.Now.ToShortDateString() + "', Cantidadexistencia = '" + cantidadtotal + "', Precioventa = '" + float.Parse(textBox10.Text) + "', Preciocompra = '" + float.Parse(textBox9.Text) + "' Where ArticuloID = '" + Int64.Parse(textBox12.Text) + "'";

                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();

                sqlConnection1 = new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBstk.s3db ;Version=3;");
                cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                //comando sql para insercion
                cmd.CommandText = "UPDATE Existencia Set Limite = '" + Int64.Parse(textBox14.Text) + "' WHERE ArticuloID = '"+Int64.Parse(textBox12.Text)+"'";

                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();

                textBox12.Text = "";
                textBox11.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
                label27.Text = "0";
                textBox14.Text = "";

            }
            else
            {
                if (textBox12.Text == "")
                {
                    MessageBox.Show("No ha introducido un articulo para actualizar");
                }
                else
                {
                    MessageBox.Show("Introduzca una cantidad valida");
                }
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox1.Text = "";

            textBox12.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            label27.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {


            

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                //create the database query
                string query = "SELECT * From Almacen";

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




                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                int i = 0;
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    i += c.Width;

                }
                dataGridView1.Width = i + dataGridView1.RowHeadersWidth + 2;

            }
            else if (tabControl1.SelectedIndex == 3)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                //create the connection string
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                //create the database query
                string query = "SELECT ArticuloID, Nombrearticulo From Almacen";

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
                dataGridView2.DataSource = bSource;
                dAdapter.Update(dTable);

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                int i = 0;
                foreach (DataGridViewColumn c in dataGridView2.Columns)
                {
                    i += c.Width;

                }
                dataGridView2.Width = i + dataGridView2.RowHeadersWidth + 2;

                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
                {
                    IncludeLabel = true,
                    Alignment = AlignmentPositions.CENTER,
                    Width = 300,
                    Height = 100,
                    RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                };
                try
                {
                    Image img = barcode.Encode(TYPE.CODE128B, dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    pictureBox1.Image = img;
                }
                catch
                { 
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro que desea eliminar?", "Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resultado == DialogResult.Yes)
                {

                    Int64 articuloID = Int64.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                    new System.Data.SQLite.SQLiteConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db");

                    System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = "Delete From Almacen Where [ArticuloID] = " + articuloID+"";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();

                    appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    sqlConnection1 =
                                    new System.Data.SQLite.SQLiteConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBstk.s3db");

                    cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = "Delete From Existencia Where [ArticuloID] = " + articuloID + "";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();

                    appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    //create the connection string
                    string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

                    //create the database query
                    string query = "Select * From Almacen";

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
            }
            else
            {
                MessageBox.Show("Tiene que elegir un articulo para borrarlo");
            }
        }

        private void Almacen_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //create the connection string
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";

            //create the database query
            string query = "SELECT * From Almacen Where Nombrearticulo like '%"+textBox2.Text+"%'";

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
            {
                IncludeLabel = true,
                Alignment = AlignmentPositions.CENTER,
                Width = 300,
                Height = 100,
                RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                BackColor = Color.White,
                ForeColor = Color.Black,
            };

            Image img = barcode.Encode(TYPE.CODE128B, dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            pictureBox1.Image = img;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
        System.Drawing.Printing.PrintDocument doc2 = new System.Drawing.Printing.PrintDocument();
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, this.pictureBox1.Width, this.pictureBox1.Height));
            //e.Graphics.DrawImage((Image)bmp, x, y);
            for (int i = 0; i <= Int32.Parse(comboBox1.Text) - 1; i++)
            {
                if (i <= 1)
                {
                    e.Graphics.DrawImage((Image)bmp, x, y);
                }
                else if (i == 2 || i == 3)
                {
                    e.Graphics.DrawImage((Image)bmp, x, y + 120);
                }
                else if (i == 4 || i == 5)
                {
                    e.Graphics.DrawImage((Image)bmp, x, y + 240);
                }
                else if (i == 6 || i == 7)
                {
                    e.Graphics.DrawImage((Image)bmp, x, y + 360);
                }
                else if (i == 8 || i == 9)
                {
                    e.Graphics.DrawImage((Image)bmp, x, y + 480);
                }
                else if (i == 10 || i == 11)
                {
                    e.Graphics.DrawImage((Image)bmp, x, y + 600);
                }
                else if (i == 12 || i == 13)
                {
                    e.Graphics.DrawImage((Image)bmp, x, y + 720);
                }
                else if (i == 14 || i == 15)
                {
                    e.Graphics.DrawImage((Image)bmp, x, y + 840);
                }


                if ((i + 1) % 2 != 0)
                {
                    x += 350;
                }
                else
                {
                    x = e.MarginBounds.Left;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            doc.PrintPage += this.printDocument1_PrintPage;
            PrintPreviewDialog ppdlg = new PrintPreviewDialog();
            ppdlg.Document = doc;
            ((Form)ppdlg).WindowState = FormWindowState.Maximized;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            System.Drawing.Icon ico = new System.Drawing.Icon(appPath + @"\Img\caritasico.ico");
            ((Form)ppdlg).Icon = ico;
            ppdlg.ShowDialog();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

            doc.PrintPage += this.printDocument1_PrintPage;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button8, "Vista Previa");
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button9, "Ventana de Dialogo de Impresion");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //create the connection string
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + @"\DBpinc.s3db";
            string query = "";
            if (textBox3.Text != "")
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    //create the database query
                    query = "SELECT ArticuloID, Nombrearticulo From Almacen Where ArticuloID like '%" + textBox3.Text + "%'";
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    query = "SELECT ArticuloID, Nombrearticulo From Almacen Where Nombrearticulo like '%" + textBox3.Text + "%'";
                }
            }
            else
            {
                query = "SELECT ArticuloID, Nombrearticulo From Almacen"; 
            }
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
            dataGridView2.DataSource = bSource;
            dAdapter.Update(dTable);
        }
        string[] codigos = new string[16];
        int jcodigo = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                codigos[jcodigo] = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                jcodigo++;
                doc2.PrintPage += this.printDocument2_PrintPage;
                label9.Text = jcodigo.ToString();
            }
            catch
            {
                MessageBox.Show("Se ha llegado al limite de codigo de barras para la hoja.");
            }
        }
        int icodigo = 0;
        float xe;
        float ye;
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            if (icodigo < 1)
            {
                xe = e.MarginBounds.Left;
                ye = e.MarginBounds.Top;
            }
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
            {
                IncludeLabel = true,
                Alignment = AlignmentPositions.CENTER,
                Width = 300,
                Height = 100,
                RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                BackColor = Color.White,
                ForeColor = Color.Black,
            };

            Image img = barcode.Encode(TYPE.CODE128B, codigos[icodigo].ToString());
            pictureBox1.Image = img;



            Bitmap bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, this.pictureBox1.Width, this.pictureBox1.Height));
            //e.Graphics.DrawImage((Image)bmp, x, y);


            if (icodigo <= 1)
            {
                e.Graphics.DrawImage((Image)bmp, xe, ye);
            }
            else if (icodigo == 2 || icodigo == 3)
            {
                if (icodigo == 2)
                {
                    ye = ye + 120;
                }
                e.Graphics.DrawImage((Image)bmp, xe, ye);
            }
            else if (icodigo == 4 || icodigo == 5)
            {
                if (icodigo == 4)
                {
                    ye = ye + 120;
                }
                e.Graphics.DrawImage((Image)bmp, xe, ye);
            }
            else if (icodigo == 6 || icodigo == 7)
            {
                if (icodigo == 6)
                {
                    ye = ye + 120;
                }
                e.Graphics.DrawImage((Image)bmp, xe, ye);
            }
            else if (icodigo == 8 || icodigo == 9)
            {
                if (icodigo == 8)
                {
                    ye = ye + 120;
                }
                e.Graphics.DrawImage((Image)bmp, xe, ye);
            }
            else if (icodigo == 10 || icodigo == 11)
            {
                if (icodigo == 10)
                {
                    ye = ye + 120;
                }
                e.Graphics.DrawImage((Image)bmp, xe, ye);
            }
            else if (icodigo == 12 || icodigo == 13)
            {
                if (icodigo == 12)
                {
                    ye = ye + 120;
                }
                e.Graphics.DrawImage((Image)bmp, xe, ye);
            }
            else if (icodigo == 14 || icodigo == 15)
            {
                if (icodigo == 14)
                {
                    ye = ye + 120;
                }
                e.Graphics.DrawImage((Image)bmp, xe, ye);
            }
                

            if ((icodigo + 1) % 2 != 0)
            {
                xe += 350;
            }
            else
            {
                xe = e.MarginBounds.Left;
            }
            icodigo++;
            
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            PrintPreviewDialog ppdlg = new PrintPreviewDialog();
            ppdlg.Document = doc2;
            ((Form)ppdlg).WindowState = FormWindowState.Maximized;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            System.Drawing.Icon ico = new System.Drawing.Icon(appPath + @"\Img\caritasico.ico");
            ((Form)ppdlg).Icon = ico;
            ppdlg.ShowDialog();
            icodigo = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            doc2 = new System.Drawing.Printing.PrintDocument();
            icodigo = 0;
            jcodigo = 0;
            label9.Text = "0";
            
        }

        
    }
}
