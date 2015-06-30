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
namespace CaritasVentas
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            pictureBox1.Image = Image.FromFile(appPath + @"\inicio.jpg");
            if (Bienvenida.tipouser != "Administrador")
            {
                historialDeVentasToolStripMenuItem.Visible = false;
                articulosToolStripMenuItem.Visible = false;
                proveedoresToolStripMenuItem.Visible = false;
            }
        }

       


        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Almacen almacen = new Almacen();
            almacen.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            almacen.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void historialDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registrarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            venta.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            venta.Show();
        }

        private void historialDeVentasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Ventashechas ventashechas = new Ventashechas();
            ventashechas.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            ventashechas.Show();
        }

        private void altaDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores provee = new Proveedores();
            provee.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            provee.Show();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        
    }
}
