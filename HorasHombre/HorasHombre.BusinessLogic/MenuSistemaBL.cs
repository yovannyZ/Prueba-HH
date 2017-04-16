using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class MenuSistemaBL : BizObject
    {
        public static MenuSistema ObtenerPorId(int id)
        {
            return AppProvider.Menu.ObtenerPorId(id);
        }

        public static MenuSistema ObtenerPorNombre(string nombre)
        {
            return AppProvider.Menu.ObtenerPorNombre(nombre);
        }

        public static List<MenuSistema> ObtenerTodo()
        {
            return AppProvider.Menu.ObtenerTodo();
        }

        public static int Insertar(MenuSistema menu)
        {
            return AppProvider.Menu.Insertar(menu);
        }

        public static bool Actualizar(MenuSistema menu)
        {
            return AppProvider.Menu.Actualizar(menu);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Menu.Eliminar(id);
        }
    }
}
