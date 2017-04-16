using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ConfiguracionBL : BizObject
    {
        public static Configuracion ObtenerPorId(int id)
        {
            return AppProvider.Configuracion.ObtenerPorId(id);
        }

        public static Configuracion ObtenerPorCodigo(string codigo)
        {
            return AppProvider.Configuracion.ObtenerPorCodigo(codigo);
        }

        public static List<Configuracion> ObtenerTodo()
        {
            return AppProvider.Configuracion.ObtenerTodo();
        }

        public static int Insertar(Configuracion configuracion)
        {
            return AppProvider.Configuracion.Insertar(configuracion);
        }

        public static bool Actualizar(Configuracion configuracion)
        {
            return AppProvider.Configuracion.Actualizar(configuracion);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Configuracion.Eliminar(id);
        }
    }
}
