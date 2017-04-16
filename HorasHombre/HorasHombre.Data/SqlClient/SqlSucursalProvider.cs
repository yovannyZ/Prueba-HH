using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlSucursalProvider : SucursalProvider
    {
        public override Sucursal ObtenerPorId(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerPorId_Sucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFromReader(reader);
                return null;
            }
        }

        public override List<Sucursal> ObtenerTodo()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_ObtenerTodo_Sucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetSucursalCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int Insertar(Sucursal sucursal)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Insertar_Sucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CoSucursal", SqlDbType.VarChar).Value = sucursal.Codigo;
                cmd.Parameters.Add("@NoSucursal", SqlDbType.VarChar).Value = sucursal.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = sucursal.DescripcionCorta;
                cmd.Parameters.Add("@TxNumeroRuc", SqlDbType.VarChar).Value = sucursal.NumeroRuc;
                cmd.Parameters.Add("@TxTelefono", SqlDbType.VarChar).Value = sucursal.Telefono;
                cmd.Parameters.Add("@TxDireccion", SqlDbType.VarChar).Value = sucursal.Direccion;
                cmd.Parameters.Add("@TxLocalidad", SqlDbType.VarChar).Value = sucursal.Localidad;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = sucursal.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@IdSucursal"].Value;
            }
        }

        public override bool Actualizar(Sucursal sucursal)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Actualizar_Sucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = sucursal.Id;
                cmd.Parameters.Add("@CoSucursal", SqlDbType.VarChar).Value = sucursal.Codigo;
                cmd.Parameters.Add("@NoSucursal", SqlDbType.VarChar).Value = sucursal.Nombre;
                cmd.Parameters.Add("@TxDescripcionCorta", SqlDbType.VarChar).Value = sucursal.DescripcionCorta;
                cmd.Parameters.Add("@TxNumeroRuc", SqlDbType.VarChar).Value = sucursal.NumeroRuc;
                cmd.Parameters.Add("@TxTelefono", SqlDbType.VarChar).Value = sucursal.Telefono;
                cmd.Parameters.Add("@TxDireccion", SqlDbType.VarChar).Value = sucursal.Direccion;
                cmd.Parameters.Add("@TxLocalidad", SqlDbType.VarChar).Value = sucursal.Localidad;
                cmd.Parameters.Add("@FlActivo", SqlDbType.Bit).Value = sucursal.EstaActivo;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Eliminar_Sucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public override bool Activar(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pa_Activar_Sucursal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = id;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

    }
}
