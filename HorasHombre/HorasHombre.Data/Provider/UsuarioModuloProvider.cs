using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class UsuarioModuloProvider : DataAccess
    {
        static private UsuarioModuloProvider _instance = null;
        static public UsuarioModuloProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (UsuarioModuloProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlUsuarioModuloProvider"));
                return _instance;
            }
        }

        public abstract UsuarioModulo ObtenerPorId(UsuarioModulo usuarioModulo);
        public abstract List<UsuarioModulo> ObtenerTodo(int idUsuario);
        public abstract bool Insertar(UsuarioModulo usuarioModulo);
        public abstract bool Eliminar(int idUsuario);

        public virtual UsuarioModulo GetFromReader(IDataReader reader)
        {
            UsuarioModulo um = new UsuarioModulo();
            um.Usuario = new Usuario() { Id = int.Parse(reader["IdUsuario"].ToString()) };
            um.Modulo = (Modulo)int.Parse(reader["NuModulo"].ToString());
            return um;
        }

        public virtual List<UsuarioModulo> GetCollectionFromReader(IDataReader reader)
        {
            List<UsuarioModulo> ObjUsuarioModulo = new List<UsuarioModulo>();
            while (reader.Read())
                ObjUsuarioModulo.Add(GetFromReader(reader));
            return ObjUsuarioModulo;
        }
    }
}
