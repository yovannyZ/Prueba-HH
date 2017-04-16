namespace HorasHombre.AppWin.Views.Administracion
{
    partial class frmUserLog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserLog));
            this.tcGeneral = new ExtControls.ExtendedTabControl();
            this.tpListado = new System.Windows.Forms.TabPage();
            this.scVisor = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ecpOpciones = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.gbBuscar = new System.Windows.Forms.GroupBox();
            this.gbOrdenar = new System.Windows.Forms.GroupBox();
            this.rbAsc = new System.Windows.Forms.RadioButton();
            this.rbDesc = new System.Windows.Forms.RadioButton();
            this.gbOpciones = new System.Windows.Forms.GroupBox();
            this.rbContiene = new System.Windows.Forms.RadioButton();
            this.rbEmpieza = new System.Windows.Forms.RadioButton();
            this.rbTermina = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLista = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.tcDetalleLog = new ExtControls.ExtendedTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.lblModulo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNombrePc = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRegistrado = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.imgGrid = new System.Windows.Forms.ImageList(this.components);
            this.tcGeneral.SuspendLayout();
            this.tpListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scVisor)).BeginInit();
            this.scVisor.Panel1.SuspendLayout();
            this.scVisor.Panel2.SuspendLayout();
            this.scVisor.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.ecpOpciones.SuspendLayout();
            this.gbBuscar.SuspendLayout();
            this.gbOrdenar.SuspendLayout();
            this.gbOpciones.SuspendLayout();
            this.tcDetalleLog.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcGeneral
            // 
            this.tcGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcGeneral.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcGeneral.Controls.Add(this.tpListado);
            this.tcGeneral.Location = new System.Drawing.Point(14, 13);
            this.tcGeneral.Name = "tcGeneral";
            this.tcGeneral.Padding = new System.Drawing.Point(3, 3);
            this.tcGeneral.SelectedIndex = 0;
            this.tcGeneral.Size = new System.Drawing.Size(528, 606);
            this.tcGeneral.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcGeneral.TabIndex = 3;
            // 
            // tpListado
            // 
            this.tpListado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpListado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpListado.Controls.Add(this.scVisor);
            this.tpListado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpListado.ForeColor = System.Drawing.Color.SteelBlue;
            this.tpListado.Location = new System.Drawing.Point(4, 27);
            this.tpListado.Name = "tpListado";
            this.tpListado.Padding = new System.Windows.Forms.Padding(3);
            this.tpListado.Size = new System.Drawing.Size(520, 575);
            this.tpListado.TabIndex = 0;
            this.tpListado.Text = "Listado";
            // 
            // scVisor
            // 
            this.scVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scVisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scVisor.Location = new System.Drawing.Point(3, 3);
            this.scVisor.Name = "scVisor";
            this.scVisor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scVisor.Panel1
            // 
            this.scVisor.Panel1.Controls.Add(this.panel1);
            // 
            // scVisor.Panel2
            // 
            this.scVisor.Panel2.Controls.Add(this.tcDetalleLog);
            this.scVisor.Size = new System.Drawing.Size(512, 567);
            this.scVisor.SplitterDistance = 332;
            this.scVisor.SplitterWidth = 5;
            this.scVisor.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvListado);
            this.panel1.Controls.Add(this.ecpOpciones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 330);
            this.panel1.TabIndex = 6;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.AllowUserToResizeColumns = false;
            this.dgvListado.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.BackgroundColor = System.Drawing.Color.White;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column3,
            this.Column1,
            this.Column4,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListado.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListado.Location = new System.Drawing.Point(0, 35);
            this.dgvListado.MultiSelect = false;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(510, 295);
            this.dgvListado.TabIndex = 3;
            this.dgvListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvListado_CellFormatting);
            this.dgvListado.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectRow);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Id";
            this.Column6.HeaderText = "GUI";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Type";
            this.Column3.HeaderText = "Tipo";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 35;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Date";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Fecha";
            this.Column1.Name = "Column1";
            this.Column1.Width = 140;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Module";
            this.Column4.HeaderText = "Módulo";
            this.Column4.Name = "Column4";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Source";
            this.Column2.HeaderText = "Origen";
            this.Column2.Name = "Column2";
            this.Column2.Width = 180;
            // 
            // ecpOpciones
            // 
            this.ecpOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ecpOpciones.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Small;
            this.ecpOpciones.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Classic;
            this.ecpOpciones.Controls.Add(this.gbBuscar);
            this.ecpOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.ecpOpciones.ExpandedHeight = 164;
            this.ecpOpciones.IsExpanded = false;
            this.ecpOpciones.Location = new System.Drawing.Point(0, 0);
            this.ecpOpciones.Name = "ecpOpciones";
            this.ecpOpciones.Size = new System.Drawing.Size(510, 35);
            this.ecpOpciones.TabIndex = 0;
            this.ecpOpciones.Text = "Opciones de filtro";
            this.ecpOpciones.UseAnimation = true;
            // 
            // gbBuscar
            // 
            this.gbBuscar.BackColor = System.Drawing.Color.Transparent;
            this.gbBuscar.Controls.Add(this.gbOrdenar);
            this.gbBuscar.Controls.Add(this.gbOpciones);
            this.gbBuscar.Controls.Add(this.label1);
            this.gbBuscar.Controls.Add(this.cboLista);
            this.gbBuscar.Controls.Add(this.txtBuscar);
            this.gbBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.gbBuscar.Location = new System.Drawing.Point(33, 31);
            this.gbBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Padding = new System.Windows.Forms.Padding(0);
            this.gbBuscar.Size = new System.Drawing.Size(573, 138);
            this.gbBuscar.TabIndex = 0;
            this.gbBuscar.TabStop = false;
            // 
            // gbOrdenar
            // 
            this.gbOrdenar.Controls.Add(this.rbAsc);
            this.gbOrdenar.Controls.Add(this.rbDesc);
            this.gbOrdenar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gbOrdenar.Location = new System.Drawing.Point(3, 76);
            this.gbOrdenar.Name = "gbOrdenar";
            this.gbOrdenar.Size = new System.Drawing.Size(294, 59);
            this.gbOrdenar.TabIndex = 3;
            this.gbOrdenar.TabStop = false;
            this.gbOrdenar.Text = "Ordenar:";
            // 
            // rbAsc
            // 
            this.rbAsc.AutoSize = true;
            this.rbAsc.Checked = true;
            this.rbAsc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(181)))));
            this.rbAsc.Location = new System.Drawing.Point(7, 25);
            this.rbAsc.Name = "rbAsc";
            this.rbAsc.Size = new System.Drawing.Size(87, 19);
            this.rbAsc.TabIndex = 0;
            this.rbAsc.TabStop = true;
            this.rbAsc.Text = "Ascendente";
            this.rbAsc.UseVisualStyleBackColor = true;
            // 
            // rbDesc
            // 
            this.rbDesc.AutoSize = true;
            this.rbDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(181)))));
            this.rbDesc.Location = new System.Drawing.Point(115, 25);
            this.rbDesc.Name = "rbDesc";
            this.rbDesc.Size = new System.Drawing.Size(93, 19);
            this.rbDesc.TabIndex = 1;
            this.rbDesc.Text = "Descendente";
            this.rbDesc.UseVisualStyleBackColor = true;
            // 
            // gbOpciones
            // 
            this.gbOpciones.Controls.Add(this.rbContiene);
            this.gbOpciones.Controls.Add(this.rbEmpieza);
            this.gbOpciones.Controls.Add(this.rbTermina);
            this.gbOpciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOpciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gbOpciones.Location = new System.Drawing.Point(342, 13);
            this.gbOpciones.Name = "gbOpciones";
            this.gbOpciones.Size = new System.Drawing.Size(227, 122);
            this.gbOpciones.TabIndex = 4;
            this.gbOpciones.TabStop = false;
            this.gbOpciones.Text = "Opciones:";
            // 
            // rbContiene
            // 
            this.rbContiene.AutoSize = true;
            this.rbContiene.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(181)))));
            this.rbContiene.Location = new System.Drawing.Point(7, 83);
            this.rbContiene.Name = "rbContiene";
            this.rbContiene.Size = new System.Drawing.Size(174, 19);
            this.rbContiene.TabIndex = 2;
            this.rbContiene.Text = "Tiene la palabra(%[word]%):";
            this.rbContiene.UseVisualStyleBackColor = true;
            // 
            // rbEmpieza
            // 
            this.rbEmpieza.AutoSize = true;
            this.rbEmpieza.Checked = true;
            this.rbEmpieza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(181)))));
            this.rbEmpieza.Location = new System.Drawing.Point(7, 25);
            this.rbEmpieza.Name = "rbEmpieza";
            this.rbEmpieza.Size = new System.Drawing.Size(95, 19);
            this.rbEmpieza.TabIndex = 0;
            this.rbEmpieza.TabStop = true;
            this.rbEmpieza.Text = "Empieza con:";
            this.rbEmpieza.UseVisualStyleBackColor = true;
            // 
            // rbTermina
            // 
            this.rbTermina.AutoSize = true;
            this.rbTermina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(181)))));
            this.rbTermina.Location = new System.Drawing.Point(7, 54);
            this.rbTermina.Name = "rbTermina";
            this.rbTermina.Size = new System.Drawing.Size(88, 19);
            this.rbTermina.TabIndex = 1;
            this.rbTermina.Text = "Termina en:";
            this.rbTermina.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(181)))));
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // cboLista
            // 
            this.cboLista.BackColor = System.Drawing.Color.White;
            this.cboLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLista.FormattingEnabled = true;
            this.cboLista.Location = new System.Drawing.Point(63, 13);
            this.cboLista.Name = "cboLista";
            this.cboLista.Size = new System.Drawing.Size(234, 23);
            this.cboLista.TabIndex = 1;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(3, 43);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(293, 23);
            this.txtBuscar.TabIndex = 2;
            // 
            // tcDetalleLog
            // 
            this.tcDetalleLog.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcDetalleLog.Controls.Add(this.tabPage1);
            this.tcDetalleLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetalleLog.Location = new System.Drawing.Point(0, 0);
            this.tcDetalleLog.Name = "tcDetalleLog";
            this.tcDetalleLog.Padding = new System.Drawing.Point(3, 3);
            this.tcDetalleLog.SelectedIndex = 0;
            this.tcDetalleLog.Size = new System.Drawing.Size(510, 228);
            this.tcDetalleLog.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcDetalleLog.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(502, 197);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tlpLog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtDescripcion);
            this.splitContainer1.Size = new System.Drawing.Size(494, 189);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // tlpLog
            // 
            this.tlpLog.AutoScroll = true;
            this.tlpLog.ColumnCount = 2;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpLog.Controls.Add(this.lblModulo, 1, 0);
            this.tlpLog.Controls.Add(this.label8, 0, 0);
            this.tlpLog.Controls.Add(this.lblNombrePc, 1, 5);
            this.tlpLog.Controls.Add(this.label7, 0, 5);
            this.tlpLog.Controls.Add(this.lblUsuario, 1, 4);
            this.tlpLog.Controls.Add(this.label6, 0, 4);
            this.tlpLog.Controls.Add(this.lblRegistrado, 2, 3);
            this.tlpLog.Controls.Add(this.label5, 0, 3);
            this.tlpLog.Controls.Add(this.lblTipo, 1, 2);
            this.tlpLog.Controls.Add(this.label4, 0, 2);
            this.tlpLog.Controls.Add(this.lblOrigen, 1, 1);
            this.tlpLog.Controls.Add(this.label2, 0, 1);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(0, 0);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 7;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpLog.Size = new System.Drawing.Size(199, 189);
            this.tlpLog.TabIndex = 5;
            // 
            // lblModulo
            // 
            this.lblModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModulo.Location = new System.Drawing.Point(62, 3);
            this.lblModulo.Margin = new System.Windows.Forms.Padding(3);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(134, 23);
            this.lblModulo.TabIndex = 20;
            this.lblModulo.Text = "[]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Modulo:";
            // 
            // lblNombrePc
            // 
            this.lblNombrePc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombrePc.Location = new System.Drawing.Point(62, 148);
            this.lblNombrePc.Margin = new System.Windows.Forms.Padding(3);
            this.lblNombrePc.Name = "lblNombrePc";
            this.lblNombrePc.Size = new System.Drawing.Size(134, 23);
            this.lblNombrePc.TabIndex = 18;
            this.lblNombrePc.Text = "[]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Equipo:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.Location = new System.Drawing.Point(62, 119);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(134, 23);
            this.lblUsuario.TabIndex = 16;
            this.lblUsuario.Text = "[]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Usuario:";
            // 
            // lblRegistrado
            // 
            this.lblRegistrado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegistrado.Location = new System.Drawing.Point(62, 90);
            this.lblRegistrado.Margin = new System.Windows.Forms.Padding(3);
            this.lblRegistrado.Name = "lblRegistrado";
            this.lblRegistrado.Size = new System.Drawing.Size(134, 23);
            this.lblRegistrado.TabIndex = 14;
            this.lblRegistrado.Text = "[]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Registrado:";
            // 
            // lblTipo
            // 
            this.lblTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTipo.Location = new System.Drawing.Point(62, 61);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(3);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(134, 23);
            this.lblTipo.TabIndex = 12;
            this.lblTipo.Text = "[]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tipo:";
            // 
            // lblOrigen
            // 
            this.lblOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrigen.Location = new System.Drawing.Point(62, 32);
            this.lblOrigen.Margin = new System.Windows.Forms.Padding(3);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(134, 23);
            this.lblOrigen.TabIndex = 9;
            this.lblOrigen.Text = "[]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Origen:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(0, 0);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescripcion.Size = new System.Drawing.Size(290, 189);
            this.txtDescripcion.TabIndex = 5;
            // 
            // imgGrid
            // 
            this.imgGrid.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgGrid.ImageStream")));
            this.imgGrid.TransparentColor = System.Drawing.Color.Transparent;
            this.imgGrid.Images.SetKeyName(0, "Error.png");
            this.imgGrid.Images.SetKeyName(1, "Info.png");
            this.imgGrid.Images.SetKeyName(2, "Warning.png");
            // 
            // frmUserLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 633);
            this.Controls.Add(this.tcGeneral);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmUserLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor de eventos";
            this.tcGeneral.ResumeLayout(false);
            this.tpListado.ResumeLayout(false);
            this.scVisor.Panel1.ResumeLayout(false);
            this.scVisor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scVisor)).EndInit();
            this.scVisor.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ecpOpciones.ResumeLayout(false);
            this.ecpOpciones.PerformLayout();
            this.gbBuscar.ResumeLayout(false);
            this.gbBuscar.PerformLayout();
            this.gbOrdenar.ResumeLayout(false);
            this.gbOrdenar.PerformLayout();
            this.gbOpciones.ResumeLayout(false);
            this.gbOpciones.PerformLayout();
            this.tcDetalleLog.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.tlpLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected ExtControls.ExtendedTabControl tcGeneral;
        private System.Windows.Forms.TabPage tpListado;
        private System.Windows.Forms.SplitContainer scVisor;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        protected MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel ecpOpciones;
        protected System.Windows.Forms.GroupBox gbBuscar;
        protected System.Windows.Forms.GroupBox gbOrdenar;
        protected System.Windows.Forms.RadioButton rbAsc;
        protected System.Windows.Forms.RadioButton rbDesc;
        protected System.Windows.Forms.GroupBox gbOpciones;
        protected System.Windows.Forms.RadioButton rbContiene;
        protected System.Windows.Forms.RadioButton rbEmpieza;
        protected System.Windows.Forms.RadioButton rbTermina;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox cboLista;
        protected System.Windows.Forms.TextBox txtBuscar;
        protected ExtControls.ExtendedTabControl tcDetalleLog;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNombrePc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRegistrado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ImageList imgGrid;
    }
}