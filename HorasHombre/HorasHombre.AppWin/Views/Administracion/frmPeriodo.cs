using BrightIdeasSoftware;
using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.Administracion
{
    public partial class frmPeriodo : HerenciaVisual.frmMantenimiento, IPeriodoView
    {
        PeriodoEditor mPresenter;
        int mSelectPeriodoID;

        #region . Constructor .

        private static frmPeriodo _instance;
        public static frmPeriodo GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmPeriodo();
            _instance.BringToFront();
            return _instance;
        }

        private frmPeriodo()
        {
            InitializeComponent();
            this.ShowRemovedItem = false;
            this.ShowDeletedItems = false;
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
                this.mPresenter = new PeriodoEditor(this);
                Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
                this.CanRead = permiso.CanRead;
                this.CanWrite = permiso.CanWrite;
                this.CanDelete = permiso.CanDelete;
                this.ShowDeletedItems = permiso.ShowDeleteItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region . IPeriodoView Members .

        public int Id
        {
            get { return 0; }
            set { }
        }

        public DateTime FechaInicio
        {
            get { return this.dtpInicio.Value; }
            set { this.dtpInicio.Value = value; }
        }

        public DateTime FechaCierre
        {
            get { return this.dtpFin.Value; }
            set { this.dtpFin.Value = value; }
        }

        public Modulo Modulo
        {
            get
            {
                KeyValuePair<string, int> value = ((KeyValuePair<string, int>)cboModulo.SelectedItem);
                return (Modulo)value.Value;
            }
            set { this.cboModulo.SelectedValue = (int)value; }
        }

        public bool Activo
        {
            get { return false; }
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

        public List<Periodo> DataSource
        {
            set
            {
                btnVer.Enabled = (value != null && value.Count > 0);
                btnEliminar.Enabled = (value != null && value.Count > 0);
                this.olvListado.SetObjects(value);
            }
        }

        public List<Periodo> InactiveDataSource
        {
            set
            {
                btnVerEliminado.Enabled = (value != null && value.Count > 0);
                this.olvListadoInactivos.SetObjects(value);
            }
        }

        public DataSourceContainer ModuloDataSource
        {
            set
            {
                this.cboModulo.DataSource = value.DataSource;
                this.cboModulo.DisplayMember = value.DataTextFieldName;
                this.cboModulo.ValueMember = value.DataValueFieldName;
            }
        }

        public int SelectId
        {
            get { return this.mSelectPeriodoID; }
        }

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> ActiveAction;
        public event EventHandler<EventArgs> CancelAction;
        public event EventHandler<EventArgs> ClosePeriodo;
        public event EventHandler<EventArgs> DeleteAction;
        public event EventHandler<EventArgs> FindIndexAction;
        public event EventHandler<EventArgs> NewAction;
        public event EventHandler<EventArgs> SaveAction;
        public event EventHandler<EventArgs> SelectPeriodo;
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControl(gbDatos);
                this.ActivateControl(gbDatos, true);
                this.dtpInicio.Enabled = true;
                if (NewAction != null)
                    NewAction(sender, e);
                this.cboModulo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
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
                this.cboModulo.Enabled = false;
                this.dtpInicio.Enabled = false;
                if (ViewAction != null)
                    ViewAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void ActivarRegistro(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (this.dgvListado.CurrentCell.ColumnIndex == 3)
                //{
                //    SelectRow(this.dgvListado);
                //    if (ActiveAction != null)
                //        ActiveAction(sender, e);
                //}
                //////else 
                ////if (this.dgvListado.CurrentCell.ColumnIndex == 3)
                ////{
                ////    SelectRow(this.dgvListado);
                ////    if (ClosePeriodo != null)
                ////        ClosePeriodo(sender, e);
                ////}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Periodo),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarFecha(object sender, EventArgs e)
        {
            DateTime value = this.dtpInicio.Value;
            this.dtpFin.Value = new DateTime(value.Year, value.Month, 1).AddMonths(1).AddDays(-1);
        }

        public override void SeleccionarItem(object sender, EventArgs e)
        {
            ObjectListView listView = sender as ObjectListView;
            Periodo a = (Periodo)listView.SelectedObject;
            if (a != null)
                this.mSelectPeriodoID = a.Id;
        }
    }
}
