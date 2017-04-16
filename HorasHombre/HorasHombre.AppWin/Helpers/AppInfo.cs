using HorasHombre.Model;
using System;
using System.IO;
using System.Reflection;

namespace HorasHombre.AppWin.Helpers
{
    public class AppInfo
    {
        #region . Private members .

        private static string _tittle;
        private static string _productName;
        private static string _version;
        private static string _copyRight;
        private static string _company;
        private static string _descripcion;
        private static Usuario _currentUser;
        private static Empresa _currentCompany;
        private static Periodo _currentPeriod;

        public static string RutaAyuda
        {
            get { return Path.Combine(AppInfo.AppPath, @"..\SIHO.chm"); }
        }

        private static string _hostName;
        //private static string _appPath;

        #endregion

        #region . Public members .
        public static string Tittle
        {
            get { return _tittle; }
        }

        public static string ProductName
        {
            get { return _productName; }
        }

        public static string Version
        {
            get { return _version; }
        }

        public static string CopyRight
        {
            get { return _copyRight; }
        }

        public static string Company
        {
            get { return _company; }
        }

        public static string Descripcion
        {
            get { return _descripcion; }
        }

        public static Usuario CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public static Empresa CurrentCompany
        {
            get { return _currentCompany; }
            set { _currentCompany = value; }
        }

        public static Periodo CurrentPeriod
        {
            get { return _currentPeriod; }
            set { _currentPeriod = value; }
        }

        public static string HostName
        {
            get { return AppInfo._hostName; }
            set { AppInfo._hostName = value; }
        }

        public static string AppPath
        {
            get
            {
                return Environment.CurrentDirectory;
            }
        }

        #endregion

        public static void Configurar()
        {
            Assembly app = Assembly.GetExecutingAssembly();
            AssemblyTitleAttribute title = (AssemblyTitleAttribute)app.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];
            AssemblyProductAttribute product = (AssemblyProductAttribute)app.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0];
            AssemblyCopyrightAttribute copyright = (AssemblyCopyrightAttribute)app.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0];
            AssemblyCompanyAttribute company = (AssemblyCompanyAttribute)app.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)[0];
            AssemblyDescriptionAttribute description = (AssemblyDescriptionAttribute)app.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0];

            _tittle = title.Title;
            _productName = product.Product;
            _version = app.GetName().Version.ToString();
            _copyRight = copyright.Copyright.ToString();
            _company = company.Company;
            _descripcion = description.Description;
            _hostName = Environment.MachineName;
        }
    }
}
