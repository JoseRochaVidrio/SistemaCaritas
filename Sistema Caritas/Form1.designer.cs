namespace Caritas
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaDonacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarDonacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarDonacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarDonacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(664, 274);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.donacionesToolStripMenuItem,
            this.consultaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(664, 38);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.inicioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inicioToolStripMenuItem.Image")));
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(91, 34);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem.Image")));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(125, 34);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // donacionesToolStripMenuItem
            // 
            this.donacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaDonacionToolStripMenuItem,
            this.modificarDonacionToolStripMenuItem,
            this.borrarDonacionToolStripMenuItem});
            this.donacionesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("donacionesToolStripMenuItem.Image")));
            this.donacionesToolStripMenuItem.Name = "donacionesToolStripMenuItem";
            this.donacionesToolStripMenuItem.Size = new System.Drawing.Size(150, 34);
            this.donacionesToolStripMenuItem.Text = "Donaciones";
            // 
            // nuevaDonacionToolStripMenuItem
            // 
            this.nuevaDonacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevaDonacionToolStripMenuItem.Image")));
            this.nuevaDonacionToolStripMenuItem.Name = "nuevaDonacionToolStripMenuItem";
            this.nuevaDonacionToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.nuevaDonacionToolStripMenuItem.Text = "Nueva Donacion";
            this.nuevaDonacionToolStripMenuItem.Click += new System.EventHandler(this.nuevaDonacionToolStripMenuItem_Click);
            // 
            // modificarDonacionToolStripMenuItem
            // 
            this.modificarDonacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarDonacionToolStripMenuItem.Image")));
            this.modificarDonacionToolStripMenuItem.Name = "modificarDonacionToolStripMenuItem";
            this.modificarDonacionToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.modificarDonacionToolStripMenuItem.Text = "Modificar Donacion";
            this.modificarDonacionToolStripMenuItem.Click += new System.EventHandler(this.modificarDonacionToolStripMenuItem_Click);
            // 
            // borrarDonacionToolStripMenuItem
            // 
            this.borrarDonacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("borrarDonacionToolStripMenuItem.Image")));
            this.borrarDonacionToolStripMenuItem.Name = "borrarDonacionToolStripMenuItem";
            this.borrarDonacionToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.borrarDonacionToolStripMenuItem.Text = "Borrar Donacion";
            this.borrarDonacionToolStripMenuItem.Click += new System.EventHandler(this.borrarDonacionToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarDonacionesToolStripMenuItem});
            this.consultaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultaToolStripMenuItem.Image")));
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(122, 34);
            this.consultaToolStripMenuItem.Text = "Consulta";
            // 
            // consultarDonacionesToolStripMenuItem
            // 
            this.consultarDonacionesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarDonacionesToolStripMenuItem.Image")));
            this.consultarDonacionesToolStripMenuItem.Name = "consultarDonacionesToolStripMenuItem";
            this.consultarDonacionesToolStripMenuItem.Size = new System.Drawing.Size(289, 34);
            this.consultarDonacionesToolStripMenuItem.Text = "Consultar Donaciones";
            this.consultarDonacionesToolStripMenuItem.Click += new System.EventHandler(this.consultarDonacionesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 316);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caritas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaDonacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarDonacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarDonacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarDonacionesToolStripMenuItem;

    }
}

