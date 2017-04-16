using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PlanillaDetalleBL : BizObject
    {
        public static List<PlanillaDetalle> ObtenerPorId(int id)
        {
            return AppProvider.PlanillaDetalle.ObtenerPorId(id);
        }

        //public static List<PlanillaDetalle> ObtenerTodo()
        //{
        //    return AppProvider.Planilla.();
        //}

        public static bool Insertar(PlanillaDetalle planillaDetalle, int idPlanilla)
        {
            return AppProvider.PlanillaDetalle.Insertar(planillaDetalle, idPlanilla);
        }

        public static bool Actualizar(PlanillaDetalle planillaDetalle)
        {
            return AppProvider.PlanillaDetalle.Actualizar(planillaDetalle);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.PlanillaDetalle.Eliminar(id);
        }
    }
}
