namespace SarazaFlix.UI2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.cmbContenidos = new System.Windows.Forms.ComboBox();
            this.numVelocidad = new System.Windows.Forms.NumericUpDown();
            this.chkAhorroDatos = new System.Windows.Forms.CheckBox();
            this.btnReproducir = new System.Windows.Forms.Button();
            this.btnExportarUsuarios = new System.Windows.Forms.Button();
            this.btnExportarContenidos = new System.Windows.Forms.Button();
            this.lstConsola = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numVelocidad)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(205, 21);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(192, 21);
            this.cmbUsuarios.TabIndex = 0;
            // 
            // cmbContenidos
            // 
            this.cmbContenidos.FormattingEnabled = true;
            this.cmbContenidos.Location = new System.Drawing.Point(205, 76);
            this.cmbContenidos.Name = "cmbContenidos";
            this.cmbContenidos.Size = new System.Drawing.Size(192, 21);
            this.cmbContenidos.TabIndex = 1;
            // 
            // numVelocidad
            // 
            this.numVelocidad.Location = new System.Drawing.Point(205, 120);
            this.numVelocidad.Name = "numVelocidad";
            this.numVelocidad.Size = new System.Drawing.Size(192, 20);
            this.numVelocidad.TabIndex = 2;
            this.numVelocidad.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // chkAhorroDatos
            // 
            this.chkAhorroDatos.AutoSize = true;
            this.chkAhorroDatos.Location = new System.Drawing.Point(252, 165);
            this.chkAhorroDatos.Name = "chkAhorroDatos";
            this.chkAhorroDatos.Size = new System.Drawing.Size(135, 17);
            this.chkAhorroDatos.TabIndex = 3;
            this.chkAhorroDatos.Text = "Forzar Ahorro de Datos";
            this.chkAhorroDatos.UseVisualStyleBackColor = true;
            // 
            // btnReproducir
            // 
            this.btnReproducir.Location = new System.Drawing.Point(481, 21);
            this.btnReproducir.Name = "btnReproducir";
            this.btnReproducir.Size = new System.Drawing.Size(75, 23);
            this.btnReproducir.TabIndex = 4;
            this.btnReproducir.Text = "Reproducir";
            this.btnReproducir.UseVisualStyleBackColor = true;
            this.btnReproducir.Click += new System.EventHandler(this.btnReproducir_Click);
            // 
            // btnExportarUsuarios
            // 
            this.btnExportarUsuarios.Location = new System.Drawing.Point(455, 76);
            this.btnExportarUsuarios.Name = "btnExportarUsuarios";
            this.btnExportarUsuarios.Size = new System.Drawing.Size(127, 23);
            this.btnExportarUsuarios.TabIndex = 5;
            this.btnExportarUsuarios.Text = "Exportar Usuario";
            this.btnExportarUsuarios.UseVisualStyleBackColor = true;
            this.btnExportarUsuarios.Click += new System.EventHandler(this.btnExportarUsuarios_Click);
            // 
            // btnExportarContenidos
            // 
            this.btnExportarContenidos.Location = new System.Drawing.Point(481, 133);
            this.btnExportarContenidos.Name = "btnExportarContenidos";
            this.btnExportarContenidos.Size = new System.Drawing.Size(75, 23);
            this.btnExportarContenidos.TabIndex = 6;
            this.btnExportarContenidos.Text = "Exportar Contenidos";
            this.btnExportarContenidos.UseVisualStyleBackColor = true;
            this.btnExportarContenidos.Click += new System.EventHandler(this.btnExportarContenidos_Click);
            // 
            // lstConsola
            // 
            this.lstConsola.FormattingEnabled = true;
            this.lstConsola.Location = new System.Drawing.Point(86, 204);
            this.lstConsola.Name = "lstConsola";
            this.lstConsola.Size = new System.Drawing.Size(665, 186);
            this.lstConsola.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstConsola);
            this.Controls.Add(this.btnExportarContenidos);
            this.Controls.Add(this.btnExportarUsuarios);
            this.Controls.Add(this.btnReproducir);
            this.Controls.Add(this.chkAhorroDatos);
            this.Controls.Add(this.numVelocidad);
            this.Controls.Add(this.cmbContenidos);
            this.Controls.Add(this.cmbUsuarios);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numVelocidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.ComboBox cmbContenidos;
        private System.Windows.Forms.NumericUpDown numVelocidad;
        private System.Windows.Forms.CheckBox chkAhorroDatos;
        private System.Windows.Forms.Button btnReproducir;
        private System.Windows.Forms.Button btnExportarUsuarios;
        private System.Windows.Forms.Button btnExportarContenidos;
        private System.Windows.Forms.ListBox lstConsola;
    }
}

