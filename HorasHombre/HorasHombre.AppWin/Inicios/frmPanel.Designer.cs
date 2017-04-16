namespace HorasHombre.AppWin.Inicios
{
    partial class frmPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHorasHombre = new System.Windows.Forms.Button();
            this.pbHorasHombre = new System.Windows.Forms.PictureBox();
            this.pbAdministracion = new System.Windows.Forms.PictureBox();
            this.btnAdministracion = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorasHombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdministracion)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnHorasHombre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbHorasHombre, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbAdministracion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdministracion, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.31746F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.68254F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 252);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnHorasHombre
            // 
            this.btnHorasHombre.BackColor = System.Drawing.Color.Transparent;
            this.btnHorasHombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHorasHombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHorasHombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorasHombre.Location = new System.Drawing.Point(275, 217);
            this.btnHorasHombre.Name = "btnHorasHombre";
            this.btnHorasHombre.Size = new System.Drawing.Size(266, 32);
            this.btnHorasHombre.TabIndex = 3;
            this.btnHorasHombre.Text = "Horas hombre";
            this.btnHorasHombre.UseVisualStyleBackColor = false;
            this.btnHorasHombre.Click += new System.EventHandler(this.AbrirHorasHombre);
            // 
            // pbHorasHombre
            // 
            this.pbHorasHombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHorasHombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHorasHombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbHorasHombre.Image = global::HorasHombre.AppWin.Properties.Resources.trabajo;
            this.pbHorasHombre.Location = new System.Drawing.Point(275, 3);
            this.pbHorasHombre.Name = "pbHorasHombre";
            this.pbHorasHombre.Size = new System.Drawing.Size(266, 208);
            this.pbHorasHombre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHorasHombre.TabIndex = 1;
            this.pbHorasHombre.TabStop = false;
            this.pbHorasHombre.Click += new System.EventHandler(this.AbrirHorasHombre);
            // 
            // pbAdministracion
            // 
            this.pbAdministracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAdministracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAdministracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAdministracion.Image = ((System.Drawing.Image)(resources.GetObject("pbAdministracion.Image")));
            this.pbAdministracion.Location = new System.Drawing.Point(3, 3);
            this.pbAdministracion.Name = "pbAdministracion";
            this.pbAdministracion.Size = new System.Drawing.Size(266, 208);
            this.pbAdministracion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdministracion.TabIndex = 0;
            this.pbAdministracion.TabStop = false;
            this.pbAdministracion.Click += new System.EventHandler(this.AbrirAdministracion);
            // 
            // btnAdministracion
            // 
            this.btnAdministracion.BackColor = System.Drawing.Color.Transparent;
            this.btnAdministracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdministracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdministracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministracion.Location = new System.Drawing.Point(3, 217);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(266, 32);
            this.btnAdministracion.TabIndex = 2;
            this.btnAdministracion.Text = "Administración";
            this.btnAdministracion.UseVisualStyleBackColor = false;
            this.btnAdministracion.Click += new System.EventHandler(this.AbrirAdministracion);
            // 
            // frmPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(544, 252);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel principal";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHorasHombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdministracion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbAdministracion;
        private System.Windows.Forms.PictureBox pbHorasHombre;
        private System.Windows.Forms.Button btnAdministracion;
        private System.Windows.Forms.Button btnHorasHombre;
    }
}