using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class PersonaBL : BizObject
    {
        public static Persona ObtenerPorId(int id)
        {
            var r = AppProvider.Persona.ObtenerPorId(id);
            if (r != null)
                r.CentroCosto = AppProvider.CentroCosto.ObtenerPorId(r.CentroCosto.Id);
            return r;
        }

        public static List<Persona> ObtenerTodo()
        {
            var lista = AppProvider.Persona.ObtenerTodo();
            var listaCentroCosto = AppProvider.CentroCosto.ObtenerTodo();
            for (int i = 0; i < lista.Count; i++)
                lista[i].CentroCosto = (from x in listaCentroCosto
                                        where x.Id == lista[i].CentroCosto.Id
                                        select x).FirstOrDefault();
            return lista;
        }

        public static List<Persona> ObtenerTodoPorArea(Area area)
        {
            var lista = AppProvider.Persona.ObtenerTodo();
            var listaPersonaArea = AppProvider.PersonaArea.ObtenerTodo(area.Id);
            var listaCentroCosto = AppProvider.CentroCosto.ObtenerTodo();
            lista = lista.Where(a => listaPersonaArea.Any(m => m.Persona.Id == a.Id)).ToList();
            for (int i = 0; i < lista.Count; i++)
                lista[i].CentroCosto = (from x in listaCentroCosto
                                        where x.Id == lista[i].CentroCosto.Id
                                        select x).FirstOrDefault();
            return lista;
        }

        public static int Insertar(Persona persona)
        {
            return AppProvider.Persona.Insertar(persona);
        }

        public static bool Insertar(List<Persona> personas)
        {
            bool exito = true;
            for (int i = 0; i < personas.Count; i++)
            {
                exito = AppProvider.Persona.Insertar(personas[i]) > 0;
                if (!exito)
                    break;
            }
            return exito;
        }

        public static bool Actualizar(Persona persona)
        {
            return AppProvider.Persona.Actualizar(persona);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Persona.Eliminar(id);
        }

        public static bool Activar(int id)
        {
            return AppProvider.Persona.Activar(id);
        }
    }
}
