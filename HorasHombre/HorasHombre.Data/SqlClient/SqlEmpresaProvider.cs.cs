using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;


namespace HorasHombre.Data.SqlClient
{
    public class SqlEmpresaProvider : EmpresaProvider
    {
        public override Empresa ObtenerPorId(int idEmpresa)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * From Empresa Where IdEmpresa = @IdEmpresa", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IdEmpresa", SqlDbType.Int).Value = idEmpresa;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Empresa> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * From Empresa", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }
    }
}
