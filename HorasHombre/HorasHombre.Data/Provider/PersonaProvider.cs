using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class PersonaProvider : DataAccess
    {
        static private PersonaProvider _instance = null;
        static public PersonaProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (PersonaProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlPersonaProvider"));
                return _instance;
            }
        }

        public abstract Persona ObtenerPorId(int id);
        public abstract List<Persona> ObtenerTodo();
        public abstract int Insertar(Persona persona);
        public abstract bool Actualizar(Persona persona);
        public abstract bool Eliminar(int id);
        public abstract bool Activar(int id);

        public virtual Persona GetFromReader(IDataReader reader)
        {
            Persona p = new Persona();
            p.Id = int.Parse(reader["IdPersona"].ToString());
            p.Codigo = reader["CoPersona"].ToString();
            p.Nombre = reader["NoPersona"].ToString();
            p.ApellidoPaterno = reader["TxPaterno"].ToString();
            p.ApellidoMaterno = reader["TxMaterno"].ToString();
            p.TipoPersona = (TipoPersona)int.Parse(reader["NuTipo"].ToString());
            p.TipoDocumento = new DocumentoPersona() { Id = int.Parse(reader["NuTipoDocumento"].ToString()) };
            p.NumeroDocumento = reader["TxNumeroDocumento"].ToString();
            p.Email = reader["TxEmail"].ToString();
            p.CentroCosto = new CentroCosto() { Id = int.Parse(reader["IdCentroCosto"].ToString()) };
            p.EstaActivo = bool.Parse(reader["FlActivo"].ToString());

            return p;
        }

        public virtual List<Persona> GetCollectionFromReader(IDataReader reader)
        {
            List<Persona> ObjPersona = new List<Persona>();
            while (reader.Read())
                ObjPersona.Add(GetFromReader(reader));
            return ObjPersona;
        }
    }
}
