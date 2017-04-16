using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class OrdenProduccionProvider : DataAccessCostos
    {
        static private OrdenProduccionProvider _instance = null;
        static public OrdenProduccionProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (OrdenProduccionProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlOrdenProduccionProvider"));
                return _instance;
            }
        }

        public abstract OrdenProduccion ObtenerPorId(int idOrdenProduccion);
        public abstract List<OrdenProduccion> ObtenerTodo();

        public virtual OrdenProduccion GetFromReader(IDataReader reader)
        {
            OrdenProduccion a = new OrdenProduccion();
            a.Id = int.Parse(reader["IdOrdenProduccion"].ToString());
            a.NumeroOrden = reader["Nro_Ord_Prod"].ToString().Trim();
            a.Articulo = reader["Desc_Articulo"].ToString().Trim();
            a.FechaCierre = reader["Fecha_Cierre"] != DBNull.Value ? DateTime.Parse(reader["Fecha_Cierre"].ToString().Trim()) : new DateTime(1900, 1, 1);
            return a;
        }
        public virtual List<OrdenProduccion> GetOrdenesProduccionFromReader(IDataReader reader)
        {
            List<OrdenProduccion> ObjOrden = new List<OrdenProduccion>();
            while (reader.Read())
                ObjOrden.Add(GetFromReader(reader));
            return ObjOrden;
        }
    }
}
