using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HorasHombre.Data.Provider
{
    public abstract class AreaProvider : DataAccess
    {
        static private AreaProvider _instance = null;
        static public AreaProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (AreaProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlAreaProvider"));
                return _instance;
            }
        }

        public abstract Area ObtenerPorId(int id);
        public abstract List<Area> ObtenerTodo();
        public abstract int Insertar(Area area);
        public abstract bool Actualizar(Area area);
        public abstract bool Eliminar(int id);
        public abstract bool Activar(int id);

        public virtual Area GetFromReader(IDataReader reader)
        {
            Area a = new Area();
            a.Id = int.Parse(reader["IdArea"].ToString());
            a.Codigo = reader["CoArea"].ToString();
            a.Nombre = reader["NoArea"].ToString();
            a.DescripcionCorta = reader["TxDescripcionCorta"].ToString();
            a.EsAutomatico = bool.Parse(reader["FlAutomatico"].ToString());
            a.EstaActivo = bool.Parse(reader["FlActivo"].ToString());
            return a;
        }

        public virtual List<Area> GetCollectionFromReader(IDataReader reader)
        {
            List<Area> ObjArea = new List<Area>();
            while (reader.Read())
                ObjArea.Add(GetFromReader(reader));
            return ObjArea;
        }
    }
}
