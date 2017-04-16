using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class UsuarioProvider : DataAccessBdGeneral
    {
        static private UsuarioProvider _instance = null;
        static public UsuarioProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (UsuarioProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlUsuarioProvider"));
                return _instance;
            }
        }

        public abstract Usuario ObtenerPorId(int idUsuario);
        public abstract List<Usuario> ObtenerTodo();

        public virtual Usuario GetFromReader(IDataReader reader)
        {
            Usuario s = null;

            s = new Usuario();
            s.Id = int.Parse(reader["IdUsuario"].ToString());
            s.Codigo = reader["Cod_Usu"].ToString();
            s.Nombre = reader["Nombres"].ToString();
            s.Apellido = reader["Apellidos"].ToString();
            s.Nick = reader["Nick"].ToString();
            s.Clave = reader["Clave"].ToString();
            if (reader["Tipo"].ToString() == "MS")
                s.TipoUsuario = TipoUsuario.Super;
            else if (reader["Tipo"].ToString() == "AD")
                s.TipoUsuario = TipoUsuario.Administrador;
            else
                s.TipoUsuario = TipoUsuario.Usuario;

            return s;
        }

        public virtual List<Usuario> GetCollectionFromReader(IDataReader reader)
        {
            List<Usuario> ObjUsuario = new List<Usuario>();
            while (reader.Read())
                ObjUsuario.Add(GetFromReader(reader));
            return ObjUsuario;
        }
    }
}
