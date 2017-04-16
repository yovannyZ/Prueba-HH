using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.Administracion
{
    public partial class frmUserLog : Form, IUserLogEditorView
    {
        UserLogEditor mPresenter;
        Guid mSelectedGuid;

        #region . Constructor .

        private static frmUserLog _instance;
        public static frmUserLog GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmUserLog();
            _instance.BringToFront();
            return _instance;
        }

        private frmUserLog()
        {
            InitializeComponent();
            this.dgvListado.AutoGenerateColumns = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.mPresenter = new UserLogEditor(this);

            if (this.LoadUserLogs != null)
            {
                this.LoadUserLogs(this, EventArgs.Empty);
            }
        }

        #endregion

        #region . IUserLogEditorView Members .

        public string Description
        {
            set { txtDescripcion.Text = value; }
        }

        public string Module
        {
            set { lblModulo.Text = value.ToString(); }
        }

        public TipoObjeto Source
        {
            set { lblOrigen.Text = value.ToString(); ;}
        }

        public Helpers.TipoLog Type
        {
            set { lblTipo.Text = value.ToString(); }
        }

        public DateTime Date
        {
            set { lblRegistrado.Text = value.ToString(); }
        }

        public string UserName
        {
            set { lblUsuario.Text = value; }
        }

        public string HostName
        {
            set { lblNombrePc.Text = value; }
        }

        public string Changes
        {
            set { txtDescripcion.Text += string.Format("\r\n{0}", value); }
        }

        public List<Helpers.UserLog> UserLogDataSource
        {
            set { this.dgvListado.DataSource = value; }
        }

        public Guid SelectedGuid
        {
            get { return this.mSelectedGuid; }
        }

        #endregion

        #region . EventHandler .

        public event EventHandler<EventArgs> LoadUserLogs;
        public event EventHandler<EventArgs> SelectUserLog;

        #endregion

        private void dgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].HeaderText == "Tipo")
            {
                if (e.Value.ToString() == "Error")
                    e.Value = imgGrid.Images[0];
                else if (e.Value.ToString() == "Informacion")
                    e.Value = imgGrid.Images[1];
                else if (e.Value.ToString() == "Aviso")
                    e.Value = imgGrid.Images[2];
            }
        }

        private void SelectRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.mSelectedGuid = ((UserLog)dgvListado.Rows[e.RowIndex].DataBoundItem).Id;
                if (this.SelectUserLog != null)
                    SelectUserLog(this, EventArgs.Empty);
            }
        }
    }
}
