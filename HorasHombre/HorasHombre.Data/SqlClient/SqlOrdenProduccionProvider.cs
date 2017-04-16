using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;


namespace HorasHombre.Data.SqlClient
{
    public class SqlOrdenProduccionProvider : OrdenProduccionProvider
    {
        public override OrdenProduccion ObtenerPorId(int idOrdenProduccion)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select IdOrdenProduccion, Nro_Ord_Prod, B.Desc_Articulo, Fecha_Cierre From Orden_Produccion A " +
                    "Inner Join Articulo B On A.Cod_Articulo = B.Cod_Articulo Where IdOrdenProduccion=@IdOrdenProduccion", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@IdOrdenProduccion", SqlDbType.Int).Value = idOrdenProduccion;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<OrdenProduccion> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select IdOrdenProduccion, Nro_Ord_Prod, B.Desc_Articulo, Fecha_Cierre From Orden_Produccion A " +
                    "Inner Join Articulo B On A.Cod_Articulo = B.Cod_Articulo", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetOrdenesProduccionFromReader(ExecuteReader(cmd));
            }
        }
    }
}
