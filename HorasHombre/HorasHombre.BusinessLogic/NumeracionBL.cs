using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class NumeracionBL : BizObject
    {
        public static Numeracion ObtenerPorId(int idArea)
        {
            return AppProvider.Numeracion.ObtenerPorId(idArea);
        }

        public static List<Numeracion> ObtenerTodo()
        {
            return AppProvider.Numeracion.ObtenerTodo();
        }

        public static int Insertar(Numeracion numeracion)
        {
            return AppProvider.Numeracion.Insertar(numeracion);
        }

        public static bool Actualizar(Numeracion numeracion)
        {
            return AppProvider.Numeracion.Actualizar(numeracion);
        }

        //public static bool DeleteNumeracion(int _IdArea)
        //{
        //    return AppProvider.Numeracion.DeleteNumeracion(_IdArea);
        //}
    }
}
