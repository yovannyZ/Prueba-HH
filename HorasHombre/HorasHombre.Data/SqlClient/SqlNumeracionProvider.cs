using HorasHombre.Model;
using HorasHombre.Data.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorasHombre.Data.SqlClient
{
    public class SqlNumeracionProvider : NumeracionProvider
    {
        public override Numeracion ObtenerPorId(int idArea)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Numeracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = idArea;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Numeracion> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Numeracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(Numeracion numeracion)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Numeracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = numeracion.Area.Id;
                cmd.Parameters.Add("@TxCorrelativo", SqlDbType.VarChar).Value = numeracion.NumeroCorrelativo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdArea"].Value;
            }
        }

        public override bool Actualizar(Numeracion numeracion)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Numeracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = numeracion.Area.Id;
                cmd.Parameters.Add("@TxCorrelativo", SqlDbType.VarChar).Value = numeracion.NumeroCorrelativo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        //public override bool DeleteNumeracion(int IdArea)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("pa_Delete_Numeracion", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = IdArea;
        //        cn.Open();
        //        int ret = ExecuteNonQuery(cmd);
        //        return (ret == 1);
        //    }
        //}

    }
}
