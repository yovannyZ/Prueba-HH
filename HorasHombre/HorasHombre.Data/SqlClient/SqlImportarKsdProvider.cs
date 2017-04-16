using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlImportarKsdProvider : ImportarKsdProvider
    {
        public override List<Concepto> ObtenerConceptos()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select Descrip_Larga, Descrip_Corta, Id_Concepto From Concepto Where Id_Estado='01'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }
    }
}
