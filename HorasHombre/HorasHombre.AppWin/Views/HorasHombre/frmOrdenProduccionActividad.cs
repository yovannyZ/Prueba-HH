using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.AppWin.Views.QueryForms;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.HorasHombre
{
    public partial class frmOrdenProduccionActividad : HerenciaVisual.frmMantenimiento, IOrdenProduccionActividadView
    {
        OrdenProduccionActividadEditor mPresenter;
        int mSelectOrdenProduccionActividadID;
        List<Actividad> listaActividad;

        #region . Constructor .

        private static frmOrdenProduccionActividad _instance;
        public static frmOrdenProduccionActividad GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmOrdenProduccionActividad();
            _instance.BringToFront();
            return _instance;
        }

        private frmOrdenProduccionActividad()
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
                this.mPresenter = new OrdenProduccionActividadEditor(this);
                Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
                this.CanRead = permiso.CanRead;
                this.CanWrite = permiso.CanWrite;
                this.CanDelete = false;
                this.ShowDeletedItems = false;
                this.btnNuevo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region . IOrdenProduccionActividadView Members .

        public OrdenProduccion OrdenProduccion
        {
            get { return (OrdenProduccion)this.cboOrdenProduccion.SelectedItem; }
            set
            {
                if (value != null)
                    this.cboOrdenProduccion.Text = value.ToString();
                else
                    this.cboOrdenProduccion.SelectedIndex = -1;
            }
        }
        public List<OrdenProduccionActividad> Asignacion
        {
            get
            {
                var list = new List<OrdenProduccionActividad>();
                foreach (DataGridViewRow row in dgvAsignacion.Rows)
                {
                    list.Add(new OrdenProduccionActividad
                    {
                        Actividad = (Actividad)row.Cells[0].Value
                    });
                }
                return list;
            }
            set
            {
                this.dgvAsignacion.Rows.Clear();
                Actividad a = null;
                foreach (var item in value)
                {
                    if (value != null && value.Count > 0)
                    {
                        a = BuscarActividad(item.Actividad.Nombre, false);
                        dgvAsignacion.Rows.Add(a, a.ActividadPrincipal, a.ActividadPrincipal.ActividadPrincipal, Properties.Resources.Delete);
                    }
                }
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

        public List<OrdenProduccion> DataSource
        {
            set
            {
                btnVer.Enabled = (value != null && value.Count > 0);
                btnEliminar.Enabled = (value != null && value.Count > 0);
                this.olvListado.SetObjects(value);
                this.cboOrdenProduccion.DataSource = value;
            }
        }

        public List<OrdenProduccion> OrdenProduccionDataSource
        {
            set
            {
                this.cboOrdenProduccion.DataSource = value;
            }
        }

        public List<Actividad> ActividadDataSource
        {
            set
            {
                //this.dgvcbActividad.DataSource = value;
                this.listaActividad = value;
            }
        }

        public int SelectId
        {
            get { return this.mSelectOrdenProduccionActividadID; }
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
        public event EventHandler<EventArgs> SelectOrdenProduccion;
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
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
                this.cboOrdenProduccion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
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
                this.cboOrdenProduccion.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
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
                    this.mSelectOrdenProduccionActividadID = ((OrdenProduccion)grid.Rows[grid.CurrentRow.Index].DataBoundItem).Id;
                    if (this.SelectOrdenProduccion != null)
                        SelectOrdenProduccion(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
                        AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ActivarRegistro(object sender, DataGridViewCellEventArgs e)
        {

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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
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
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarActivo(object sender, EventArgs e)
        {
            try
            {
                if (this.cboOrdenProduccion.SelectedIndex != -1 && this.SelectActivo != null)
                    SelectActivo(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarActividad(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = this.dgvAsignacion.Rows.Add("", "", "", Properties.Resources.Delete);
                this.dgvAsignacion.CurrentCell = this.dgvAsignacion.Rows[rowIndex].Cells[0];
                this.dgvAsignacion.BeginEdit(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FinalizarModificacionDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int columna = e.ColumnIndex;
                object dato = this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value;
                if (dato != null && !string.IsNullOrEmpty(dato.ToString()))
                {
                    if (columna == 0)
                    {
                        int posGuion = dato.ToString().IndexOf("-");
                        if (posGuion != -1 && posGuion == 6)
                            dato = dato.ToString().Substring(8);
                        Actividad p = this.BuscarActividad(dato.ToString(), false);
                        if (p != null)
                        {
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = p;
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[1].Value = p.ActividadPrincipal;
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[2].Value = p.ActividadPrincipal.ActividadPrincipal;
                        }
                        else
                        {
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[columna].Value = "";
                            this.dgvAsignacion.Rows[e.RowIndex].Cells[1].Value = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Actividad BuscarActividad(object datoBuscar, bool buscarPadre)
        {
            Actividad p = null;
            if (!buscarPadre)
            {
                p = (from x in listaActividad
                     where x.Nombre == datoBuscar.ToString()
                     select x).FirstOrDefault();
                p.ActividadPrincipal = BuscarActividad(p.ActividadPrincipal.Id, true);
                p.ActividadPrincipal.ActividadPrincipal = BuscarActividad(p.ActividadPrincipal.ActividadPrincipal.Id, true);
            }
            else
            {
                p = (from x in listaActividad
                     where x.Id == int.Parse(datoBuscar.ToString())
                     select x).FirstOrDefault();
            }
            return p;
        }

        private void PresionarTecla(object sender, KeyEventArgs e)
        {
            try
            {
                int rowIndex = this.dgvAsignacion.CurrentCell.RowIndex;
                int colIndex = this.dgvAsignacion.CurrentCell.ColumnIndex;
                if (e.Control && e.KeyCode == Keys.F1)
                {
                    if (colIndex == 0)
                    {
                        //frmConsultaActividad frm = new frmConsultaActividad();
                        //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        //{
                        //    var p = (Actividad)frm.DataContainer.CurrentRow.DataBoundItem;
                        //    this.dgvAsignacion.Rows[rowIndex].Cells[colIndex].Value = p;
                        //    this.dgvAsignacion.CurrentCell = this.dgvAsignacion.Rows[rowIndex].Cells[colIndex + 1];
                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAsignacion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;
                dText.KeyUp -= new KeyEventHandler(PresionarTecla);
                dText.KeyUp += new KeyEventHandler(PresionarTecla);

                if (dgvAsignacion.CurrentCell.ColumnIndex == 0)
                {
                    if (listaActividad != null)
                    {
                        var source = new AutoCompleteStringCollection();
                        String[] stringArray = listaActividad.Where(c => c.Nivel == 3).Select(i => i.Nombre).ToArray();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuitarFila(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvAsignacion.CurrentCell.ColumnIndex == 3)
                {
                    var cc = this.dgvAsignacion.Rows[e.RowIndex].Cells[0].Value;
                    DialogResult rpta = MessageBox.Show(string.Format("¿Desea eliminar quitar a {0}?", cc),
                        AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rpta == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.dgvAsignacion.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MoverMouseEnGridView(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
                this.dgvAsignacion.Cursor = Cursors.Hand;
            else
                this.dgvAsignacion.Cursor = Cursors.Default;
        }

        private void LiberarMouseEnGridView(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvAsignacion.Cursor = Cursors.Default;
        }
    }
}
