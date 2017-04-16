using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlCentroCostoProvider : CentroCostoProvider
    {
        public override CentroCosto ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_CentroCosto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCentroCosto", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<CentroCosto> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_CentroCosto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(CentroCosto centroCosto)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_CentroCosto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCentroCosto", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CoCentroCosto", SqlDbType.VarChar).Value = centroCosto.Codigo;
                cmd.Parameters.Add("@NoCentroCosto", SqlDbType.VarChar).Value = centroCosto.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = centroCosto.DescripcionCorta;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = centroCosto.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdCentroCosto"].Value;
            }
        }

        public override bool Actualizar(CentroCosto centroCosto)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_CentroCosto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCentroCosto", SqlDbType.Int).Value = centroCosto.Id;
                cmd.Parameters.Add("@CoCentroCosto", SqlDbType.VarChar).Value = centroCosto.Codigo;
                cmd.Parameters.Add("@NoCentroCosto", SqlDbType.VarChar).Value = centroCosto.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = centroCosto.DescripcionCorta;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = centroCosto.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_CentroCosto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCentroCosto", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Activar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Activar_CentroCosto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdCentroCosto", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
