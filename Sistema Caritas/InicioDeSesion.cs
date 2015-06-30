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
using SecuGen.FDxSDKPro.Windows;


namespace Sistema_Caritas
{
    public partial class InicioDeSesion : Form
    {
        private SGFingerPrintManager m_FPM;
        private Int32 m_ImageWidth;
        private Int32 m_ImageHeight;
        private Int32 m_Dpi;
        private SGFPMSecurityLevel m_SecurityLevel;

        private Byte[] m_RegMin1;
        private Byte[] m_RegMin2;
        private Byte[] m_VrfMin;
        private Byte[] m_StoredTemplate;
        private bool m_DeviceOpened;
        
        public InicioDeSesion()
        {
            InitializeComponent();
        }


        private void InicioDeSesion_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///create the connection string
            string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
            ///create the connection string
            string connString = @"Data Source= " + appPath2 + @"\DBUC.s3db ;Version=3;";

            //create the database query
            string query = "SELECT * FROM Usuarios";

            //create an OleDbDataAdapter to execute the query
            System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

            //create a command builder
            System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

            //create a DataTable to hold the query results
            DataTable dTable = new DataTable();
            //fill the DataTable
            dAdapter.Fill(dTable);
            dAdapter.Update(dTable);

            bool usuarioexistente = false;

            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DataRow Row = dTable.Rows[i];

                if (Row["Usuario"].ToString() == textBox1.Text && Row["Contrasena"].ToString() == textBox2.Text)
                {
                    MessageBox.Show("Bienvenido al Sistema Caritas");
                    ((Form)this.MdiParent).Controls["menuStrip1"].Enabled = true;
                    usuarioexistente = true;

                    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                    System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                           new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBUC.s3db ;Version=3;");

                    System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    //comando sql para insercion
                    cmd.CommandText = "Update Usuarios Set FechaUltimaSesion = '"+DateTime.Now.ToShortDateString()+"' Where ID = '"+Row["ID"].ToString()+"'";

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();

                    sqlConnection1.Close();
                    string prueba = Row["TipoDeUsuario"].ToString();
                    if (Row["TipoDeUsuario"].ToString() == "Administrador")
                    {
                        Form frm = (Form)this.MdiParent;
                        MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];
                        ToolStripMenuItem ti = (ToolStripMenuItem)ms.Items["controlDeUsuariosToolStripMenuItem"];
                        ti.Visible = true;
                    }
                    Bienvenida.tipouser = Row["TipoDeUsuario"].ToString();
                    this.Close();
                    //--------------

                    appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                    ///create the connection string
                    connString = @"Data Source= " + appPath2 + @"\DBpinc.s3db ;Version=3;";

                    //create the database query
                    query = "SELECT * FROM Almacen";

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
                        for (int k = 0; k < dTable.Rows.Count; k++)
                        {
                            Row = dTable.Rows[k];
                            Int32 cantidadexistencia = Int32.Parse(Row["Cantidadexistencia"].ToString());
                            string nombre = Row["Nombrearticulo"].ToString();
                            appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                            ///create the connection string
                            connString = @"Data Source= " + appPath2 + @"\DBstk.s3db ;Version=3;";

                            //create the database query
                            query = "SELECT * FROM Existencia Where ArticuloID = '" + Row["ArticuloID"].ToString() + "'";

                            //create an OleDbDataAdapter to execute the query
                            dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                            //create a command builder
                            cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                            //create a DataTable to hold the query results
                            DataTable dTable2 = new DataTable();
                            //fill the DataTable
                            dAdapter.Fill(dTable2);
                            dAdapter.Update(dTable2);

                            if (dTable2.Rows.Count > 0)
                            {
                                Row = dTable2.Rows[0];
                                Int64 cantlimite = Int64.Parse(Row["Limite"].ToString());
                                if (cantlimite >= cantidadexistencia)
                                {
                                    MessageBox.Show("Quedan " + cantlimite.ToString() + " o menos en existencia del articulo " + nombre + "");
                                }
                            }
                        }
                    }

                    //--------------
                    break;

                }
            }
            if (usuarioexistente == false)
            {
                MessageBox.Show("Usuario o contraseña incorrecta"); 
            }


        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                button1.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Byte[] fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            Int32 error = (Int32)SGFPMError.ERROR_NONE;
            Int32 img_qlty = 0;

            if (m_DeviceOpened)
                error = m_FPM.GetImage(fp_image);
            else

                error = GetImageFromFile(fp_image);

            if (error == (Int32)SGFPMError.ERROR_NONE)
            {
                m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
                PB1.Value = img_qlty;

                DrawImage(fp_image, pictureBox1);

                SGFPMFingerInfo finger_info = new SGFPMFingerInfo();
                finger_info.FingerNumber = (SGFPMFingerPosition)1;
                finger_info.ImageQuality = (Int16)img_qlty;
                finger_info.ImpressionType = (Int16)SGFPMImpressionType.IMPTYPE_LP;
                finger_info.ViewNumber = 1;

                // CreateTemplate
                error = m_FPM.CreateTemplate(finger_info, fp_image, m_RegMin1);

                if (error == (Int32)SGFPMError.ERROR_NONE)
                    StatusBar.Text = "First image is captured";
                else
                    StatusBar.Text = "GetMinutiae() Error : " + error;
            }
            else
                StatusBar.Text = "GetImage() Error : " + error;

            ///////////////////////////////////

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            error = (Int32)SGFPMError.ERROR_NONE;
            img_qlty = 0;

            if (m_DeviceOpened)
                error = m_FPM.GetImage(fp_image);
            else
                error = GetImageFromFile(fp_image);

            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            PB2.Value = img_qlty;

            if (error == (Int32)SGFPMError.ERROR_NONE)
            {
                DrawImage(fp_image, pictureBox2);

                SGFPMFingerInfo finger_info = new SGFPMFingerInfo();
                finger_info.FingerNumber = (SGFPMFingerPosition)1;
                finger_info.ImageQuality = (Int16)img_qlty;
                finger_info.ImpressionType = (Int16)SGFPMImpressionType.IMPTYPE_LP;
                finger_info.ViewNumber = 1;

                error = m_FPM.CreateTemplate(finger_info, fp_image, m_RegMin2);

                if (error == (Int32)SGFPMError.ERROR_NONE)
                    StatusBar.Text = "Second image is captured";
                else
                    StatusBar.Text = "GetMinutiae() Error : " + error;
            }
            else
                StatusBar.Text = "GetImage() Error : " + error;
        }

        /////////////////////////////////////
        private void DrawImage(Byte[] imgData, PictureBox picBox)
        {
            int colorval;
            Bitmap bmp = new Bitmap(m_ImageWidth, m_ImageHeight);
            picBox.Image = (Image)bmp;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    colorval = (int)imgData[(j * m_ImageWidth) + i];
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval));
                }
            }
            picBox.Refresh();
        }

        /////////////////////////////////////
        private Int32 GetImageFromFile(Byte[] data)
        {
            OpenFileDialog open_dlg;
            open_dlg = new OpenFileDialog();

            open_dlg.Title = "Image raw file dialog";
            open_dlg.Filter = "Image raw files (*.raw)|*.raw";

            if (open_dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream inStream = File.OpenRead(open_dlg.FileName);

                BinaryReader br = new BinaryReader(inStream);

                Byte[] local_data = new Byte[data.Length];
                local_data = br.ReadBytes(data.Length);
                Array.Copy(local_data, data, data.Length);

                br.Close();
                return (Int32)SGFPMError.ERROR_NONE;
            }
            return (Int32)SGFPMError.ERROR_FUNCTION_FAILED;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            m_SecurityLevel = SGFPMSecurityLevel.NORMAL;
            m_StoredTemplate = null;
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

                this.Height = 453;
                this.Width = 820;

                pictureBox1.Enabled = true;
                pictureBox2.Enabled = true;
                PB1.Enabled = true;
                PB2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;

                button1.Enabled = false;
                textBox2.Enabled = false;

                button5.Enabled = false;
                button5.Visible = false;

                button6.Visible = true;
                button6.Enabled = true;
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

        private void button4_Click(object sender, EventArgs e)
        {

            bool matched = false;
            Int32 err = 0;
            err = m_FPM.MatchTemplate(m_RegMin1, m_RegMin2, m_SecurityLevel, ref matched);

            if ((err == (Int32)SGFPMError.ERROR_NONE))
            {
                if (matched)
                {
                    // Save template after merging two template - m_FetBuf1, m_FetBuf2
                    Byte[] merged_template;
                    Int32 buf_size = 0;

                    m_FPM.GetTemplateSizeAfterMerge(m_RegMin1, m_RegMin2, ref buf_size);
                    merged_template = new Byte[buf_size];
                    m_FPM.MergeAnsiTemplate(m_RegMin1, m_RegMin2, merged_template);

                    if (m_StoredTemplate == null)
                    {
                        m_StoredTemplate = new Byte[buf_size];
                        merged_template.CopyTo(m_StoredTemplate, 0);
                    }
                    else
                    {
                        Int32 new_size = 0;
                        err = m_FPM.GetTemplateSizeAfterMerge(m_StoredTemplate, merged_template, ref new_size);

                        Byte[] new_enroll_template = new Byte[new_size];

                        err = m_FPM.MergeAnsiTemplate(merged_template, m_StoredTemplate, new_enroll_template);

                        m_StoredTemplate = new Byte[new_size];

                        new_enroll_template.CopyTo(m_StoredTemplate, 0);
                    }



                    StatusBar.Text = "Template registration success";


                    ////////////////////////////////////
                    PictureBox picturebox3 = new PictureBox();

                    string appPath2 = Path.GetDirectoryName(Application.ExecutablePath);
                    ///create the connection string
                    string connString = @"Data Source= " + appPath2 + @"\DBUC.s3db ;Version=3;";

                    //create the database query
                    string query = "SELECT * FROM Usuarios where Usuario = '" + textBox1.Text + "'";

                    //create an OleDbDataAdapter to execute the query
                    System.Data.SQLite.SQLiteDataAdapter dAdapter = new System.Data.SQLite.SQLiteDataAdapter(query, connString);

                    //create a command builder
                    System.Data.SQLite.SQLiteCommandBuilder cBuilder = new System.Data.SQLite.SQLiteCommandBuilder(dAdapter);

                    //create a DataTable to hold the query results
                    DataTable dTable = new DataTable();
                    //fill the DataTable
                    dAdapter.Fill(dTable);
                    dAdapter.Update(dTable);

                    if (dTable.Rows.Count >= 1)
                    {
                        DataRow Row = dTable.Rows[0];

                        if (Row["Huella"] != null)
                        {



                            System.Byte[] fp_image = (System.Byte[])Row["Huella"];

                            ///////////////////////////////////////////////////

                            Int32 error = (Int32)SGFPMError.ERROR_NONE;
                            Int32 img_qlty = 0;

                            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);

                            if (error == (Int32)SGFPMError.ERROR_NONE)
                            {
                                DrawImage(fp_image, picturebox3);

                                SGFPMFingerInfo finger_info = new SGFPMFingerInfo();
                                finger_info.FingerNumber = (SGFPMFingerPosition)1;
                                finger_info.ImageQuality = (Int16)img_qlty;
                                finger_info.ImpressionType = (Int16)SGFPMImpressionType.IMPTYPE_LP;
                                finger_info.ViewNumber = 1;

                                // Create template
                                error = m_FPM.CreateTemplate(finger_info, fp_image, m_VrfMin);

                                if (error == (Int32)SGFPMError.ERROR_NONE)
                                {
                                    StatusBar.Text = "Verification image is captured";

                                    if (m_StoredTemplate == null)
                                    {
                                        StatusBar.Text = "No data to verify";
                                        return;
                                    }

                                    string[] fingerpos_str = new string[]
                           {
                              "Unknown finger",
                              "Right thumb",
                              "Right index finger",
                              "Right middle finger",
                              "Right ring finger",
                              "Right little finger",
                              "Left thumb",
                              "Left index finger",
                              "Left middle finger",
                              "Left ring finger",
                              "Left little finger"};


                                    SGFPMFingerPosition finger_pos = SGFPMFingerPosition.FINGPOS_UK;
                                    bool finger_found = false;

                                    SGFPMANSITemplateInfo sample_info = new SGFPMANSITemplateInfo();
                                    err = m_FPM.GetAnsiTemplateInfo(m_StoredTemplate, sample_info);

                                    for (int i = 0; i < sample_info.TotalSamples; i++)
                                    {
                                        matched = false;
                                        err = m_FPM.MatchAnsiTemplate(m_StoredTemplate, i, m_VrfMin, 0, m_SecurityLevel, ref matched);
                                        if (matched)
                                        {
                                            finger_found = true;
                                            finger_pos = (SGFPMFingerPosition)sample_info.SampleInfo[i].FingerNumber;
                                            break;
                                        }
                                    }

                                    if (err == (Int32)SGFPMError.ERROR_NONE)
                                    {
                                        if (finger_found)
                                        {
                                            StatusBar.Text = "The matched data found. Finger position: " + fingerpos_str[(Int32)finger_pos];
                                            textBox2.Text = Row["Contrasena"].ToString();
                                            button1.Enabled = true;
                                            button1.PerformClick();
                                        }
                                        else
                                            StatusBar.Text = "Cannot find a matched data";
                                    }
                                    else
                                        StatusBar.Text = "MatchAnsiTemplate() Error : " + err;

                                }

                                else
                                    StatusBar.Text = "GetMinutiae() Error : " + error;
                            }
                            else
                                StatusBar.Text = "GetImage() Error : " + error;

                        }
                        else
                        {
                            MessageBox.Show("No hay huella con la cual comparar"); 
                        }
                        ////////////////////////////////////////////////
                    }
                    else
                    {
                        MessageBox.Show("El usuario no existe U olvido colocarlo");
                    }
                    
                }
                else
                {
                    StatusBar.Text = "Template registration failed";
                }
                

            }
            else
                StatusBar.Text = "MatchTemplate() Error: " + err;
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Width = 410;
            this.Height = 276;
            button1.Enabled = true;
            textBox2.Enabled = true;
            button6.Enabled = false;
            button6.Visible = false;
            button5.Visible = true;
            button5.Enabled = true;

            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            PB1.Enabled = false;
            PB2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
    }
}
