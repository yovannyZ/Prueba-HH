using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Inicios
{
    public partial class frmPanel : Form
    {
        IPeriodoService mPeriodoServices;
        public frmPanel()
        {
            InitializeComponent();
            if (AppInfo.CurrentUser.TipoUsuario != Model.TipoUsuario.Super)
                HabilitarPanel();
            mPeriodoServices = PeriodoService.Instance;
        }

        private void HabilitarPanel()
        {
            this.pbAdministracion.Enabled = GenericUtil.ValidarModulo(AppInfo.CurrentUser, Model.Modulo.Administracion);
            this.btnAdministracion.Enabled = GenericUtil.ValidarModulo(AppInfo.CurrentUser, Model.Modulo.Administracion);
            this.pbHorasHombre.Enabled = GenericUtil.ValidarModulo(AppInfo.CurrentUser, Model.Modulo.HorasHombre);
            this.btnHorasHombre.Enabled = GenericUtil.ValidarModulo(AppInfo.CurrentUser, Model.Modulo.HorasHombre);
        }

        private void AbrirAdministracion(object sender, EventArgs e)
        {
            this.Hide();
            frmAdministracion frm = new frmAdministracion();
            frm.ShowDialog();
            this.Show();
        }

        private void AbrirHorasHombre(object sender, EventArgs e)
        {
            AppInfo.CurrentPeriod = this.mPeriodoServices.ObtenerActivo(Modulo.HorasHombre);
            if (AppInfo.CurrentPeriod != null)
            {
                this.Hide();
                frmHorasHombre frm = new frmHorasHombre();
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("No existe periodo activo. Comuníquese con el Administrador del sistema", AppInfo.Tittle,
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
