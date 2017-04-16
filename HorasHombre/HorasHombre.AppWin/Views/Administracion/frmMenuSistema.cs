using AdvancedDataGridView;
using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Inicios;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.Administracion
{
    public partial class frmMenuSistema : Form, IMenuSistemaView
    {
        MenuSistemaEditor mPresenter;

        #region . Constructor .

        private static frmMenuSistema _instance;
        public static frmMenuSistema GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmMenuSistema();
            _instance.BringToFront();
            return _instance;
        }

        public frmMenuSistema()
        {
            InitializeComponent();
            this.btnMenuSistema.Click += new EventHandler(this.MenuSistema_Click);
            this.ssEstado.Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.mPresenter = new MenuSistemaEditor(this);
            Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
        }

        #endregion

        #region . ILoginView Members .

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> MenuSistema;

        #endregion

        #region . Events for Buttons .

        private async void MenuSistema_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnMenuSistema.Enabled = false;
                ssEstado.Visible = true;
                await Procesar();
                MessageBox.Show("Se realizó el proceso de importación de datos.",
                        AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ssEstado.Visible = false;
                this.btnMenuSistema.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Otro),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnMenuSistema.Enabled = true;
                ssEstado.Visible = false;
            }
        }

        private async Task Procesar()
        {
            await Task.Run(async () =>
            {
                if (MenuSistema != null)
                    MenuSistema(null, null);
            });
        }

        #endregion

    }
}
