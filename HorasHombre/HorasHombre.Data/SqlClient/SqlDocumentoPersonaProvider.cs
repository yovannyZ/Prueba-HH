using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlDocumentoPersonaProvider : DocumentoPersonaProvider
    {
        public override DocumentoPersona ObtenerPorId(int idDocumentoPersona)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * From Documento_Personal Where IdDocumento=@IdDocumento", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = idDocumentoPersona;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<DocumentoPersona> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * From Documento_Personal", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }
    }
}
