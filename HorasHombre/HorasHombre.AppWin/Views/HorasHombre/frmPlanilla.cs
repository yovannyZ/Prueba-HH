using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.HorasHombre
{
    public partial class frmPlanilla : HerenciaVisual.frmMantenimiento, IPlanillaView
    {
        PlanillaEditor mPresenter;
        int mSelectPlanillaID;
        List<Persona> listaPersona;
        List<OrdenProduccion> listaOrden;
        List<Actividad> listaActividad;
        List<CentroCosto> listaCentroCosto;
        List<Novedad> listaNovedad;
        Novedad novedadAutomatica;
        string ordenAnterior = string.Empty;
        string novedadAnterior = string.Empty;

        #region . Constructor .

        private static frmPlanilla _instance;
        public static frmPlanilla GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmPlanilla();
            _instance.BringToFront();
            return _instance;
        }

        private frmPlanilla()
        {
            InitializeComponent();
            this.ShowRemovedItem = false;
            this.btnActivar.Click += new EventHandler(this.Activar_Click);
            this.btnCancelar.Click += new EventHandler(this.Cancelar_Click);
            this.btnEliminar.Click += new EventHandler(this.Eliminar_Click);
            this.btnGrabar.Click += new EventHandler(this.Grabar_Click);
            this.btnNuevo.Click += new EventHandler(this.Nuevo_Click);
            this.btnImprimir.Click += new EventHandler(this.Imprimir_Click);
            this.btnVer.Click += new EventHandler(this.Ver_Click);
            this.btnVerEliminado.Click += new EventHandler(this.VerEliminado_Click);
            this.tcGeneral.Selecting += new TabControlCancelEventHandler(this.TabControl_Selecting);
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
                this.mPresenter = new PlanillaEditor(this);
                this.CanActivate = permiso.CanActivate;
                this.CanRead = permiso.CanRead;
                this.CanWrite = permiso.CanWrite;
                this.CanDelete = permiso.CanDelete;
                this.ShowDeletedItems = permiso.ShowDeleteItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region . IPlanillaView Members .

        public int Id
        {
            get { return 0; }
            set { }
        }

        public string NumeroPlanilla
        {
            get { return this.txtNumeroPlanilla.Text; }
            set { this.txtNumeroPlanilla.Text = value; }
        }

        public DateTime Fecha
        {
            get { return this.dtpFecha.Value; }
            set { this.dtpFecha.Value = value; }
        }

        public Sucursal Sucursal
        {
            get { return (Sucursal)this.cboSucursal.SelectedItem; }
            set
            {
                if (value != null)
                    this.cboSucursal.Text = value.ToString();
                else
                    this.cboSucursal.SelectedIndex = -1;
            }
        }

        public Area Area
        {
            get { return (Area)this.cboArea.SelectedItem; }
            set
            {
                if (value != null)
                    this.cboArea.Text = value.ToString();
                else
                    this.cboArea.SelectedIndex = -1;
            }
        }

        public Novedad NovedadAutomatica
        {
            set
            {
                this.novedadAutomatica = value;
            }
        }

        public List<PlanillaDetalle> Detalle
        {
            get
            {
                var list = new List<PlanillaDetalle>();
                PlanillaDetalle d;
                foreach (DataGridViewRow row in this.dgvAsignacion.Rows)
                {
                    d = new PlanillaDetalle();
                    d.Id = int.Parse(row.Cells[0].Value.ToString());
                    d.Persona = (Persona)row.Cells[2].Value;
                    d.Novedad = (Novedad)row.Cells[3].Value;
                    d.Inicio = DateTime.Parse(row.Cells[4].Value.ToString()).TimeOfDay;
                    d.Fin = DateTime.Parse(row.Cells[5].Value.ToString()).TimeOfDay;
                    if (d.Novedad.TipoDistribucion == TipoDistribucion.Directa)
                    {
                        d.CentroCosto = null;
                        d.RelacionActividad = BLL.OrdenProduccionActividadBL.ObtenerPorId((OrdenProduccion)row.Cells[6].Value,
                            (Actividad)row.Cells[7].Value);
                    }
                    else if (d.Novedad.TipoDistribucion == TipoDistribucion.Indirecta)
                    {
                        d.RelacionActividad = null;
                        d.CentroCosto = (CentroCosto)row.Cells[8].Value;
                    }
                    else
                    {
                        d.RelacionActividad = null;
                        d.CentroCosto = null;
                    }
                    list.Add(d);
                }
                return list;
            }
            set
            {
                this.dgvAsignacion.Rows.Clear();
                var f = new DateTime(this.Fecha.Year, this.Fecha.Month, this.Fecha.Day);
                int fila = -1;
                for (int i = 0; i < value.Count; i++)
                {
                    if (value[i].Novedad.TipoDistribucion == TipoDistribucion.Directa)
                    {
                        fila = this.dgvAsignacion.Rows.Add(value[i].Id, Properties.Resources.Delete, value[i].Persona, value[i].Novedad,
                            f + value[i].Inicio, f + value[i].Fin, value[i].RelacionActividad.OrdenProduccion,
                            value[i].RelacionActividad.Actividad, "", Properties.Resources.Delete);
                    }
                    else if (value[i].Novedad.TipoDistribucion == TipoDistribucion.Indirecta)
                        fila = this.dgvAsignacion.Rows.Add(value[i].Id, Properties.Resources.Delete, value[i].Persona,
                            value[i].Novedad, f + value[i].Inicio, f + value[i].Fin, "", "", value[i].CentroCosto,
                            Properties.Resources.Delete);
                    else
                        fila = this.dgvAsignacion.Rows.Add(value[i].Id, Properties.Resources.Delete, value[i].Persona,
                            value[i].Novedad, f + value[i].Inicio, f + value[i].Fin, "", "", "", Properties.Resources.Delete);
                    this.dgvAsignacion.Rows[fila].ReadOnly = true;
                }
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
                this.btnImprimir.Enabled = value;
            }
        }

        public List<Planilla> DataSource
        {
            set
            {
                btnVer.Enabled = (value != null && value.Count > 0);
                btnEliminar.Enabled = (this.CanDelete && value != null && value.Count > 0);
                this.olvListado.SetObjects(value);
            }
        }

        public List<Planilla> InactiveDataSource
        {
            set
            {
                btnVerEliminado.Enabled = (value != null && value.Count > 0);
                this.olvListadoInactivos.SetObjects( value);
            }
        }

        public List<Sucursal> SucursalDataSource
        {
            set
            {
                this.cboSucursal.DataSource = value;
            }
        }

        public List<Area> AreaDataSource
        {
            set
            {
                this.cboArea.DataSource = value;
            }
        }

        public List<Persona> PersonaDataSource
        {
            set
            {
                this.listaPersona = value;
                this.dgvAsignacion.Rows.Clear();
                if (value.Count == 0)
                    MessageBox.Show("No existe personal asignado a esta area", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (this.Area.EsAutomatico)
                    {
                        var f = new DateTime(this.Fecha.Year, this.Fecha.Month, this.Fecha.Day);
                        TimeSpan inicio = new TimeSpan(8, 0, 0);
                        TimeSpan fin = new TimeSpan(18, 0, 0);
                        for (int i = 0; i < value.Count; i++)
                        {
                            dgvAsignacion.Rows.Add(0, Properties.Resources.Delete, value[i], this.novedadAutomatica, f + inicio, f + fin, "", "",
                                value[i].CentroCosto, Properties.Resources.Delete);
                            this.dgvAsignacion.Rows[i].ReadOnly = false;
                            this.dgvAsignacion.Rows[i].Cells[6].ReadOnly = true;
                            this.dgvAsignacion.Rows[i].Cells[7].ReadOnly = true;
                            this.dgvAsignacion.Rows[i].Cells[8].ReadOnly = true;
                            this.dgvAsignacion.CurrentCell = this.dgvAsignacion.Rows[i].Cells[2];
                            this.dgvAsignacion.BeginEdit(true);
                        }

                    }
                }
                this.btnAgregar.Enabled = value.Count > 0;
            }
        }

        public List<OrdenProduccion> OrdenProduccionDataSource
        {
            set
            {
                this.listaOrden = value;
                if (value.Count == 0)
                    MessageBox.Show("No existen ordenes cargadas.", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public List<Actividad> ActividadDataSource
        {
            set
            {
                this.listaActividad = value;
                if (value.Count == 0)
                    MessageBox.Show("No existen actividades cargadas.", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public List<CentroCosto> CentroCostoDataSource
        {
            set
            {
                this.listaCentroCosto = value;
                if (value.Count == 0)
                    MessageBox.Show("No existen centros de costo cargados.", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public List<Novedad> NovedadDataSource
        {
            set
            {
                this.listaNovedad = value;
                if (value.Count == 0)
                    MessageBox.Show("No existen novedades cargadas.", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public int SelectId
        {
            get { return this.mSelectPlanillaID; }
        }

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> ActiveAction;
        public event EventHandler<EventArgs> CancelAction;
        public event EventHandler<EventArgs> DeleteAction;
        public event EventHandler<EventArgs> FindIndexAction;
        public event EventHandler<EventArgs> NewAction;
        public event EventHandler<EventArgs> PrintAction;
        public event EventHandler<EventArgs> SaveAction;
        public event EventHandler<EventArgs> SelectPlanilla;
        public event EventHandler<EventArgs> SelectArea;
        public event EventHandler<EventArgs> SelectOrden;
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
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
                this.cboSucursal.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (PrintAction != null)
                    PrintAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
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
                this.ClearControl(gbDatos);
                this.ActivateControl(gbDatos, true);
                this.cboSucursal.Enabled = false;
                this.cboArea.Enabled = false;
                this.txtNumeroPlanilla.Enabled = false;
                this.dtpFecha.Enabled = false;
                if (ViewAction != null)
                    ViewAction(sender, e);
                this.btnImprimir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
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
                this.cboSucursal.Enabled = false;
                this.cboArea.Enabled = false;
                this.txtNumeroPlanilla.Enabled = false;
                this.dtpFecha.Enabled = false;
                if (ViewAction != null)
                    ViewAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void SelectRow(DataGridView grid)
        {
            if (grid.RowCount > 0 && grid.CurrentRow.Index > -1)
            {
                try
                {
                    this.mSelectPlanillaID = ((Planilla)grid.Rows[grid.CurrentRow.Index].DataBoundItem).Id;
                    if (this.SelectPlanilla != null)
                        SelectPlanilla(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                        AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ActivarRegistro(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ordenar(object sender, EventArgs e)
        {
            try
            {
                if (SortAction != null)
                    SortAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscar(object sender, EventArgs e)
        {
            try
            {
                if (FindIndexAction != null)
                    FindIndexAction(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarArea(object sender, EventArgs e)
        {
            try
            {
                if (this.cboArea.SelectedIndex != -1 && this.SelectArea != null)
                    SelectArea(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarPersona(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                int rowIndex = this.dgvAsignacion.Rows.Add(0, Properties.Resources.Delete, "", "", fecha, fecha.AddHours(1),
                    "", "", "", Properties.Resources.Delete);
                this.dgvAsignacion.Rows[rowIndex].ReadOnly = false;
                this.dgvAsignacion.Rows[rowIndex].Cells[6].ReadOnly = true;
                this.dgvAsignacion.Rows[rowIndex].Cells[7].ReadOnly = true;
                this.dgvAsignacion.Rows[rowIndex].Cells[8].ReadOnly = true;
                this.dgvAsignacion.CurrentCell = this.dgvAsignacion.Rows[rowIndex].Cells[2];
                this.dgvAsignacion.BeginEdit(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FinalizarEdicionCeldaEnGrid(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int columna = e.ColumnIndex;
                object dato = this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value;
                if (dato != null)
                {
                    if (columna == 2)
                    {
                        int posGuion = dato.ToString().IndexOf("-");
                        if (posGuion != -1 && posGuion == 6)
                            dato = dato.ToString().Substring(8);
                        Persona p = this.BuscarPersona(dato.ToString());
                        if (p != null)
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = p;
                        else
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = "";
                    }
                    else if (columna == 3)
                    {
                        int posGuion = dato.ToString().IndexOf("-");
                        if (posGuion != -1 && posGuion == 3)
                            dato = dato.ToString().Substring(5);
                        Novedad n = this.BuscarNovedad(dato.ToString());
                        if (n != null)
                        {
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = n;
                            if (novedadAnterior != n.ToString())
                            {
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[6].Value = "";
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[7].Value = "";
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[8].Value = "";
                            }
                            if (n.TipoDistribucion == TipoDistribucion.Directa)
                            {
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[6].ReadOnly = false;
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[7].ReadOnly = false;
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[8].ReadOnly = true;
                            }
                            else if (n.TipoDistribucion == TipoDistribucion.Indirecta)
                            {
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[6].ReadOnly = true;
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[7].ReadOnly = true;
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[8].ReadOnly = false;
                            }
                            else if (n.TipoDistribucion == TipoDistribucion.IndirectaSinCentroCosto)
                            {
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[6].ReadOnly = true;
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[7].ReadOnly = true;
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[8].ReadOnly = true;
                            }
                        }
                        else
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = "";
                    }
                    else if (columna == 6)
                    {
                        if (string.IsNullOrEmpty(dato.ToString()))
                            return;
                        OrdenProduccion o = this.BuscarOrden(dato.ToString());
                        if (o != null)
                        {
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = o;
                            if (ordenAnterior != o.NumeroOrden)
                                this.dgvAsignacion.Rows[e.RowIndex].Cells[7].Value = "";
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[8].Value = "";

                        }
                        else
                        {
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = "";
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[7].Value = "";
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[8].Value = "";
                        }
                        if (this.SelectOrden != null)
                            SelectOrden(sender, EventArgs.Empty);
                    }
                    else if (columna == 7)
                    {
                        if (string.IsNullOrEmpty(dato.ToString()))
                            return;
                        int posGuion = dato.ToString().IndexOf("-");
                        if (posGuion != -1 && posGuion == 6)
                            dato = dato.ToString().Substring(8);
                        Actividad a = this.BuscarActividad(dato.ToString());
                        if (a != null)
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = a;
                        else
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = "";
                    }
                    else if (columna == 8)
                    {
                        if (string.IsNullOrEmpty(dato.ToString()))
                            return;
                        int posGuion = dato.ToString().IndexOf("-");
                        if (posGuion != -1 && posGuion == 6)
                            dato = dato.ToString().Substring(0, posGuion - 1);
                        CentroCosto c = this.BuscarCentroCosto(dato.ToString());
                        if (c != null)
                        {
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = c;
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[6].Value = "";
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[7].Value = "";
                        }
                        else
                        {
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = "";
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[6].Value = "";
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[7].Value = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Persona BuscarPersona(object datoBuscar)
        {
            Persona p = null;
            p = (from x in listaPersona
                 where x.Descripcion == datoBuscar.ToString()
                 select x).FirstOrDefault();
            return p;
        }

        private Novedad BuscarNovedad(object datoBuscar)
        {
            Novedad n = null;
            n = (from x in listaNovedad
                 where x.Nombre == datoBuscar.ToString()
                 select x).FirstOrDefault();
            return n;
        }

        private OrdenProduccion BuscarOrden(object datoBuscar)
        {
            OrdenProduccion o = null;
            o = (from x in listaOrden
                 where x.NumeroOrden == datoBuscar.ToString()
                 select x).FirstOrDefault();
            return o;
        }

        private Actividad BuscarActividad(object datoBuscar)
        {
            Actividad a = null;
            a = (from x in listaActividad
                 where x.Nombre == datoBuscar.ToString()
                 select x).FirstOrDefault();
            return a;
        }

        private CentroCosto BuscarCentroCosto(object datoBuscar)
        {
            CentroCosto c = null;
            c = (from x in listaCentroCosto
                 where x.Codigo == datoBuscar.ToString()
                 select x).FirstOrDefault();
            return c;
        }

        private void PresionarTecla(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = this.dgvAsignacion.CurrentCell.RowIndex;
                int colIndex = this.dgvAsignacion.CurrentCell.ColumnIndex;
                if (e.Control && e.KeyCode == Keys.F1)
                {
                    if (colIndex == 2)
                    {
                        //frmConsultaPersona frm = new frmConsultaPersona();
                        //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        //{
                        //    var p = (Persona)frm.DataContainer.CurrentRow.DataBoundItem;
                        //    this.dgvAsignacion.Rows[rowIndex].Cells[colIndex].Value = p;
                        //    this.dgvAsignacion.CurrentCell = this.dgvAsignacion.Rows[rowIndex].Cells[colIndex + 1];
                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarControlDeEdicion(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgvAsignacion.CurrentCell.ColumnIndex == 2)
                {
                    DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                    dText.KeyUp -= new KeyEventHandler(PresionarTecla);
                    dText.KeyUp += new KeyEventHandler(PresionarTecla);
                    var source = new AutoCompleteStringCollection();
                    String[] stringArray = listaPersona.Select(i => i.Descripcion).ToArray();
                    source.AddRange(stringArray);

                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodCode.AutoCompleteCustomSource = source;
                        prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }
                else if (dgvAsignacion.CurrentCell.ColumnIndex == 3)
                {
                    DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                    dText.KeyUp -= new KeyEventHandler(PresionarTecla);
                    dText.KeyUp += new KeyEventHandler(PresionarTecla);

                    novedadAnterior = dText.Text;

                    var source = new AutoCompleteStringCollection();
                    String[] stringArray = listaNovedad.Select(i => i.Nombre).ToArray();
                    source.AddRange(stringArray);

                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodCode.AutoCompleteCustomSource = source;
                        prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }
                else if (dgvAsignacion.CurrentCell.ColumnIndex == 6)
                {
                    DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                    dText.KeyUp -= new KeyEventHandler(PresionarTecla);
                    dText.KeyUp += new KeyEventHandler(PresionarTecla);

                    ordenAnterior = dText.Text;

                    var source = new AutoCompleteStringCollection();
                    String[] stringArray = listaOrden.Select(i => i.NumeroOrden).ToArray();
                    source.AddRange(stringArray);

                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodCode.AutoCompleteCustomSource = source;
                        prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }
                else if (dgvAsignacion.CurrentCell.ColumnIndex == 7)
                {
                    DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                    dText.KeyUp -= new KeyEventHandler(PresionarTecla);
                    dText.KeyUp += new KeyEventHandler(PresionarTecla);
                    if (this.listaActividad == null)
                        return;
                    var source = new AutoCompleteStringCollection();
                    String[] stringArray = this.listaActividad.Select(i => i.Nombre).ToArray();
                    source.AddRange(stringArray);

                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodCode.AutoCompleteCustomSource = source;
                        prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }
                else if (dgvAsignacion.CurrentCell.ColumnIndex == 8)
                {
                    DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                    dText.KeyUp -= new KeyEventHandler(PresionarTecla);
                    dText.KeyUp += new KeyEventHandler(PresionarTecla);
                    var source = new AutoCompleteStringCollection();
                    String[] stringArray = listaCentroCosto.Select(i => i.Codigo).ToArray();
                    source.AddRange(stringArray);

                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        prodCode.AutoCompleteCustomSource = source;
                        prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MoverMouseEnGridView(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 9)
                this.dgvAsignacion.Cursor = Cursors.Hand;
            else
                this.dgvAsignacion.Cursor = Cursors.Default;
        }

        private void LiberarMouseEnGridView(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvAsignacion.Cursor = Cursors.Default;
        }

        private void ModificarFila(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (this.dgvAsignacion.CurrentCell.ColumnIndex == 1)
                    {
                        this.dgvAsignacion.Rows[e.RowIndex].Cells[3].ReadOnly = false;
                        this.dgvAsignacion.Rows[e.RowIndex].Cells[4].ReadOnly = false;
                        this.dgvAsignacion.Rows[e.RowIndex].Cells[5].ReadOnly = false;
                        this.dgvAsignacion.CurrentCell = this.dgvAsignacion.Rows[e.RowIndex].Cells[3];
                        this.dgvAsignacion.BeginEdit(true);
                    }
                    else if (this.dgvAsignacion.CurrentCell.ColumnIndex == 9)
                    {
                        var p = this.dgvAsignacion.Rows[e.RowIndex].Cells[2].Value;
                        DialogResult rpta = MessageBox.Show(string.Format("¿Desea quitar a {0}?", p),
                            AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rpta == System.Windows.Forms.DialogResult.Yes)
                        {
                            this.dgvAsignacion.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
