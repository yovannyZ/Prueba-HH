using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HorasHombre.Data.Provider
{
    public abstract class ConfiguracionProvider : DataAccess
    {
        static private ConfiguracionProvider _instance = null;
        static public ConfiguracionProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ConfiguracionProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlConfiguracionProvider"));
                return _instance;
            }
        }

        public abstract Configuracion ObtenerPorId(int id);
        public abstract Configuracion ObtenerPorCodigo(string codigo);
        public abstract List<Configuracion> ObtenerTodo();
        public abstract int Insertar(Configuracion configuracion);
        public abstract bool Actualizar(Configuracion configuracion);
        public abstract bool Eliminar(int id);

        public virtual Configuracion GetFromReader(IDataReader reader)
        {
            Configuracion c = new Configuracion();
            c.Id = int.Parse(reader["IdConfiguracion"].ToString());
            c.Codigo = reader["CoConfiguracion"].ToString();
            c.Descripcion = reader["TxDescripcion"].ToString();
            c.Valor = reader["TxValor"].ToString();
            c.EstaActivo = bool.Parse(reader["FlActivo"].ToString());
            return c;
        }

        public virtual List<Configuracion> GetCollectionFromReader(IDataReader reader)
        {
            List<Configuracion> ObjConfiguracion = new List<Configuracion>();
            while (reader.Read())
                ObjConfiguracion.Add(GetFromReader(reader));
            return ObjConfiguracion;
        }
    }
}
