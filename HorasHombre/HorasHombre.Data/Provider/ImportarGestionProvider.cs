using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class ImportarGestionProvider : DataAccessGestion
    {
        static private ImportarGestionProvider _instance = null;
        static public ImportarGestionProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ImportarGestionProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlImportarGestionProvider"));
                return _instance;
            }
        }
        public abstract List<Persona> ObtenerPersonas();
        public abstract List<CentroCosto> ObtenerCentrosCosto();
        public abstract List<Sucursal> ObtenerSucursales();

        public virtual Persona GetPersonaFromReader(IDataReader reader)
        {
            Persona persona = null;

            persona = new Persona()
            {
                Codigo = reader["Cod_Per"].ToString().Trim(),
                Nombre = reader["Nombre"].ToString().Trim(),
                ApellidoPaterno = reader["Paterno"].ToString().Trim(),
                ApellidoMaterno = reader["Materno"].ToString().Trim(),
                TipoPersona = reader["Tipo_Per"].ToString() == "N" ? TipoPersona.Natural : TipoPersona.Juridica,
                TipoDocumento = new DocumentoPersona() { Id = int.Parse(reader["IdDocumento"].ToString()) },
                NumeroDocumento = reader["Nro_Doc"].ToString().Trim(),
                Email = reader["Mail"].ToString().Trim()
            };
            if (string.IsNullOrEmpty(reader["Paterno"].ToString().Trim()) && string.IsNullOrEmpty(reader["Materno"].ToString().Trim()) &&
                string.IsNullOrEmpty(reader["Nombre"].ToString().Trim()))
                persona.Nombre = reader["Desc_Per"].ToString().Trim();

            return persona;
        }
        public virtual List<Persona> GetPersonasFromReader(IDataReader reader)
        {
            List<Persona> ObjPersona = new List<Persona>();
            while (reader.Read())
                ObjPersona.Add(GetPersonaFromReader(reader));
            return ObjPersona;
        }

        public virtual CentroCosto GetCentroCostoFromReader(IDataReader reader)
        {
            CentroCosto cc = null;

            cc = new CentroCosto()
            {
                Codigo = reader["Cod_Area"].ToString().Trim(),
                Nombre = reader["Desc_Area"].ToString().Trim(),
                DescripcionCorta = reader["Desc_Corta"].ToString().Trim()
            };

            return cc;
        }
        public virtual List<CentroCosto> GetCentrosCostoFromReader(IDataReader reader)
        {
            List<CentroCosto> ObjCentroCosto = new List<CentroCosto>();
            while (reader.Read())
                ObjCentroCosto.Add(GetCentroCostoFromReader(reader));
            return ObjCentroCosto;
        }

        public virtual Sucursal GetSucursalFromReader(IDataReader reader)
        {
            Sucursal s = null;

            s = new Sucursal();
            s.Codigo = reader["Cod_Sucursal"].ToString().Trim();
            s.Nombre = reader["Desc_Sucursal"].ToString().Trim();
            s.DescripcionCorta = reader["Desc_Corta"].ToString().Trim();
            s.NumeroRuc = reader["Nro_Ruc"].ToString().Trim();
            s.Telefono = reader["Telefono"].ToString().Trim();
            s.Direccion = reader["Direccion"].ToString().Trim();


            return s;
        }
        public virtual List<Sucursal> GetSucursalesFromReader(IDataReader reader)
        {
            List<Sucursal> ObjSucursal = new List<Sucursal>();
            while (reader.Read())
                ObjSucursal.Add(GetSucursalFromReader(reader));
            return ObjSucursal;
        }
    }
}
