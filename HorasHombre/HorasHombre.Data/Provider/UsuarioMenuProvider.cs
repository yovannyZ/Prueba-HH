using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class UsuarioMenuProvider : DataAccess
    {
        static private UsuarioMenuProvider _instance = null;
        static public UsuarioMenuProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (UsuarioMenuProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlUsuarioMenuProvider"));
                return _instance;
            }
        }

        public abstract UsuarioMenu ObtenerPorId(UsuarioMenu usuarioMenu);
        public abstract List<UsuarioMenu> ObtenerTodo(int idUsuario);
        public abstract bool Insertar(UsuarioMenu usuarioMenu);
        public abstract bool Eliminar(int idUsuario);

        public virtual UsuarioMenu GetFromReader(IDataReader reader)
        {
            UsuarioMenu um = new UsuarioMenu();
            um.Usuario = new Usuario() { Id = int.Parse(reader["IdUsuario"].ToString()) };
            um.Menu = new MenuSistema() { Id = int.Parse(reader["IdMenu"].ToString()) };
            um.PuedeActivar = bool.Parse(reader["FlActivar"].ToString());
            um.PuedeEliminar = bool.Parse(reader["FlEliminar"].ToString());
            um.PuedeEscribir = bool.Parse(reader["FlEscribir"].ToString());
            um.PuedeLeer = bool.Parse(reader["FlLeer"].ToString());
            um.PuedeVer = bool.Parse(reader["FlVer"].ToString());
            return um;
        }

        public virtual List<UsuarioMenu> GetCollectionFromReader(IDataReader reader)
        {
            List<UsuarioMenu> ObjUsuarioMenu = new List<UsuarioMenu>();
            while (reader.Read())
                ObjUsuarioMenu.Add(GetFromReader(reader));
            return ObjUsuarioMenu;
        }
    }
}
