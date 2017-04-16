using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlActividadProvider : ActividadProvider
    {
        public override Actividad ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Actividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdActividad", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Actividad> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Actividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(Actividad actividad)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Actividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdActividad", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CoActividad", SqlDbType.VarChar).Value = actividad.Codigo;
                cmd.Parameters.Add("@NoActividad", SqlDbType.VarChar).Value = actividad.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = actividad.DescripcionCorta;
                cmd.Parameters.Add("@IdActividadPrincipal", SqlDbType.Int).Value = actividad.ActividadPrincipal != null ? actividad.ActividadPrincipal.Id : 0;
                cmd.Parameters.Add("@TxObservacion", SqlDbType.VarChar).Value = actividad.Observacion;
                cmd.Parameters.Add("@NuNivel", SqlDbType.Int).Value = actividad.Nivel;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = actividad.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdActividad"].Value;
            }
        }

        public override bool Actualizar(Actividad actividad)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Actividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdActividad", SqlDbType.Int).Value = actividad.Id;
                cmd.Parameters.Add("@CoActividad", SqlDbType.VarChar).Value = actividad.Codigo;
                cmd.Parameters.Add("@NoActividad", SqlDbType.VarChar).Value = actividad.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = actividad.DescripcionCorta;
                cmd.Parameters.Add("@IdActividadPrincipal", SqlDbType.Int).Value = actividad.ActividadPrincipal != null ? actividad.ActividadPrincipal.Id : 0;
                cmd.Parameters.Add("@TxObservacion", SqlDbType.VarChar).Value = actividad.Observacion;
                cmd.Parameters.Add("@NuNivel", SqlDbType.Int).Value = actividad.Nivel;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = actividad.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_Actividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdActividad", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Activar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Activar_Actividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdActividad", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
