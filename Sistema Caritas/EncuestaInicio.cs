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
    public partial class EncuestaInicio : Form
    {
        public EncuestaInicio()
        {
            InitializeComponent();
        }

        private void EncuestaInicio_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            pictureBox1.Image = Image.FromFile(appPath + @"\inicio.jpg");
            if (Bienvenida.tipouser != "Administrador")
            {
                mToolStripMenuItem.Visible = false;
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevaEncuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevaEncuesta nuevaencuestachild = new NuevaEncuesta();
            nuevaencuestachild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            nuevaencuestachild.Show();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BajaEncuesta bajaencuestachild = new BajaEncuesta();
            bajaencuestachild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            bajaencuestachild.Show();
        }

        private void modificarEncuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarEncuestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estadisticas estadisticaschild = new Estadisticas();
            estadisticaschild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            estadisticaschild.Show();
        }
    }
}
