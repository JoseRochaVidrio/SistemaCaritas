using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaritasVentas
{
    public partial class Cambio : Form
    {
        public Cambio(string datoscambio, string titulo)
        {
            InitializeComponent();

            this.Text = titulo;
            label1.Text = datoscambio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cambio_Load(object sender, EventArgs e)
        {

        }
    }
}
