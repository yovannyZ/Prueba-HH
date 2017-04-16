using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Transactions;
using HorasHombre.AppWin.Inicios;

namespace HorasHombre.AppWin.Presenters
{
    public interface IMenuSistemaView
    {
        #region . EventHandler .

        event EventHandler<EventArgs> MenuSistema;

        #endregion

    }

    public interface IMenuSistemaService
    {
        List<MenuSistema> ObtenerMenu();
        List<MenuSistema> ObtenerMenuNuevo();
        MenuSistema ObtenerPorId(int id);
        MenuSistema ObtenerPorNombre(string nombre);
        bool Insertar(MenuSistema menuSistema);
        bool Actualizar(MenuSistema menuSistema);
    }

    public class MenuSistemaService : IMenuSistemaService
    {
        #region . Instance .

        private static MenuSistemaService mInstance = null;

        public static MenuSistemaService Instance
        {
            get { return mInstance; }
        }

        static MenuSistemaService()
        {
            mInstance = new MenuSistemaService();
        }

        #endregion

        #region . IPersonaService members .

        public List<MenuSistema> ObtenerMenu()
        {
            List<MenuSistema> listaMenu = MenuSistemaBL.ObtenerTodo();
            return listaMenu;
        }

        public List<MenuSistema> ObtenerMenuNuevo()
        {
            List<MenuSistema> listaMenu = new List<MenuSistema>();
            Form frm = new frmAdministracion();
            MenuStrip ms = (MenuStrip)frm.Controls["msPrincipal"];
            listaMenu.AddRange(GenericUtil.ObtenerMenu(ms, Modulo.Administracion));

            frm = new frmHorasHombre();
            ms = (MenuStrip)frm.Controls["msPrincipal"];
            listaMenu.AddRange(GenericUtil.ObtenerMenu(ms, Modulo.HorasHombre));

            return listaMenu;
        }

        public MenuSistema ObtenerPorId(int id)
        {
            MenuSistema menuSistema = MenuSistemaBL.ObtenerPorId(id);
            return menuSistema;
        }

        public MenuSistema ObtenerPorNombre(string nombre)
        {
            MenuSistema menuSistema = MenuSistemaBL.ObtenerPorNombre(nombre);
            return menuSistema;
        }

        public bool Insertar(MenuSistema menuSistema)
        {
            return MenuSistemaBL.Insertar(menuSistema) > 0;
        }

        public bool Actualizar(MenuSistema menuSistema)
        {
            return MenuSistemaBL.Actualizar(menuSistema);
        }

        #endregion
    }

    public class MenuSistemaEditor
    {
        #region . variables .

        private IMenuSistemaView mView;
        private IMenuSistemaService mMenuSistemaService;

        #endregion

        public MenuSistemaEditor(IMenuSistemaView view)
        {
            this.mView = view;
            this.mMenuSistemaService = MenuSistemaService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            // Set EventHandler
            this.mView.MenuSistema += new EventHandler<EventArgs>(mView_Menu);
        }

        #endregion

        #region . EventHandler .

        private void mView_Menu(object sender, EventArgs e)
        {
            bool exito = true;
            using (TransactionScope trx = new TransactionScope(TransactionScopeOption.Required, System.TimeSpan.MaxValue))
            {
                var listaMenu = this.mMenuSistemaService.ObtenerMenuNuevo();
                MenuSistema menu;
                string cambios = string.Empty;
                for (int i = 0; i < listaMenu.Count; i++)
                {
                    menu = this.mMenuSistemaService.ObtenerPorNombre(listaMenu[i].Nombre);
                    if (menu == null)
                    {
                        if (listaMenu[i].MenuPrincipal.Nombre != "")
                            listaMenu[i].MenuPrincipal = this.mMenuSistemaService.ObtenerPorNombre(listaMenu[i].MenuPrincipal.Nombre);
                        exito = this.mMenuSistemaService.Insertar(listaMenu[i]);
                        if (!exito)
                            break;
                    }
                    else
                    {
                        cambios = ReflectionUtil.GetChangesFromObjects((object)menu,
                       (object)listaMenu[i]);

                        if (cambios.Length > 3)
                        {
                            menu.Descripcion = listaMenu[i].Descripcion;
                            menu.Modulo = listaMenu[i].Modulo;
                            menu.TieneFormulario = !string.IsNullOrEmpty(listaMenu[i].Formulario);
                            menu.Formulario = listaMenu[i].Formulario;
                            exito = this.mMenuSistemaService.Actualizar(menu);
                            if (!exito)
                                break;
                        }
                    }
                    exito = InsertarSubMenu(listaMenu[i], ref exito);
                    if (!exito)
                        break;
                }
                if (exito)
                {
                    trx.Complete();
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.PlanillaDetalle, TipoLog.Informacion,
                        "Se grabarón los datos");
                }
            }

        }

        private bool InsertarSubMenu(MenuSistema menuSistema, ref bool estado)
        {
            List<MenuSistema> datos = menuSistema.SubMenu;
            MenuSistema menu;
            string cambios = string.Empty;
            for (int i = 0; i < datos.Count; i++)
            {
                menu = this.mMenuSistemaService.ObtenerPorNombre(datos[i].Nombre);
                if (menu == null)
                {
                    if (datos[i].MenuPrincipal.Nombre != "")
                        datos[i].MenuPrincipal = this.mMenuSistemaService.ObtenerPorNombre(datos[i].MenuPrincipal.Nombre);
                    estado = this.mMenuSistemaService.Insertar(datos[i]);
                    if (!estado)
                        break;
                }
                else
                {
                    cambios = ReflectionUtil.GetChangesFromObjects((object)menu,
                   (object)datos[i]);

                    if (cambios.Length > 3)
                    {
                        menu.Descripcion = datos[i].Descripcion;
                        menu.Modulo = datos[i].Modulo;
                        menu.TieneFormulario = !string.IsNullOrEmpty(datos[i].Formulario);
                        menu.Formulario = datos[i].Formulario;
                        estado = this.mMenuSistemaService.Actualizar(menu);
                        if (!estado)
                            break;
                    }
                }
                if (datos[i].SubMenu.Count > 0)
                    estado = InsertarSubMenu(datos[i], ref estado);
                if (!estado)
                    break;
            }
            return estado;
        }

        #endregion
    }
}
