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

/* Spectrum Rarity "The art of the programming" */
namespace ExpedienteClinico
{
    public partial class Forma1 : Form
    {
        public Forma1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            pictureBox1.Image = Image.FromFile(appPath + @"\inicio.jpg");
            if (Bienvenida.tipouser != "Administrador")
            {
                modificarToolStripMenuItem.Visible = false;
                bajaToolStripMenuItem.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void nuevoExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoExpediente nuevoexp = new NuevoExpediente();
            nuevoexp.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            nuevoexp.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarExp modificar = new ModificarExp();
            modificar.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            modificar.Show();
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BajaExp baja = new BajaExp();
            baja.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            baja.Show();
        }

        private void consultarExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaExp consulta = new ConsultaExp();
            consulta.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            consulta.Show();
        }
    }
}
