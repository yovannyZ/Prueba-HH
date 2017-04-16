using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlUsuarioProvider : UsuarioProvider
    {
        public override Usuario ObtenerPorId(int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * From Usuario Where IdUsuario=@IdUsuario", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Usuario> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * From Usuario", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }
    }
}
