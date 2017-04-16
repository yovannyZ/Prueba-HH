using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HorasHombre.Data.Provider
{
    public abstract class ConceptoProvider : DataAccess
    {
        static private ConceptoProvider _instance = null;
        static public ConceptoProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ConceptoProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlConceptoProvider"));
                return _instance;
            }
        }

        public abstract Concepto ObtenerPorId(int id);
        public abstract List<Concepto> ObtenerTodo();
        public abstract int Insertar(Concepto concepto);
        public abstract bool Actualizar(Concepto concepto);
        public abstract bool Eliminar(int id);

        public virtual Concepto GetFromReader(IDataReader reader)
        {
            Concepto c = new Concepto();
            c.Id = int.Parse(reader["IdConcepto"].ToString());
            c.Codigo = reader["CoConcepto"].ToString();
            c.Nombre = reader["NoConcepto"].ToString();
            c.DescripcionCorta = reader["TxDescripcionCorta"].ToString();
            c.Referencia = reader["TxReferencia"].ToString();
            c.TipoPlanilla = (TipoPlanilla)int.Parse(reader["NuTipoPlanilla"].ToString());
            c.EstaActivo = bool.Parse(reader["FlActivo"].ToString());
            return c;
        }

        public virtual List<Concepto> GetCollectionFromReader(IDataReader reader)
        {
            List<Concepto> ObjConcepto = new List<Concepto>();
            while (reader.Read())
                ObjConcepto.Add(GetFromReader(reader));
            return ObjConcepto;
        }
    }
}
