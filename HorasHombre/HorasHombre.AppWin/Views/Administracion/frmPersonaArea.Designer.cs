namespace HorasHombre.AppWin.Views.Administracion
{
    partial class frmPersonaArea
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
            this.dgvAsignacion = new System.Windows.Forms.DataGridView();
            this.dgvtxtCentroCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlListadoActivos
            // 
            this.pnlListadoActivos.Size = new System.Drawing.Size(474, 263);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.cboArea);
            this.gbDatos.Controls.Add(this.btnAgregar);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.dgvAsignacion);
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
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsignacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAsignacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAsignacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAsignacion.Location = new System.Drawing.Point(3, 52);
            this.dgvAsignacion.MultiSelect = false;
            this.dgvAsignacion.Name = "dgvAsignacion";
            this.dgvAsignacion.RowHeadersVisible = false;
            this.dgvAsignacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignacion.Size = new System.Drawing.Size(468, 235);
            this.dgvAsignacion.TabIndex = 3;
            this.dgvAsignacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.QuitarFila);
            this.dgvAsignacion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.FinalizarModificacionDataGridView);
            this.dgvAsignacion.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.LiberarMouseEnGridView);
            this.dgvAsignacion.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MoverMouseEnGridView);
            this.dgvAsignacion.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDistribucion_EditingControlShowing);
            // 
            // dgvtxtCentroCosto
            // 
            this.dgvtxtCentroCosto.HeaderText = "Persona";
            this.dgvtxtCentroCosto.Name = "dgvtxtCentroCosto";
            this.dgvtxtCentroCosto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvtxtCentroCosto.Width = 380;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Area:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Image = global::HorasHombre.AppWin.Properties.Resources.Delete;
            this.btnAgregar.Location = new System.Drawing.Point(363, 21);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(105, 28);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.AgregarPersona);
            // 
            // cboArea
            // 
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(46, 26);
            this.cboArea.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards;
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(311, 23);
            this.cboArea.TabIndex = 1;
            // 
            // frmPersonaArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(490, 389);
            this.Name = "frmPersonaArea";
            this.ShowDeletedItems = true;
            this.Text = "Asignación de areas";
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
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtCentroCosto;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private SergeUtils.EasyCompletionComboBox cboArea;
    }
}
