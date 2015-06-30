using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Sistema_Caritas;

namespace Caritas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            pictureBox1.Image = Image.FromFile(appPath+@"\inicio.jpg");
            if (Bienvenida.tipouser != "Administrador")
            {
                modificarDonacionToolStripMenuItem.Visible = false;
                borrarDonacionToolStripMenuItem.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void nuevaDonacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Altas altafrm = new Altas();
            altafrm.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            altafrm.Show();
        }

        private void modificarDonacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar modfrm = new Modificar();
            modfrm.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            modfrm.Show();
        }

        private void borrarDonacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bajas bajafrm = new Bajas();
            bajafrm.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            bajafrm.Show();
        }

        private void consultarDonacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas consform = new Consultas();
            consform.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            consform.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
