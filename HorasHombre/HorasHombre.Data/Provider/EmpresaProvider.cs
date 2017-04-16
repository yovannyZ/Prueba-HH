using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class EmpresaProvider : DataAccessBdGeneral
    {
        static private EmpresaProvider _instance = null;
        static public EmpresaProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (EmpresaProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlEmpresaProvider"));
                return _instance;
            }
        }

        public abstract Empresa ObtenerPorId(int idEmpresa);
        public abstract List<Empresa> ObtenerTodo();

        public virtual Empresa GetFromReader(IDataReader reader)
        {
            Empresa empresa = null;
            empresa = new Empresa();
            empresa.Id = int.Parse(reader["IdEmpresa"].ToString());
            empresa.Codigo = reader["Cod_Empresa"].ToString();
            empresa.Nombre = reader["Razon_Social"].ToString();
            empresa.NumeroRuc = reader["Nro_Ruc"].ToString();

            return empresa;
        }

        public virtual List<Empresa> GetCollectionFromReader(IDataReader reader)
        {
            List<Empresa> ObjEmpresa = new List<Empresa>();
            while (reader.Read())
                ObjEmpresa.Add(GetFromReader(reader));
            return ObjEmpresa;
        }
    }
}
