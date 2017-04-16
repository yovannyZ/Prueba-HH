using BrightIdeasSoftware;
using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.Administracion
{
    public partial class frmPersona : HerenciaVisual.frmMantenimiento, IPersonaView
    {
        PersonaEditor mPresenter;
        int mSelectPersonaID;

        #region . Constructor .

        private static frmPersona _instance;
        public static frmPersona GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmPersona();
            _instance.BringToFront();
            return _instance;
        }

        private frmPersona()
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
                this.mPresenter = new PersonaEditor(this);
                Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
                this.CanActivate = permiso.CanActivate;
                this.CanDelete = permiso.CanDelete;
                this.CanRead = permiso.CanRead;
                this.CanWrite = permiso.CanWrite;
                this.ShowDeletedItems = permiso.ShowDeleteItems;
                this.btnNuevo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region . IPersonaView Members .

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

        public string ApellidoPaterno
        {
            get { return this.txtPaterno.Text; }
            set { this.txtPaterno.Text = value; }
        }

        public string ApellidoMaterno
        {
            get { return this.txtMaterno.Text; }
            set { this.txtMaterno.Text = value; }
        }

        public TipoPersona TipoPersona
        {
            get
            {
                KeyValuePair<string, int> value = ((KeyValuePair<string, int>)cboTipo.SelectedItem);
                return (TipoPersona)value.Value;
            }
            set { this.cboTipo.SelectedValue = (int)value; }
        }

        public DocumentoPersona TipoDocumento
        {
            get { return (DocumentoPersona)this.cboDocumento.SelectedItem; }
            set
            {
                if (value != null)
                    this.cboDocumento.Text = value.ToString();
                else
                    this.cboDocumento.SelectedIndex = 0;
            }
        }

        public string NumeroDocumento
        {
            get { return this.txtNumero.Text; }
            set { this.txtNumero.Text = value; }
        }

        public string Email
        {
            get { return this.txtEmail.Text; }
            set { this.txtEmail.Text = value; }
        }

        public CentroCosto CentroCosto
        {
            get { return (CentroCosto)this.cboCentroCosto.SelectedItem; }
            set
            {
                if (value != null)
                    this.cboCentroCosto.Text = value.ToString();
                else
                    this.cboCentroCosto.SelectedIndex = 0;
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
                if (this.CanWrite)
                    this.btnGrabar.Enabled = !value;
                if (this.CanActivate)
                    this.btnActivar.Enabled = !value;
            }
        }

        public List<Persona> DataSource
        {
            set
            {
                btnVer.Enabled = (value != null && value.Count > 0);
                btnEliminar.Enabled = (value != null && value.Count > 0);
                this.olvListado.SetObjects(value);
            }
        }

        public List<Persona> InactiveDataSource
        {
            set
            {
                btnVerEliminado.Enabled = (value != null && value.Count > 0);
                this.olvListadoInactivos.SetObjects(value);
            }
        }

        public DataSourceContainer TipoPersonaDataSource
        {
            set
            {
                this.cboTipo.DataSource = value.DataSource;
                this.cboTipo.DisplayMember = value.DataTextFieldName;
                this.cboTipo.ValueMember = value.DataValueFieldName;
            }
        }

        public List<DocumentoPersona> TipoDocumentoDataSource
        {
            set
            {
                value.Insert(0, new DocumentoPersona() { Id = 0, Nombre = "Seleccione -" });
                this.cboDocumento.DataSource = value;
            }
        }

        public List<CentroCosto> CentroCostoDataSource
        {
            set
            {
                value.Insert(0, new CentroCosto() { Id = 0, Nombre = "Seleccione -" });
                this.cboCentroCosto.DataSource = value;
            }
        }

        public int SelectId
        {
            get { return this.mSelectPersonaID; }
        }

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> ActiveAction;
        public event EventHandler<EventArgs> CancelAction;
        public event EventHandler<EventArgs> DeleteAction;
        public event EventHandler<EventArgs> FindIndexAction;
        public event EventHandler<EventArgs> NewAction;
        public event EventHandler<EventArgs> SaveAction;
        public event EventHandler<EventArgs> SelectPersona;
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Persona),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void SeleccionarItem(object sender, EventArgs e)
        {
            ObjectListView listView = sender as ObjectListView;
            Persona a = (Persona)listView.SelectedObject;
            if (a != null)
                this.mSelectPersonaID = a.Id;
        }
    }
}
