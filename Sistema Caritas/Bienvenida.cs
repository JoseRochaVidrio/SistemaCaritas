using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CaritasVentas;
using Caritas;
using ExpedienteClinico;
using System.Data.SQLite;
using System.IO;

namespace Sistema_Caritas
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }
        public static string tipouser;
        private void Bienvenida_Load(object sender, EventArgs e)
        {
            
            InicioDeSesion inicio = new InicioDeSesion();
            inicio.MdiParent = Sistema_Caritas.Bienvenida.ActiveForm;
            inicio.Show();
        }

        private void moduloDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inicio iniciochild = new Inicio();
            iniciochild.MdiParent = this;
            iniciochild.Show();
        }

        private void caritasDonadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 formachild = new Form1();
            formachild.MdiParent = this;
            formachild.Show();
        }

        private void caritasExpedientesClinicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forma1 forma1child = new Forma1();
            forma1child.MdiParent = this;
            forma1child.Show();
        }

        private void controlDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlUsuarios controlchild = new ControlUsuarios();
            controlchild.MdiParent = this;
            controlchild.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> lst = new List<Form>();
            try
            {
                for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
                {
                    Form f = Application.OpenForms[i1];
                    if (f.IsMdiChild)
                        lst.Add(f);
                }
            }
            catch (IndexOutOfRangeException)
            {
                //This can change if they close/open a form while code is running. Just throw it away
            }
            while (lst.Count > 0)
            {
                Form f = lst[0];
                f.Close();
                f.Dispose();
                lst.RemoveAt(0);
            }
            menuStrip1.Enabled = false;
            controlDeUsuariosToolStripMenuItem.Visible = false;
            InicioDeSesion iniciodesesion = new InicioDeSesion();
            iniciodesesion.MdiParent = this;
            iniciodesesion.Show();
        }

        private void salirDelProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tipouser);
        }

        private void cerrarTodasLasVentanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> lst = new List<Form>();
            try
            {
                for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
                {
                    Form f = Application.OpenForms[i1];
                    if (f.IsMdiChild)
                        lst.Add(f);
                }
            }
            catch (IndexOutOfRangeException)
            {
                //This can change if they close/open a form while code is running. Just throw it away
            }
            while (lst.Count > 0)
            {
                Form f = lst[0];
                f.Close();
                f.Dispose();
                lst.RemoveAt(0);
            }
        }

        private void encuestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncuestaInicio encuestachild = new EncuestaInicio();
            encuestachild.MdiParent = this;
            encuestachild.Show();
        }

        private void expedientesDeSillasDeRuedasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicioExpSillas expsillaschild = new InicioExpSillas();
            expsillaschild.MdiParent = this;
            expsillaschild.Show();
        }

        private void Bienvenida_Activated(object sender, EventArgs e)
        {
            
                        
        }

        private void bitacoraDelComedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicioBitacora iniciobit = new InicioBitacora();
            iniciobit.MdiParent = this;
            iniciobit.Show();
        }

    }
}
