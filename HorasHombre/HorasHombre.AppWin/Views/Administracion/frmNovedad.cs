using BrightIdeasSoftware;
using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.Administracion
{
    public partial class frmNovedad : HerenciaVisual.frmMantenimiento, INovedadView
    {
        NovedadEditor mPresenter;
        int mSelectNovedadID;

        #region . Constructor .

        private static frmNovedad _instance;
        public static frmNovedad GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNovedad();
            _instance.BringToFront();
            return _instance;
        }

        private frmNovedad()
        {
            InitializeComponent();
            this.ShowRemovedItem = false;
            this.btnActivar.Click += new EventHandler(this.Activar_Click);
            this.btnCancelar.Click += new EventHandler(this.Cancelar_Click);
            this.btnEliminar.Click += new EventHandler(this.Eliminar_Click);
            this.btnGrabar.Click += new EventHandler(this.Grabar_Click);
            this.btnNuevo.Click += new EventHandler(this.Nuevo_Click);
            this.btnVer.Click += new EventHandler(this.Ver_Click);
            this.btnVerEliminado.Click += new EventHandler(this.VerEliminado_Click);
            this.tcGeneral.Selecting += new TabControlCancelEventHandler(this.TabControl_Selecting);
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                this.mPresenter = new NovedadEditor(this);
                Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
                this.CanRead = permiso.CanRead;
                this.CanWrite = permiso.CanWrite;
                this.CanDelete = permiso.CanDelete;
                this.ShowDeletedItems = permiso.ShowDeleteItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region . INovedadView Members .

        public int Id
        {
            get { return 0; }
            set { }
        }

        public string Codigo
        {
            get { return this.txtCodigo.Text; }
            set { this.txtCodigo.Text = value; }
        }

        public string Nombre
        {
            get { return this.txtNombre.Text; }
            set { this.txtNombre.Text = value; }
        }

        public string DescripcionCorta
        {
            get { return this.txtDescripcionCorta.Text; }
            set { this.txtDescripcionCorta.Text = value; }
        }

        public TipoDistribucion TipoDistribucion
        {
            get
            {
                KeyValuePair<string, int> value = ((KeyValuePair<string, int>)cboTipo.SelectedItem);
                return (TipoDistribucion)value.Value;
            }
            set { this.cboTipo.SelectedValue = (int)value; }
        }

        public bool AplicaCosto
        {
            get { return this.chkCosto.Checked; }
            set { this.chkCosto.Checked = value; }
        }

        public bool MostrarCheck
        {
            set
            {
                this.chkCosto.Checked = value;
                this.chkCosto.Visible = value;
            }
        }

        public bool Activo
        {
            get { return true; }
            set { }
        }

        public bool IsEditing
        {
            get { return this.Editing; }
        }

        public bool IsSuccessful
        {
            set
            {
                this.btnGrabar.Enabled = !value;
                this.btnActivar.Enabled = !value;
            }
        }

        public List<Novedad> DataSource
        {
            set
            {
                btnVer.Enabled = (value != null && value.Count > 0);
                btnEliminar.Enabled = (value != null && value.Count > 0);
                this.olvListado.SetObjects(value);
            }
        }

        public List<Novedad> InactiveDataSource
        {
            set
            {
                btnVerEliminado.Enabled = (value != null && value.Count > 0);
                this.olvListadoInactivos.SetObjects(value);
            }
        }

        public DataSourceContainer TipoDistribucionDataSource
        {
            set
            {
                this.cboTipo.DataSource = value.DataSource;
                this.cboTipo.DisplayMember = value.DataTextFieldName;
                this.cboTipo.ValueMember = value.DataValueFieldName;
            }
        }

        public int SelectId
        {
            get { return this.mSelectNovedadID; }
        }

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> ActiveAction;
        public event EventHandler<EventArgs> CancelAction;
        public event EventHandler<EventArgs> DeleteAction;
        public event EventHandler<EventArgs> FindIndexAction;
        public event EventHandler<EventArgs> NewAction;
        public event EventHandler<EventArgs> SaveAction;
        public event EventHandler<EventArgs> SelectNovedad;
        public event EventHandler<EventArgs> SelectTipoDistribucion;
        public event TabControlCancelEventHandler SelectingTabAction;
        public event EventHandler<EventArgs> SortAction;
        public event EventHandler<EventArgs> ViewAction;

        #endregion

        #region . Events for Buttons .

        private void Activar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActiveAction != null)
                    ActiveAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CancelAction != null)
                    CancelAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (!this.HasSelection)
            {
                MessageBox.Show("Debe seleccionar un registro", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                if (DeleteAction != null)
                    DeleteAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveAction != null)
                    SaveAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControl(gbDatos);
                this.ActivateControl(gbDatos, true);
                if (NewAction != null)
                    NewAction(sender, e);
                this.txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (SelectingTabAction != null)
                    SelectingTabAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ver_Click(object sender, EventArgs e)
        {
            if (!this.HasSelection)
            {
                MessageBox.Show("Debe seleccionar un registro.", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                this.ActivateControl(gbDatos, true);
                this.txtCodigo.Enabled = false;
                if (ViewAction != null)
                    ViewAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerEliminado_Click(object sender, EventArgs e)
        {
            if (!this.HasSelectionInactive)
            {
                MessageBox.Show("Debe seleccionar un registro.", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                this.ActivateControl(gbDatos, false);
                if (ViewAction != null)
                    ViewAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void ActivarRegistro(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Novedad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarTipoDistribuccion(object sender, EventArgs e)
        {
            try
            {
                if (this.cboTipo.SelectedIndex != -1 && this.SelectTipoDistribucion != null)
                    SelectTipoDistribucion(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void SeleccionarItem(object sender, EventArgs e)
        {
            ObjectListView listView = sender as ObjectListView;
            Novedad a = (Novedad)listView.SelectedObject;
            if (a != null)
                this.mSelectNovedadID = a.Id;
        }
    }
}
