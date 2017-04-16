using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class SucursalBL : BizObject
    {
        public static Sucursal ObtenerPorId(int id)
        {
            return AppProvider.Sucursal.ObtenerPorId(id);
        }

        public static List<Sucursal> ObtenerTodo()
        {
            return AppProvider.Sucursal.ObtenerTodo();
        }

        public static int Insertar(Sucursal sucursal)
        {
            return AppProvider.Sucursal.Insertar(sucursal);
        }

        public static bool Insertar(List<Sucursal> sucursales)
        {
            bool exito = true;
            for (int i = 0; i < sucursales.Count; i++)
            {
                exito = AppProvider.Sucursal.Insertar(sucursales[i]) > 0;
                if (!exito)
                    break;
            }
            return exito;
        }

        public static bool Actualizar(Sucursal sucursal)
        {
            return AppProvider.Sucursal.Actualizar(sucursal);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Sucursal.Eliminar(id);
        }

        public static bool Activar(int id)
        {
            return AppProvider.Sucursal.Activar(id);
        }
    }
}
