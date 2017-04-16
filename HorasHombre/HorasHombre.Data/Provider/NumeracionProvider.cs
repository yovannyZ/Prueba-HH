using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HorasHombre.Data.Provider
{
    public abstract class NumeracionProvider : DataAccess
    {
        static private NumeracionProvider _instance = null;
        static public NumeracionProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (NumeracionProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlNumeracionProvider"));
                return _instance;
            }
        }

        public abstract Numeracion ObtenerPorId(int idArea);
        public abstract List<Numeracion> ObtenerTodo();
        public abstract int Insertar(Numeracion numeracion);
        public abstract bool Actualizar(Numeracion numeracion);
        //public abstract bool DeleteNumeracion(int IdArea);

        public virtual Numeracion GetFromReader(IDataReader reader)
        {
            Numeracion n = new Numeracion();
            n.NumeroCorrelativo = reader["TxCorrelativo"].ToString();
            n.Area = new Area() { Id = int.Parse(reader["IdArea"].ToString()) };
            return n;
        }

        public virtual List<Numeracion> GetCollectionFromReader(IDataReader reader)
        {
            List<Numeracion> numeracion = new List<Numeracion>();
            while (reader.Read())
                numeracion.Add(GetFromReader(reader));
            return numeracion;
        }
    }
}
