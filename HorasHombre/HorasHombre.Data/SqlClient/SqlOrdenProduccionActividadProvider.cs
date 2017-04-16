using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlOrdenProduccionActividadProvider : OrdenProduccionActividadProvider
    {
        public override OrdenProduccionActividad ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_OrdenProduccionActividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdRelacion", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<OrdenProduccionActividad> ObtenerTodo(OrdenProduccion orden)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_OrdenProduccionActividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdOrdenProduccion", SqlDbType.Int).Value = orden.Id;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(OrdenProduccionActividad ordenProduccionActividad)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_OrdenProduccionActividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdRelacion", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IdOrdenProduccion", SqlDbType.Int).Value = ordenProduccionActividad.OrdenProduccion.Id;
                cmd.Parameters.Add("@IdActividad", SqlDbType.Int).Value = ordenProduccionActividad.Actividad.Id;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = ordenProduccionActividad.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdRelacion"].Value;
            }
        }

        public override bool Actualizar(OrdenProduccionActividad ordenProduccionActividad)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_OrdenProduccionActividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdRelacion", SqlDbType.Int).Value = ordenProduccionActividad.Id;
                cmd.Parameters.Add("@IdOrdenProduccion", SqlDbType.Int).Value = ordenProduccionActividad.OrdenProduccion.Id;
                cmd.Parameters.Add("@IdActividad", SqlDbType.Int).Value = ordenProduccionActividad.Actividad.Id;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = ordenProduccionActividad.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_OrdenProduccionActividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdRelacion", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
