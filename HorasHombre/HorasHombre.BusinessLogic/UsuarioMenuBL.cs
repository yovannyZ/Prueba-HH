using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BLL
{
    public class UsuarioMenuBL : BizObject
    {
        public static List<UsuarioMenu> ObtenerTodo(Usuario usuario)
        {
            var lista = AppProvider.UsuarioMenu.ObtenerTodo(usuario.Id);
            var listaMenu = MenuSistemaBL.ObtenerTodo();
            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].Menu = (from x in listaMenu
                                   where x.Id == lista[i].Menu.Id
                                   select x).FirstOrDefault();
            }

            return lista;
        }

        public static bool Insertar(List<UsuarioMenu> asignacion)
        {
            bool exito = false;
            using (TransactionScope trx = new TransactionScope())
            {
                AppProvider.UsuarioMenu.Eliminar(asignacion[0].Usuario.Id);
                foreach (var item in asignacion)
                {
                    exito = AppProvider.UsuarioMenu.Insertar(item);
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
            return AppProvider.UsuarioMenu.Eliminar(usuario.Id);
        }
    }
}
