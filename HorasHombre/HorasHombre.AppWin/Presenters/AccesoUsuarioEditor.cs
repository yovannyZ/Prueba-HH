using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IAccesoUsuarioView : IMethodProvider
    {
        #region . Properties .

        Usuario Usuario { get; set; }
        List<UsuarioModulo> AsignacionModulo { get; set; }
        List<UsuarioMenu> AsignacionMenu { get; set; }
        List<UsuarioArea> AsignacionArea { get; set; }
        List<UsuarioSucursal> AsignacionSucursal { get; set; }
        List<Usuario> DataSource { set; }
        List<string> ModuloDisponible { set; }
        List<MenuSistema> MenuDisponible { set; }
        List<Area> AreaDisponible { set; }
        List<Sucursal> SucursalDisponible { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> SelectActivo;

        #endregion
    }

    public interface IAccesoUsuarioService
    {
        List<UsuarioModulo> ObtenerAccesoModulo(Usuario usuario);
        List<UsuarioMenu> ObtenerAccesoMenu(Usuario usuario);
        List<UsuarioArea> ObtenerAccesoArea(Usuario usuario);
        List<UsuarioSucursal> ObtenerAccesoSucursal(Usuario usuario);
        bool InsertarAccesoUsuario(Usuario usuario);
        //bool InsertarAccesoMenu(List<UsuarioMenu> asignacion);
        //bool InsertarAccesoArea(List<UsuarioArea> asignacion);
        //bool InsertarAccesoSucursal(List<UsuarioSucursal> asignacion);
        //bool EliminarAccesoModulo(Usuario usuario);
        //bool EliminarAccesoMenu(Usuario usuario);
        //bool EliminarAccesoArea(Usuario usuario);
        //bool EliminarAccesoSucursal(Usuario usuario);
    }

    public class AccesoUsuarioService : IAccesoUsuarioService
    {
        #region . Instance .

        private static AccesoUsuarioService mInstance = null;

        public static AccesoUsuarioService Instance
        {
            get { return mInstance; }
        }

        static AccesoUsuarioService()
        {
            mInstance = new AccesoUsuarioService();
        }

        #endregion

        #region . IUsuarioModuloService members .

        public List<UsuarioModulo> ObtenerAccesoModulo(Usuario usuario)
        {
            List<UsuarioModulo> UsuarioModulos = UsuarioModuloBL.ObtenerTodo(usuario);
            return UsuarioModulos;
        }
        public List<UsuarioMenu> ObtenerAccesoMenu(Usuario usuario)
        {
            List<UsuarioMenu> usuarioMenu = UsuarioMenuBL.ObtenerTodo(usuario);
            return usuarioMenu;
        }
        public List<UsuarioArea> ObtenerAccesoArea(Usuario usuario)
        {
            List<UsuarioArea> usuarioArea = UsuarioAreaBL.ObtenerTodo(usuario);
            return usuarioArea;
        }
        public List<UsuarioSucursal> ObtenerAccesoSucursal(Usuario usuario)
        {
            List<UsuarioSucursal> usuarioSucursal = UsuarioSucursalBL.ObtenerTodo(usuario);
            return usuarioSucursal;
        }

        public bool InsertarAccesoUsuario(Usuario usuario)
        {
            return AccesoUsuarioBL.Insertar(usuario);
        }
        //public bool InsertarAccesoMenu(List<UsuarioMenu> listaUsuarioMenu)
        //{
        //    return UsuarioMenuBL.Insertar(listaUsuarioMenu);
        //}
        //public bool InsertarAccesoArea(List<UsuarioArea> listaUsuarioArea)
        //{
        //    return UsuarioAreaBL.Insertar(listaUsuarioArea);
        //}
        //public bool InsertarAccesoSucursal(List<UsuarioSucursal> listaUsuarioSucursal)
        //{
        //    return UsuarioSucursalBL.Insertar(listaUsuarioSucursal);
        //}

        //public bool EliminarAccesoModulo(Usuario usuario)
        //{
        //    return UsuarioModuloBL.Eliminar(usuario);
        //}
        //public bool EliminarAccesoMenu(Usuario usuario)
        //{
        //    return UsuarioMenuBL.Eliminar(usuario);
        //}
        //public bool EliminarAccesoArea(Usuario usuario)
        //{
        //    return UsuarioAreaBL.Eliminar(usuario);
        //}
        //public bool EliminarAccesoSucursal(Usuario usuario)
        //{
        //    return UsuarioSucursalBL.Eliminar(usuario);
        //}

        #endregion
    }

    public class AccesoUsuarioEditor
    {
        #region . variables .

        private IAccesoUsuarioView mView;
        private IAccesoUsuarioService mAccesoUsuarioService;
        private IUsuarioService mUsuarioService;
        private IMenuSistemaService mMenuSistemaService;
        private IAreaService mAreaService;
        private ISucursalService mSucursalService;
        private List<Usuario> mActives = null;
        private Usuario mActual;
        private Usuario mOld;
        private string mTipoOrdenActivo;

        #endregion

        public List<Usuario> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public AccesoUsuarioEditor(IAccesoUsuarioView view)
        {
            this.mView = view;
            this.mAccesoUsuarioService = AccesoUsuarioService.Instance;
            this.mUsuarioService = UsuarioService.Instance;
            this.mMenuSistemaService = MenuSistemaService.Instance;
            this.mAreaService = AreaService.Instance;
            this.mSucursalService = SucursalService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.DataSource = this.mUsuarioService.ObtenerTodo().ToList();
            // Set EventHandler
            this.mView.CancelAction += new EventHandler<EventArgs>(mView_Cancel);
            this.mView.DeleteAction += new EventHandler<EventArgs>(mView_Delete);
            this.mView.NewAction += new EventHandler<EventArgs>(mView_New);
            this.mView.SaveAction += new EventHandler<EventArgs>(mView_Save);
            this.mView.SelectingTabAction += mview_ValidateTab;
            this.mView.ViewAction += new EventHandler<EventArgs>(mView_View);

        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mUsuarioService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));
            this.mView.DataSource = this.AllActive;
        }

        private void GetData()
        {
            this.mActual.AccesoModulo = this.mView.AsignacionModulo;
            this.mActual.AccesoMenu = this.mView.AsignacionMenu;
            this.mActual.AccesoArea = this.mView.AsignacionArea;
            this.mActual.AccesoSucursal = this.mView.AsignacionSucursal;
        }

        private void SetData()
        {

        }

        private void Insertar(ref bool successful, ref string message)
        {
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.AccesoUsuario, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mActual);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.AccesoUsuario, TipoLog.Informacion,
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

        private void mview_KeyPressUsuarioModulo(object sender, KeyEventArgs e)
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
            this.mActual = new Usuario();
            SetData();
        }

        private void mView_Save(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro de guardar los cambios?", AppInfo.Tittle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                string message = string.Empty;
                GetData();
                successful = this.mAccesoUsuarioService.InsertarAccesoUsuario(this.mActual);

                if (successful)
                {
                    MessageBox.Show("Los cambios se realizaron correctamente", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SetData();
            }
        }

        private void mview_ValidateTab(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == "tpDatos" && !this.mView.IsEditing)
                e.Cancel = true;
            else if (e.TabPage.Name != "tpDatos" && this.mView.IsEditing)
                e.Cancel = true;
        }

        private void mView_View(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mActual = this.mUsuarioService.ObtenerPorId(this.mView.SelectId);
            if (this.mActual != null)
            {
                this.mView.AsignacionModulo = mAccesoUsuarioService.ObtenerAccesoModulo(this.mActual);
                var lista = new DataSourceContainer(typeof(Modulo), true).DataSource as List<KeyValuePair<string, int>>;

                var otro = lista.Where(a => !this.mView.AsignacionModulo.Any(m => (int)m.Modulo == (int)a.Value)).ToList().Select(x => x.Key).ToList();
                this.mView.ModuloDisponible = otro;

                this.mView.AsignacionMenu = this.mAccesoUsuarioService.ObtenerAccesoMenu(this.mActual);
                this.mView.MenuDisponible = this.mMenuSistemaService.ObtenerMenu().Where(c =>
                    !this.mView.AsignacionMenu.Any(m => m.Menu.Id == c.Id) && c.TieneFormulario == true).ToList();

                this.mView.AsignacionArea = this.mAccesoUsuarioService.ObtenerAccesoArea(this.mActual);
                this.mView.AreaDisponible = this.mAreaService.ObtenerTodo().Where(c =>
                    !this.mView.AsignacionArea.Any(m => m.Area.Id == c.Id)).ToList();

                this.mView.AsignacionSucursal = this.mAccesoUsuarioService.ObtenerAccesoSucursal(this.mActual);
                this.mView.SucursalDisponible = this.mSucursalService.ObtenerTodo().Where(c =>
                    !this.mView.AsignacionSucursal.Any(m => m.Sucursal.Id == c.Id)).ToList();
            }
            this.mOld = GenericEntityAction<Usuario>.Clone(this.mActual);
            SetData();
        }

        #endregion

    }
}
