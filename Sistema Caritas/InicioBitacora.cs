using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Caritas
{
    public partial class InicioBitacora : Form
    {
        public InicioBitacora()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevaBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevaEntradaSalidaBitacora nuevaes = new NuevaEntradaSalidaBitacora();
            nuevaes.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            nuevaes.Show();
            
        }

        private void eliminarBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarEntradaSalidaBitacora eliminares = new EliminarEntradaSalidaBitacora();
            eliminares.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            eliminares.Show();
        }

        private void modificarBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarEntradaSalidaBitacora modificares = new ModificarEntradaSalidaBitacora();
            modificares.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            modificares.Show();
        }

        private void entradasSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultasBitacoraComedor cnsltabitacora = new ConsultasBitacoraComedor();
            cnsltabitacora.MdiParent = Bienvenida.ActiveForm;
            cnsltabitacora.Show();
        }
    }
}
