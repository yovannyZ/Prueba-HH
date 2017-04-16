using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BLL
{
    public class UsuarioSucursalBL : BizObject
    {
        public static List<UsuarioSucursal> ObtenerTodo(Usuario usuario)
        {
            var lista = AppProvider.UsuarioSucursal.ObtenerTodo(usuario.Id);
            var listaSucursal = SucursalBL.ObtenerTodo();
            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].Sucursal = (from x in listaSucursal
                                     where x.Id == lista[i].Sucursal.Id
                                     select x).FirstOrDefault();
            }

            return lista;
        }

        public static bool Insertar(List<UsuarioSucursal> asignacion)
        {
            bool exito = false;
            using (TransactionScope trx = new TransactionScope())
            {
                AppProvider.UsuarioSucursal.Eliminar(asignacion[0].Usuario.Id);
                foreach (var item in asignacion)
                {
                    exito = AppProvider.UsuarioSucursal.Insertar(item);
                    if (!exito)
                        return false;
                }
                if (!exito)
                    throw new Exception("Error desconocido al grabar la distribución");
                trx.Complete();
            }
            return exito;
        }

        public static bool Eliminar(Usuario usuario)
        {
            return AppProvider.UsuarioSucursal.Eliminar(usuario.Id);
        }
    }
}
