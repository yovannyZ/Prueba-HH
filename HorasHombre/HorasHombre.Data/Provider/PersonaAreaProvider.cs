using System;
using System.Collections.Generic;
using System.Data;
using HorasHombre.Model;

namespace HorasHombre.Data.Provider
{
    public abstract class PersonaAreaProvider : DataAccess
    {
        static private PersonaAreaProvider _instance = null;
        static public PersonaAreaProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (PersonaAreaProvider)Activator.CreateInstance(Type.GetType("HorasHombre.Data.SqlClient.SqlPersonaAreaProvider"));
                return _instance;
            }
        }

        public abstract PersonaArea ObtenerPorId(PersonaArea PersonaArea);
        public abstract List<PersonaArea> ObtenerTodo(int idArea);
        public abstract bool Insertar(PersonaArea objPersonaArea);
        public abstract bool Eliminar(int idArea);

        public virtual PersonaArea GetFromReader(IDataReader reader)
        {
            PersonaArea s = null;

            s = new PersonaArea();
            s.Area = new Area() { Id = int.Parse(reader["IdArea"].ToString()) };
            s.Persona = new Persona() { Id = int.Parse(reader["IdPersona"].ToString()) };
            return s;
        }

        public virtual List<PersonaArea> GetCollectionFromReader(IDataReader reader)
        {
            List<PersonaArea> ObjPersonaArea = new List<PersonaArea>();
            while (reader.Read())
                ObjPersonaArea.Add(GetFromReader(reader));
            return ObjPersonaArea;
        }
    }
}
