using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class UsuarioSucursalProvider : DataAccess
    {
        static private UsuarioSucursalProvider _instance = null;
        static public UsuarioSucursalProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (UsuarioSucursalProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlUsuarioSucursalProvider"));
                return _instance;
            }
        }

        public abstract UsuarioSucursal ObtenerPorId(UsuarioSucursal usuarioSucursal);
        public abstract List<UsuarioSucursal> ObtenerTodo(int idUsuario);
        public abstract bool Insertar(UsuarioSucursal usuarioSucursal);
        public abstract bool Eliminar(int idUsuario);

        public virtual UsuarioSucursal GetFromReader(IDataReader reader)
        {
            UsuarioSucursal us = new UsuarioSucursal();
            us.Usuario = new Usuario() { Id = int.Parse(reader["IdUsuario"].ToString()) };
            us.Sucursal = new Sucursal() { Id = int.Parse(reader["IdSucursal"].ToString()) };
            return us;
        }

        public virtual List<UsuarioSucursal> GetCollectionFromReader(IDataReader reader)
        {
            List<UsuarioSucursal> ObjUsuarioSucursal = new List<UsuarioSucursal>();
            while (reader.Read())
                ObjUsuarioSucursal.Add(GetFromReader(reader));
            return ObjUsuarioSucursal;
        }
    }
}
