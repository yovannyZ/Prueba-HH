using HorasHombre.Data;
using HorasHombre.Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DocumentoPersonaBL : BizObject
    {
        public static DocumentoPersona ObtenerPorId(int idDocumentoPersona)
        {
            return AppProvider.DocumentoPersona.ObtenerPorId(idDocumentoPersona);
        }

        public static List<DocumentoPersona> ObtenerTodo()
        {
            return AppProvider.DocumentoPersona.ObtenerTodo();
        }
    }
}

