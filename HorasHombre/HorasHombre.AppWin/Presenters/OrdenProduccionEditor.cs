using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HorasHombre.AppWin.Presenters
{
    public interface IOrdenProduccionView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string NumeroOrden { get; set; }
        DateTime FechaCierre { get; set; }
        List<OrdenProduccion> OrdenProduccionDataSource { set; }
        bool IsSuccessful { set; }

        #endregion

    }

    public interface IOrdenProduccionService
    {
        List<OrdenProduccion> ObtenerTodo();
        OrdenProduccion ObtenerPorId(int id);
    }

    public class OrdenProduccionService : IOrdenProduccionService
    {
        #region . Instance .

        private static OrdenProduccionService mInstance = null;

        public static OrdenProduccionService Instance
        {
            get { return mInstance; }
        }

        static OrdenProduccionService()
        {
            mInstance = new OrdenProduccionService();
        }

        #endregion

        #region . ICargoService members .

        public List<OrdenProduccion> ObtenerTodo()
        {
            List<OrdenProduccion> OrdenProducciones = OrdenProduccionBL.ObtenerTodo();
            return OrdenProducciones;
        }

        public OrdenProduccion ObtenerPorId(int id)
        {
            OrdenProduccion cargo = OrdenProduccionBL.ObtenerPorId(id);
            return cargo;
        }

        #endregion

    }

    public class OrdenProduccionEditor
    {
        #region . variables .

        private IOrdenProduccionView mView;
        private IOrdenProduccionService mOrdenProduccionService;
        private List<OrdenProduccion> mActives = null;
        private OrdenProduccion mActual = null;

        #endregion

        public List<OrdenProduccion> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public OrdenProduccionEditor(IOrdenProduccionView view)
        {
            this.mView = view;
            this.mOrdenProduccionService = OrdenProduccionService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.OrdenProduccionDataSource = this.mOrdenProduccionService.ObtenerTodo();
        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mOrdenProduccionService.ObtenerTodo().ToList();
            this.mActives.Sort((e, e1) => e.NumeroOrden.CompareTo(e1.NumeroOrden));
        }

        private void GetData()
        {
            this.mActual.NumeroOrden = this.mView.NumeroOrden;
            this.mActual.FechaCierre = this.mView.FechaCierre;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.NumeroOrden = this.mActual.NumeroOrden;
            this.mView.FechaCierre = this.mActual.FechaCierre;
        }

        #endregion

        #region . EventHandler .

        private void mView_Cancel(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
        }

        private void mView_View(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
