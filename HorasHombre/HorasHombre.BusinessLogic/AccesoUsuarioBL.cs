using HorasHombre.Data;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace BLL
{
    public class AccesoUsuarioBL : BizObject
    {
        public static bool Insertar(Usuario usuario)
        {
            bool exito = false;
            using (TransactionScope trx = new TransactionScope())
            {
                AppProvider.UsuarioModulo.Eliminar(usuario.Id);
                for (int i = 0; i < usuario.AccesoModulo.Count; i++)
                {
                    exito = AppProvider.UsuarioModulo.Insertar(usuario.AccesoModulo[i]);
                    if (!exito)
                        return false;
                }


                AppProvider.UsuarioMenu.Eliminar(usuario.Id);
                for (int i = 0; i < usuario.AccesoMenu.Count; i++)
                {
                    exito = AppProvider.UsuarioMenu.Insertar(usuario.AccesoMenu[i]);
                    if (!exito)
                        return false;
                }

                AppProvider.UsuarioArea.Eliminar(usuario.Id);
                for (int i = 0; i < usuario.AccesoArea.Count; i++)
                {
                    exito = AppProvider.UsuarioArea.Insertar(usuario.AccesoArea[i]);
                    if (!exito)
                        return false;
                }

                AppProvider.UsuarioSucursal.Eliminar(usuario.Id);
                for (int i = 0; i < usuario.AccesoSucursal.Count; i++)
                {
                    exito = AppProvider.UsuarioSucursal.Insertar(usuario.AccesoSucursal[i]);
                    if (!exito)
                        return false;
                }

                if (!exito)
                    throw new Exception("Error desconocido al grabar los accesos de usuario.");
                trx.Complete();
            }
            return exito;
        }
    }
}
