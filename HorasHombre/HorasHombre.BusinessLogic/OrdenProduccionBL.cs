using HorasHombre.Data;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class OrdenProduccionBL : BizObject
    {
        public static OrdenProduccion ObtenerPorId(int idOrdenProduccion)
        {
            return AppProvider.OrdenProduccion.ObtenerPorId(idOrdenProduccion);
        }
        public static List<OrdenProduccion> ObtenerTodo()
        {
            return AppProvider.OrdenProduccion.ObtenerTodo();
        }

        public static List<Actividad> ObtenerActividades(OrdenProduccion ordenProduccion)
        {
            var lista = AppProvider.ImportarCosto.ObtenerActividadesPorOrden(ordenProduccion.NumeroOrden);
            return lista;
        }
    }
}
