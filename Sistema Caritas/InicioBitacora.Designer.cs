namespace Sistema_Caritas
{
    partial class InicioBitacora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioBitacora));
            this.modificarBitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.eliminarBitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaBitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarBitacorasDelComedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradasSalidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // modificarBitacoraToolStripMenuItem
            // 
            this.modificarBitacoraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarBitacoraToolStripMenuItem.Image")));
            this.modificarBitacoraToolStripMenuItem.Name = "modificarBitacoraToolStripMenuItem";
            this.modificarBitacoraToolStripMenuItem.Size = new System.Drawing.Size(314, 34);
            this.modificarBitacoraToolStripMenuItem.Text = "Modificar Entrada/Salida";
            this.modificarBitacoraToolStripMenuItem.Click += new System.EventHandler(this.modificarBitacoraToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(664, 274);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // eliminarBitacoraToolStripMenuItem
            // 
            this.eliminarBitacoraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarBitacoraToolStripMenuItem.Image")));
            this.eliminarBitacoraToolStripMenuItem.Name = "eliminarBitacoraToolStripMenuItem";
            this.eliminarBitacoraToolStripMenuItem.Size = new System.Drawing.Size(314, 34);
            this.eliminarBitacoraToolStripMenuItem.Text = "Eliminar Entrada/Salida";
            this.eliminarBitacoraToolStripMenuItem.Click += new System.EventHandler(this.eliminarBitacoraToolStripMenuItem_Click);
            // 
            // nuevaBitacoraToolStripMenuItem
            // 
            this.nuevaBitacoraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevaBitacoraToolStripMenuItem.Image")));
            this.nuevaBitacoraToolStripMenuItem.Name = "nuevaBitacoraToolStripMenuItem";
            this.nuevaBitacoraToolStripMenuItem.Size = new System.Drawing.Size(314, 34);
            this.nuevaBitacoraToolStripMenuItem.Text = "Nueva Entrada/Salida";
            this.nuevaBitacoraToolStripMenuItem.Click += new System.EventHandler(this.nuevaBitacoraToolStripMenuItem_Click);
            // 
            // consultarBitacorasDelComedorToolStripMenuItem
            // 
            this.consultarBitacorasDelComedorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entradasSalidasToolStripMenuItem});
            this.consultarBitacorasDelComedorToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultarBitacorasDelComedorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarBitacorasDelComedorToolStripMenuItem.Image")));
            this.consultarBitacorasDelComedorToolStripMenuItem.Name = "consultarBitacorasDelComedorToolStripMenuItem";
            this.consultarBitacorasDelComedorToolStripMenuItem.Size = new System.Drawing.Size(210, 34);
            this.consultarBitacorasDelComedorToolStripMenuItem.Text = "Consultar Bitacora";
            // 
            // entradasSalidasToolStripMenuItem
            // 
            this.entradasSalidasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("entradasSalidasToolStripMenuItem.Image")));
            this.entradasSalidasToolStripMenuItem.Name = "entradasSalidasToolStripMenuItem";
            this.entradasSalidasToolStripMenuItem.Size = new System.Drawing.Size(332, 34);
            this.entradasSalidasToolStripMenuItem.Text = "Consultar Entradas/Salidas";
            this.entradasSalidasToolStripMenuItem.Click += new System.EventHandler(this.entradasSalidasToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AllowMerge = false;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem,
            this.bitacoraToolStripMenuItem,
            this.consultarBitacorasDelComedorToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(664, 38);
            this.menuStrip2.TabIndex = 15;
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
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaBitacoraToolStripMenuItem,
            this.modificarBitacoraToolStripMenuItem,
            this.eliminarBitacoraToolStripMenuItem});
            this.bitacoraToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bitacoraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bitacoraToolStripMenuItem.Image")));
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(116, 34);
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            // 
            // InicioBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 316);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InicioBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitacora del Comedor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem modificarBitacoraToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem eliminarBitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaBitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarBitacorasDelComedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradasSalidasToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;

    }
}