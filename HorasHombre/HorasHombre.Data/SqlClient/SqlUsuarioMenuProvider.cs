using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlUsuarioMenuProvider : UsuarioMenuProvider
    {
        public override UsuarioMenu ObtenerPorId(UsuarioMenu usuarioMenu)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_UsuarioMenu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = usuarioMenu.Usuario.Id;
                cmd.Parameters.Add("@IdMenu", SqlDbType.Int).Value = usuarioMenu.Menu.Id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<UsuarioMenu> ObtenerTodo(int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_UsuarioMenu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override bool Insertar(UsuarioMenu usuarioMenu)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_UsuarioMenu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = usuarioMenu.Usuario.Id;
                cmd.Parameters.Add("@IdMenu", SqlDbType.Int).Value = usuarioMenu.Menu.Id;
                cmd.Parameters.Add("@FlActivar", SqlDbType.Bit).Value = usuarioMenu.PuedeActivar;
                cmd.Parameters.Add("@FlEliminar", SqlDbType.Bit).Value = usuarioMenu.PuedeEliminar;
                cmd.Parameters.Add("@FlEscribir", SqlDbType.Bit).Value = usuarioMenu.PuedeEscribir;
                cmd.Parameters.Add("@FlLeer", SqlDbType.Bit).Value = usuarioMenu.PuedeLeer;
                cmd.Parameters.Add("@FlVer", SqlDbType.Bit).Value = usuarioMenu.PuedeVer;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret > 0;
            }
        }

        public override bool Eliminar(int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_UsuarioMenu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
