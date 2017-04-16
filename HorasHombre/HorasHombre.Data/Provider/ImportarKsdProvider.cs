using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class ImportarKsdProvider : DataAccessKsd
    {
        static private ImportarKsdProvider _instance = null;
        static public ImportarKsdProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ImportarKsdProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlImportarKsdProvider"));
                return _instance;
            }
        }
        public abstract List<Concepto> ObtenerConceptos();

        public virtual Concepto GetFromReader(IDataReader reader)
        {
            Concepto c = new Concepto();
            c.Id = 0;
            c.Codigo = "S/C";
            c.Nombre = reader["Descrip_Larga"].ToString();
            c.DescripcionCorta = reader["Descrip_Corta"].ToString();
            c.Referencia = reader["Id_Concepto"].ToString();
            c.EstaActivo = true;
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
