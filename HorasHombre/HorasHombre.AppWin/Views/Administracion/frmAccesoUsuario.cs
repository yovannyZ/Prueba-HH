using BrightIdeasSoftware;
using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.AppWin.Views.QueryForms;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace HorasHombre.AppWin.Views.Administracion
{
    public partial class frmAccesoUsuario : HerenciaVisual.frmMantenimiento, IAccesoUsuarioView
    {
        AccesoUsuarioEditor mPresenter;
        int mSelectAccesoUsuarioID;

        #region . Constructor .

        private static frmAccesoUsuario _instance;
        public static frmAccesoUsuario GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmAccesoUsuario();
            _instance.BringToFront();
            return _instance;
        }

        private frmAccesoUsuario()
        {
            InitializeComponent();
            this.ShowRemovedItem = false;
            this.dgvModuloAsignado.AutoGenerateColumns = false;
            this.dgvModuloDisponible.AutoGenerateColumns = false;
            this.dgvMenuAsignado.AutoGenerateColumns = false;
            this.dgvMenuDisponible.AutoGenerateColumns = false;
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
                this.mPresenter = new AccesoUsuarioEditor(this);
                Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
                this.CanRead = permiso.CanRead;
                this.CanWrite = permiso.CanWrite;
                this.CanDelete = false;
                this.ShowDeletedItems = false;
                this.btnNuevo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region . IAccesoUsuarioView Members .

        public Usuario Usuario
        {
            get { return (Usuario)this.cboUsuario.SelectedItem; }
            set
            {
                if (value != null)
                    this.cboUsuario.Text = value.ToString();
                else
                    this.cboUsuario.SelectedIndex = -1;
            }
        }
        public List<UsuarioModulo> AsignacionModulo
        {
            get
            {
                var lista = new List<UsuarioModulo>();
                for (int i = 0; i < this.dgvModuloAsignado.RowCount; i++)
                {
                    lista.Add(new UsuarioModulo
                    {
                        Usuario = (Usuario)this.cboUsuario.SelectedItem,
                        Modulo = ReflectionUtil.GetEnumValueFromTittle<Modulo>(this.dgvModuloAsignado.Rows[i].Cells[0].Value.ToString())
                    });
                }
                return lista;
            }
            set
            {
                this.dgvModuloAsignado.Rows.Clear();
                for (int i = 0; i < value.Count; i++)
                    this.dgvModuloAsignado.Rows.Add(ReflectionUtil.GetEnumTittleAttribute(value[i].Modulo));
                VerificarEstadoBotones();
            }
        }

        public List<UsuarioMenu> AsignacionMenu
        {
            get
            {
                var lista = new List<UsuarioMenu>();
                UsuarioMenu um;
                for (int i = 0; i < this.dgvMenuAsignado.RowCount; i++)
                {
                    um = new UsuarioMenu();
                    um.Usuario = (Usuario)this.cboUsuario.SelectedItem;
                    um.Menu = (MenuSistema)this.dgvMenuAsignado.Rows[i].Cells[0].Value;
                    um.PuedeLeer = bool.Parse(this.dgvMenuAsignado.Rows[i].Cells[1].Value.ToString());
                    um.PuedeEscribir = bool.Parse(this.dgvMenuAsignado.Rows[i].Cells[2].Value.ToString());
                    um.PuedeEliminar = bool.Parse(this.dgvMenuAsignado.Rows[i].Cells[3].Value.ToString());
                    um.PuedeActivar = bool.Parse(this.dgvMenuAsignado.Rows[i].Cells[4].Value.ToString());
                    um.PuedeVer = bool.Parse(this.dgvMenuAsignado.Rows[i].Cells[5].Value.ToString());

                    lista.Add(um);
                }
                return lista;
            }
            set
            {
                this.dgvMenuAsignado.Rows.Clear();
                for (int i = 0; i < value.Count; i++)
                    this.dgvMenuAsignado.Rows.Add(value[i].Menu, value[i].PuedeLeer, value[i].PuedeEscribir,
                        value[i].PuedeEliminar, value[i].PuedeActivar, value[i].PuedeVer);
                VerificarEstadoBotones();
            }
        }

        public List<UsuarioArea> AsignacionArea
        {
            get
            {
                var lista = new List<UsuarioArea>();
                UsuarioArea ua;
                for (int i = 0; i < this.dgvAreaAsignado.RowCount; i++)
                {
                    ua = new UsuarioArea();
                    ua.Usuario = (Usuario)this.cboUsuario.SelectedItem;
                    ua.Area = (Area)this.dgvAreaAsignado.Rows[i].Cells[0].Value;
                    lista.Add(ua);
                }
                return lista;
            }
            set
            {
                this.dgvAreaAsignado.Rows.Clear();
                for (int i = 0; i < value.Count; i++)
                    this.dgvAreaAsignado.Rows.Add(value[i].Area);
                VerificarEstadoBotones();
            }
        }

        public List<UsuarioSucursal> AsignacionSucursal
        {
            get
            {
                var lista = new List<UsuarioSucursal>();
                UsuarioSucursal ua;
                for (int i = 0; i < this.dgvSucursalAsignado.RowCount; i++)
                {
                    ua = new UsuarioSucursal();
                    ua.Usuario = (Usuario)this.cboUsuario.SelectedItem;
                    ua.Sucursal = (Sucursal)this.dgvSucursalAsignado.Rows[i].Cells[0].Value;
                    lista.Add(ua);
                }
                return lista;
            }
            set
            {
                this.dgvSucursalAsignado.Rows.Clear();
                for (int i = 0; i < value.Count; i++)
                    this.dgvSucursalAsignado.Rows.Add(value[i].Sucursal);
                VerificarEstadoBotones();
            }
        }

        public bool EstaActivo
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

        public List<Usuario> DataSource
        {
            set
            {
                btnVer.Enabled = (value != null && value.Count > 0);
                btnEliminar.Enabled = (value != null && value.Count > 0);
                this.olvListado.SetObjects(value);
                this.cboUsuario.DataSource = value;
            }
        }

        public List<Usuario> UsuarioDataSource
        {
            set
            {
                this.cboUsuario.DataSource = value;
            }
        }

        public List<string> ModuloDisponible
        {
            set
            {
                this.dgvModuloDisponible.Rows.Clear();
                for (int i = 0; i < value.Count; i++)
                    this.dgvModuloDisponible.Rows.Add(value[i]);
                VerificarEstadoBotones();
            }
        }

        public List<MenuSistema> MenuDisponible
        {
            set
            {
                this.dgvMenuDisponible.Rows.Clear();
                for (int i = 0; i < value.Count; i++)
                    this.dgvMenuDisponible.Rows.Add(value[i]);
                VerificarEstadoBotones();
            }
        }

        public List<Area> AreaDisponible
        {
            set
            {
                this.dgvAreaDisponible.Rows.Clear();
                for (int i = 0; i < value.Count; i++)
                    this.dgvAreaDisponible.Rows.Add(value[i]);
                VerificarEstadoBotones();
            }
        }

        public List<Sucursal> SucursalDisponible
        {
            set
            {
                this.dgvSucursalDisponible.Rows.Clear();
                for (int i = 0; i < value.Count; i++)
                    this.dgvSucursalDisponible.Rows.Add(value[i]);
                VerificarEstadoBotones();
            }
        }

        public int SelectId
        {
            get { return this.mSelectAccesoUsuarioID; }
        }

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> ActiveAction;
        public event EventHandler<EventArgs> CancelAction;
        public event EventHandler<EventArgs> DeleteAction;
        public event EventHandler<EventArgs> FindIndexAction;
        public event EventHandler<EventArgs> NewAction;
        public event EventHandler<EventArgs> SaveAction;
        public event EventHandler<EventArgs> SelectActivo;
        public event EventHandler<EventArgs> SelectUsuario;
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
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
                this.cboUsuario.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
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
                if (ViewAction != null)
                    ViewAction(sender, e);
                this.cboUsuario.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void ActivarRegistro(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SeleccionarActivo(object sender, EventArgs e)
        {
            try
            {
                if (this.cboUsuario.SelectedIndex != -1 && this.SelectActivo != null)
                    SelectActivo(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.AccesoUsuario),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerificarEstadoBotones()
        {
            this.btnAgregarModulo.Enabled = this.dgvModuloDisponible.RowCount > 0;
            this.btnAgregarTodosModulo.Enabled = this.dgvModuloDisponible.RowCount > 0;
            this.btnQuitarModulo.Enabled = this.dgvModuloAsignado.RowCount > 0;
            this.btnQuitarTodosModulo.Enabled = this.dgvModuloAsignado.RowCount > 0;

            this.btnAgregarMenu.Enabled = this.dgvMenuDisponible.RowCount > 0;
            this.btnAgregarTodosMenu.Enabled = this.dgvMenuDisponible.RowCount > 0;
            this.btnQuitarMenu.Enabled = this.dgvMenuAsignado.RowCount > 0;
            this.btnQuitarTodosMenu.Enabled = this.dgvMenuAsignado.RowCount > 0;
        }

        private void AgregarUno(object sender, EventArgs e)
        {
            string modulo = ((Button)sender).Tag.ToString();
            string gridOrigen = string.Format("dgv{0}Disponible", modulo);
            string gridDestino = string.Format("dgv{0}Asignado", modulo);
            DataGridView origen = this.Controls.Find(gridOrigen, true).FirstOrDefault() as DataGridView;
            DataGridView destino = this.Controls.Find(gridDestino, true).FirstOrDefault() as DataGridView;

            DataGridViewRow fila = origen.CurrentRow;
            if (gridDestino == "dgvMenuAsignado")
                destino.Rows.Add(fila.Cells[0].Value, false, false, false, false, false);
            else
                destino.Rows.Add(fila.Cells[0].Value);
            origen.Rows.Remove(fila);
            VerificarEstadoBotones();
        }

        private void AgregarTodos(object sender, EventArgs e)
        {
            string modulo = ((Button)sender).Tag.ToString();
            string gridOrigen = string.Format("dgv{0}Disponible", modulo);
            string gridDestino = string.Format("dgv{0}Asignado", modulo);
            DataGridView origen = this.Controls.Find(gridOrigen, true).FirstOrDefault() as DataGridView;
            DataGridView destino = this.Controls.Find(gridDestino, true).FirstOrDefault() as DataGridView;

            for (int i = 0; i < origen.RowCount; i++)
                destino.Rows.Add(origen.Rows[i].Cells[0].Value);
            origen.Rows.Clear();
            VerificarEstadoBotones();
        }

        private void QuitarUno(object sender, EventArgs e)
        {
            string modulo = ((Button)sender).Tag.ToString();
            string gridOrigen = string.Format("dgv{0}Asignado", modulo);
            string gridDestino = string.Format("dgv{0}Disponible", modulo);
            DataGridView origen = this.Controls.Find(gridOrigen, true).FirstOrDefault() as DataGridView;
            DataGridView destino = this.Controls.Find(gridDestino, true).FirstOrDefault() as DataGridView;

            DataGridViewRow fila = origen.CurrentRow;
            destino.Rows.Add(fila.Cells[0].Value);
            origen.Rows.Remove(fila);
            VerificarEstadoBotones();
        }

        private void QuitarTodos(object sender, EventArgs e)
        {
            string modulo = ((Button)sender).Tag.ToString();
            string gridOrigen = string.Format("dgv{0}Asignado", modulo);
            string gridDestino = string.Format("dgv{0}Disponible", modulo);
            DataGridView origen = this.Controls.Find(gridOrigen, true).FirstOrDefault() as DataGridView;
            DataGridView destino = this.Controls.Find(gridDestino, true).FirstOrDefault() as DataGridView;

            for (int i = 0; i < origen.RowCount; i++)
                destino.Rows.Add(origen.Rows[i].Cells[0].Value);
            origen.Rows.Clear();
            VerificarEstadoBotones();
        }

        public override void SeleccionarItem(object sender, EventArgs e)
        {
            ObjectListView listView = sender as ObjectListView;
            Usuario a = (Usuario)listView.SelectedObject;
            if (a != null)
                this.mSelectAccesoUsuarioID = a.Id;
        }
    }
}
