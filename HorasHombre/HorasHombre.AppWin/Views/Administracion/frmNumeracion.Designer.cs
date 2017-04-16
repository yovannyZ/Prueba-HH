namespace HorasHombre.AppWin.Views.Administracion
{
    partial class frmNumeracion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cboArea = new SergeUtils.EasyCompletionComboBox();
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
            this.gbDatos.Controls.Add(this.cboArea);
            this.gbDatos.Controls.Add(this.txtNumero);
            this.gbDatos.Controls.Add(this.label2);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Area:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Correlativo";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(75, 46);
            this.txtNumero.MaxLength = 7;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(186, 23);
            this.txtNumero.TabIndex = 3;
            // 
            // cboArea
            // 
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(75, 22);
            this.cboArea.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards;
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(269, 23);
            this.cboArea.TabIndex = 1;
            // 
            // frmNumeracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(490, 389);
            this.Name = "frmNumeracion";
            this.ShowDeletedItems = true;
            this.Text = "Numeración";
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private SergeUtils.EasyCompletionComboBox cboArea;
    }
}
