using HorasHombre.Data;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ImportarBL : BizObject
    {
        public static List<Actividad> ObtenerActividades()
        {
            var listaNuevos = AppProvider.ImportarCosto.ObtenerActividades();
            var listaAnteriores = AppProvider.Actividad.ObtenerTodo();
            var lista = (from x in listaNuevos
                         where !listaAnteriores.Any(p => p.Codigo == x.Codigo)
                         select x).ToList();

            return lista;
            //return AppProvider.ImportarCosto.ObtenerActividades();
        }

        public static List<CentroCosto> ObtenerCentrosCosto()
        {
            var listaNuevos = AppProvider.ImportarGestion.ObtenerCentrosCosto();
            var listaAnteriores = AppProvider.CentroCosto.ObtenerTodo();
            var lista = (from x in listaNuevos
                         where !listaAnteriores.Any(p => p.Codigo == x.Codigo)
                         select x).ToList();

            return lista;
            //return AppProvider.ImportarGestion.ObtenerCentrosCosto();
        }

        public static List<Concepto> ObtenerConceptos()
        {
            var listaNuevos = AppProvider.ImportarKsd.ObtenerConceptos();
            var listaAnteriores = AppProvider.Concepto.ObtenerTodo();
            var lista = (from x in listaNuevos
                         where !listaAnteriores.Any(p => p.Referencia == x.Referencia)
                         select x).ToList();

            return lista;
            //return AppProvider.ImportarKsd.ObtenerConceptos();
        }

        public static List<Persona> ObtenerPersonas()
        {
            var listaNuevos = AppProvider.ImportarGestion.ObtenerPersonas();
            var listaAnteriores = AppProvider.Persona.ObtenerTodo();
            var lista = (from x in listaNuevos
                         where !listaAnteriores.Any(p => p.Codigo == x.Codigo)
                         select x).ToList();

            return lista;
            //return AppProvider.ImportarGestion.ObtenerPersonas();
        }

        public static List<Sucursal> ObtenerSucursales()
        {
            var listaNuevos = AppProvider.ImportarGestion.ObtenerSucursales();
            var listaAnteriores = AppProvider.Sucursal.ObtenerTodo();
            var lista = (from x in listaNuevos
                         where !listaAnteriores.Any(p => p.Codigo == x.Codigo)
                         select x).ToList();

            return lista;
            //return AppProvider.ImportarGestion.ObtenerSucursales();
        }
    }
}
