namespace HorasHombre.AppWin.Views.Administracion
{
    partial class frmPersona
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaterno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPaterno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTipo = new SergeUtils.EasyCompletionComboBox();
            this.cboDocumento = new SergeUtils.EasyCompletionComboBox();
            this.cboCentroCosto = new SergeUtils.EasyCompletionComboBox();
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
            this.pnlListadoActivos.Size = new System.Drawing.Size(567, 263);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.cboCentroCosto);
            this.gbDatos.Controls.Add(this.cboDocumento);
            this.gbDatos.Controls.Add(this.cboTipo);
            this.gbDatos.Controls.Add(this.label8);
            this.gbDatos.Controls.Add(this.txtNumero);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.label7);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.txtMaterno);
            this.gbDatos.Controls.Add(this.label5);
            this.gbDatos.Controls.Add(this.txtPaterno);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.txtEmail);
            this.gbDatos.Controls.Add(this.label9);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.txtCodigo);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Size = new System.Drawing.Size(567, 290);
            this.gbDatos.TabIndex = 0;
            // 
            // tcGeneral
            // 
            this.tcGeneral.Controls.Add(this.tpEliminados);
            this.tcGeneral.Size = new System.Drawing.Size(583, 367);
            // 
            // tpListado
            // 
            this.tpListado.Size = new System.Drawing.Size(575, 336);
            // 
            // tpDatos
            // 
            this.tpDatos.Size = new System.Drawing.Size(575, 336);
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
            this.olvListado.Size = new System.Drawing.Size(567, 263);
            // 
            // pnlAgruparActivos
            // 
            this.pnlAgruparActivos.Location = new System.Drawing.Point(3, 304);
            this.pnlAgruparActivos.Size = new System.Drawing.Size(567, 27);
            // 
            // olvListadoInactivos
            // 
            this.olvListadoInactivos.Size = new System.Drawing.Size(420, 251);
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Descripcion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(294, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Numero:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(351, 94);
            this.txtNumero.MaxLength = 20;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(184, 23);
            this.txtNumero.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Documento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo:";
            // 
            // txtMaterno
            // 
            this.txtMaterno.Location = new System.Drawing.Point(351, 70);
            this.txtMaterno.MaxLength = 20;
            this.txtMaterno.Name = "txtMaterno";
            this.txtMaterno.Size = new System.Drawing.Size(184, 23);
            this.txtMaterno.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ap. Materno:";
            // 
            // txtPaterno
            // 
            this.txtPaterno.Location = new System.Drawing.Point(84, 70);
            this.txtPaterno.MaxLength = 20;
            this.txtPaterno.Name = "txtPaterno";
            this.txtPaterno.Size = new System.Drawing.Size(178, 23);
            this.txtPaterno.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ap. Paterno:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(84, 118);
            this.txtEmail.MaxLength = 60;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(451, 23);
            this.txtEmail.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Email:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(84, 46);
            this.txtNombre.MaxLength = 60;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(451, 23);
            this.txtNombre.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombres:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(84, 22);
            this.txtCodigo.MaxLength = 5;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(97, 23);
            this.txtCodigo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Cto. Costo:";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(270, 22);
            this.cboTipo.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards;
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(265, 23);
            this.cboTipo.TabIndex = 4;
            // 
            // cboDocumento
            // 
            this.cboDocumento.FormattingEnabled = true;
            this.cboDocumento.Location = new System.Drawing.Point(84, 94);
            this.cboDocumento.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards;
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Size = new System.Drawing.Size(204, 23);
            this.cboDocumento.TabIndex = 12;
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(84, 142);
            this.cboCentroCosto.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards;
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(264, 23);
            this.cboCentroCosto.TabIndex = 0;
            // 
            // frmPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(583, 389);
            this.Name = "frmPersona";
            this.ShowDeletedItems = true;
            this.Text = "Persona";
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


        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaterno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPaterno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private SergeUtils.EasyCompletionComboBox cboCentroCosto;
        private SergeUtils.EasyCompletionComboBox cboDocumento;
        private SergeUtils.EasyCompletionComboBox cboTipo;
    }
}
