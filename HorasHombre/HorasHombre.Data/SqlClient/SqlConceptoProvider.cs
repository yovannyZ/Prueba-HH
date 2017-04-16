using HorasHombre.Model;
using HorasHombre.Data.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorasHombre.Data.SqlClient
{
    public class SqlConceptoProvider : ConceptoProvider
    {
        public override Concepto ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Concepto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Concepto> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Concepto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }
        public override int Insertar(Concepto concepto)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Concepto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdConcepto", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CoConcepto", SqlDbType.VarChar).Value = concepto.Codigo;
                cmd.Parameters.Add("@NoConcepto", SqlDbType.VarChar).Value = concepto.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = concepto.DescripcionCorta;
                cmd.Parameters.Add("@TxReferencia", SqlDbType.VarChar).Value = concepto.Referencia;
                cmd.Parameters.Add("@NuTipoPlanilla", SqlDbType.Int).Value = concepto.TipoPlanilla;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = concepto.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdConcepto"].Value;
            }
        }

        public override bool Actualizar(Concepto concepto)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Concepto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = concepto.Id;
                cmd.Parameters.Add("@CoConcepto", SqlDbType.VarChar).Value = concepto.Codigo;
                cmd.Parameters.Add("@NoConcepto", SqlDbType.VarChar).Value = concepto.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = concepto.DescripcionCorta;
                cmd.Parameters.Add("@TxReferencia", SqlDbType.VarChar).Value = concepto.Referencia;
                cmd.Parameters.Add("@NuTipoPlanilla", SqlDbType.Int).Value = concepto.TipoPlanilla;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = concepto.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_Concepto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdConcepto", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
