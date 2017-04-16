using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class ImportarCostoProvider : DataAccessCostos
    {
        static private ImportarCostoProvider _instance = null;
        static public ImportarCostoProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ImportarCostoProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlImportarCostoProvider"));
                return _instance;
            }
        }
        public abstract List<Actividad> ObtenerActividades();
        public abstract List<Actividad> ObtenerActividadesPorOrden(string numeroOrden);

        public virtual Actividad GetActividadFromReader(IDataReader reader)
        {
            Actividad a = new Actividad();
            a.Codigo = reader["Cod_Actividad"].ToString().Trim();
            a.Nombre = reader["Desc_Actividad"].ToString().Trim();
            a.DescripcionCorta = reader["Desc_Corta"].ToString().Trim();
            a.Observacion = reader["Observacion"].ToString().Trim();
            a.Nivel = 1;

            return a;
        }
        public virtual List<Actividad> GetActividadesFromReader(IDataReader reader)
        {
            List<Actividad> ObjActividad = new List<Actividad>();
            while (reader.Read())
                ObjActividad.Add(GetActividadFromReader(reader));
            return ObjActividad;
        }
    }
}
