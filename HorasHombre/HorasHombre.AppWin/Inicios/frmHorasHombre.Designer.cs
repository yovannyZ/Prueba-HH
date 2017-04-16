namespace HorasHombre.AppWin.Inicios
{
    partial class frmHorasHombre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHorasHombre));
            this.ssEstado = new System.Windows.Forms.StatusStrip();
            this.tsslUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCompany = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslProceso = new System.Windows.Forms.ToolStripStatusLabel();
            this.msPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuTransaccion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrdenProduccionAsignarActividad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPlanilla = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReporteHorasHombre = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportePlanillaHoras = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.ssEstado.SuspendLayout();
            this.msPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssEstado
            // 
            this.ssEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslUser,
            this.tsslCompany,
            this.toolStripStatusLabel1,
            this.tsslProceso});
            this.ssEstado.Location = new System.Drawing.Point(0, 576);
            this.ssEstado.Name = "ssEstado";
            this.ssEstado.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ssEstado.Size = new System.Drawing.Size(1021, 25);
            this.ssEstado.TabIndex = 3;
            this.ssEstado.Text = "statusStrip1";
            // 
            // tsslUser
            // 
            this.tsslUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsslUser.Name = "tsslUser";
            this.tsslUser.Size = new System.Drawing.Size(20, 20);
            // 
            // tsslCompany
            // 
            this.tsslCompany.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslCompany.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsslCompany.Name = "tsslCompany";
            this.tsslCompany.Size = new System.Drawing.Size(20, 20);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(960, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsslProceso
            // 
            this.tsslProceso.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslProceso.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tsslProceso.Name = "tsslProceso";
            this.tsslProceso.Size = new System.Drawing.Size(4, 20);
            // 
            // msPrincipal
            // 
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTransaccion});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(1021, 24);
            this.msPrincipal.TabIndex = 4;
            this.msPrincipal.Text = "menuStrip1";
            // 
            // mnuTransaccion
            // 
            this.mnuTransaccion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOrdenProduccionAsignarActividad,
            this.toolStripMenuItem1,
            this.mnuPlanilla,
            this.mnuReporteHorasHombre});
            this.mnuTransaccion.Name = "mnuTransaccion";
            this.mnuTransaccion.Size = new System.Drawing.Size(83, 20);
            this.mnuTransaccion.Text = "Transacción";
            this.mnuTransaccion.ToolTipText = "Transacción";
            // 
            // mnuOrdenProduccionAsignarActividad
            // 
            //this.mnuOrdenProduccionAsignarActividad.Image = 
            this.mnuOrdenProduccionAsignarActividad.Name = "mnuOrdenProduccionAsignarActividad";
            this.mnuOrdenProduccionAsignarActividad.Size = new System.Drawing.Size(156, 22);
            this.mnuOrdenProduccionAsignarActividad.Tag = "frmOrdenProduccionActividad";
            this.mnuOrdenProduccionAsignarActividad.Text = "O/P - Actividad";
            this.mnuOrdenProduccionAsignarActividad.ToolTipText = "Mantenimiento de relación O/P - Actividad";
            this.mnuOrdenProduccionAsignarActividad.Click += new System.EventHandler(this.AbrirOrdenProduccionActividad);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // mnuPlanilla
            // 
            this.mnuPlanilla.Image = global::HorasHombre.AppWin.Properties.Resources.Task;
            this.mnuPlanilla.Name = "mnuPlanilla";
            this.mnuPlanilla.Size = new System.Drawing.Size(156, 22);
            this.mnuPlanilla.Tag = "frmPlanilla";
            this.mnuPlanilla.Text = "Planilla";
            this.mnuPlanilla.ToolTipText = "Mantenimiento de planilla de horas hombre";
            this.mnuPlanilla.Click += new System.EventHandler(this.AbrirPlanilla);
            // 
            // mnuReporteHorasHombre
            // 
            this.mnuReporteHorasHombre.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportePlanillaHoras});
            this.mnuReporteHorasHombre.Name = "mnuReporteHorasHombre";
            this.mnuReporteHorasHombre.Size = new System.Drawing.Size(156, 22);
            this.mnuReporteHorasHombre.Text = "Reportes";
            this.mnuReporteHorasHombre.ToolTipText = "Reportes";
            // 
            // mnuReportePlanillaHoras
            // 
            this.mnuReportePlanillaHoras.Image = ((System.Drawing.Image)(resources.GetObject("mnuReportePlanillaHoras.Image")));
            this.mnuReportePlanillaHoras.Name = "mnuReportePlanillaHoras";
            this.mnuReportePlanillaHoras.Size = new System.Drawing.Size(112, 22);
            this.mnuReportePlanillaHoras.Tag = "frmReportePlanilla";
            this.mnuReportePlanillaHoras.Text = "Planilla";
            this.mnuReportePlanillaHoras.ToolTipText = "Reporte planillas hora hombre";
            this.mnuReportePlanillaHoras.Click += new System.EventHandler(this.AbrirReportePlanilla);
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.Location = new System.Drawing.Point(0, 24);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPrincipal.Size = new System.Drawing.Size(1021, 25);
            this.tsPrincipal.TabIndex = 6;
            this.tsPrincipal.Text = "toolStrip1";
            // 
            // frmHorasHombre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HorasHombre.AppWin.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1021, 601);
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.ssEstado);
            this.Controls.Add(this.msPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msPrincipal;
            this.Name = "frmHorasHombre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Horas hombre";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ssEstado.ResumeLayout(false);
            this.ssEstado.PerformLayout();
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssEstado;
        private System.Windows.Forms.ToolStripStatusLabel tsslUser;
        private System.Windows.Forms.ToolStripStatusLabel tsslCompany;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslProceso;
        private System.Windows.Forms.MenuStrip msPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuTransaccion;
        private System.Windows.Forms.ToolStripMenuItem mnuOrdenProduccionAsignarActividad;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuPlanilla;
        private System.Windows.Forms.ToolStripMenuItem mnuReporteHorasHombre;
        private System.Windows.Forms.ToolStripMenuItem mnuReportePlanillaHoras;
        private System.Windows.Forms.ToolStrip tsPrincipal;
    }
}