using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HorasHombre.Model;
using HorasHombre.Data.Provider;

namespace HorasHombre.Data.SqlClient
{
    public class SqlImportarGestionProvider : ImportarGestionProvider
    {
        public override List<Persona> ObtenerPersonas()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select A.Cod_Per, Nombre, Paterno, Materno, Desc_Per, Tipo_Per, " +
                    "IdDocumento, Nro_Doc, Mail From Maestro_Personas A Inner Join BD_General_Coi.dbo.Documento_Personal B " + 
                    "On A.Cod_Tipo_Doc = B.Cod_Tipo Inner Join Persona_CLase C On A.Cod_Per = C.Cod_Per And " +
                    "C.Cod_Clase = 1 And C.Cod_Cat=2 Order By Tipo_Per, IdDocumento, A.Cod_per", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetPersonasFromReader(ExecuteReader(cmd));
            }
        }

        public override List<CentroCosto> ObtenerCentrosCosto()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select Cod_Area, Desc_Area, Desc_Corta From Area", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetCentrosCostoFromReader(ExecuteReader(cmd));
            }
        }

        public override List<Sucursal> ObtenerSucursales()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select Cod_Sucursal, Desc_Sucursal, Desc_Corta, Nro_Ruc, Telefono, Direccion, " +
                    "Localidad From Sucursal", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                return GetSucursalesFromReader(ExecuteReader(cmd));
            }
        }
    }
}
