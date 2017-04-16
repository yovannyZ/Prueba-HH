using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Reports.Forms
{
    public partial class frmReportePlanilla : Form, IReportePlanillaView
    {

        ReportePlanillaEditor mPresenter;
        List<Persona> listaPersona;

        #region . Constructor .

        private static frmReportePlanilla _instance;
        public static frmReportePlanilla GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmReportePlanilla();
            _instance.BringToFront();
            return _instance;
        }

        public frmReportePlanilla()
        {
            InitializeComponent();
            this.btnImprimir.Click += new EventHandler(this.MostrarReporte_Click);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.mPresenter = new ReportePlanillaEditor(this);
            Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
        }

        #endregion

        #region . IReportePlanillaView Members .

        public string TipoReporte
        {
            get
            {
                if (this.rbTrabajador.Checked)
                    return "Trabajador";
                else
                    return "Planilla";
            }
        }

        public DateTime Inicio
        {
            get { return this.dtpInicio.Value; }
        }

        public DateTime Fin
        {
            get { return this.dtpFin.Value; }
        }

        public bool BuscarPorPersona
        {
            get { return this.chkPersona.Checked; }
        }

        public Persona Persona
        {
            get
            {
                Persona p = null;
                if (!string.IsNullOrEmpty(this.txtPersona.Text))
                {
                    p = (from x in listaPersona
                         where x.Descripcion == this.txtPersona.Text
                         select x).FirstOrDefault();
                }
                return p;
            }
        }

        public Area Area
        {
            get { return (Area)this.cboArea.SelectedItem; }
        }

        public string NumeroPlanilla
        {
            get { return this.txtNumeroPlanilla.Text; }
            set { this.txtNumeroPlanilla.Text = value; }
        }

        public List<Area> AreaDataSource
        {
            set
            {
                this.cboArea.DataSource = value;
            }
        }

        public List<Persona> PersonaDataSource
        {
            set
            {
                this.listaPersona = value;
                var source = new AutoCompleteStringCollection();
                String[] stringArray = listaPersona.Select(i => i.Descripcion).ToArray();
                source.AddRange(stringArray);
                this.txtPersona.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.txtPersona.AutoCompleteCustomSource = source;
                this.txtPersona.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> MostrarReporte;

        #endregion

        #region . Events for Buttons .

        private async void MostrarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (MostrarReporte != null)
                    MostrarReporte(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Otro),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void ActivarPersona(object sender, EventArgs e)
        {
            this.txtPersona.Enabled = this.chkPersona.Checked;
        }

        private void ActivarTipoReporte(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = sender as RadioButton;
                GroupBox gb = this.Controls.Find(rb.Tag.ToString(), true).FirstOrDefault() as GroupBox;
                gb.Enabled = rb.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.HorasHombre, TipoObjeto.Planilla),
                                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
