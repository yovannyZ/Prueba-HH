using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class SucursalProvider : DataAccess
    {
        static private SucursalProvider _instance = null;
        static public SucursalProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (SucursalProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlSucursalProvider"));
                return _instance;
            }
        }

        public abstract Sucursal ObtenerPorId(int id);
        public abstract List<Sucursal> ObtenerTodo();
        public abstract int Insertar(Sucursal sucursal);
        public abstract bool Actualizar(Sucursal sucursal);
        public abstract bool Eliminar(int id);
        public abstract bool Activar(int id);

        public virtual Sucursal GetFromReader(IDataReader reader)
        {
            Sucursal s = new Sucursal();
            s.Id = int.Parse(reader["IdSucursal"].ToString());
            s.Codigo = reader["CoSucursal"].ToString();
            s.Nombre = reader["NoSucursal"].ToString();
            s.DescripcionCorta = reader["TxDescripcionCorta"].ToString();
            s.NumeroRuc = reader["TxNumeroRuc"].ToString();
            s.Telefono = reader["TxTelefono"].ToString();
            s.Direccion = reader["TxDireccion"].ToString();
            s.Localidad = reader["TxLocalidad"].ToString();
            s.EstaActivo = bool.Parse(reader["FlActivo"].ToString());

            return s;
        }

        public virtual List<Sucursal> GetSucursalCollectionFromReader(IDataReader reader)
        {
            List<Sucursal> ObjSucursal = new List<Sucursal>();
            while (reader.Read())
                ObjSucursal.Add(GetFromReader(reader));
            return ObjSucursal;
        }
    }
}
