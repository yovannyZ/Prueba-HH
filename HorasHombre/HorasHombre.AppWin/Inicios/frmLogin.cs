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
    public partial class frmLogin : Form, ILoginView
    {
        LoginEditor mPresenter;
        bool logueado;

        #region . Constructor .

        public frmLogin()
        {
            InitializeComponent();
            this.btnCancelar.Click += new EventHandler(this.Cancelar_Click);
            this.btnAceptar.Click += new EventHandler(this.Grabar_Click);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.mPresenter = new LoginEditor(this);
            if (!string.IsNullOrEmpty(this.txtUsuario.Text))
                this.txtClave.Select();
            else
                this.cboEmpresa.Select();
        }

        #endregion

        #region . ILoginView Members .

        public int Id
        {
            get { return 0; }
            set { }
        }

        public string Nick
        {
            get { return this.txtUsuario.Text; }
            set { txtUsuario.Text = value; }
        }

        public string Clave
        {
            get { return this.txtClave.Text; }
            set { txtClave.Text = value; }
        }

        public Empresa Empresa
        {
            get { return (Empresa)this.cboEmpresa.SelectedItem; }
            set
            {
                if (value != null)
                    this.cboEmpresa.Text = value.ToString();
                else
                    this.cboEmpresa.SelectedIndex = -1;
            }
        }

        public List<Empresa> EmpresaDataSource
        {
            set
            {
                this.cboEmpresa.DataSource = value;
            }
        }

        public bool IsLogged
        {
            set
            {
                this.logueado = value;
            }
        }

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> IniciarSesion;

        #endregion

        #region . Events for Buttons .

        private void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IniciarSesion != null)
                    IniciarSesion(sender, e);
                if (this.logueado)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    MessageBox.Show("Usuario o contraseña incorrecta", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClave.Clear();
                this.txtClave.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Login),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
