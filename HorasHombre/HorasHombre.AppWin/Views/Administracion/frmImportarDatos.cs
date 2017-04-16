using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.Administracion
{
    public partial class frmImportarDatos : Form, IImportarView
    {
        ImportarEditor mPresenter;

        #region . Constructor .

        private static frmImportarDatos _instance;
        public static frmImportarDatos GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmImportarDatos();
            _instance.BringToFront();
            return _instance;
        }

        public frmImportarDatos()
        {
            InitializeComponent();
            this.dgvActividad.AutoGenerateColumns = false;
            this.dgvCentroCosto.AutoGenerateColumns = false;
            this.dgvPersona.AutoGenerateColumns = false;
            this.dgvSucursal.AutoGenerateColumns = false;
            this.btnImportar.Click += new EventHandler(this.Importar_Click);
            this.ssEstado.Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.mPresenter = new ImportarEditor(this);
            Permiso permiso = GenericUtil.ValidarFormulario(AppInfo.CurrentUser, this.Name);
        }

        #endregion

        #region . ILoginView Members .

        public List<Actividad> ListaActividad
        {
            get { return (List<Actividad>)this.dgvActividad.DataSource; }
            set
            {
                this.dgvActividad.DataSource = value;
            }
        }

        public List<CentroCosto> ListaCentroCosto
        {
            get { return (List<CentroCosto>)this.dgvCentroCosto.DataSource; }
            set { this.dgvCentroCosto.DataSource = value; }
        }

        public List<Concepto> ListaConceptoRemuneracion
        {
            get
            {
                List<Concepto> lista = new List<Concepto>();
                Concepto c;
                for (int i = 0; i < this.dgvConceptoRemuneracion.RowCount; i++)
                    if (bool.Parse(this.dgvConceptoRemuneracion.Rows[i].Cells[1].Value.ToString()))
                    {
                        c = (Concepto)this.dgvConceptoRemuneracion.Rows[i].Cells[0].Value;
                        c.TipoPlanilla = TipoPlanilla.Remuneracion;
                        lista.Add(c);
                    }
                return lista;
            }
        }

        public List<Concepto> ListaConceptoUtilidades
        {
            get
            {
                List<Concepto> lista = new List<Concepto>();
                Concepto c;
                for (int i = 0; i < this.dgvConceptoUtilidades.RowCount; i++)
                    if (bool.Parse(this.dgvConceptoUtilidades.Rows[i].Cells[1].Value.ToString()))
                    {
                        c = (Concepto)this.dgvConceptoUtilidades.Rows[i].Cells[0].Value;
                        c.TipoPlanilla = TipoPlanilla.Utilidades;
                        lista.Add(c);
                    }
                return lista;
            }
        }

        public List<Persona> ListaPersona
        {
            get { return (List<Persona>)this.dgvPersona.DataSource; }
            set { this.dgvPersona.DataSource = value; }
        }

        public List<Sucursal> ListaSucursal
        {
            get { return (List<Sucursal>)this.dgvSucursal.DataSource; }
            set { this.dgvSucursal.DataSource = value; }
        }

        public List<Concepto> ConceptoDataSource
        {
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    this.dgvConceptoRemuneracion.Rows.Add(value[i], false);
                    this.dgvConceptoUtilidades.Rows.Add(value[i], false);
                }

            }
        }

        #endregion

        #region . Event Handler .

        public event EventHandler<EventArgs> Importar;

        #endregion

        #region . Events for Buttons .

        private async void Importar_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnImportar.Enabled = false;
                ssEstado.Visible = true;
                await Procesar();
                MessageBox.Show("Se realizó el proceso de importación de datos.",
                        AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ssEstado.Visible = false;
                this.btnImportar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorHandler.ObtenerMensajeError(ex, ModuloLog.Administracion, TipoObjeto.Otro),
                    AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnImportar.Enabled = true;
                ssEstado.Visible = false;
            }
        }

        private async Task Procesar()
        {
            await Task.Run(async () =>
            {
                if (Importar != null)
                    Importar(null, null);
            });
        }

        #endregion


        //private void VerificarEstadoBotones()
        //{
        //    this.btnAgregarRemuneracion.Enabled = this.dgvConceptoRemuneracion.RowCount > 0;
        //    this.btnAgregarTodosRemuneracion.Enabled = this.dgvConceptoRemuneracion.RowCount > 0;
        //    this.btnQuitarRemuneracion.Enabled = this.dgvConceptoRemuneracionAsignado.RowCount > 0;
        //    this.btnQuitarTodosRemuneracion.Enabled = this.dgvConceptoRemuneracionAsignado.RowCount > 0;

        //    this.btnAgregarUtilidades.Enabled = this.dgvConceptoUtilidades.RowCount > 0;
        //    this.btnAgregarTodosUtilidades.Enabled = this.dgvConceptoUtilidades.RowCount > 0;
        //    this.btnQuitarUtilidades.Enabled = this.dgvConceptoUtilidadesAsignado.RowCount > 0;
        //    this.btnQuitarTodosUtilidades.Enabled = this.dgvConceptoUtilidadesAsignado.RowCount > 0;
        //}

        //private void AgregarUno(object sender, EventArgs e)
        //{
        //    string modulo = ((Button)sender).Tag.ToString();
        //    string gridOrigen = string.Format("dgvConcepto{0}", modulo);
        //    string gridDestino = string.Format("dgvConcepto{0}Asignado", modulo);
        //    DataGridView origen = this.Controls.Find(gridOrigen, true).FirstOrDefault() as DataGridView;
        //    DataGridView destino = this.Controls.Find(gridDestino, true).FirstOrDefault() as DataGridView;

        //    DataGridViewRow fila = origen.CurrentRow;
        //    destino.Rows.Add(fila.Cells[0].Value);
        //    origen.Rows.Remove(fila);
        //    VerificarEstadoBotones();
        //}

        //private void QuitarUno(object sender, EventArgs e)
        //{
        //    string modulo = ((Button)sender).Tag.ToString();
        //    string gridOrigen = string.Format("dgvConcepto{0}Asignado", modulo);
        //    string gridDestino = string.Format("dgvConcepto{0}", modulo);
        //    DataGridView origen = this.Controls.Find(gridOrigen, true).FirstOrDefault() as DataGridView;
        //    DataGridView destino = this.Controls.Find(gridDestino, true).FirstOrDefault() as DataGridView;

        //    DataGridViewRow fila = origen.CurrentRow;
        //    destino.Rows.Add(fila.Cells[0].Value);
        //    origen.Rows.Remove(fila);
        //    VerificarEstadoBotones();
        //}

        //private void QuitarTodos(object sender, EventArgs e)
        //{
        //    string modulo = ((Button)sender).Tag.ToString();
        //    string gridOrigen = string.Format("dgvConcepto{0}Asignado", modulo);
        //    string gridDestino = string.Format("dgvConcepto{0}", modulo);
        //    DataGridView origen = this.Controls.Find(gridOrigen, true).FirstOrDefault() as DataGridView;
        //    DataGridView destino = this.Controls.Find(gridDestino, true).FirstOrDefault() as DataGridView;

        //    for (int i = 0; i < origen.RowCount; i++)
        //        destino.Rows.Add(origen.Rows[i].Cells[0].Value);
        //    origen.Rows.Clear();
        //    VerificarEstadoBotones();
        //}
    }
}
