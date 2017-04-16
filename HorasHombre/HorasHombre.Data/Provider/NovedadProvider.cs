using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HorasHombre.Data.Provider
{
    public abstract class NovedadProvider : DataAccess
    {
        static private NovedadProvider _instance = null;
        static public NovedadProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (NovedadProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlNovedadProvider"));
                return _instance;
            }
        }


        public abstract Novedad ObtenerPorId(int id);
        public abstract Novedad ObtenerPorCodigo(string codigo);
        public abstract List<Novedad> ObtenerTodo();
        public abstract int Insertar(Novedad novedad);
        public abstract bool Actualizar(Novedad novedad);
        public abstract bool Eliminar(int id);
        public abstract bool Activar(int id);

        public virtual Novedad GetFromReader(IDataReader reader)
        {
            Novedad n = new Novedad();
            n.Id = int.Parse(reader["IdNovedad"].ToString());
            n.Codigo = reader["CoNovedad"].ToString();
            n.Nombre = reader["NoNovedad"].ToString();
            n.DescripcionCorta = reader["TxDescripcionCorta"].ToString();
            n.TipoDistribucion = (TipoDistribucion)int.Parse(reader["NuTipoDistribucion"].ToString());
            n.AplicaCosto = bool.Parse(reader["FlCosto"].ToString());
            n.EstaActivo = bool.Parse(reader["FlActivo"].ToString());

            return n;
        }

        public virtual List<Novedad> GetCollectionFromReader(IDataReader reader)
        {
            List<Novedad> ObjNovedad = new List<Novedad>();
            while (reader.Read())
                ObjNovedad.Add(GetFromReader(reader));
            return ObjNovedad;
        }
    }
}
