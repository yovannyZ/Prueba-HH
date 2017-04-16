using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BLL
{
    public class UsuarioAreaBL : BizObject
    {
        public static List<UsuarioArea> ObtenerTodo(Usuario usuario)
        {
            var lista = AppProvider.UsuarioArea.ObtenerTodo(usuario.Id);
            var listaArea = AreaBL.ObtenerTodo();
            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].Area = (from x in listaArea
                                 where x.Id == lista[i].Area.Id
                                 select x).FirstOrDefault();
            }

            return lista;
        }

        public static bool Insertar(List<UsuarioArea> asignacion)
        {
            bool exito = false;
            using (TransactionScope trx = new TransactionScope())
            {
                AppProvider.UsuarioArea.Eliminar(asignacion[0].Usuario.Id);
                foreach (var item in asignacion)
                {
                    exito = AppProvider.UsuarioArea.Insertar(item);
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
            return AppProvider.UsuarioArea.Eliminar(usuario.Id);
        }
    }
}
