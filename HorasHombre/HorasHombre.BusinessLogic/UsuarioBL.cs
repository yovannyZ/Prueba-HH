using HorasHombre.Data;
using HorasHombre.Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBL : BizObject
    {
        public static Usuario ObtenerPorId(int idUsuario)
        {
            return AppProvider.Usuario.ObtenerPorId( idUsuario);
        }

        public static List<Usuario> ObtenerTodo()
        {
            return AppProvider.Usuario.ObtenerTodo();
        }
    }
}
