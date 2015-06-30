using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sistema_Caritas
{
    public partial class InicioExpSillas : Form
    {
        public InicioExpSillas()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoExpedienteSillas NuevoExpedienteSillaschild = new NuevoExpedienteSillas();
            NuevoExpedienteSillaschild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            NuevoExpedienteSillaschild.Show();

            
        }

        private void modificarExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerModificacionesExpSillas VerModificacionesExpSillaschild = new VerModificacionesExpSillas();
            VerModificacionesExpSillaschild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            VerModificacionesExpSillaschild.Show();
        }

        private void eliminarExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EliminarExpedienteSillas EliminarExpedienteSillaschild = new EliminarExpedienteSillas();
            EliminarExpedienteSillaschild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            EliminarExpedienteSillaschild.Show();
        }

        private void expedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaExpedienteSillas ConsultaExpedienteSillaschild = new ConsultaExpedienteSillas();
            ConsultaExpedienteSillaschild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            ConsultaExpedienteSillaschild.Show(); 
        }

        private void InicioExpSillas_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            pictureBox1.Image = Image.FromFile(appPath + @"\inicio.jpg");
            if (Bienvenida.tipouser != "Administrador")
            {
                modificarExpedienteToolStripMenuItem.Visible = false;
                eliminarExpedienteToolStripMenuItem.Visible = false;
            }
        }
    }
}
