using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IPlanillaView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string NumeroPlanilla { get; set; }
        DateTime Fecha { get; set; }
        Sucursal Sucursal { get; set; }
        Area Area { get; set; }
        Novedad NovedadAutomatica { set; }
        List<PlanillaDetalle> Detalle { get; set; }
        bool Activo { get; set; }
        List<Planilla> DataSource { set; }
        List<Area> AreaDataSource { set; }
        List<Sucursal> SucursalDataSource { set; }
        List<Persona> PersonaDataSource { set; }
        List<OrdenProduccion> OrdenProduccionDataSource { set; }
        List<Actividad> ActividadDataSource { set; }
        List<CentroCosto> CentroCostoDataSource { set; }
        List<Novedad> NovedadDataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> PrintAction;
        event EventHandler<EventArgs> SelectArea;
        event EventHandler<EventArgs> SelectOrden;

        #endregion
    }

    public interface IPlanillaService
    {
        List<Planilla> ObtenerTodo();
        Planilla ObtenerPorId(int id);
        List<PlanillaDetalle> ObtenerDetalle(Planilla planilla);
        bool Insertar(Planilla planilla);
        bool Actualizar(Planilla planilla);
        bool Eliminar(int id);
        //bool Activar(int id);
    }

    public class PlanillaService : IPlanillaService
    {
        #region . Instance .

        private static PlanillaService mInstance = null;

        public static PlanillaService Instance
        {
            get { return mInstance; }
        }

        static PlanillaService()
        {
            mInstance = new PlanillaService();
        }

        #endregion

        #region . IPlanillaService members .

        public List<Planilla> ObtenerTodo()
        {
            List<Planilla> planillas = PlanillaBL.ObtenerTodo();
            return planillas;
        }

        public Planilla ObtenerPorId(int id)
        {
            Planilla planilla = PlanillaBL.ObtenerPorId(id);
            return planilla;
        }

        public List<PlanillaDetalle> ObtenerDetalle(Planilla planilla)
        {
            List<PlanillaDetalle> detalle = PlanillaBL.ObtenerDetalle(planilla);
            return detalle;
        }

        public bool Insertar(Planilla planilla)
        {
            return PlanillaBL.Insertar(planilla);
        }

        public bool Actualizar(Planilla planilla)
        {
            return PlanillaBL.Actualizar(planilla);
        }

        public bool Eliminar(int id)
        {
            return PlanillaBL.Eliminar(id);
        }

        #endregion

    }

    public class PlanillaEditor
    {
        #region . variables .

        private IPlanillaView mView;
        private IPlanillaService mPlanillaService;
        private IAreaService mAreaService;
        private ISucursalService mSucursalService;
        private IPersonaService mPersonaService;
        private IOrdenProduccionService mOrdenProduccionService;
        private IActividadService mActividadService;
        private ICentroCostoService mCentroCostoService;
        private INovedadService mNovedadService;
        private IConfiguracionService mConfiguracionService;
        private INumeracionService mNumeracionService;
        private List<Planilla> mActives = null;
        private Planilla mActual;
        private Planilla mOld;
        private string mTipoOrdenActivo;

        #endregion

        public List<Planilla> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public PlanillaEditor(IPlanillaView view)
        {
            this.mView = view;
            this.mPlanillaService = PlanillaService.Instance;
            this.mAreaService = AreaService.Instance;
            this.mSucursalService = SucursalService.Instance;
            this.mPersonaService = PersonaService.Instance;
            this.mOrdenProduccionService = OrdenProduccionService.Instance;
            this.mActividadService = ActividadService.Instance;
            this.mCentroCostoService = CentroCostoService.Instance;
            this.mNovedadService = NovedadService.Instance;
            this.mConfiguracionService = ConfiguracionService.Instance;
            this.mNumeracionService = NumeracionService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.DataSource = this.mPlanillaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mView.AreaDataSource = this.mAreaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mView.SucursalDataSource = this.mSucursalService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mView.OrdenProduccionDataSource = this.mOrdenProduccionService.ObtenerTodo().
                Where(c => c.FechaCierre == new DateTime(1900, 1, 1) ||
                    (c.FechaCierre.Year == AppInfo.CurrentPeriod.FechaInicio.Year && c.FechaCierre.Month == AppInfo.CurrentPeriod.FechaInicio.Month)).ToList();
            this.mView.CentroCostoDataSource = this.mCentroCostoService.ObtenerTodo().Where(c => c.EstaActivo == true && c.Codigo.Length == 5).ToList();
            this.mView.NovedadDataSource = this.mNovedadService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            // Set EventHandler
            this.mView.CancelAction += new EventHandler<EventArgs>(mView_Cancel);
            this.mView.DeleteAction += new EventHandler<EventArgs>(mView_Delete);
            this.mView.NewAction += new EventHandler<EventArgs>(mView_New);
            this.mView.PrintAction += new EventHandler<EventArgs>(mView_Print);
            this.mView.SaveAction += new EventHandler<EventArgs>(mView_Save);
            this.mView.SelectArea += new EventHandler<EventArgs>(mview_SelectArea);
            this.mView.SelectOrden += new EventHandler<EventArgs>(mview_SelectOrden);
            this.mView.SelectingTabAction += mview_ValidateTab;
            this.mView.ViewAction += new EventHandler<EventArgs>(mView_View);

        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mPlanillaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mActives.Sort((e, e1) => e.NumeroPlanilla.CompareTo(e1.NumeroPlanilla));
            this.mView.DataSource = this.AllActive;
        }

        private void GetData()
        {
            this.mActual.Sucursal = this.mView.Sucursal;
            this.mActual.Area = this.mView.Area;
            this.mActual.Fecha = this.mView.Fecha;
            this.mActual.NumeroPlanilla = this.mView.NumeroPlanilla;
            this.mActual.Detalle = this.mView.Detalle;
        }

        private void SetData()
        {
            this.mView.Sucursal = this.mActual.Sucursal;
            this.mView.Area = this.mActual.Area;
            this.mView.Fecha = this.mActual.Fecha;
            this.mView.NumeroPlanilla = this.mActual.NumeroPlanilla;
            this.mView.Detalle = this.mActual.Detalle;
        }

        private void Insertar(ref bool successful, ref string message)
        {
            this.mActual.EstaActivo = true;
            this.mActual.Periodo = AppInfo.CurrentPeriod;
            this.mActual.Usuario = AppInfo.CurrentUser;
            successful = this.mPlanillaService.Insertar(this.mActual);
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.HorasHombre, TipoObjeto.Planilla, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            //var tr = object.Equals(this.mOld, this.mCurrent);
            successful = this.mPlanillaService.Actualizar(this.mActual);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.HorasHombre, TipoObjeto.Planilla, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()), changes);
        }

        #endregion

        #region . EventHandler .

        private void mView_Cancel(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mActual = this.mOld;
        }

        private void mView_Delete(object sender, EventArgs e)
        {
        }

        private void mview_KeyPressPlanilla(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
                mView_New(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.Escape)
                mView_Cancel(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.F2)
                mView_View(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.Delete)
                mView_Delete(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.F6)
                mView_Save(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void mView_New(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mOld = this.mActual;
            this.mActual = new Planilla();
            SetData();
        }

        private void mView_Print(object sender, EventArgs e)
        {
            string reporte = string.Empty;
            reporte = "HorasHombre.AppWin.Reports.ReportViewers.rptPlanillaHoras.rdlc";
            var lista = this.mActual.Detalle;
            Form frm = GenericUtil.CreateReport(reporte, "DSPlanilla", lista, AppInfo.CurrentCompany.Nombre,
                AppInfo.CurrentCompany.NumeroRuc, AppInfo.CurrentUser.Nick);

            frm.ShowDialog();
        }

        private void mView_Save(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro de guardar los cambios?", AppInfo.Tittle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                string message = string.Empty;
                GetData();
                if (this.mActual.Detalle.Count == 0)
                {
                    MessageBox.Show("No existen detalles para grabar.", AppInfo.Tittle,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.mActual.Id != 0)
                {
                    string changes = ReflectionUtil.GetChangesFromObjects((object)this.mOld,
                       (object)this.mActual);

                    Actualizar(changes, ref successful, ref message);
                }
                else
                {
                    Insertar(ref successful, ref message);
                }

                if (successful)
                {
                    MessageBox.Show("Los cambios se realizaron correctamente", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    LoadData();
                    this.mActual.Detalle = mPlanillaService.ObtenerDetalle(this.mActual).Where(c => c.EstaActivo == true).ToList();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SetData();
            }
        }

        private void mview_SelectArea(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            Area area = (Area)cb.SelectedItem;
            if (area != null && area.EsAutomatico)
            {
                var configuracion = this.mConfiguracionService.ObtenerPorCodigo("DFNOV");
                if (configuracion != null)
                    this.mView.NovedadAutomatica = this.mNovedadService.ObtenerPorCodigo(configuracion.Valor);
            }
            this.mView.PersonaDataSource = this.mPersonaService.ObtenerTodoPorArea(area).Where(c => c.EstaActivo == true).ToList();
            var n = this.mNumeracionService.ObtenerPorId(area);
            if (n != null)
                this.mView.NumeroPlanilla = n.NumeroCorrelativo;
        }

        private void mview_SelectOrden(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            OrdenProduccion orden = new OrdenProduccion();
            if (dgv.CurrentCell.Value != null && !string.IsNullOrEmpty(dgv.CurrentCell.Value.ToString()))
                orden = (OrdenProduccion)dgv.CurrentCell.Value;
            //this.mView.ActividadDataSource = this.mActividadService.ObtenerTodoPorOrden(orden).Where(c => c.EstaActivo == true).ToList();
        }

        private void mview_ValidateTab(object sender, TabControlCancelEventArgs e)
        {
            TabPage tp = e.TabPage;
            if (e.TabPage.Name == "tpDatos" && !this.mView.IsEditing)
                e.Cancel = true;
            else if (e.TabPage.Name != "tpDatos" && this.mView.IsEditing)
                e.Cancel = true;
        }

        private void mView_View(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mActual = this.mPlanillaService.ObtenerPorId(this.mView.SelectId);
            if (this.mActual != null)
                this.mActual.Detalle = mPlanillaService.ObtenerDetalle(this.mActual).Where(c => c.EstaActivo == true).ToList();
            this.mOld = GenericEntityAction<Planilla>.Clone(this.mActual);
            SetData();
        }

        #endregion

    }
}
