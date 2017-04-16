using BLL;
using HorasHombre.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Helpers
{
    public static class GenericUtil
    {
        public static IList GenerateSourceFromListToIList(TipoObjeto typeObject)
        {
            IList list = null;
            return list;
        }

        public static void Ordenar(TipoObjeto typeObject, ref IList collection, TipoOrden sortType,
            string property)
        {
            if (typeObject == TipoObjeto.CentroCosto)
            {
                List<CentroCosto> list = (List<CentroCosto>)collection;
                GenericEntityAction<CentroCosto>.Sort(ref list, sortType, property);
            }
        }

        public static Permiso ValidarFormulario(Usuario usuario, string nombreFormulario)
        {
            Permiso p = new Permiso();
            if (usuario.TipoUsuario != TipoUsuario.Super)
            {
                var lista = UsuarioMenuBL.ObtenerTodo(usuario).Where(c => c.Menu.TieneFormulario == true).ToList();
                var m = (from x in lista
                         where x.Menu.Formulario == nombreFormulario
                         select x).FirstOrDefault();
                if (m != null)
                {
                    p.CanRead = m.PuedeLeer;
                    p.CanWrite = m.PuedeEscribir;
                    p.CanDelete = m.PuedeEliminar;
                    p.CanActivate = m.PuedeActivar;
                }
            }
            else
                p = new Permiso(true, true, true, true, true);
            return p;
        }

        public static bool ValidarModulo(Usuario usuario, Modulo modulo)
        {
            bool acceso = false;
            var lista = UsuarioModuloBL.ObtenerTodo(usuario);
            var m = (from x in lista
                     where x.Modulo == modulo
                     select x).FirstOrDefault();
            if (m != null)
                acceso = true;
            return acceso;
        }

        public static bool ValidarMenu(Usuario usuario, string nombreMenu, Modulo modulo)
        {
            bool acceso = false;
            var lista = UsuarioMenuBL.ObtenerTodo(usuario);
            var m = (from x in lista
                     where x.Menu.Nombre == nombreMenu && x.Menu.Modulo == modulo
                     select x).FirstOrDefault();
            if (m != null)
                acceso = m.PuedeLeer;
            return acceso;
        }

        public static String CreateMessageForException(Exception exception)
        {
            string message = "Error desconocido";
            if (exception is ArgumentException)
                message = ((ArgumentException)exception).HResult.ToString();
            else if (exception is ArgumentException)
                message = ((ArgumentException)exception).HResult.ToString();
            else if (exception is ArgumentNullException)
                message = ((ArgumentNullException)exception).HResult.ToString();
            else if (exception is ArgumentOutOfRangeException)
                message = ((ArgumentOutOfRangeException)exception).HResult.ToString();

            return message;
        }

        public static void CreateLog(ModuloLog modulo, TipoObjeto origen, TipoLog tipo, string descripcion, string cambios = "")
        {
            try
            {
                UserLog userLog = new UserLog(modulo, origen, tipo, descripcion, cambios);
                List<UserLog> list = GetUserLog();
                list.Add(userLog);
                string fileName = Path.Combine(AppInfo.AppPath, @"..\activity.dasp");
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, list);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static List<UserLog> GetUserLog()
        {
            List<UserLog> list = new List<UserLog>();
            string fileName = Path.Combine(AppInfo.AppPath, @"..\activity.dasp");
            if (File.Exists(fileName))
            {
                try
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        if (fs.Length > 0)
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            list = (List<UserLog>)formatter.Deserialize(fs);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            list = list.OrderByDescending(c => c.Date).ToList();
            return list;
        }

        public static string Encriptar(string value)
        {
            //Crear clave SHA1
            UTF8Encoding encod = new UTF8Encoding();
            Byte[] buffer = encod.GetBytes(value);
            Byte[] result;
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            //Implementación de la clase Abstracta SHA1.
            result = sha.ComputeHash(buffer);
            /* Convertir los valores en hexadecimal, Si tiene una cifra se
             * rellena con cero para para que ocupe dos dígitos */
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString().ToUpper();
        }

        public static string FormatoDecimal(decimal numero, int decimales)
        {
            string num = "0.000";
            if (decimales == 0)
            {
                num = string.Format("{0:N0}", numero);
            }
            else if (decimales == 2)
            {
                num = string.Format("{0:N2}", numero);
            }
            else if (decimales == 3)
            {
                num = string.Format("{0:N3}", numero);
            }
            else if (decimales == 4)
            {
                num = string.Format("{0:N4}", numero);
            }
            return num;
        }

        public static bool IsNumeric(object sender, KeyPressEventArgs e)
        {
            bool noValido = false;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                noValido = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                noValido = true;
            }

            return noValido;
        }

        public static bool IsNumeric(string stringToTest)
        {
            int result;
            return int.TryParse(stringToTest, out result);
        }

        static List<ReportParameter> GetParameters(ReportViewer reporte, params object[] values)
        {
            List<ReportParameter> lista = new List<ReportParameter>();
            var Parametros = reporte.LocalReport.GetParameters();
            if (Parametros.Count > 0)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    lista.Add(new ReportParameter(Parametros[i].Name, values[i].ToString()));
                }
            }

            return lista;
        }

        public static Form CreateReport(string reporte, string dataSetName, IList lista, params object[] values)
        {
            Form frm = new Form();
            ReportViewer rep = new ReportViewer();
            rep.Dock = DockStyle.Fill;
            rep.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            rep.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            rep.LocalReport.ReportEmbeddedResource = reporte;
            var parametros = GetParameters(rep, values);
            rep.LocalReport.SetParameters(parametros);
            rep.LocalReport.DataSources.Clear();
            rep.LocalReport.DataSources.Add(new ReportDataSource(dataSetName, lista));
            rep.RefreshReport();
            frm.Controls.Add(rep);
            frm.WindowState = FormWindowState.Maximized;

            return frm;
        }

        public static List<MenuSistema> ObtenerMenu(MenuStrip menuPrincipal, Modulo modulo)
        {
            List<MenuSistema> listaMenu = new List<MenuSistema>();
            MenuSistema m;
            foreach (ToolStripMenuItem menuItem in menuPrincipal.Items)
            {
                m = new MenuSistema();
                m.Nombre = menuItem.Name;
                m.Descripcion = menuItem.ToolTipText;
                m.MenuPrincipal = new MenuSistema() { Nombre = "" };
                m.Modulo = modulo;
                m.Formulario = string.Empty;
                if (menuItem.Tag != null)
                {
                    m.TieneFormulario = true;
                    m.Formulario = menuItem.Tag.ToString();
                }
                listaMenu.Add(m);
                CargarSubMenu(menuItem, m);
            }
            return listaMenu;
        }

        private static void CargarSubMenu(ToolStripMenuItem item, MenuSistema menuPadre)
        {
            MenuSistema m;
            foreach (ToolStripMenuItem dropDownItem in item.DropDownItems.OfType<ToolStripMenuItem>())
            {
                if (dropDownItem is ToolStripMenuItem)
                {
                    m = new MenuSistema();
                    m.Nombre = dropDownItem.Name;
                    m.Descripcion = dropDownItem.ToolTipText;
                    m.MenuPrincipal = new MenuSistema() { Nombre = menuPadre.Nombre };
                    m.Modulo = menuPadre.Modulo;
                    m.Formulario = string.Empty;
                    if (dropDownItem.Tag != null)
                    {
                        m.TieneFormulario = true;
                        m.Formulario = dropDownItem.Tag.ToString();
                    }
                    menuPadre.SubMenu.Add(m);
                    if (dropDownItem.HasDropDownItems)
                        CargarSubMenu(dropDownItem, m);
                }
            }
        }

    }

    public static class GenericEntityAction<T>
    {
        public static void Sort(ref List<T> collection, TipoOrden sortType,
            string property)
        {
            if (!string.IsNullOrEmpty(property) && collection != null
                && collection.Count > 0)
            {
                Type t = collection[0].GetType();

                if (sortType == TipoOrden.Ascendente)
                {
                    collection = collection.OrderBy(a => t.InvokeMember(property,
                        BindingFlags.GetProperty, null, a, null)).ToList();
                }
                else
                {
                    collection = collection.OrderByDescending(a => t.InvokeMember(property,
                        BindingFlags.GetProperty, null, a, null)).ToList();
                }
            }
        }

        public static void Filter(ref List<T> collection, string property, string filterValue, TipoFiltro filtrType)
        {
            if (!string.IsNullOrEmpty(property) && collection != null && collection.Count > 0
                && !string.IsNullOrEmpty(filterValue))
            {
                var filteredCollection = new List<T>();
                foreach (var item in collection)
                {
                    // To check multiple properties use,
                    // item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)

                    var propertyInfo = item.GetType()
                            .GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfo == null)
                        throw new NotSupportedException("property given does not exists");

                    var propertyValue = propertyInfo.GetValue(item, null);
                    AddItemInList(filterValue, ref filteredCollection, item, propertyValue, filtrType);
                }
                collection = filteredCollection;
            }
        }

        private static void AddItemInList(string filterValue, ref List<T> filteredCollection, T item,
            object propertyValue, TipoFiltro filtrType)
        {
            if (filtrType == TipoFiltro.Empieza)
            {
                if (propertyValue.ToString().ToUpper().StartsWith(filterValue.ToUpper()))
                    filteredCollection.Add(item);
            }
            else if (filtrType == TipoFiltro.Termina)
            {
                if (propertyValue.ToString().ToUpper().EndsWith(filterValue.ToUpper()))
                    filteredCollection.Add(item);
            }
            else
                if (propertyValue.ToString().ToUpper().Contains(filterValue.ToUpper()))
                    filteredCollection.Add(item);
        }

        public static T Clone(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                try
                {
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(stream);
                }
                catch (SerializationException ex)
                {
                    GenericUtil.CreateLog(ModuloLog.Otro, TipoObjeto.Otro, TipoLog.Error, ex.Message);
                    throw new ArgumentException(ex.Message, ex);
                }
                catch { throw; }
            }
        }

    }
}
