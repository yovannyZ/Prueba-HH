using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HorasHombre.AppWin.Presenters
{
    public interface ILoginView
    {
        #region . Properties .

        int Id { get; set; }
        string Nick { get; set; }
        string Clave { get; set; }
        Empresa Empresa { get; set; }
        List<Empresa> EmpresaDataSource { set; }
        bool IsLogged { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> IniciarSesion;

        #endregion

    }

    public interface ILoginService
    {
        List<Usuario> ObtenerTodo();
        Usuario ObtenerPorId(int id);
    }

    public class LoginService : ILoginService
    {
        #region . Instance .

        private static LoginService mInstance = null;

        public static LoginService Instance
        {
            get { return mInstance; }
        }

        static LoginService()
        {
            mInstance = new LoginService();
        }

        #endregion

        #region . ILoginService members .

        public List<Usuario> ObtenerTodo()
        {
            List<Usuario> usuarios = UsuarioBL.ObtenerTodo();
            return usuarios;
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = UsuarioBL.ObtenerPorId(id);

            return usuario;
        }

        #endregion

    }

    public class LoginEditor
    {
        #region . variables .

        private ILoginView mView;
        private ILoginService mLoginService;
        private IEmpresaService mEmpresaService;
        private IPeriodoService mPeriodoService;
        private List<Usuario> mActives = null;

        #endregion

        public List<Usuario> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public LoginEditor(ILoginView view)
        {
            this.mView = view;
            this.mLoginService = LoginService.Instance;
            this.mEmpresaService = EmpresaService.Instance;
            this.mPeriodoService = PeriodoService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.EmpresaDataSource = this.mEmpresaService.ObtenerTodo();
            this.mView.Empresa = null;
            // Set EventHandler
            this.mView.IniciarSesion += new EventHandler<EventArgs>(mView_IniciarSesion);
            this.mView.Empresa = this.mEmpresaService.ObtenerPorId(int.Parse(Properties.Settings.Default.Empresa));
            this.mView.Nick = Properties.Settings.Default.Usuario;
        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mLoginService.ObtenerTodo().ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));
        }

        #endregion

        #region . EventHandler .

        private void mView_IniciarSesion(object sender, EventArgs e)
        {
            this.mView.IsLogged = false;
            var usuario = (from x in this.AllActive
                           where x.Nick == this.mView.Nick &&
                           x.Clave == GenericUtil.Encriptar(this.mView.Clave)
                           select x).FirstOrDefault();
            if (usuario != null)
            {
                this.mView.IsLogged = true;
                AppInfo.CurrentUser = usuario;
                AppInfo.CurrentCompany = this.mView.Empresa;
                Properties.Settings.Default.BaseDatos = AppInfo.CurrentCompany.Codigo;
                Properties.Settings.Default.Empresa = AppInfo.CurrentCompany.Id.ToString();
                Properties.Settings.Default.Usuario = AppInfo.CurrentUser.Nick;
                Properties.Settings.Default.Save();
            }
        }

        #endregion
    }
}
