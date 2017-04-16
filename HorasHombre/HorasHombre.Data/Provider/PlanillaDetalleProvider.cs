using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class PlanillaDetalleProvider : DataAccess
    {
        static private PlanillaDetalleProvider _instance = null;
        static public PlanillaDetalleProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (PlanillaDetalleProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlPlanillaDetalleProvider"));
                return _instance;
            }
        }

        public abstract List<PlanillaDetalle> ObtenerPorId(int id);
        public abstract bool Insertar(PlanillaDetalle planillaDetalle, int idPlanilla);
        public abstract bool Actualizar(PlanillaDetalle planillaDetalle);
        public abstract bool Eliminar(int id);

        public virtual PlanillaDetalle GetFromReader(IDataReader reader)
        {
            PlanillaDetalle p = new PlanillaDetalle();
            p.Id = int.Parse(reader["IdPlanillaDetalle"].ToString());
            p.Planilla = new Planilla() { Id = int.Parse(reader["IdPlanilla"].ToString()) };
            p.Persona = new Persona() { Id = int.Parse(reader["IdPersona"].ToString()) };
            p.CentroCosto = reader["IdCentroCosto"] != DBNull.Value ? new CentroCosto() { Id = int.Parse(reader["IdCentroCosto"].ToString()) } : null;
            p.RelacionActividad = reader["IdRelacion"] != DBNull.Value ? new OrdenProduccionActividad()
            {
                Id = int.Parse(reader["IdRelacion"].ToString()),
                Actividad = new Actividad(),
                OrdenProduccion = new OrdenProduccion()
            } : null;
            p.Novedad = new Novedad() { Id = int.Parse(reader["IdNovedad"].ToString()) };
            p.Inicio = TimeSpan.Parse(reader["FeInicio"].ToString());
            p.Fin = TimeSpan.Parse(reader["FeFin"].ToString());
            p.EstaActivo = bool.Parse(reader["FlActivo"].ToString());
            return p;
        }

        public virtual List<PlanillaDetalle> GetCollectionFromReader(IDataReader reader)
        {
            List<PlanillaDetalle> ObjPlanillaDetalle = new List<PlanillaDetalle>();
            while (reader.Read())
                ObjPlanillaDetalle.Add(GetFromReader(reader));
            return ObjPlanillaDetalle;
        }
    }
}
