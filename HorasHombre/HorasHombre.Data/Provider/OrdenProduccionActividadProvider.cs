using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class OrdenProduccionActividadProvider : DataAccess
    {
        static private OrdenProduccionActividadProvider _instance = null;
        static public OrdenProduccionActividadProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (OrdenProduccionActividadProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlOrdenProduccionActividadProvider"));
                return _instance;
            }
        }

        public abstract OrdenProduccionActividad ObtenerPorId(int id);
        public abstract List<OrdenProduccionActividad> ObtenerTodo(OrdenProduccion orden);
        public abstract int Insertar(OrdenProduccionActividad OrdenProduccionActividad);
        public abstract bool Actualizar(OrdenProduccionActividad OrdenProduccionActividad);
        public abstract bool Eliminar(int id);

        public virtual OrdenProduccionActividad GetFromReader(IDataReader reader)
        {
            OrdenProduccionActividad r = new OrdenProduccionActividad();
            r.Id = int.Parse(reader["IdRelacion"].ToString());
            r.OrdenProduccion = new OrdenProduccion() { Id = int.Parse(reader["IdOrdenProduccion"].ToString()) };
            r.Actividad = new Actividad() { Id = int.Parse(reader["IdActividad"].ToString()) };
            r.EstaActivo = bool.Parse(reader["FlActivo"].ToString());

            return r;
        }

        public virtual List<OrdenProduccionActividad> GetCollectionFromReader(IDataReader reader)
        {
            List<OrdenProduccionActividad> ObjOrdenProduccionActividad = new List<OrdenProduccionActividad>();
            while (reader.Read())
                ObjOrdenProduccionActividad.Add(GetFromReader(reader));
            return ObjOrdenProduccionActividad;
        }
    }
}
