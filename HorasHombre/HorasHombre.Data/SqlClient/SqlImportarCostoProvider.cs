using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlImportarCostoProvider : ImportarCostoProvider
    {
        public override List<Actividad> ObtenerActividades()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select Cod_Actividad, Desc_Actividad, Desc_Corta, Observacion From Actividad", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetActividadesFromReader(ExecuteReader(cmd));
            }
        }

        public override List<Actividad> ObtenerActividadesPorOrden(string numeroOrden)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select A.Cod_Actividad, Desc_Actividad, Desc_Corta, A.Observacion " +
                "From Actividad A Inner Join Orden_Produccion_Actividad B On A.Cod_Actividad = B.Cod_Actividad " +
                "Where B.Nro_Ord_Prod = @Nro_OP", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Nro_OP", SqlDbType.VarChar).Value = numeroOrden;
                cn.Open();
                return GetActividadesFromReader(ExecuteReader(cmd));
            }
        }
    }
}
