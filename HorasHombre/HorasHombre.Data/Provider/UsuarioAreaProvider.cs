using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class UsuarioAreaProvider : DataAccess
    {
        static private UsuarioAreaProvider _instance = null;
        static public UsuarioAreaProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (UsuarioAreaProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlUsuarioAreaProvider"));
                return _instance;
            }
        }

        public abstract UsuarioArea ObtenerPorId(UsuarioArea usuarioArea);
        public abstract List<UsuarioArea> ObtenerTodo(int idUsuario);
        public abstract bool Insertar(UsuarioArea usuarioArea);
        public abstract bool Eliminar(int idUsuario);

        public virtual UsuarioArea GetFromReader(IDataReader reader)
        {
            UsuarioArea ua = new UsuarioArea();
            ua.Usuario = new Usuario() { Id = int.Parse(reader["IdUsuario"].ToString()) };
            ua.Area = new Area() { Id = int.Parse(reader["IdArea"].ToString()) };
            return ua;
        }

        public virtual List<UsuarioArea> GetCollectionFromReader(IDataReader reader)
        {
            List<UsuarioArea> ObjUsuarioArea = new List<UsuarioArea>();
            while (reader.Read())
                ObjUsuarioArea.Add(GetFromReader(reader));
            return ObjUsuarioArea;
        }
    }
}
