using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SecuGen.FDxSDKPro.Windows;
using System.Data.SQLite;

namespace Sistema_Caritas
{
    public partial class AltaUsuarios : Form
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

        public AltaUsuarios()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
                if (textBox4.Text != "" && textBox3.Text != "")
                {
                    if (textBox4.Text == textBox3.Text)
                    {
                        label5.Text = "OK";
                        button1.Enabled = true;
                    }
                    else
                    {
                        label5.Text = "No coinciden";
                        button1.Enabled = false;
                    }
                }
                else
                {
                    label5.Text = "";
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                System.Data.SQLite.SQLiteConnection sqlConnection1 =
                                       new System.Data.SQLite.SQLiteConnection(@"Data Source=" + appPath + @"\DBUC.s3db ;Version=3;");

                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                //comando sql para insercion
                cmd.CommandText = "INSERT INTO Usuarios (Nombre, Usuario, Contrasena, FechaContrasena, TipoDeUsuario, Huella) VALUES ('"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+DateTime.Now.ToShortDateString()+"', '"+comboBox1.Text+"', @0)";
                SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
                cmd.Connection = sqlConnection1;
                param.Value = fp_image;
                cmd.Parameters.Add(param);

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();

                sqlConnection1.Close();

                MessageBox.Show("Usuario Guardado con Exito");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                label5.Text = "";
                pictureBox1.Image = null;
                progressBar1.Value = 0;
            }
            else
            {
                MessageBox.Show("Hay campos en blancos sin llenar"); 
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox3.Text != "")
            {
                if (textBox4.Text == textBox3.Text)
                {
                    label5.Text = "OK";
                    button1.Enabled = true;
                }
                else
                {
                    label5.Text = "No coinciden";
                    button1.Enabled = false;
                }
            }
            else
            {
                label5.Text = "";
            }
        }

        private void AltaUsuarios_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            Int32 error = (Int32)SGFPMError.ERROR_NONE;
            Int32 img_qlty = 0;

            if (m_DeviceOpened)
                error = m_FPM.GetImage(fp_image);
            else

                error = GetImageFromFile(fp_image);

            if (error == (Int32)SGFPMError.ERROR_NONE)
            {
                m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
                progressBar1.Value = img_qlty;
                
                DrawImage(fp_image, pictureBox1);

                SGFPMFingerInfo finger_info = new SGFPMFingerInfo();
                finger_info.FingerNumber = (SGFPMFingerPosition)1;
                finger_info.ImageQuality = (Int16)img_qlty;
                finger_info.ImpressionType = (Int16)SGFPMImpressionType.IMPTYPE_LP;
                finger_info.ViewNumber = 1;

                // CreateTemplate
                error = m_FPM.CreateTemplate(finger_info, fp_image, m_RegMin1);

                if (error == (Int32)SGFPMError.ERROR_NONE)
                    label1.Text = "First image is captured";
                else
                    label1.Text = "GetMinutiae() Error : " + error;
            }
            else
                label1.Text = "GetImage() Error : " + error;

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
    }
}
