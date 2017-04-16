using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BLL
{
    public class PlanillaBL : BizObject
    {
        public static Planilla ObtenerPorId(int id)
        {
            var listaSucursal = AppProvider.Sucursal.ObtenerTodo();
            var listaArea = AppProvider.Area.ObtenerTodo();
            var listaUsuario = AppProvider.Usuario.ObtenerTodo();
            var planilla = AppProvider.Planilla.ObtenerPorId(id);
            if (planilla != null)
            {
                planilla.Sucursal = (from x in listaSucursal
                                     where x.Id == planilla.Sucursal.Id
                                     select x).FirstOrDefault();
                planilla.Area = (from x in listaArea
                                 where x.Id == planilla.Area.Id
                                 select x).FirstOrDefault();
                planilla.Usuario = (from x in listaUsuario
                                    where x.Id == planilla.Usuario.Id
                                    select x).FirstOrDefault();
            }


            return planilla;
        }

        public static List<Planilla> ObtenerTodo()
        {
            var lista = AppProvider.Planilla.ObtenerTodo();
            var listaSucursal = AppProvider.Sucursal.ObtenerTodo();
            var listaArea = AppProvider.Area.ObtenerTodo();
            var listaUsuario = AppProvider.Usuario.ObtenerTodo();

            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].Sucursal = (from x in listaSucursal
                                     where x.Id == lista[i].Sucursal.Id
                                     select x).FirstOrDefault();
                lista[i].Area = (from x in listaArea
                                 where x.Id == lista[i].Area.Id
                                 select x).FirstOrDefault();
                lista[i].Usuario = (from x in listaUsuario
                                    where x.Id == lista[i].Usuario.Id
                                    select x).FirstOrDefault();
            }
            return lista;
        }

        public static List<Planilla> ObtenerTodoConDetalle()
        {
            var lista = AppProvider.Planilla.ObtenerTodo();
            var listaSucursal = AppProvider.Sucursal.ObtenerTodo();
            var listaArea = AppProvider.Area.ObtenerTodo();

            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].Sucursal = (from x in listaSucursal
                                     where x.Id == lista[i].Sucursal.Id
                                     select x).FirstOrDefault();
                lista[i].Area = (from x in listaArea
                                 where x.Id == lista[i].Area.Id
                                 select x).FirstOrDefault();
                lista[i].Detalle = ObtenerDetalle(lista[i]);
            }
            return lista;
        }

        public static List<PlanillaDetalle> ObtenerDetalle(Planilla planilla)
        {
            var lista = AppProvider.PlanillaDetalle.ObtenerPorId(planilla.Id);
            var listaPersona = AppProvider.Persona.ObtenerTodo();
            var listaNovedad = AppProvider.Novedad.ObtenerTodo();
            var listaCentroCosto = AppProvider.CentroCosto.ObtenerTodo();
            var listaOrden = AppProvider.OrdenProduccion.ObtenerTodo();
            var listaActividad = AppProvider.Actividad.ObtenerTodo();

            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].Planilla = planilla;
                lista[i].Persona = (from x in listaPersona
                                    where x.Id == lista[i].Persona.Id
                                    select x).FirstOrDefault();
                lista[i].Novedad = (from x in listaNovedad
                                    where x.Id == lista[i].Novedad.Id
                                    select x).FirstOrDefault();
                if (lista[i].CentroCosto.Id != 0)
                    lista[i].CentroCosto = (from x in listaCentroCosto
                                            where x.Id == lista[i].CentroCosto.Id
                                            select x).FirstOrDefault();
                else
                {
                    var r = AppProvider.OrdenProduccionActividad.ObtenerPorId(lista[i].RelacionActividad.Id);
                    if (r != null)
                    {
                        lista[i].RelacionActividad.OrdenProduccion = (from x in listaOrden
                                                                      where x.Id == r.OrdenProduccion.Id
                                                                      select x).FirstOrDefault();
                        lista[i].RelacionActividad.Actividad = (from x in listaActividad
                                                                where x.Id == r.Actividad.Id
                                                                select x).FirstOrDefault();
                    }

                }

            }
            return lista;
        }

        public static bool Insertar(Planilla planilla)
        {
            bool exito = false;
            int id = 0;
            using (TransactionScope trx = new TransactionScope(TransactionScopeOption.Required, System.TimeSpan.MaxValue))
            {
                id = AppProvider.Planilla.Insertar(planilla);
                exito = id > 0;
                if (exito)
                {
                    for (int i = 0; i < planilla.Detalle.Count; i++)
                    {
                        exito = AppProvider.PlanillaDetalle.Insertar(planilla.Detalle[i], id);
                        if (!exito)
                            return false;
                    }
                }
                if (exito)
                {
                    planilla.Id = id;
                    var n = AppProvider.Numeracion.ObtenerPorId(planilla.Area.Id);
                    n.NumeroCorrelativo = (int.Parse(planilla.NumeroPlanilla.ToString()) + 1).ToString();
                    exito = AppProvider.Numeracion.Actualizar(n);
                }

                if (!exito)
                    throw new Exception("Error desconocido al grabar la planilla");
                trx.Complete();
            }
            return exito;
        }

        public static bool Actualizar(Planilla planilla)
        {
            bool exito = false;
            int id = planilla.Id;
            using (TransactionScope trx = new TransactionScope(TransactionScopeOption.Required, System.TimeSpan.MaxValue))
            {
                exito = AppProvider.PlanillaDetalle.Eliminar(planilla.Id);
                if (exito)
                {
                    for (int i = 0; i < planilla.Detalle.Count; i++)
                    {
                        if (planilla.Detalle[i].Id == 0)
                            exito = AppProvider.PlanillaDetalle.Insertar(planilla.Detalle[i], id);
                        else
                            exito = AppProvider.PlanillaDetalle.Actualizar(planilla.Detalle[i]);
                        if (!exito)
                            return false;
                    }
                }

                if (!exito)
                    throw new Exception("Error desconocido al grabar la planilla");
                trx.Complete();

            }
            return exito;
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Planilla.Eliminar(id);
        }
    }
}
