using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlUsuarioSucursalProvider : UsuarioSucursalProvider
    {
        public override UsuarioSucursal ObtenerPorId(UsuarioSucursal usuarioSucursal)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_UsuarioSucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = usuarioSucursal.Usuario.Id;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = usuarioSucursal.Sucursal.Id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<UsuarioSucursal> ObtenerTodo(int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_UsuarioSucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override bool Insertar(UsuarioSucursal usuarioSucursal)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_UsuarioSucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = usuarioSucursal.Usuario.Id;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = usuarioSucursal.Sucursal.Id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret > 0;
            }
        }

        public override bool Eliminar(int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_UsuarioSucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
