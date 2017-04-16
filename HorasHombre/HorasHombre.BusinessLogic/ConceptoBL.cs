using HorasHombre.Model;
using HorasHombre.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ConceptoBL : BizObject
    {
        public static Concepto ObtenerPorId(int id)
        {
            return AppProvider.Concepto.ObtenerPorId(id);
        }

        public static List<Concepto> ObtenerTodo()
        {
            return AppProvider.Concepto.ObtenerTodo();
        }

        public static int Insertar(Concepto concepto)
        {
            return AppProvider.Concepto.Insertar(concepto);
        }

        public static bool Insertar(List<Concepto> conceptos)
        {
            bool exito = true;
            var ultimoRegistro = AppProvider.Concepto.ObtenerTodo().OrderByDescending(c => c.Codigo).FirstOrDefault();
            string ultimoCodigo = string.Empty;
            if (ultimoRegistro == null)
                ultimoCodigo = "000";
            else
                ultimoCodigo = ultimoRegistro.Codigo;
            for (int i = 0; i < conceptos.Count; i++)
            {
                ultimoCodigo = (int.Parse(ultimoCodigo) + 1).ToString("000");
                conceptos[i].Codigo = ultimoCodigo;
                exito = AppProvider.Concepto.Insertar(conceptos[i]) > 0;
                if (!exito)
                    break;
            }
            return exito;
        }

        public static bool Actualizar(Concepto concepto)
        {
            return AppProvider.Concepto.Actualizar(concepto);
        }

        public static bool Eliminar(int id)
        {
            return AppProvider.Concepto.Eliminar(id);
        }
    }
}
