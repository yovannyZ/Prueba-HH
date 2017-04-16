using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HorasHombre.Data.Provider
{
    public abstract class PeriodoProvider : DataAccess
    {
        static private PeriodoProvider _instance = null;
        static public PeriodoProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (PeriodoProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlPeriodoProvider"));
                return _instance;
            }
        }

        public abstract Periodo ObtenerPorId(int idPeriodo);
        public abstract Periodo ObtenerPorFechaInicio(DateTime fechaInicio);
        public abstract Periodo ObtenerActivo(Modulo modulo);
        public abstract List<Periodo> ObtenerTodo();
        public abstract int Insertar(Periodo periodo);
        public abstract bool Actualizar(Periodo periodo);
        public abstract bool Eliminar(int idPeriodo);
        public abstract bool Activar(Periodo periodo);
        public abstract bool Close(Periodo periodo);

        public virtual Periodo GetFromReader(IDataReader reader)
        {
            Periodo p = null;

            p = new Periodo();
            p.Id = int.Parse(reader["IdPeriodo"].ToString());
            p.FechaInicio = DateTime.Parse(reader["FeInicio"].ToString());
            p.FechaCierre = DateTime.Parse(reader["FeCierre"].ToString());
            p.EstaActivo = bool.Parse(reader["FlActivo"].ToString());
            p.EstaCerrado = bool.Parse(reader["FlCierre"].ToString());
            p.Modulo = (Modulo)int.Parse(reader["NuModulo"].ToString());

            return p;
        }

        public virtual List<Periodo> GetCollectionFromReader(IDataReader reader)
        {
            List<Periodo> ObjPeriodo = new List<Periodo>();
            while (reader.Read())
                ObjPeriodo.Add(GetFromReader(reader));
            return ObjPeriodo;
        }
    }
}
