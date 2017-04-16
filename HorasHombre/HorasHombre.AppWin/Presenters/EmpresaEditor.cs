using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IEmpresaView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        List<Empresa> EmpresaDataSource { set; }
        bool IsSuccessful { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> SelectCargo;

        #endregion
    }

    public interface IEmpresaService
    {
        List<Empresa> ObtenerTodo();
        Empresa ObtenerPorId(int id);
    }

    public class EmpresaService : IEmpresaService
    {
        #region . Instance .

        private static EmpresaService mInstance = null;

        public static EmpresaService Instance
        {
            get { return mInstance; }
        }

        static EmpresaService()
        {
            mInstance = new EmpresaService();
        }

        #endregion

        #region . ICargoService members .

        public List<Empresa> ObtenerTodo()
        {
            List<Empresa> empresas = EmpresaBL.ObtenerTodo();
            return empresas;
        }

        public Empresa ObtenerPorId(int id)
        {
            Empresa cargo = EmpresaBL.ObtenerPorId(id);
            return cargo;
        }

        #endregion

    }

    public class EmpresaEditor
    {
        #region . variables .

        private IEmpresaView mView;
        private IEmpresaService mEmpresaService;
        private List<Empresa> mActives = null;
        private Empresa mActual = null;

        #endregion

        public List<Empresa> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public EmpresaEditor(IEmpresaView view)
        {
            this.mView = view;
            this.mEmpresaService = EmpresaService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.EmpresaDataSource = this.mEmpresaService.ObtenerTodo();
        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mEmpresaService.ObtenerTodo().ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));
        }

        private void GetData()
        {
            this.mActual.Codigo = this.mView.Codigo;
            this.mActual.Nombre = this.mView.Nombre;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.Codigo = this.mActual.Codigo;
            this.mView.Nombre = this.mActual.Nombre;
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
