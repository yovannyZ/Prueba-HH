using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlPeriodoProvider : PeriodoProvider
    {
        public override Periodo ObtenerPorId(int idPeriodo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Periodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = idPeriodo;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override Periodo ObtenerPorFechaInicio(DateTime fechaInicio)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorFechaInicio_Periodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = fechaInicio;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override Periodo ObtenerActivo(Modulo modulo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerActivo_Periodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NuModulo", SqlDbType.Int).Value = (int)modulo;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Periodo> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Periodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(Periodo objPeriodo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Periodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPeriodo", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@FeInicio", SqlDbType.DateTime).Value = objPeriodo.FechaInicio;
                cmd.Parameters.Add("@FeCierre", SqlDbType.DateTime).Value = objPeriodo.FechaCierre;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = objPeriodo.EstaActivo;
                cmd.Parameters.Add("@FlCierre", SqlDbType.Bit).Value = objPeriodo.EstaCerrado;
                cmd.Parameters.Add("@NuModulo", SqlDbType.Int).Value = objPeriodo.Modulo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdPeriodo"].Value;
            }
        }

        public override bool Actualizar(Periodo objPeriodo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Periodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = objPeriodo.Id;
                cmd.Parameters.Add("@FeInicio", SqlDbType.DateTime).Value = objPeriodo.FechaInicio;
                cmd.Parameters.Add("@FeCierre", SqlDbType.DateTime).Value = objPeriodo.FechaCierre;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = objPeriodo.EstaActivo;
                cmd.Parameters.Add("@FlCierre", SqlDbType.Bit).Value = objPeriodo.EstaCerrado;
                cmd.Parameters.Add("@NuModulo", SqlDbType.Int).Value = objPeriodo.Modulo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int idPeriodo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_Periodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = idPeriodo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Activar(Periodo periodo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Activar_Periodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = periodo.Id;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = periodo.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Close(Periodo periodo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Close_Periodo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = periodo.Id;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = periodo.EstaCerrado;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
