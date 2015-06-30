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
using SecuGen.FDxSDKPro.Windows;

namespace Sistema_Caritas
{
    public partial class NuevaEntradaSalidaBitacora : Form
    {

        private SGFingerPrintManager m_FPM;
        private Int32 m_ImageWidth;
        private Int32 m_ImageHeight;
        private Int32 m_Dpi;
        private Byte[] m_RegMin1;
        private Byte[] m_RegMin2;
        private Byte[] m_VrfMin;
        private bool m_DeviceOpened;
        private Byte[] m_StoredTemplate;
        private SGFPMSecurityLevel m_SecurityLevel;
        private Byte[] fp_image;
        public NuevaEntradaSalidaBitacora()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                int cantidad;
                if (int.TryParse(textBox3.Text, out cantidad))
                {
                    float peso;
                    if (float.TryParse(textBox4.Text, out peso))
                    {
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                               new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;");

                        System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        //comando sql para insercion
                        cmd.CommandText = "INSERT INTO Entradas values ('"+label1.Text+"', '"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+textBox4.Text+"', '"+textBox5.Text+"', '"+textBox6.Text+"', '"+textBox7.Text+"', '"+comboBox1.Text+"', '"+textBox8.Text+"')";

                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();

                        sqlConnection1.Close();
                        MessageBox.Show("Entrada guardada con exito.");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        comboBox1.SelectedIndex = 0;
                        textBox8.Text = "";

                        
                        ///create the connection string
                        string connString = @"Data Source= " + appPath + @"\DBBIT.s3db ;Version=3;";

                        //create the database query
                        string query = "SELECT * FROM Entradas";

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
                            DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                            string num = Row["Numero"].ToString();
                            int autonum = Int32.Parse(num);
                            label1.Text = (autonum + 1).ToString();
                        }
                        else
                        {
                            label1.Text = "1";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Revise de nuevo su campo de peso, solo se permiten numeros flotantes.");
                    }
                }
                else
                {
                    MessageBox.Show("Revise de nuevo su campo de cantidad, solo se permiten numeros.");
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NuevaEntradaSalidaBitacora_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBBIT.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM Entradas";

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
                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string num = Row["Numero"].ToString();
                int autonum = Int32.Parse(num);
                label1.Text = (autonum + 1).ToString();
            }
            else
            {
                label1.Text = "1";
            }

            
            

            //create the database query
            query = "SELECT * FROM Salidas";

            //create an OleDbDataAdapter to execute the query
            dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);


            if (dTable.Rows.Count != 0)
            {
                DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                string num = Row["Numero"].ToString();
                int autonum = Int32.Parse(num);
                label12.Text = (autonum + 1).ToString();
            }
            else
            {
                label12.Text = "1";
            }

            m_ImageWidth = 260;
            m_ImageHeight = 300;
            m_Dpi = 500;
            m_FPM = new SGFingerPrintManager();
            Int32 error;
            SGFPMDeviceName device_name = SGFPMDeviceName.DEV_UNKNOWN;
            Int32 device_id = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            device_name = SGFPMDeviceName.DEV_AUTO;

            m_DeviceOpened = false;

            if (device_name != SGFPMDeviceName.DEV_UNKNOWN)
                error = m_FPM.Init(device_name);
            else
                error = m_FPM.InitEx(m_ImageWidth, m_ImageHeight, m_Dpi);

            if (error == (Int32)SGFPMError.ERROR_NONE)
            {
                SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
                m_FPM.GetDeviceInfo(pInfo);
                m_ImageWidth = pInfo.ImageWidth;
                m_ImageHeight = pInfo.ImageHeight;
                StatusBar.Text = "Initialization Success";
                pictureBox1.Visible = true;
                progressBar1.Visible = true;
                button3.Visible = true;
                button4.Visible = false;
            }
            else
            {
                StatusBar.Text = "Init() Error " + error;
                return;
            }

            // Set template format to ANSI 378
            error = m_FPM.SetTemplateFormat(SGFPMTemplateFormat.ANSI378);

            // Get Max template size
            Int32 max_template_size = 0;
            error = m_FPM.GetMaxTemplateSize(ref max_template_size);

            m_RegMin1 = new Byte[max_template_size];
            m_RegMin2 = new Byte[max_template_size];
            m_VrfMin = new Byte[max_template_size];

            // OpenDevice if device is selected
            if (device_name != SGFPMDeviceName.DEV_UNKNOWN)
            {
                error = m_FPM.OpenDevice(device_id);
                if (error == (Int32)SGFPMError.ERROR_NONE)
                {
                    m_DeviceOpened = true;

                }
                else
                {
                    StatusBar.Text = "OpenDevice() Error : " + error;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
            {
                int cantidad;
                if (int.TryParse(textBox12.Text, out cantidad))
                {
                    float peso;
                    if (float.TryParse(textBox14.Text, out peso))
                    {
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                               new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBBIT.s3db ;Version=3;");

                        System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        //comando sql para insercion
                        cmd.CommandText = "INSERT INTO Salidas (Numero, Salida, Descripcion, Cantidad, Peso, Equivalentes, Nota, TipoDeApoyo, Responsable, Huella) values ('" + label12.Text + "', '" + textBox9.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "', '" + textBox14.Text + "', '" + textBox16.Text + "', '" + textBox15.Text + "', '" + textBox13.Text + "', '" + textBox10.Text + "',@0 )";
                        SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
                        cmd.Connection = sqlConnection1;
                        param.Value = fp_image;
                        cmd.Parameters.Add(param);
                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();

                        sqlConnection1.Close();
                        MessageBox.Show("Salida guardada con exito.");
                        textBox9.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        textBox14.Text = "";
                        textBox16.Text = "";
                        textBox15.Text = "";
                        textBox13.Text = "";
                        textBox10.Text = "";


                        ///create the connection string
                        string connString = @"Data Source= " + appPath + @"\DBBIT.s3db ;Version=3;";

                        //create the database query
                        string query = "SELECT * FROM Salidas";

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
                            DataRow Row = dTable.Rows[dTable.Rows.Count - 1];
                            string num = Row["Numero"].ToString();
                            int autonum = Int32.Parse(num);
                            label12.Text = (autonum + 1).ToString();
                        }
                        else
                        {
                            label12.Text = "1";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Revise de nuevo su campo de peso, solo se permiten numeros flotantes.");
                    }
                }
                else
                {
                    MessageBox.Show("Revise de nuevo su campo de cantidad, solo se permiten numeros.");
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                panel1.BringToFront();
            }
            else
            {
                panel2.BringToFront();
            }

           
        }
    }
}
