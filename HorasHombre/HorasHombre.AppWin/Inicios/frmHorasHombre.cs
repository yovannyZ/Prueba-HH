using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Reports.Forms;
using HorasHombre.AppWin.Views.HorasHombre;
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
    public partial class frmHorasHombre : Form
    {
        public frmHorasHombre()
        {
            InitializeComponent();
            tsslUser.Text = string.Format("[ {0} ]", AppInfo.CurrentUser.Nick);
            tsslCompany.Text = string.Format("[ {0} ]", AppInfo.CurrentCompany.Nombre);
            tsslProceso.Text = string.Format("Proceso: [ {0} ]", AppInfo.CurrentPeriod);
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackgroundImage = Properties.Resources.fondo;
                    ctl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    break;
                }
            }
            if (AppInfo.CurrentUser.TipoUsuario != Model.TipoUsuario.Super)
                HabilitarMenu();
        }

        private void HabilitarMenu()
        {
            foreach (ToolStripMenuItem menuItem in msPrincipal.Items)
            {
                if (menuItem.HasDropDownItems)
                    HabilitarSubMenu(menuItem);
                else
                    menuItem.Enabled = GenericUtil.ValidarMenu(AppInfo.CurrentUser, menuItem.Name, Model.Modulo.Administracion);
            }
        }

        private void HabilitarSubMenu(ToolStripMenuItem menuItem)
        {
            foreach (ToolStripMenuItem dropDownItem in menuItem.DropDownItems.OfType<ToolStripMenuItem>())
            {
                if (dropDownItem.HasDropDownItems)
                    HabilitarSubMenu(dropDownItem);
                else
                    dropDownItem.Enabled = GenericUtil.ValidarMenu(AppInfo.CurrentUser, dropDownItem.Name, Model.Modulo.Administracion);
            }

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Refresh();
        }

        #region . Transacción .

        private void AbrirOrdenProduccionActividad(object sender, EventArgs e)
        {
            frmOrdenProduccionActividad frm = frmOrdenProduccionActividad.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirPlanilla(object sender, EventArgs e)
        {
            frmPlanilla frm = frmPlanilla.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion

        private void AbrirReportePlanilla(object sender, EventArgs e)
        {
            frmReportePlanilla frm = frmReportePlanilla.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

    }
}
