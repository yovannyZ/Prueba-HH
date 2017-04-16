using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlMenuSistemaProvider : MenuSistemaProvider
    {
        public override MenuSistema ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Menu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdMenu", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override MenuSistema ObtenerPorNombre(string nombre)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorNombre_Menu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NoMenu", SqlDbType.VarChar).Value = nombre;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<MenuSistema> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Menu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(MenuSistema menu)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Menu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdMenu", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@NoMenu", SqlDbType.VarChar).Value = menu.Nombre;
                cmd.Parameters.Add("@TxDescripcionMenu", SqlDbType.VarChar).Value = menu.Descripcion;
                cmd.Parameters.Add("@IdMenuPadre", SqlDbType.Int).Value = menu.MenuPrincipal.Id;
                cmd.Parameters.Add("@FlFormulario", SqlDbType.Bit).Value = menu.TieneFormulario;
                cmd.Parameters.Add("@TxFormulario", SqlDbType.VarChar).Value = menu.Formulario;
                cmd.Parameters.Add("@NuModulo", SqlDbType.Int).Value = menu.Modulo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdMenu"].Value;
            }
        }

        public override bool Actualizar(MenuSistema menu)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Menu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdMenu", SqlDbType.Int).Value = menu.Id;
                cmd.Parameters.Add("@NoMenu", SqlDbType.VarChar).Value = menu.Nombre;
                cmd.Parameters.Add("@TxDescripcionMenu", SqlDbType.VarChar).Value = menu.Descripcion;
                cmd.Parameters.Add("@IdMenuPadre", SqlDbType.Int).Value = menu.MenuPrincipal.Id;
                cmd.Parameters.Add("@FlFormulario", SqlDbType.Bit).Value = menu.TieneFormulario;
                cmd.Parameters.Add("@TxFormulario", SqlDbType.VarChar).Value = menu.Formulario;
                cmd.Parameters.Add("@NuModulo", SqlDbType.Int).Value = menu.Modulo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_Menu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdMenu", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
