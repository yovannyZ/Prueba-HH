using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class DocumentoPersonaProvider : DataAccessBdGeneral
    {
        static private DocumentoPersonaProvider _instance = null;
        static public DocumentoPersonaProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (DocumentoPersonaProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlDocumentoPersonaProvider"));
                return _instance;
            }
        }

        public abstract DocumentoPersona ObtenerPorId(int idDocumentoPersona);
        public abstract List<DocumentoPersona> ObtenerTodo();

        public virtual DocumentoPersona GetFromReader(IDataReader reader)
        {
            DocumentoPersona DocumentoPersona = null;

            DocumentoPersona = new DocumentoPersona()
            {
                Id = int.Parse(reader["IdDocumento"].ToString()),
                Codigo = reader["Cod_Tipo"].ToString(),
                Nombre = reader["Desc_Tipo"].ToString(),
                DescripcionCorta = reader["Abre"].ToString()
            };

            return DocumentoPersona;
        }

        public virtual List<DocumentoPersona> GetCollectionFromReader(IDataReader reader)
        {
            List<DocumentoPersona> ObjDocumentoPersona = new List<DocumentoPersona>();
            while (reader.Read())
                ObjDocumentoPersona.Add(GetFromReader(reader));
            return ObjDocumentoPersona;
        }
    }
}
