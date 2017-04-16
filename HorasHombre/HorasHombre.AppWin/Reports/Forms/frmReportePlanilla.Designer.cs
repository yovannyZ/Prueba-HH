namespace HorasHombre.AppWin.Reports.Forms
{
    partial class frmReportePlanilla
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
            this.gbTrabajador = new System.Windows.Forms.GroupBox();
            this.txtPersona = new System.Windows.Forms.TextBox();
            this.chkPersona = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbTrabajador = new System.Windows.Forms.RadioButton();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.gbPlanilla = new System.Windows.Forms.GroupBox();
            this.txtNumeroPlanilla = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.rbPlanilla = new System.Windows.Forms.RadioButton();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gbTrabajador.SuspendLayout();
            this.gbPlanilla.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTrabajador
            // 
            this.gbTrabajador.Controls.Add(this.txtPersona);
            this.gbTrabajador.Controls.Add(this.chkPersona);
            this.gbTrabajador.Controls.Add(this.label2);
            this.gbTrabajador.Controls.Add(this.dtpFin);
            this.gbTrabajador.Controls.Add(this.label1);
            this.gbTrabajador.Controls.Add(this.dtpInicio);
            this.gbTrabajador.Location = new System.Drawing.Point(12, 12);
            this.gbTrabajador.Name = "gbTrabajador";
            this.gbTrabajador.Size = new System.Drawing.Size(378, 117);
            this.gbTrabajador.TabIndex = 18;
            this.gbTrabajador.TabStop = false;
            // 
            // txtPersona
            // 
            this.txtPersona.Enabled = false;
            this.txtPersona.Location = new System.Drawing.Point(83, 83);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Size = new System.Drawing.Size(289, 23);
            this.txtPersona.TabIndex = 26;
            // 
            // chkPersona
            // 
            this.chkPersona.AutoSize = true;
            this.chkPersona.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPersona.Location = new System.Drawing.Point(6, 87);
            this.chkPersona.Name = "chkPersona";
            this.chkPersona.Size = new System.Drawing.Size(71, 19);
            this.chkPersona.TabIndex = 21;
            this.chkPersona.Text = "Persona:";
            this.chkPersona.UseVisualStyleBackColor = true;
            this.chkPersona.CheckedChanged += new System.EventHandler(this.ActivarPersona);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Al:";
            // 
            // rbTrabajador
            // 
            this.rbTrabajador.AutoSize = true;
            this.rbTrabajador.Checked = true;
            this.rbTrabajador.Location = new System.Drawing.Point(20, 12);
            this.rbTrabajador.Name = "rbTrabajador";
            this.rbTrabajador.Size = new System.Drawing.Size(100, 19);
            this.rbTrabajador.TabIndex = 20;
            this.rbTrabajador.TabStop = true;
            this.rbTrabajador.Tag = "gbTrabajador";
            this.rbTrabajador.Text = "Por trabajador";
            this.rbTrabajador.UseVisualStyleBackColor = true;
            this.rbTrabajador.CheckedChanged += new System.EventHandler(this.ActivarTipoReporte);
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(39, 54);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(95, 23);
            this.dtpFin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Del:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Checked = false;
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(39, 25);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(95, 23);
            this.dtpInicio.TabIndex = 0;
            // 
            // gbPlanilla
            // 
            this.gbPlanilla.Controls.Add(this.txtNumeroPlanilla);
            this.gbPlanilla.Controls.Add(this.label4);
            this.gbPlanilla.Controls.Add(this.label3);
            this.gbPlanilla.Controls.Add(this.cboArea);
            this.gbPlanilla.Enabled = false;
            this.gbPlanilla.Location = new System.Drawing.Point(12, 135);
            this.gbPlanilla.Name = "gbPlanilla";
            this.gbPlanilla.Size = new System.Drawing.Size(378, 104);
            this.gbPlanilla.TabIndex = 19;
            this.gbPlanilla.TabStop = false;
            // 
            // txtNumeroPlanilla
            // 
            this.txtNumeroPlanilla.Location = new System.Drawing.Point(77, 54);
            this.txtNumeroPlanilla.Name = "txtNumeroPlanilla";
            this.txtNumeroPlanilla.Size = new System.Drawing.Size(102, 23);
            this.txtNumeroPlanilla.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "N° Planilla:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Area:";
            // 
            // cboArea
            // 
            this.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(77, 25);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(271, 23);
            this.cboArea.TabIndex = 22;
            // 
            // rbPlanilla
            // 
            this.rbPlanilla.AutoSize = true;
            this.rbPlanilla.Location = new System.Drawing.Point(20, 135);
            this.rbPlanilla.Name = "rbPlanilla";
            this.rbPlanilla.Size = new System.Drawing.Size(84, 19);
            this.rbPlanilla.TabIndex = 21;
            this.rbPlanilla.Tag = "gbPlanilla";
            this.rbPlanilla.Text = "Por planilla";
            this.rbPlanilla.UseVisualStyleBackColor = true;
            this.rbPlanilla.CheckedChanged += new System.EventHandler(this.ActivarTipoReporte);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(285, 245);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(105, 28);
            this.btnImprimir.TabIndex = 20;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // frmReportePlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 285);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.rbTrabajador);
            this.Controls.Add(this.rbPlanilla);
            this.Controls.Add(this.gbPlanilla);
            this.Controls.Add(this.gbTrabajador);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.Name = "frmReportePlanilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte planilla horas hombre";
            this.gbTrabajador.ResumeLayout(false);
            this.gbTrabajador.PerformLayout();
            this.gbPlanilla.ResumeLayout(false);
            this.gbPlanilla.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTrabajador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.RadioButton rbTrabajador;
        private System.Windows.Forms.GroupBox gbPlanilla;
        private System.Windows.Forms.RadioButton rbPlanilla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.TextBox txtNumeroPlanilla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPersona;
        private System.Windows.Forms.CheckBox chkPersona;
        private System.Windows.Forms.Button btnImprimir;

    }
}