using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class PlanillaProvider : DataAccess
    {
        static private PlanillaProvider _instance = null;
        static public PlanillaProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (PlanillaProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlPlanillaProvider"));
                return _instance;
            }
        }

        public abstract Planilla ObtenerPorId(int id);
        public abstract List<Planilla> ObtenerTodo();
        public abstract int Insertar(Planilla planilla);
        public abstract bool Actualizar(Planilla planilla);
        public abstract bool Eliminar(int id);

        public virtual Planilla GetFromReader(IDataReader reader)
        {
            Planilla p = new Planilla();
            p.Id = int.Parse(reader["IdPlanilla"].ToString());
            p.NumeroPlanilla = reader["NuPlanilla"].ToString();
            p.Fecha = DateTime.Parse(reader["FePlanilla"].ToString());
            p.Usuario = new Usuario() { Id = int.Parse(reader["IdUsuario"].ToString()) };
            p.Sucursal = new Sucursal() { Id = int.Parse(reader["IdSucursal"].ToString()) };
            p.Periodo = new Periodo() { Id = int.Parse(reader["IdPeriodo"].ToString()) };
            p.Area = new Area() { Id = int.Parse(reader["IdArea"].ToString()) };
            p.EstaActivo = bool.Parse(reader["FlActivo"].ToString());

            return p;
        }

        public virtual List<Planilla> GetCollectionFromReader(IDataReader reader)
        {
            List<Planilla> ObjPlanilla = new List<Planilla>();
            while (reader.Read())
                ObjPlanilla.Add(GetFromReader(reader));
            return ObjPlanilla;
        }
    }
}
