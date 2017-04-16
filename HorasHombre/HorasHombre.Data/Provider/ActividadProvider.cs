using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HorasHombre.Data.Provider
{
    public abstract class ActividadProvider : DataAccess
    {
        static private ActividadProvider _instance = null;
        static public ActividadProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ActividadProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlActividadProvider"));
                return _instance;
            }
        }

        public abstract Actividad ObtenerPorId(int id);
        public abstract List<Actividad> ObtenerTodo();
        public abstract int Insertar(Actividad actividad);
        public abstract bool Actualizar(Actividad actividad);
        public abstract bool Eliminar(int id);
        public abstract bool Activar(int id);

        public virtual Actividad GetFromReader(IDataReader reader)
        {
            Actividad a = new Actividad();
            a.Id = int.Parse(reader["IdActividad"].ToString());
            a.Codigo = reader["CoActividad"].ToString();
            a.Nombre = reader["NoActividad"].ToString();
            a.DescripcionCorta = reader["TxDescripcionCorta"].ToString();
            a.ActividadPrincipal = reader["IdActividadPrincipal"] != DBNull.Value ? new Actividad() { Id = int.Parse(reader["IdActividadPrincipal"].ToString()) } : null;
            a.Observacion = reader["TxObservacion"].ToString();
            a.Nivel = int.Parse(reader["NuNivel"].ToString());
            a.EstaActivo = bool.Parse(reader["FlActivo"].ToString());

            return a;
        }

        public virtual List<Actividad> GetCollectionFromReader(IDataReader reader)
        {
            List<Actividad> ObjActividad = new List<Actividad>();
            while (reader.Read())
                ObjActividad.Add(GetFromReader(reader));
            return ObjActividad;
        }
    }
}
