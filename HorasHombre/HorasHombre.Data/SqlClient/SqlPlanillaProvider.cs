using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlPlanillaProvider : PlanillaProvider
    {
        public override Planilla ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Planilla", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPlanilla", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Planilla> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Planilla", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(Planilla planilla)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Planilla", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPlanilla", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@NuPlanilla", SqlDbType.VarChar).Value = planilla.NumeroPlanilla;
                cmd.Parameters.Add("@FePlanilla", SqlDbType.DateTime).Value = planilla.Fecha;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = planilla.Usuario.Id;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = planilla.Sucursal.Id;
                cmd.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = planilla.Periodo.Id;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = planilla.Area.Id;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = planilla.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdPlanilla"].Value;
            }
        }

        public override bool Actualizar(Planilla planilla)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Planilla", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPlanilla", SqlDbType.Int).Value = planilla.Id;
                cmd.Parameters.Add("@NuPlanilla", SqlDbType.VarChar).Value = planilla.NumeroPlanilla;
                cmd.Parameters.Add("@FePlanilla", SqlDbType.DateTime).Value = planilla.Fecha;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = planilla.Usuario.Id;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = planilla.Sucursal.Id;
                cmd.Parameters.Add("@IdPeriodo", SqlDbType.Int).Value = planilla.Periodo.Id;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = planilla.Area.Id;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = planilla.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_Planilla", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPlanilla", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
