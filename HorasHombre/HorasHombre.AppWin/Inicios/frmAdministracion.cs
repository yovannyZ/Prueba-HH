using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Views.Administracion;
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
    public partial class frmAdministracion : Form
    {
        public frmAdministracion()
        {
            InitializeComponent();
            tsslUser.Text = string.Format("Usuario: {0}", AppInfo.CurrentUser.Nick);
            tsslCompany.Text = string.Format("Empresa: {0}", AppInfo.CurrentCompany.Nombre);
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
            {
                HabilitarMenu();
                HabilitarTool();
            }

        }

        private void HabilitarTool()
        {
            foreach (ToolStripButton buttonItem in tsPrincipal.Items)
            {
                object tag = buttonItem.Tag;
                if (tag != null)
                    buttonItem.Enabled = GenericUtil.ValidarMenu(AppInfo.CurrentUser, tag.ToString(), Model.Modulo.Administracion);
            }
        }

        private void HabilitarMenu()
        {
            foreach (ToolStripMenuItem menuItem in msPrincipal.Items)
            {
                object tag = menuItem.Tag;
                if (tag != null && tag.ToString() == "*")
                    continue;
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
                object tag = dropDownItem.Tag;
                if (tag != null && tag.ToString() == "*")
                    continue;
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

        #region . Tablas .

        private void AbrirCentroCosto(object sender, EventArgs e)
        {
            frmCentroCosto frm = frmCentroCosto.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirPersonas(object sender, EventArgs e)
        {
            frmPersona frm = frmPersona.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirSucursal(object sender, EventArgs e)
        {
            frmSucursal frm = frmSucursal.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirActividad(object sender, EventArgs e)
        {
            frmActividad frm = frmActividad.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirArea(object sender, EventArgs e)
        {
            frmArea frm = frmArea.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirPersonaArea(object sender, EventArgs e)
        {
            frmPersonaArea frm = frmPersonaArea.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirConceptos(object sender, EventArgs e)
        {
            frmConcepto frm = frmConcepto.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirNovedad(object sender, EventArgs e)
        {
            frmNovedad frm = frmNovedad.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirNumeracion(object sender, EventArgs e)
        {
            frmNumeracion frm = frmNumeracion.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region . Proceso .

        private void AbrirImportacionDatos(object sender, EventArgs e)
        {
            frmImportarDatos frm = frmImportarDatos.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirPeriodo(object sender, EventArgs e)
        {
            frmPeriodo frm = frmPeriodo.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion

        #region . Seguridad .

        private void AbrirUsuarioModulo(object sender, EventArgs e)
        {
            frmAccesoUsuario frm = frmAccesoUsuario.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirMenuSistema(object sender, EventArgs e)
        {
            frmMenuSistema frm = frmMenuSistema.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirVisorEventos(object sender, EventArgs e)
        {
            frmUserLog frm = frmUserLog.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AbrirConfiguracion(object sender, EventArgs e)
        {
            frmConfiguracion frm = frmConfiguracion.GetInstance();
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion

        #region . Ayuda .

        private void AbrirAcercaDe(object sender, EventArgs e)
        {
            Acerca frm = new Acerca();
            frm.ShowDialog();
        }

        private void AbrirAyuda(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, AppInfo.RutaAyuda, HelpNavigator.TopicId, "100");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Otro),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion        

        private void Salir(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
