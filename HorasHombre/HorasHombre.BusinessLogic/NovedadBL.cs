using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class NovedadBL : BizObject
    {
        public static Novedad ObtenerPorId(int id)
        {
            return AppProvider.Novedad.ObtenerPorId(id);
        }

        public static Novedad ObtenerPorCodigo(string codigo)
        {
            return AppProvider.Novedad.ObtenerPorCodigo(codigo);
        }

        public static List<Novedad> ObtenerTodo()
        {
            return AppProvider.Novedad.ObtenerTodo();
        }

        public static int Insertar(Novedad novedad)
        {
            return AppProvider.Novedad.Insertar(novedad);
        }

        public static bool Actualizar(Novedad novedad)
        {
            return AppProvider.Novedad.Actualizar(novedad);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Novedad.Eliminar(id);
        }

        public static bool Activar(int id)
        {
            return AppProvider.Novedad.Activar(id);
        }
    }
}
