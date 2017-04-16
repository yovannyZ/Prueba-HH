using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HorasHombre.Data.Provider
{
    public abstract class MenuSistemaProvider : DataAccess
    {
        static private MenuSistemaProvider _instance = null;
        static public MenuSistemaProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (MenuSistemaProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlMenuSistemaProvider"));
                return _instance;
            }
        }

        public abstract MenuSistema ObtenerPorId(int id);
        public abstract MenuSistema ObtenerPorNombre(string nombre);
        public abstract List<MenuSistema> ObtenerTodo();
        public abstract int Insertar(MenuSistema menu);
        public abstract bool Actualizar(MenuSistema menu);
        public abstract bool Eliminar(int id);

        public virtual MenuSistema GetFromReader(IDataReader reader)
        {
            MenuSistema m = new MenuSistema();
            m.Id = int.Parse(reader["IdMenu"].ToString());
            m.Nombre = reader["NoMenu"].ToString();
            m.Descripcion = reader["TxDescripcionMenu"].ToString();
            m.MenuPrincipal = new MenuSistema() { Id = int.Parse(reader["IdMenuPadre"].ToString()) };
            m.TieneFormulario = bool.Parse(reader["FlFormulario"].ToString());
            m.Formulario = reader["TxFormulario"].ToString();
            m.Modulo = (Modulo)int.Parse(reader["NuModulo"].ToString());

            return m;
        }

        public virtual List<MenuSistema> GetCollectionFromReader(IDataReader reader)
        {
            List<MenuSistema> ObjMenu = new List<MenuSistema>();
            while (reader.Read())
                ObjMenu.Add(GetFromReader(reader));
            return ObjMenu;
        }
    }
}
