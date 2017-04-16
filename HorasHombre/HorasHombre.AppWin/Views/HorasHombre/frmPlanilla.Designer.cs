namespace HorasHombre.AppWin.Views.HorasHombre
{
    partial class frmPlanilla
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvAsignacion = new System.Windows.Forms.DataGridView();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvtxtPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new UserControls.TimeColumn();
            this.Column6 = new UserControls.TimeColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroPlanilla = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.tcGeneral.SuspendLayout();
            this.tpListado.SuspendLayout();
            this.tpDatos.SuspendLayout();
            this.tpEliminados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.btnImprimir);
            this.gbDatos.Controls.Add(this.txtNumeroPlanilla);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.btnAgregar);
            this.gbDatos.Controls.Add(this.dgvAsignacion);
            this.gbDatos.Controls.Add(this.cboArea);
            this.gbDatos.Controls.Add(this.cboSucursal);
            this.gbDatos.Location = new System.Drawing.Point(3, 53);
            this.gbDatos.Size = new System.Drawing.Size(836, 423);
            // 
            // tcGeneral
            // 
            this.tcGeneral.Controls.Add(this.tpEliminados);
            this.tcGeneral.Size = new System.Drawing.Size(852, 512);
            // 
            // tpListado
            // 
            this.tpListado.Size = new System.Drawing.Size(844, 481);
            // 
            // tpDatos
            // 
            this.tpDatos.Size = new System.Drawing.Size(844, 481);
            // 
            // tpEliminados
            // 
            this.tpEliminados.Size = new System.Drawing.Size(844, 481);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sucursal:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(725, 51);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(105, 28);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar item";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.AgregarPersona);
            // 
            // dgvAsignacion
            // 
            this.dgvAsignacion.AllowUserToAddRows = false;
            this.dgvAsignacion.AllowUserToDeleteRows = false;
            this.dgvAsignacion.AllowUserToOrderColumns = true;
            this.dgvAsignacion.AllowUserToResizeColumns = false;
            this.dgvAsignacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvAsignacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAsignacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column14,
            this.Column4,
            this.dgvtxtPersona,
            this.Column10,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column13});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsignacion.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAsignacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAsignacion.Location = new System.Drawing.Point(9, 80);
            this.dgvAsignacion.MultiSelect = false;
            this.dgvAsignacion.Name = "dgvAsignacion";
            this.dgvAsignacion.RowHeadersVisible = false;
            this.dgvAsignacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignacion.Size = new System.Drawing.Size(821, 309);
            this.dgvAsignacion.TabIndex = 10;
            this.dgvAsignacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ModificarFila);
            this.dgvAsignacion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.FinalizarEdicionCeldaEnGrid);
            this.dgvAsignacion.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.LiberarMouseEnGridView);
            this.dgvAsignacion.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MoverMouseEnGridView);
            this.dgvAsignacion.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.MostrarControlDeEdicion);
            // 
            // Column14
            // 
            this.Column14.Frozen = true;
            this.Column14.HeaderText = "Id";
            this.Column14.Name = "Column14";
            this.Column14.Visible = false;
            this.Column14.Width = 20;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "";
            this.Column4.Image = global::HorasHombre.AppWin.Properties.Resources.Delete;
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.ToolTipText = "Quitar registro";
            this.Column4.Width = 20;
            // 
            // dgvtxtPersona
            // 
            this.dgvtxtPersona.Frozen = true;
            this.dgvtxtPersona.HeaderText = "Persona";
            this.dgvtxtPersona.Name = "dgvtxtPersona";
            this.dgvtxtPersona.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvtxtPersona.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvtxtPersona.Width = 240;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Novedad";
            this.Column10.Name = "Column10";
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 180;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Inicio";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.Width = 65;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Fin";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.Width = 65;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "O/P.";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 65;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Actividad";
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 180;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Centro costo";
            this.Column9.Name = "Column9";
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 180;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "";
            this.Column13.Image = global::HorasHombre.AppWin.Properties.Resources.Delete;
            this.Column13.Name = "Column13";
            this.Column13.ToolTipText = "Editar registro";
            this.Column13.Width = 20;
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(66, 22);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(268, 23);
            this.cboSucursal.TabIndex = 9;
            // 
            // cboArea
            // 
            this.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(66, 51);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(268, 23);
            this.cboArea.TabIndex = 9;
            this.cboArea.SelectedIndexChanged += new System.EventHandler(this.SeleccionarArea);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Area:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fecha Planilla:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(506, 24);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(99, 23);
            this.dtpFecha.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nro. Planilla:";
            // 
            // txtNumeroPlanilla
            // 
            this.txtNumeroPlanilla.Location = new System.Drawing.Point(506, 51);
            this.txtNumeroPlanilla.Name = "txtNumeroPlanilla";
            this.txtNumeroPlanilla.Size = new System.Drawing.Size(99, 23);
            this.txtNumeroPlanilla.TabIndex = 15;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(725, 395);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(105, 28);
            this.btnImprimir.TabIndex = 16;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // frmPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(877, 549);
            this.Name = "frmPlanilla";
            this.ShowDeletedItems = true;
            this.Text = "Planilla de horas";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.tcGeneral.ResumeLayout(false);
            this.tpListado.ResumeLayout(false);
            this.tpDatos.ResumeLayout(false);
            this.tpEliminados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvAsignacion;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private UserControls.TimeColumn Column5;
        private UserControls.TimeColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewImageColumn Column13;
        private System.Windows.Forms.Button btnImprimir;
    }
}
