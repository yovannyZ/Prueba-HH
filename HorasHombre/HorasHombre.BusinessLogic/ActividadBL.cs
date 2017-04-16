using HorasHombre.Data;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ActividadBL : BizObject
    {
        public static Actividad ObtenerPorId(int id)
        {
            return AppProvider.Actividad.ObtenerPorId(id);
        }

        public static List<Actividad> ObtenerTodo()
        {
            return AppProvider.Actividad.ObtenerTodo();
        }

        public static List<Actividad> ObtenerTodoPorOrden(OrdenProduccion orden, bool costos)
        {
            var listaActividad = AppProvider.Actividad.ObtenerTodo();
            List<Actividad> lista = new List<Actividad>();
            if (!costos)
            {
                var listaActividadOrden = AppProvider.OrdenProduccionActividad.ObtenerTodo(orden);
                lista = listaActividad.Where(a => listaActividadOrden.Any(m => m.Actividad.Id == a.Id)).ToList();
            }
            else
            {
                var listaActividadOrden = AppProvider.ImportarCosto.ObtenerActividadesPorOrden(orden.NumeroOrden);
                Actividad a;
                for (int i = 0; i < listaActividadOrden.Count; i++)
                {
                    a = (from x in listaActividad
                         where x.Codigo == listaActividadOrden[i].Codigo
                         select x).FirstOrDefault();
                    if (a != null)
                    {
                        lista.Add(a);
                        BuscarActividadesHijas(a.Id, ref listaActividad, ref lista);
                    }
                }
            }

            return lista;
        }

        private static void BuscarActividadesHijas(int idActividadPrincipal, ref List<Actividad> listaActividad, ref List<Actividad> lista)
        {
            var listaHijos = listaActividad.Where(a => a.ActividadPrincipal.Id == idActividadPrincipal).ToList();
            Actividad ac;
            for (int i = 0; i < listaHijos.Count; i++)
            {
                ac = (from x in listaActividad
                      where x.Id == listaHijos[i].Id
                      select x).FirstOrDefault();
                if (ac != null)
                {
                    lista.Add(ac);
                    BuscarActividadesHijas(ac.Id, ref listaActividad, ref lista);
                }
            }
        }

        public static int Insertar(Actividad actividad)
        {
            return AppProvider.Actividad.Insertar(actividad);
        }

        public static bool Insertar(List<Actividad> actividades)
        {
            bool exito = true;
            for (int i = 0; i < actividades.Count; i++)
            {
                exito = AppProvider.Actividad.Insertar(actividades[i]) > 0;
                if (!exito)
                    break;
            }
            return exito;
        }

        public static bool Actualizar(Actividad actividad)
        {
            return AppProvider.Actividad.Actualizar(actividad);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Actividad.Eliminar(id);
        }

        public static bool Activar(int id)
        {
            return AppProvider.Actividad.Activar(id);
        }
    }
}
