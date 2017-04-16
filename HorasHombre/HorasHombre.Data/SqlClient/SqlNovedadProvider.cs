using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlNovedadProvider : NovedadProvider
    {
        public override Novedad ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Novedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdNovedad", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override Novedad ObtenerPorCodigo(string codigo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorCodigo_Novedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CoNovedad", SqlDbType.VarChar).Value = codigo;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Novedad> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Novedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(Novedad novedad)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Novedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdNovedad", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CoNovedad", SqlDbType.VarChar).Value = novedad.Codigo;
                cmd.Parameters.Add("@NoNovedad", SqlDbType.VarChar).Value = novedad.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = novedad.DescripcionCorta;
                cmd.Parameters.Add("@NuTipoDistribucion", SqlDbType.Int).Value = novedad.TipoDistribucion;
                cmd.Parameters.Add("@FlCosto", SqlDbType.Bit).Value = novedad.AplicaCosto;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = novedad.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdNovedad"].Value;
            }
        }

        public override bool Actualizar(Novedad novedad)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Novedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdNovedad", SqlDbType.Int).Value = novedad.Id;
                cmd.Parameters.Add("@CoNovedad", SqlDbType.VarChar).Value = novedad.Codigo;
                cmd.Parameters.Add("@NoNovedad", SqlDbType.VarChar).Value = novedad.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = novedad.DescripcionCorta;
                cmd.Parameters.Add("@NuTipoDistribucion", SqlDbType.Int).Value = novedad.TipoDistribucion;
                cmd.Parameters.Add("@FlCosto", SqlDbType.Bit).Value = novedad.AplicaCosto;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = novedad.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_Novedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdNovedad", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Activar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Activar_Novedad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdNovedad", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
