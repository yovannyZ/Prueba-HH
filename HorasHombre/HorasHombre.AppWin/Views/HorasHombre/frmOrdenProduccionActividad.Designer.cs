namespace HorasHombre.AppWin.Views.HorasHombre
{
    partial class frmOrdenProduccionActividad
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAsignacion = new System.Windows.Forms.DataGridView();
            this.dgvtxtCentroCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cboOrdenProduccion = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlListadoActivos
            // 
            this.pnlListadoActivos.Size = new System.Drawing.Size(553, 224);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.btnAgregar);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.dgvAsignacion);
            this.gbDatos.Controls.Add(this.cboOrdenProduccion);
            this.gbDatos.Size = new System.Drawing.Size(553, 243);
            // 
            // tcGeneral
            // 
            this.tcGeneral.Controls.Add(this.tpEliminados);
            this.tcGeneral.Size = new System.Drawing.Size(563, 315);
            // 
            // tpListado
            // 
            this.tpListado.Size = new System.Drawing.Size(555, 285);
            // 
            // tpDatos
            // 
            this.tpDatos.Size = new System.Drawing.Size(555, 285);
            // 
            // tpEliminados
            // 
            this.tpEliminados.Size = new System.Drawing.Size(555, 285);
            // 
            // pnlListadoEliminados
            // 
            this.pnlListadoEliminados.Size = new System.Drawing.Size(553, 247);
            // 
            // olvListado
            // 
            this.olvListado.Size = new System.Drawing.Size(553, 224);
            // 
            // pnlAgruparActivos
            // 
            this.pnlAgruparActivos.Location = new System.Drawing.Point(0, 260);
            this.pnlAgruparActivos.Size = new System.Drawing.Size(553, 23);
            // 
            // olvListadoInactivos
            // 
            this.olvListadoInactivos.Size = new System.Drawing.Size(553, 247);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "NumeroOrden";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Articulo";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NumeroOrden";
            this.Column1.HeaderText = "O. Prod.";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Articulo";
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            this.Column2.Width = 380;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ord. Producción:";
            // 
            // dgvAsignacion
            // 
            this.dgvAsignacion.AllowUserToAddRows = false;
            this.dgvAsignacion.AllowUserToDeleteRows = false;
            this.dgvAsignacion.AllowUserToOrderColumns = true;
            this.dgvAsignacion.AllowUserToResizeColumns = false;
            this.dgvAsignacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvAsignacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsignacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtCentroCosto,
            this.Column5,
            this.Column6,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsignacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAsignacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAsignacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAsignacion.Location = new System.Drawing.Point(3, 66);
            this.dgvAsignacion.MultiSelect = false;
            this.dgvAsignacion.Name = "dgvAsignacion";
            this.dgvAsignacion.RowHeadersVisible = false;
            this.dgvAsignacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignacion.Size = new System.Drawing.Size(547, 174);
            this.dgvAsignacion.TabIndex = 10;
            this.dgvAsignacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.QuitarFila);
            this.dgvAsignacion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.FinalizarModificacionDataGridView);
            this.dgvAsignacion.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.LiberarMouseEnGridView);
            this.dgvAsignacion.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MoverMouseEnGridView);
            this.dgvAsignacion.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAsignacion_EditingControlShowing);
            // 
            // dgvtxtCentroCosto
            // 
            this.dgvtxtCentroCosto.HeaderText = "Actividad N3";
            this.dgvtxtCentroCosto.Name = "dgvtxtCentroCosto";
            this.dgvtxtCentroCosto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvtxtCentroCosto.Width = 220;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Actividad N2";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 180;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Actividad N1";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 180;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.Width = 20;
            // 
            // cboOrdenProduccion
            // 
            this.cboOrdenProduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenProduccion.FormattingEnabled = true;
            this.cboOrdenProduccion.Location = new System.Drawing.Point(93, 19);
            this.cboOrdenProduccion.Name = "cboOrdenProduccion";
            this.cboOrdenProduccion.Size = new System.Drawing.Size(262, 21);
            this.cboOrdenProduccion.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Image = global::HorasHombre.AppWin.Properties.Resources.Delete;
            this.btnAgregar.Location = new System.Drawing.Point(433, 22);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 24);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar item";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.AgregarActividad);
            // 
            // frmOrdenProduccionActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(563, 337);
            this.Name = "frmOrdenProduccionActividad";
            this.ShowDeletedItems = true;
            this.Text = "Orden Produccón - Actividad";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAsignacion;
        private System.Windows.Forms.ComboBox cboOrdenProduccion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtCentroCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
