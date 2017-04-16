using HorasHombre.Model;
using HorasHombre.Data.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HorasHombre.Data.SqlClient
{
    public class SqlConfiguracionProvider : ConfiguracionProvider
    {
        public override Configuracion ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Configuracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdConfiguracion", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }
        public override Configuracion ObtenerPorCodigo(string codigo)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorCodigo_Configuracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CoConfiguracion", SqlDbType.VarChar).Value = codigo;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Configuracion> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Configuracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(Configuracion configuracion)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Configuracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdConfiguracion", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = configuracion.Codigo;
                cmd.Parameters.Add("@TxDescripcion", SqlDbType.VarChar).Value = configuracion.Descripcion;
                cmd.Parameters.Add("@TxValor", SqlDbType.VarChar).Value = configuracion.Valor;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = configuracion.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdConfiguracion"].Value;
            }
        }

        public override bool Actualizar(Configuracion configuracion)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Configuracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdConfiguracion", SqlDbType.Int).Value = configuracion.Id;
                cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = configuracion.Codigo;
                cmd.Parameters.Add("@TxDescripcion", SqlDbType.VarChar).Value = configuracion.Descripcion;
                cmd.Parameters.Add("@TxValor", SqlDbType.VarChar).Value = configuracion.Valor;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = configuracion.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Delete_Configuracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdConfiguracion", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
