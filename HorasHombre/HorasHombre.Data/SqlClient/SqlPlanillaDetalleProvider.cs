using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlPlanillaDetalleProvider : PlanillaDetalleProvider
    {
        public override List<PlanillaDetalle> ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_PlanillaDetalle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPlanilla", SqlDbType.Int).Value = id;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
                //IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                //if (reader.Read())
                //    return GetFromReader(reader);
                //return null;
            }
        }

        //public override List<PlanillaDetalle> ObtenerTodo()
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_PlanillaDetalle", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        return GetCollectionFromReader(ExecuteReader(cmd));
        //    }
        //}

        public override bool Insertar(PlanillaDetalle planillaDetalle, int idPlanilla)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_PlanillaDetalle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPlanilla", SqlDbType.Int).Value = idPlanilla;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = planillaDetalle.Persona.Id;
                cmd.Parameters.Add("@IdNovedad", SqlDbType.Int).Value = planillaDetalle.Novedad.Id;
                cmd.Parameters.Add("@IdCentroCosto", SqlDbType.Int).Value = planillaDetalle.CentroCosto != null ? planillaDetalle.CentroCosto.Id : 0;
                cmd.Parameters.Add("@IdRelacion", SqlDbType.Int).Value = planillaDetalle.RelacionActividad != null ? planillaDetalle.RelacionActividad.Id : 0;
                cmd.Parameters.Add("@FeInicio", SqlDbType.Time).Value = planillaDetalle.Inicio;
                cmd.Parameters.Add("@FeFin", SqlDbType.Time).Value = planillaDetalle.Fin;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Actualizar(PlanillaDetalle planillaDetalle)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_PlanillaDetalle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPlanillaDetalle", SqlDbType.Int).Value = planillaDetalle.Id;
                cmd.Parameters.Add("@IdNovedad", SqlDbType.Int).Value = planillaDetalle.Novedad.Id;
                cmd.Parameters.Add("@IdCentroCosto", SqlDbType.Int).Value = planillaDetalle.CentroCosto != null ? planillaDetalle.CentroCosto.Id : 0;
                cmd.Parameters.Add("@IdRelacion", SqlDbType.Int).Value = planillaDetalle.RelacionActividad != null ? planillaDetalle.RelacionActividad.Id : 0;
                cmd.Parameters.Add("@FeInicio", SqlDbType.Time).Value = planillaDetalle.Inicio;
                cmd.Parameters.Add("@FeFin", SqlDbType.Time).Value = planillaDetalle.Fin;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_PlanillaDetalle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPlanilla", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
        }

    }
}
