using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlPersonaAreaProvider : PersonaAreaProvider
    {
        public override PersonaArea ObtenerPorId(PersonaArea personaArea)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_PersonaArea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = personaArea.Area.Id;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = personaArea.Persona.Id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<PersonaArea> ObtenerTodo(int idArea)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_PersonaArea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = idArea;
                cn.Open();
                return GetCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override bool Insertar(PersonaArea personaArea)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_PersonaArea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = personaArea.Area.Id;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = personaArea.Persona.Id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret > 0;
            }
        }

        public override bool Eliminar(int idArea)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_PersonaArea", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdArea", SqlDbType.Int).Value = idArea;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret >= 0);
            }
        }

    }
}
