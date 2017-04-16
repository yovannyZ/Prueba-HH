namespace HorasHombre.AppWin.Views.Administracion
{
    partial class frmNovedad
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDescripcionCorta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCosto = new System.Windows.Forms.CheckBox();
            this.cboTipo = new SergeUtils.EasyCompletionComboBox();
            this.pnlListadoActivos.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.tcGeneral.SuspendLayout();
            this.tpListado.SuspendLayout();
            this.tpDatos.SuspendLayout();
            this.tpEliminados.SuspendLayout();
            this.pnlListadoEliminados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvListado)).BeginInit();
            this.pnlAgruparActivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvListadoInactivos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlListadoActivos
            // 
            this.pnlListadoActivos.Size = new System.Drawing.Size(474, 263);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.cboTipo);
            this.gbDatos.Controls.Add(this.chkCosto);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.txtDescripcionCorta);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.txtCodigo);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Size = new System.Drawing.Size(474, 290);
            this.gbDatos.TabIndex = 0;
            // 
            // tcGeneral
            // 
            this.tcGeneral.Controls.Add(this.tpEliminados);
            this.tcGeneral.Size = new System.Drawing.Size(490, 367);
            // 
            // tpListado
            // 
            this.tpListado.Size = new System.Drawing.Size(482, 336);
            // 
            // tpDatos
            // 
            this.tpDatos.Size = new System.Drawing.Size(482, 336);
            // 
            // tpEliminados
            // 
            this.tpEliminados.Size = new System.Drawing.Size(428, 297);
            // 
            // pnlListadoEliminados
            // 
            this.pnlListadoEliminados.Size = new System.Drawing.Size(420, 251);
            // 
            // olvListado
            // 
            this.olvListado.Size = new System.Drawing.Size(474, 263);
            // 
            // pnlAgruparActivos
            // 
            this.pnlAgruparActivos.Location = new System.Drawing.Point(3, 304);
            this.pnlAgruparActivos.Size = new System.Drawing.Size(474, 27);
            // 
            // olvListadoInactivos
            // 
            this.olvListadoInactivos.Size = new System.Drawing.Size(420, 251);
            // 
            // txtDescripcionCorta
            // 
            this.txtDescripcionCorta.Location = new System.Drawing.Point(86, 70);
            this.txtDescripcionCorta.MaxLength = 20;
            this.txtDescripcionCorta.Name = "txtDescripcionCorta";
            this.txtDescripcionCorta.Size = new System.Drawing.Size(179, 23);
            this.txtDescripcionCorta.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desc. Corta:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(86, 46);
            this.txtNombre.MaxLength = 40;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(267, 23);
            this.txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(86, 22);
            this.txtCodigo.MaxLength = 2;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 23);
            this.txtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Distribución:";
            // 
            // chkCosto
            // 
            this.chkCosto.AutoSize = true;
            this.chkCosto.Location = new System.Drawing.Point(86, 120);
            this.chkCosto.Name = "chkCosto";
            this.chkCosto.Size = new System.Drawing.Size(113, 19);
            this.chkCosto.TabIndex = 8;
            this.chkCosto.Text = "¿Aplica al costo?";
            this.chkCosto.UseVisualStyleBackColor = true;
            this.chkCosto.Visible = false;
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(86, 94);
            this.cboTipo.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards;
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(179, 23);
            this.cboTipo.TabIndex = 7;
            // 
            // frmNovedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(490, 389);
            this.Name = "frmNovedad";
            this.ShowDeletedItems = true;
            this.Text = "Novedad";
            this.pnlListadoActivos.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.tcGeneral.ResumeLayout(false);
            this.tpListado.ResumeLayout(false);
            this.tpListado.PerformLayout();
            this.tpDatos.ResumeLayout(false);
            this.tpDatos.PerformLayout();
            this.tpEliminados.ResumeLayout(false);
            this.tpEliminados.PerformLayout();
            this.pnlListadoEliminados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvListado)).EndInit();
            this.pnlAgruparActivos.ResumeLayout(false);
            this.pnlAgruparActivos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvListadoInactivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcionCorta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCosto;
        private SergeUtils.EasyCompletionComboBox cboTipo;
    }
}
