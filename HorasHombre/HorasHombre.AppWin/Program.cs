using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Inicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorasHombre.AppWin
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppInfo.Configurar();
            using (frmLogin frmLogin = new frmLogin())
            {
                frmLogin.ShowDialog();
                if (frmLogin.DialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            Application.Run(new frmPanel());
        }
    }
}
