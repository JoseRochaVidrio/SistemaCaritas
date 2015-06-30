using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema_Caritas;
using System.IO;

namespace Sistema_Caritas
{
    public partial class ControlUsuarios : Form
    {
        public ControlUsuarios()
        {
            InitializeComponent();
        }

        private void altaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaUsuarios iniciosesionchild = new AltaUsuarios();
            iniciosesionchild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            iniciosesionchild.Show();
        }

        private void bajaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BajaUsuarios bajausuarioschild = new BajaUsuarios();
            bajausuarioschild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            bajausuarioschild.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modificarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarUsuario modificarchild = new ModificarUsuario();
            modificarchild.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            modificarchild.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void ControlUsuarios_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            pictureBox1.Image = Image.FromFile(appPath + @"\inicio.jpg");
        }
    }
}
