namespace HorasHombre.AppWin.Views.Administracion
{
    partial class frmImportarDatos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ssEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.btnImportar = new System.Windows.Forms.Button();
            this.tcAccesos = new System.Windows.Forms.TabControl();
            this.tpActividad = new System.Windows.Forms.TabPage();
            this.dgvActividad = new System.Windows.Forms.DataGridView();
            this.tpCentroCosto = new System.Windows.Forms.TabPage();
            this.dgvCentroCosto = new System.Windows.Forms.DataGridView();
            this.tpConcepto = new System.Windows.Forms.TabPage();
            this.dgvConceptoRemuneracion = new System.Windows.Forms.DataGridView();
            this.tpPersona = new System.Windows.Forms.TabPage();
            this.dgvPersona = new System.Windows.Forms.DataGridView();
            this.tpSucursal = new System.Windows.Forms.TabPage();
            this.dgvSucursal = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRemuneracion = new System.Windows.Forms.TabPage();
            this.tpUtilidades = new System.Windows.Forms.TabPage();
            this.dgvConceptoUtilidades = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssEstado.SuspendLayout();
            this.tcAccesos.SuspendLayout();
            this.tpActividad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividad)).BeginInit();
            this.tpCentroCosto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroCosto)).BeginInit();
            this.tpConcepto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptoRemuneracion)).BeginInit();
            this.tpPersona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersona)).BeginInit();
            this.tpSucursal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursal)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpRemuneracion.SuspendLayout();
            this.tpUtilidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptoUtilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // ssEstado
            // 
            this.ssEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.ssEstado.Location = new System.Drawing.Point(0, 377);
            this.ssEstado.Name = "ssEstado";
            this.ssEstado.Size = new System.Drawing.Size(411, 22);
            this.ssEstado.TabIndex = 2;
            this.ssEstado.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel1.Text = "Procesando:";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // btnImportar
            // 
            this.btnImportar.AutoSize = true;
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Location = new System.Drawing.Point(276, 347);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(131, 27);
            this.btnImportar.TabIndex = 3;
            this.btnImportar.Text = "Importar datos";
            this.btnImportar.UseVisualStyleBackColor = true;
            // 
            // tcAccesos
            // 
            this.tcAccesos.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcAccesos.Controls.Add(this.tpActividad);
            this.tcAccesos.Controls.Add(this.tpCentroCosto);
            this.tcAccesos.Controls.Add(this.tpConcepto);
            this.tcAccesos.Controls.Add(this.tpPersona);
            this.tcAccesos.Controls.Add(this.tpSucursal);
            this.tcAccesos.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcAccesos.HotTrack = true;
            this.tcAccesos.Location = new System.Drawing.Point(0, 0);
            this.tcAccesos.Multiline = true;
            this.tcAccesos.Name = "tcAccesos";
            this.tcAccesos.SelectedIndex = 0;
            this.tcAccesos.ShowToolTips = true;
            this.tcAccesos.Size = new System.Drawing.Size(411, 341);
            this.tcAccesos.TabIndex = 12;
            // 
            // tpActividad
            // 
            this.tpActividad.Controls.Add(this.dgvActividad);
            this.tpActividad.Location = new System.Drawing.Point(4, 27);
            this.tpActividad.Name = "tpActividad";
            this.tpActividad.Padding = new System.Windows.Forms.Padding(3);
            this.tpActividad.Size = new System.Drawing.Size(403, 310);
            this.tpActividad.TabIndex = 0;
            this.tpActividad.Text = "Actividades";
            this.tpActividad.UseVisualStyleBackColor = true;
            // 
            // dgvActividad
            // 
            this.dgvActividad.AllowUserToAddRows = false;
            this.dgvActividad.AllowUserToDeleteRows = false;
            this.dgvActividad.AllowUserToOrderColumns = true;
            this.dgvActividad.AllowUserToResizeColumns = false;
            this.dgvActividad.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvActividad.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActividad.BackgroundColor = System.Drawing.Color.White;
            this.dgvActividad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActividad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActividad.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActividad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActividad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvActividad.Location = new System.Drawing.Point(3, 3);
            this.dgvActividad.MultiSelect = false;
            this.dgvActividad.Name = "dgvActividad";
            this.dgvActividad.RowHeadersVisible = false;
            this.dgvActividad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActividad.Size = new System.Drawing.Size(397, 304);
            this.dgvActividad.TabIndex = 12;
            // 
            // tpCentroCosto
            // 
            this.tpCentroCosto.Controls.Add(this.dgvCentroCosto);
            this.tpCentroCosto.Location = new System.Drawing.Point(4, 27);
            this.tpCentroCosto.Name = "tpCentroCosto";
            this.tpCentroCosto.Padding = new System.Windows.Forms.Padding(3);
            this.tpCentroCosto.Size = new System.Drawing.Size(403, 310);
            this.tpCentroCosto.TabIndex = 1;
            this.tpCentroCosto.Text = "Centros de costo";
            this.tpCentroCosto.UseVisualStyleBackColor = true;
            // 
            // dgvCentroCosto
            // 
            this.dgvCentroCosto.AllowUserToAddRows = false;
            this.dgvCentroCosto.AllowUserToDeleteRows = false;
            this.dgvCentroCosto.AllowUserToOrderColumns = true;
            this.dgvCentroCosto.AllowUserToResizeColumns = false;
            this.dgvCentroCosto.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvCentroCosto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCentroCosto.BackgroundColor = System.Drawing.Color.White;
            this.dgvCentroCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCentroCosto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCentroCosto.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCentroCosto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCentroCosto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCentroCosto.Location = new System.Drawing.Point(3, 3);
            this.dgvCentroCosto.MultiSelect = false;
            this.dgvCentroCosto.Name = "dgvCentroCosto";
            this.dgvCentroCosto.RowHeadersVisible = false;
            this.dgvCentroCosto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCentroCosto.Size = new System.Drawing.Size(397, 304);
            this.dgvCentroCosto.TabIndex = 16;
            // 
            // tpConcepto
            // 
            this.tpConcepto.Controls.Add(this.tabControl1);
            this.tpConcepto.Location = new System.Drawing.Point(4, 27);
            this.tpConcepto.Name = "tpConcepto";
            this.tpConcepto.Padding = new System.Windows.Forms.Padding(3);
            this.tpConcepto.Size = new System.Drawing.Size(403, 310);
            this.tpConcepto.TabIndex = 2;
            this.tpConcepto.Text = "Conceptos";
            this.tpConcepto.UseVisualStyleBackColor = true;
            // 
            // dgvConceptoRemuneracion
            // 
            this.dgvConceptoRemuneracion.AllowUserToAddRows = false;
            this.dgvConceptoRemuneracion.AllowUserToDeleteRows = false;
            this.dgvConceptoRemuneracion.AllowUserToOrderColumns = true;
            this.dgvConceptoRemuneracion.AllowUserToResizeColumns = false;
            this.dgvConceptoRemuneracion.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvConceptoRemuneracion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvConceptoRemuneracion.BackgroundColor = System.Drawing.Color.White;
            this.dgvConceptoRemuneracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptoRemuneracion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.Column1});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConceptoRemuneracion.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvConceptoRemuneracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConceptoRemuneracion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvConceptoRemuneracion.Location = new System.Drawing.Point(3, 3);
            this.dgvConceptoRemuneracion.MultiSelect = false;
            this.dgvConceptoRemuneracion.Name = "dgvConceptoRemuneracion";
            this.dgvConceptoRemuneracion.RowHeadersVisible = false;
            this.dgvConceptoRemuneracion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptoRemuneracion.Size = new System.Drawing.Size(383, 264);
            this.dgvConceptoRemuneracion.TabIndex = 17;
            // 
            // tpPersona
            // 
            this.tpPersona.Controls.Add(this.dgvPersona);
            this.tpPersona.Location = new System.Drawing.Point(4, 27);
            this.tpPersona.Name = "tpPersona";
            this.tpPersona.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersona.Size = new System.Drawing.Size(403, 310);
            this.tpPersona.TabIndex = 4;
            this.tpPersona.Text = "Personas";
            this.tpPersona.UseVisualStyleBackColor = true;
            // 
            // dgvPersona
            // 
            this.dgvPersona.AllowUserToAddRows = false;
            this.dgvPersona.AllowUserToDeleteRows = false;
            this.dgvPersona.AllowUserToOrderColumns = true;
            this.dgvPersona.AllowUserToResizeColumns = false;
            this.dgvPersona.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvPersona.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPersona.BackgroundColor = System.Drawing.Color.White;
            this.dgvPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersona.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPersona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersona.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPersona.Location = new System.Drawing.Point(3, 3);
            this.dgvPersona.MultiSelect = false;
            this.dgvPersona.Name = "dgvPersona";
            this.dgvPersona.RowHeadersVisible = false;
            this.dgvPersona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersona.Size = new System.Drawing.Size(397, 304);
            this.dgvPersona.TabIndex = 26;
            // 
            // tpSucursal
            // 
            this.tpSucursal.Controls.Add(this.dgvSucursal);
            this.tpSucursal.Location = new System.Drawing.Point(4, 27);
            this.tpSucursal.Name = "tpSucursal";
            this.tpSucursal.Padding = new System.Windows.Forms.Padding(3);
            this.tpSucursal.Size = new System.Drawing.Size(403, 310);
            this.tpSucursal.TabIndex = 3;
            this.tpSucursal.Text = "Sucursal";
            this.tpSucursal.UseVisualStyleBackColor = true;
            // 
            // dgvSucursal
            // 
            this.dgvSucursal.AllowUserToAddRows = false;
            this.dgvSucursal.AllowUserToDeleteRows = false;
            this.dgvSucursal.AllowUserToOrderColumns = true;
            this.dgvSucursal.AllowUserToResizeColumns = false;
            this.dgvSucursal.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvSucursal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSucursal.BackgroundColor = System.Drawing.Color.White;
            this.dgvSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSucursal.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSucursal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSucursal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSucursal.Location = new System.Drawing.Point(3, 3);
            this.dgvSucursal.MultiSelect = false;
            this.dgvSucursal.Name = "dgvSucursal";
            this.dgvSucursal.RowHeadersVisible = false;
            this.dgvSucursal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSucursal.Size = new System.Drawing.Size(397, 304);
            this.dgvSucursal.TabIndex = 25;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpRemuneracion);
            this.tabControl1.Controls.Add(this.tpUtilidades);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(397, 301);
            this.tabControl1.TabIndex = 25;
            // 
            // tpRemuneracion
            // 
            this.tpRemuneracion.Controls.Add(this.dgvConceptoRemuneracion);
            this.tpRemuneracion.Location = new System.Drawing.Point(4, 24);
            this.tpRemuneracion.Name = "tpRemuneracion";
            this.tpRemuneracion.Padding = new System.Windows.Forms.Padding(3);
            this.tpRemuneracion.Size = new System.Drawing.Size(389, 270);
            this.tpRemuneracion.TabIndex = 0;
            this.tpRemuneracion.Text = "Remuneración";
            this.tpRemuneracion.UseVisualStyleBackColor = true;
            // 
            // tpUtilidades
            // 
            this.tpUtilidades.Controls.Add(this.dgvConceptoUtilidades);
            this.tpUtilidades.Location = new System.Drawing.Point(4, 24);
            this.tpUtilidades.Name = "tpUtilidades";
            this.tpUtilidades.Padding = new System.Windows.Forms.Padding(3);
            this.tpUtilidades.Size = new System.Drawing.Size(389, 273);
            this.tpUtilidades.TabIndex = 1;
            this.tpUtilidades.Text = "Utilidades";
            this.tpUtilidades.UseVisualStyleBackColor = true;
            // 
            // dgvConceptoUtilidades
            // 
            this.dgvConceptoUtilidades.AllowUserToAddRows = false;
            this.dgvConceptoUtilidades.AllowUserToDeleteRows = false;
            this.dgvConceptoUtilidades.AllowUserToOrderColumns = true;
            this.dgvConceptoUtilidades.AllowUserToResizeColumns = false;
            this.dgvConceptoUtilidades.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvConceptoUtilidades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvConceptoUtilidades.BackgroundColor = System.Drawing.Color.White;
            this.dgvConceptoUtilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptoUtilidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column2});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConceptoUtilidades.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvConceptoUtilidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConceptoUtilidades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvConceptoUtilidades.Location = new System.Drawing.Point(3, 3);
            this.dgvConceptoUtilidades.MultiSelect = false;
            this.dgvConceptoUtilidades.Name = "dgvConceptoUtilidades";
            this.dgvConceptoUtilidades.RowHeadersVisible = false;
            this.dgvConceptoUtilidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptoUtilidades.Size = new System.Drawing.Size(383, 267);
            this.dgvConceptoUtilidades.TabIndex = 25;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Concepto";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 330;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ok";
            this.Column1.Name = "Column1";
            this.Column1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Concepto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 330;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ok";
            this.Column2.Name = "Column2";
            this.Column2.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn3.HeaderText = "Actividad";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 370;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn6.HeaderText = "Centro costo";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 370;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn1.HeaderText = "Persona";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 370;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn10.HeaderText = "Sucursal";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 370;
            // 
            // frmImportarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 399);
            this.Controls.Add(this.tcAccesos);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.ssEstado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmImportarDatos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar datos";
            this.ssEstado.ResumeLayout(false);
            this.ssEstado.PerformLayout();
            this.tcAccesos.ResumeLayout(false);
            this.tpActividad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividad)).EndInit();
            this.tpCentroCosto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentroCosto)).EndInit();
            this.tpConcepto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptoRemuneracion)).EndInit();
            this.tpPersona.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersona)).EndInit();
            this.tpSucursal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursal)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpRemuneracion.ResumeLayout(false);
            this.tpUtilidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptoUtilidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.TabControl tcAccesos;
        private System.Windows.Forms.TabPage tpActividad;
        private System.Windows.Forms.DataGridView dgvActividad;
        private System.Windows.Forms.TabPage tpCentroCosto;
        private System.Windows.Forms.DataGridView dgvCentroCosto;
        private System.Windows.Forms.TabPage tpConcepto;
        private System.Windows.Forms.DataGridView dgvConceptoRemuneracion;
        private System.Windows.Forms.TabPage tpSucursal;
        private System.Windows.Forms.DataGridView dgvSucursal;
        private System.Windows.Forms.TabPage tpPersona;
        private System.Windows.Forms.DataGridView dgvPersona;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRemuneracion;
        private System.Windows.Forms.TabPage tpUtilidades;
        private System.Windows.Forms.DataGridView dgvConceptoUtilidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}