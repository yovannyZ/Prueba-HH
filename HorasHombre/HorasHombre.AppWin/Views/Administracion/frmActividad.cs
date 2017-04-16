using BrightIdeasSoftware;
using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.Administracion
{
    public partial class frmActividad : HerenciaVisual.frmMantenimientoTree, IActividadView
    {
        ActividadEditor mPresenter;
        int mSelectActividadID;
        List<Actividad> listAuxiliar = null;

        #region . Constructor .

        private static frmActividad _instance;
        public static frmActividad GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmActividad();
            _instance.BringToFront();
            return _instance;
        }

        private frmActividad()
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
            this.listAuxiliar = new List<Actividad>();
            this.dtlvListado.RootKeyValue = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                this.mPresenter = new ActividadEditor(this);
                Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
                this.CanActivate = permiso.CanActivate;
                this.CanDelete = permiso.CanDelete;
                this.CanRead = permiso.CanRead;
                this.CanWrite = permiso.CanWrite;
                this.ShowDeletedItems = permiso.ShowDeleteItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Actividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region . IActividadView Members .

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

        public Actividad ActividadPrincipal
        {
            get { return (Actividad)this.cboActividad.SelectedItem; }
            set
            {
                if (value != null)
                    this.cboActividad.Text = value.ToString();
                else
                    this.cboActividad.SelectedIndex = -1;
            }
        }

        public string Observacion
        {
            get { return this.txtObservacion.Text; }
            set { this.txtObservacion.Text = value; }
        }

        public string Nivel
        {
            //get { return int.Parse(this.txtNivel.Text); }
            set { this.lblNivel.Text = value; }
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
                if (this.CanWrite)
                    this.btnGrabar.Enabled = !value;
                if (this.CanActivate)
                    this.btnActivar.Enabled = !value;
            }
        }

        public List<Actividad> DataSource
        {
            set
            {
                btnVer.Enabled = (value != null && value.Count > 0);
                btnEliminar.Enabled = (this.CanDelete && value != null && value.Count > 0);
                //this.dtlvListado.SetObjects(value);
                this.dtlvListado.DataSource = value;
            }
        }

        public List<Actividad> InactiveDataSource
        {
            set
            {
                btnVerEliminado.Enabled = (value != null && value.Count > 0);
                this.olvListadoInactivos.SetObjects(value);
            }
        }

        public List<Actividad> ActividadPrincipalDataSource
        {
            set
            {
                this.cboActividad.DataSource = value;
            }
        }

        public int SelectId
        {
            get { return this.mSelectActividadID; }
        }

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> ActiveAction;
        public event EventHandler<EventArgs> CancelAction;
        public event EventHandler<EventArgs> DeleteAction;
        public event EventHandler<EventArgs> FindIndexAction;
        public event EventHandler<EventArgs> NewAction;
        public event EventHandler<EventArgs> SaveAction;
        public event EventHandler<EventArgs> SelectActividad;
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Actividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Actividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dgvListado.CurrentNode.Nodes.Count > 0)
                //{
                //    MessageBox.Show("No se puede eliminar este registro. Verifíque que no existan niveles inferiores",
                //        AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                //SelectRow(dgvListado);
                if (DeleteAction != null)
                    DeleteAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Actividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Actividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            if (!this.HasSelection)
            {
                MessageBox.Show("Debe seleccionar un registro.", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                this.ClearControl(gbDatos);
                this.ActivateControl(gbDatos, true);
                var actividad = (Actividad)this.dtlvListado.SelectedObject;
                if (NewAction != null)
                    NewAction(sender, e);
                this.cboActividad.Enabled = false;
                this.txtCodigo.Focus();
                if (actividad.Nivel == 3)
                    this.btnGrabar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Actividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Actividad),
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
                this.cboActividad.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Actividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Actividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        public override void SeleccionarItem(object sender, EventArgs e)
        {
            ObjectListView listView = sender as ObjectListView;
            Actividad a = (Actividad)listView.SelectedObject;
            if (a != null)
                this.mSelectActividadID = a.Id;
        }
    }
}
