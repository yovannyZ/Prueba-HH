using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class CentroCostoBL : BizObject
    {
        public static CentroCosto ObtenerPorId(int id)
        {
            return AppProvider.CentroCosto.ObtenerPorId(id);
        }

        public static List<CentroCosto> ObtenerTodo()
        {
            return AppProvider.CentroCosto.ObtenerTodo();
        }

        public static int Insertar(CentroCosto centroCosto)
        {
            return AppProvider.CentroCosto.Insertar(centroCosto);
        }

        public static bool Insertar(List<CentroCosto> centrosCosto)
        {
            bool exito = true;
            for (int i = 0; i < centrosCosto.Count; i++)
            {
                exito = AppProvider.CentroCosto.Insertar(centrosCosto[i]) > 0;
                if (!exito)
                    break;
            }
            return exito;
        }

        public static bool Actualizar(CentroCosto centroCosto)
        {
            return AppProvider.CentroCosto.Actualizar(centroCosto);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.CentroCosto.Eliminar(id);
        }

        public static bool Activar(int id)
        {
            return AppProvider.CentroCosto.Activar(id);
        }
    }
}
