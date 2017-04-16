using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BLL
{
    public class OrdenProduccionActividadBL : BizObject
    {
        public static OrdenProduccionActividad ObtenerPorId(int id)
        {
            return AppProvider.OrdenProduccionActividad.ObtenerPorId(id);
        }

        public static OrdenProduccionActividad ObtenerPorId(OrdenProduccion orden, Actividad actividad)
        {
            var lista = AppProvider.OrdenProduccionActividad.ObtenerTodo(orden);
            var r = lista.Where(c => c.Actividad.Id == actividad.Id).FirstOrDefault();
            var listaOrden = AppProvider.OrdenProduccion.ObtenerTodo();
            var listaActividad = AppProvider.Actividad.ObtenerTodo();
            r.OrdenProduccion = (from x in listaOrden
                                 where x.Id == r.OrdenProduccion.Id
                                 select x).FirstOrDefault();
            r.Actividad = (from x in listaActividad
                           where x.Id == r.Actividad.Id
                           select x).FirstOrDefault();
            return r;
        }

        public static List<OrdenProduccionActividad> ObtenerTodo(OrdenProduccion orden)
        {
            var lista = AppProvider.OrdenProduccionActividad.ObtenerTodo(orden);
            for (int i = 0; i < lista.Count; i++)
                lista[i].Actividad = AppProvider.Actividad.ObtenerPorId(lista[i].Actividad.Id);

            return lista;
        }

        public static bool Insertar(List<OrdenProduccionActividad> asignacion)
        {
            bool exito = true;
            using (TransactionScope trx = new TransactionScope())
            {
                List<OrdenProduccionActividad> listaAnterior = AppProvider.OrdenProduccionActividad.ObtenerTodo(asignacion[0].OrdenProduccion).Where(x => x.EstaActivo == true).ToList();
                List<OrdenProduccionActividad> eliminados = listaAnterior.Where(a => !asignacion.Any(m => m.Actividad.Id == a.Actividad.Id)).ToList();
                List<OrdenProduccionActividad> nuevos = asignacion.Where(a => !listaAnterior.Any(m => m.Actividad.Id == a.Actividad.Id)).ToList();
                for (int i = 0; i < eliminados.Count; i++)
                {
                    exito = AppProvider.OrdenProduccionActividad.Eliminar(eliminados[i].Id);
                    if (!exito)
                        return false;
                }

                if (exito)
                {
                    for (int i = 0; i < nuevos.Count; i++)
                    {
                        exito = AppProvider.OrdenProduccionActividad.Insertar(nuevos[i]) > 0;
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

        public static bool Actualizar(OrdenProduccionActividad ordenProduccionActividad)
        {
            return AppProvider.OrdenProduccionActividad.Actualizar(ordenProduccionActividad);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.OrdenProduccionActividad.Eliminar(id);
        }
    }
}
