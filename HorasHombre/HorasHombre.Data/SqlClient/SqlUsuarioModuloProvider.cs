using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlUsuarioModuloProvider : UsuarioModuloProvider
    {
        public override UsuarioModulo ObtenerPorId(UsuarioModulo usuarioModulo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_UsuarioModulo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = usuarioModulo.Usuario.Id;
                cmd.Parameters.Add("@NuModulo", SqlDbType.Int).Value = usuarioModulo.Modulo;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<UsuarioModulo> ObtenerTodo(int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_UsuarioModulo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override bool Insertar(UsuarioModulo usuarioModulo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_UsuarioModulo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = usuarioModulo.Usuario.Id;
                cmd.Parameters.Add("@NuModulo", SqlDbType.Int).Value = usuarioModulo.Modulo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret > 0;
            }
        }

        public override bool Eliminar(int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_UsuarioModulo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
