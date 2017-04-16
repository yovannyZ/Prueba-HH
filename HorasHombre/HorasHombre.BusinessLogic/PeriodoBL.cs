using System;
using System.Collections.Generic;
using HorasHombre.Data;
using HorasHombre.Model;
using System.Linq;

namespace BLL
{
    public class PeriodoBL : BizObject
    {
        public static Periodo ObtenerPorId(int id)
        {
            return AppProvider.Periodo.ObtenerPorId(id);
        }

        public static Periodo ObtenerPorFechaInicio(DateTime fechaInicio)
        {
            return AppProvider.Periodo.ObtenerPorFechaInicio(fechaInicio);
        }

        public static Periodo ObtenerActivo(Modulo modulo)
        {
            return AppProvider.Periodo.ObtenerActivo(modulo);
        }

        public static List<Periodo> ObtenerTodo()
        {
            return AppProvider.Periodo.ObtenerTodo();
        }

        public static int Insertar(Periodo periodo)
        {
            return AppProvider.Periodo.Insertar(periodo);
        }

        public static bool Actualizar(Periodo periodo)
        {
            return AppProvider.Periodo.Actualizar(periodo);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Periodo.Eliminar(id);
        }

        public static bool Activar(Periodo periodo)
        {
            periodo.EstaActivo = !periodo.EstaActivo;
            return AppProvider.Periodo.Activar(periodo);
        }

        public static bool Close(Periodo periodo)
        {
            bool exito = false;
            return exito;
        }
    }
}
