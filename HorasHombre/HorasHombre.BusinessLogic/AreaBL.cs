using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class AreaBL : BizObject
    {
        public static Area ObtenerPorId(int id)
        {
            return AppProvider.Area.ObtenerPorId(id);
        }

        public static List<Area> ObtenerTodo()
        {
            return AppProvider.Area.ObtenerTodo();
        }

        public static int Insertar(Area area)
        {
            return AppProvider.Area.Insertar(area);
        }

        public static bool Actualizar(Area area)
        {
            return AppProvider.Area.Actualizar(area);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Area.Eliminar(id);
        }

        public static bool Activar(int id)
        {
            return AppProvider.Area.Activar(id);
        }
    }
}
