using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlPersonaProvider : PersonaProvider
    {
        public override Persona ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Persona> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(Persona persona)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CoPersona", SqlDbType.VarChar).Value = persona.Codigo;
                cmd.Parameters.Add("@NoPersona", SqlDbType.VarChar).Value = persona.Nombre;
                cmd.Parameters.Add("@TxPaterno", SqlDbType.VarChar).Value = persona.ApellidoPaterno;
                cmd.Parameters.Add("@TxMaterno", SqlDbType.VarChar).Value = persona.ApellidoMaterno;
                cmd.Parameters.Add("@NuTipo", SqlDbType.Int).Value = persona.TipoPersona;
                cmd.Parameters.Add("@NuTipoDocumento", SqlDbType.Int).Value = persona.TipoDocumento.Id;
                cmd.Parameters.Add("@TxNumeroDocumento", SqlDbType.VarChar).Value = persona.NumeroDocumento;
                cmd.Parameters.Add("@TxEmail", SqlDbType.VarChar).Value = persona.Email;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = persona.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdPersona"].Value;
            }
        }

        public override bool Actualizar(Persona persona)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = persona.Id;
                cmd.Parameters.Add("@CoPersona", SqlDbType.VarChar).Value = persona.Codigo;
                cmd.Parameters.Add("@NoPersona", SqlDbType.VarChar).Value = persona.Nombre;
                cmd.Parameters.Add("@TxPaterno", SqlDbType.VarChar).Value = persona.ApellidoPaterno;
                cmd.Parameters.Add("@TxMaterno", SqlDbType.VarChar).Value = persona.ApellidoMaterno;
                cmd.Parameters.Add("@NuTipo", SqlDbType.Int).Value = persona.TipoPersona;
                cmd.Parameters.Add("@NuTipoDocumento", SqlDbType.Int).Value = persona.TipoDocumento.Id;
                cmd.Parameters.Add("@TxNumeroDocumento", SqlDbType.VarChar).Value = persona.NumeroDocumento;
                cmd.Parameters.Add("@TxEmail", SqlDbType.VarChar).Value = persona.Email;
                cmd.Parameters.Add("@IdCentroCosto", SqlDbType.Int).Value = persona.CentroCosto.Id;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = persona.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Activar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Activar_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
