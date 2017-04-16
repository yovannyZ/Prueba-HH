using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Transactions;

namespace HorasHombre.AppWin.Presenters
{
    public interface IImportarView
    {
        #region . Properties .

        List<Actividad> ListaActividad { set; get; }
        List<CentroCosto> ListaCentroCosto { set; get; }
        List<Concepto> ListaConceptoRemuneracion { get; }
        List<Concepto> ListaConceptoUtilidades { get; }
        List<Concepto> ConceptoDataSource { set; }
        List<Persona> ListaPersona { set; get; }
        List<Sucursal> ListaSucursal { set; get; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> Importar;

        #endregion

    }

    public interface IImportarService
    {
        List<Actividad> ObtenerActividades();
        List<CentroCosto> ObtenerCentroCosto();
        List<Concepto> ObtenerConceptos();
        List<Persona> ObtenerPersonas();
        List<Sucursal> ObtenerSucursales();
    }

    public class ImportarService : IImportarService
    {
        #region . Instance .

        private static ImportarService mInstance = null;

        public static ImportarService Instance
        {
            get { return mInstance; }
        }

        static ImportarService()
        {
            mInstance = new ImportarService();
        }

        #endregion

        #region . IPersonaService members .

        public List<Actividad> ObtenerActividades()
        {
            List<Actividad> actividades = ImportarBL.ObtenerActividades();
            return actividades;
        }

        public List<CentroCosto> ObtenerCentroCosto()
        {
            List<CentroCosto> centrosCosto = ImportarBL.ObtenerCentrosCosto();
            return centrosCosto;
        }

        public List<Concepto> ObtenerConceptos()
        {
            List<Concepto> conceptos = ImportarBL.ObtenerConceptos();
            return conceptos;
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> personas = ImportarBL.ObtenerPersonas();
            return personas;
        }

        public List<Sucursal> ObtenerSucursales()
        {
            List<Sucursal> sucursales = ImportarBL.ObtenerSucursales();
            return sucursales;
        }

        #endregion
    }

    public class ImportarEditor
    {
        #region . variables .

        private IImportarView mView;
        private IImportarService mImportarService;
        private IActividadService mActividadService;
        private ICentroCostoService mCentroCostoService;
        private IConceptoService mConceptoService;
        private IPersonaService mPersonaService;
        private ISucursalService mSucursalService;

        #endregion

        public ImportarEditor(IImportarView view)
        {
            this.mView = view;
            this.mImportarService = ImportarService.Instance;
            this.mActividadService = ActividadService.Instance;
            this.mCentroCostoService = CentroCostoService.Instance;
            this.mConceptoService = ConceptoService.Instance;
            this.mPersonaService = PersonaService.Instance;
            this.mSucursalService = SucursalService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            // Set EventHandler
            this.mView.Importar += new EventHandler<EventArgs>(mView_Importar);
        }

        private void LoadData()
        {
            this.mView.ListaActividad = this.mImportarService.ObtenerActividades();
            this.mView.ListaCentroCosto = this.mImportarService.ObtenerCentroCosto();
            this.mView.ConceptoDataSource = this.mImportarService.ObtenerConceptos().OrderBy(c => c.Nombre).ToList();
            this.mView.ListaPersona = this.mImportarService.ObtenerPersonas();
            this.mView.ListaSucursal = this.mImportarService.ObtenerSucursales();
        }

        #endregion

        #region . EventHandler .

        private void mView_Importar(object sender, EventArgs e)
        {
            bool exito = true;
            using (TransactionScope trx = new TransactionScope(TransactionScopeOption.Required, System.TimeSpan.MaxValue))
            {
                #region . Generar nuevos registros .

                exito = this.mActividadService.Insertar(this.mView.ListaActividad);
                if (exito)
                    exito = this.mCentroCostoService.Insertar(this.mView.ListaCentroCosto);
                if (exito)
                    exito = this.mConceptoService.Insertar(this.mView.ListaConceptoRemuneracion);
                if (exito)
                    exito = this.mConceptoService.Insertar(this.mView.ListaConceptoUtilidades);
                if (exito)
                    exito = this.mPersonaService.Insertar(this.mView.ListaPersona);
                if (exito)
                    exito = this.mSucursalService.Insertar(this.mView.ListaSucursal);

                #endregion

                if (exito)
                {
                    trx.Complete();
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Importacion, TipoLog.Informacion,
                        "Se importaron los datos");
                    LoadData();
                }
            }

        }

        #endregion
    }
}
