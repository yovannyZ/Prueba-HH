using System;
using System.Collections.Generic;
using HorasHombre.Data;
using HorasHombre.Model;
using System.Transactions;

namespace BLL
{
    public class PersonaAreaBL : BizObject
    {
        public static List<PersonaArea> ObtenerTodo(Area area)
        {
            var lista = AppProvider.PersonaArea.ObtenerTodo(area.Id);
            for (int i = 0; i < lista.Count; i++)
                lista[i].Persona = AppProvider.Persona.ObtenerPorId(lista[i].Persona.Id);

            return lista;
        }

        public static bool Insertar(List<PersonaArea> asignacion)
        {
            bool exito = false;
            using (TransactionScope trx = new TransactionScope())
            {
                exito = AppProvider.PersonaArea.Eliminar(asignacion[0].Area.Id);
                if (exito)
                {
                    foreach (var item in asignacion)
                    {
                        exito = AppProvider.PersonaArea.Insertar(item);
                        if (!exito)
                            return false;
                    }
                }
                if (!exito)
                    throw new Exception("Error desconocido al grabar la distribución");
                trx.Complete();
            }
            return exito;
        }

        public static bool Eliminar(Area area)
        {
            return AppProvider.PersonaArea.Eliminar(area.Id);
        }

    }
}
