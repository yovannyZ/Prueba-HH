using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IReportePlanillaView
    {
        #region . Properties .

        string TipoReporte { get; }
        DateTime Inicio { get; }
        DateTime Fin { get; }
        bool BuscarPorPersona { get; }
        Persona Persona { get; }
        Area Area { get; }
        string NumeroPlanilla { get; }
        List<Area> AreaDataSource { set; }
        List<Persona> PersonaDataSource { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> MostrarReporte;

        #endregion

    }

    public interface IReportePlanillaService
    {
    }

    public class ReportePlanillaService : IReportePlanillaService
    {
        #region . Instance .

        private static ReportePlanillaService mInstance = null;

        public static ReportePlanillaService Instance
        {
            get { return mInstance; }
        }

        static ReportePlanillaService()
        {
            mInstance = new ReportePlanillaService();
        }

        #endregion
    }

    public class ReportePlanillaEditor
    {
        #region . variables .

        private IReportePlanillaView mView;
        private IReportePlanillaService mReportePlanillaService;
        private IAreaService mAreaService;
        private IPersonaService mPersonaService;
        private IPlanillaService mPlanillaService;

        #endregion

        public ReportePlanillaEditor(IReportePlanillaView view)
        {
            this.mView = view;
            this.mReportePlanillaService = ReportePlanillaService.Instance;
            this.mAreaService = AreaService.Instance;
            this.mPersonaService = PersonaService.Instance;
            this.mPlanillaService = PlanillaService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            // Set EventHandler
            this.mView.MostrarReporte += new EventHandler<EventArgs>(mView_MostrarReporte);
            this.mView.AreaDataSource = this.mAreaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mView.PersonaDataSource = this.mPersonaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();


        }


        #endregion

        #region . EventHandler .

        private void mView_MostrarReporte(object sender, EventArgs e)
        {
            string reporte = string.Empty;
            List<PlanillaDetalle> lista = new List<PlanillaDetalle>();
            if (this.mView.TipoReporte == "Trabajador")
            {
                List<Planilla> listaPlanilla = this.mPlanillaService.ObtenerTodo().Where(c => c.Fecha.Date >= this.mView.Inicio.Date
                    && c.Fecha.Date <= this.mView.Fin.Date).ToList();
                for (int i = 0; i < listaPlanilla.Count; i++)
                {
                    listaPlanilla[i].Detalle = this.mPlanillaService.ObtenerDetalle(listaPlanilla[i]);
                    lista.AddRange(listaPlanilla[i].Detalle);
                }
                if (this.mView.BuscarPorPersona)
                    lista = lista.Where(c => c.Persona.Id == this.mView.Persona.Id).ToList();
                reporte = "HorasHombre.AppWin.Reports.ReportViewers.rptPlanillaResumen.rdlc";
            }
            else
            {
                Planilla planilla = this.mPlanillaService.ObtenerTodo().Where(c => c.Area.Id == this.mView.Area.Id
                    && c.NumeroPlanilla == this.mView.NumeroPlanilla).FirstOrDefault();
                if (planilla != null)
                {
                    planilla.Detalle = this.mPlanillaService.ObtenerDetalle(planilla).Where(c => c.EstaActivo == true).ToList();
                    lista.AddRange(planilla.Detalle);
                }
                reporte = "HorasHombre.AppWin.Reports.ReportViewers.rptPlanillaHoras.rdlc";
            }
            if (lista.Count > 0)
            {
                Form frm = GenericUtil.CreateReport(reporte, "DSPlanilla", lista, AppInfo.CurrentCompany.Nombre,
                   AppInfo.CurrentCompany.NumeroRuc, AppInfo.CurrentUser.Nick);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("No existen datos a mostrar.", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        #endregion
    }
}
