using HorasHombre.Data;
using HorasHombre.Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class EmpresaBL : BizObject
    {
        public static Empresa ObtenerPorId(int idEmpresa)
        {
            return AppProvider.Empresa.ObtenerPorId(idEmpresa);
        }

        public static List<Empresa> ObtenerTodo()
        {
            return AppProvider.Empresa.ObtenerTodo();
        }
    }
}
