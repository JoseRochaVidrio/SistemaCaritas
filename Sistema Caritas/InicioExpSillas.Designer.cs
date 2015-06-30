namespace Sistema_Caritas
{
    partial class InicioExpSillas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioExpSillas));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.expedientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoExpedienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarExpedienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarExpedienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expedienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.AllowMerge = false;
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem,
            this.expedientesToolStripMenuItem,
            this.consultaToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(664, 38);
            this.menuStrip2.TabIndex = 13;
            this.menuStrip2.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem1});
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem.Image")));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(91, 34);
            this.salirToolStripMenuItem.Text = "Inicio";
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem1.Image")));
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(125, 34);
            this.salirToolStripMenuItem1.Text = "Salir";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // expedientesToolStripMenuItem
            // 
            this.expedientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoExpedienteToolStripMenuItem,
            this.modificarExpedienteToolStripMenuItem,
            this.eliminarExpedienteToolStripMenuItem});
            this.expedientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("expedientesToolStripMenuItem.Image")));
            this.expedientesToolStripMenuItem.Name = "expedientesToolStripMenuItem";
            this.expedientesToolStripMenuItem.Size = new System.Drawing.Size(152, 34);
            this.expedientesToolStripMenuItem.Text = "Expedientes";
            // 
            // nuevoExpedienteToolStripMenuItem
            // 
            this.nuevoExpedienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoExpedienteToolStripMenuItem.Image")));
            this.nuevoExpedienteToolStripMenuItem.Name = "nuevoExpedienteToolStripMenuItem";
            this.nuevoExpedienteToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.nuevoExpedienteToolStripMenuItem.Text = "Nuevo Expediente";
            this.nuevoExpedienteToolStripMenuItem.Click += new System.EventHandler(this.nuevoExpedienteToolStripMenuItem_Click);
            // 
            // modificarExpedienteToolStripMenuItem
            // 
            this.modificarExpedienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarExpedienteToolStripMenuItem.Image")));
            this.modificarExpedienteToolStripMenuItem.Name = "modificarExpedienteToolStripMenuItem";
            this.modificarExpedienteToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.modificarExpedienteToolStripMenuItem.Text = "Modificar Expediente";
            this.modificarExpedienteToolStripMenuItem.Click += new System.EventHandler(this.modificarExpedienteToolStripMenuItem_Click);
            // 
            // eliminarExpedienteToolStripMenuItem
            // 
            this.eliminarExpedienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarExpedienteToolStripMenuItem.Image")));
            this.eliminarExpedienteToolStripMenuItem.Name = "eliminarExpedienteToolStripMenuItem";
            this.eliminarExpedienteToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.eliminarExpedienteToolStripMenuItem.Text = "Eliminar Expediente";
            this.eliminarExpedienteToolStripMenuItem.Click += new System.EventHandler(this.eliminarExpedienteToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expedienteToolStripMenuItem});
            this.consultaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultaToolStripMenuItem.Image")));
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(122, 34);
            this.consultaToolStripMenuItem.Text = "Consulta";
            // 
            // expedienteToolStripMenuItem
            // 
            this.expedienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("expedienteToolStripMenuItem.Image")));
            this.expedienteToolStripMenuItem.Name = "expedienteToolStripMenuItem";
            this.expedienteToolStripMenuItem.Size = new System.Drawing.Size(291, 34);
            this.expedienteToolStripMenuItem.Text = "Consultar Expedientes";
            this.expedienteToolStripMenuItem.Click += new System.EventHandler(this.expedienteToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(664, 274);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // InicioExpSillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 316);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InicioExpSillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expedientes Sillas de Ruedas";
            this.Load += new System.EventHandler(this.InicioExpSillas_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem expedientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoExpedienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarExpedienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarExpedienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expedienteToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}