using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace BLL
{
    public class UsuarioModuloBL : BizObject
    {
        public static List<UsuarioModulo> ObtenerTodo(Usuario usuario)
        {
            return AppProvider.UsuarioModulo.ObtenerTodo(usuario.Id);
        }

        public static bool Insertar(List<UsuarioModulo> asignacion)
        {
            bool exito = false;
            using (TransactionScope trx = new TransactionScope())
            {
                AppProvider.UsuarioModulo.Eliminar(asignacion[0].Usuario.Id);
                foreach (var item in asignacion)
                {
                    exito = AppProvider.UsuarioModulo.Insertar(item);
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
            return AppProvider.UsuarioModulo.Eliminar(usuario.Id);
        }
    }
}
