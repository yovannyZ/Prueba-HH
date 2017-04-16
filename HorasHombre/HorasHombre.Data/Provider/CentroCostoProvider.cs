using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HorasHombre.Data.Provider
{
    public abstract class CentroCostoProvider : DataAccess
    {
        static private CentroCostoProvider _instance = null;
        static public CentroCostoProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (CentroCostoProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlCentroCostoProvider"));
                return _instance;
            }
        }

        public abstract CentroCosto ObtenerPorId(int id);
        public abstract List<CentroCosto> ObtenerTodo();
        public abstract int Insertar(CentroCosto centroCosto);
        public abstract bool Actualizar(CentroCosto centroCosto);
        public abstract bool Eliminar(int id);
        public abstract bool Activar(int id);

        public virtual CentroCosto GetFromReader(IDataReader reader)
        {
            CentroCosto c = new CentroCosto();
            c.Id = int.Parse(reader["IdCentroCosto"].ToString());
            c.Codigo = reader["CoCentroCosto"].ToString();
            c.Nombre = reader["NoCentroCosto"].ToString();
            c.DescripcionCorta = reader["TxDescripcionCorta"].ToString();
            c.EstaActivo = bool.Parse(reader["FlActivo"].ToString());
            return c;
        }

        public virtual List<CentroCosto> GetCollectionFromReader(IDataReader reader)
        {
            List<CentroCosto> ObjCentroCosto = new List<CentroCosto>();
            while (reader.Read())
                ObjCentroCosto.Add(GetFromReader(reader));
            return ObjCentroCosto;
        }
    }
}
