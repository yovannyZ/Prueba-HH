using Microsoft.Reporting.WinForms;
using System;

namespace HorasHombre.AppWin.Helpers
{
    public static class ErrorHandler
    {
        public static string ObtenerMensajeError(Exception ex, ModuloLog modulo, TipoObjeto tipo)
        {
            string mensaje = string.Empty;
            if (ex is System.ArgumentNullException)
            {
                mensaje = string.Format("Error {0} \r\n Se obtuvo un argumento nulo.", ex.HResult);
            }
            if (ex is System.ArgumentOutOfRangeException)
            {
                mensaje = string.Format("Error {0} \r\n El índice estaba fuera del intervalo.", ex.HResult);
            }

            if (ex is NullReferenceException)
            {
                mensaje = string.Format("Error {0} \r\n No se pudo crear un objeto requerido.", ex.HResult);
            }

            if (ex is InvalidCastException)
            {
                mensaje = string.Format("Error {0} \r\n Imposible convertir los tipos de datos.", ex.HResult);
            }

            if (ex is System.InvalidOperationException)
            {

            }

            if (ex is System.IndexOutOfRangeException)
            {

            }

            if (ex is MissingReportSourceException)
            {
                mensaje = string.Format("Error {0} \r\n No se encontró el reporte.", ex.HResult);
            }

            if (ex is System.Data.SqlClient.SqlException)
            {
                mensaje = string.Format("Error {0} \r\n No se pudo completar una operación en la base de datos", ex.HResult);
            }

            if (ex is System.FormatException)
            {
                mensaje = string.Format("Error {0} \r\n El formato no cumple las especificaciones requeridas.", ex.HResult);
            }

            if (ex is Exception)
            {

            }
            GenericUtil.CreateLog(modulo, tipo, TipoLog.Error,
                string.Format(" Tipo error ==> {0} \r\n \r\n Mensaje de error ==> {1} \r\n \r\n Origen del error ==> {2}",
                ex.GetType().Name, ex.Message, ex.StackTrace));
            return mensaje;
        }
    }
}
