using HorasHombre.Model;
using HorasHombre.Data.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorasHombre.Data.SqlClient
{
    public class SqlAreaProvider : AreaProvider
    {
        public override Area ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Area", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Area> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Area", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(Area area)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Area", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CoArea", SqlDbType.VarChar).Value = area.Codigo;
                cmd.Parameters.Add("@NoArea", SqlDbType.VarChar).Value = area.Nombre;
                cmd.Parameters.Add("@TxDescCorta", SqlDbType.VarChar).Value = area.DescripcionCorta;
                cmd.Parameters.Add("@FlAutomatico", SqlDbType.Bit).Value = area.EsAutomatico;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = area.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdArea"].Value;
            }
        }

        public override bool Actualizar(Area area)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Area", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = area.Id;
                cmd.Parameters.Add("@CoArea", SqlDbType.VarChar).Value = area.Codigo;
                cmd.Parameters.Add("@NoArea", SqlDbType.VarChar).Value = area.Nombre;
                cmd.Parameters.Add("@TxDescCorta", SqlDbType.VarChar).Value = area.DescripcionCorta;
                cmd.Parameters.Add("@FlAutomatico", SqlDbType.Bit).Value = area.EsAutomatico;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = area.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_Area", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Activar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Activar_Area", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
