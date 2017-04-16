using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IUsuarioView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Nick { get; set; }
        string Clave { get; set; }
        bool EstaActivo { get; set; }
        TipoUsuario TipoUsuario { get; set; }
        List<Usuario> UsuarioDataSource { set; }
        bool IsSuccessful { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> Selectusuario;

        #endregion
    }

    public interface IUsuarioService
    {
        List<Usuario> ObtenerTodo();
        Usuario ObtenerPorId(int id);
    }

    public class UsuarioService : IUsuarioService
    {
        #region . Instance .

        private static UsuarioService mInstance = null;

        public static UsuarioService Instance
        {
            get { return mInstance; }
        }

        static UsuarioService()
        {
            mInstance = new UsuarioService();
        }

        #endregion

        #region . IusuarioService members .

        public List<Usuario> ObtenerTodo()
        {
            List<Usuario> Usuarios = UsuarioBL.ObtenerTodo();
            return Usuarios;
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = UsuarioBL.ObtenerPorId(id);
            return usuario;
        }

        #endregion

    }

    public class UsuarioEditor
    {
        #region . variables .

        private IUsuarioView mView;
        private IUsuarioService mUsuarioService;
        private List<Usuario> mActives = null;
        private Usuario mActual = null;

        #endregion

        public List<Usuario> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public UsuarioEditor(IUsuarioView view)
        {
            this.mView = view;
            this.mUsuarioService = UsuarioService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.UsuarioDataSource = this.mUsuarioService.ObtenerTodo();
        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mUsuarioService.ObtenerTodo().ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));
        }

        private void GetData()
        {
            this.mActual.Codigo = this.mView.Codigo;
            this.mActual.Nombre = this.mView.Nombre;
            this.mActual.Apellido = this.mView.Apellido;
            this.mActual.Nick = this.mView.Nick;
            this.mActual.Clave = this.mView.Clave;
            this.mActual.EstaActivo = this.mView.EstaActivo;
            this.mActual.TipoUsuario = this.mView.TipoUsuario;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.Codigo = this.mActual.Codigo;
            this.mView.Nombre = this.mActual.Nombre;
            this.mView.Apellido = this.mActual.Apellido;
            this.mView.Nick = this.mActual.Nick;
            this.mView.Clave = this.mActual.Clave;
            this.mView.EstaActivo = this.mActual.EstaActivo;
            this.mView.TipoUsuario = this.mActual.TipoUsuario;
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
