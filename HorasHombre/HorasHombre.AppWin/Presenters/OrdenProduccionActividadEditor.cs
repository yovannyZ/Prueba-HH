using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IOrdenProduccionActividadView : IMethodProvider
    {
        #region . Properties .

        OrdenProduccion OrdenProduccion { get; set; }
        List<OrdenProduccionActividad> Asignacion { get; set; }
        bool EstaActivo { get; set; }
        List<OrdenProduccion> DataSource { set; }
        List<Actividad> ActividadDataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> SelectActivo;

        #endregion
    }

    public interface IOrdenProduccionActividadService
    {
        List<OrdenProduccionActividad> ObtenerTodo(OrdenProduccion ordenProduccion);
        bool Insertar(List<OrdenProduccionActividad> ordenProduccionActividad);
        //bool Eliminar(OrdenProduccion ordenProduccion);
    }

    public class OrdenProduccionActividadService : IOrdenProduccionActividadService
    {
        #region . Instance .

        private static OrdenProduccionActividadService mInstance = null;

        public static OrdenProduccionActividadService Instance
        {
            get { return mInstance; }
        }

        static OrdenProduccionActividadService()
        {
            mInstance = new OrdenProduccionActividadService();
        }

        #endregion

        #region . IOrdenProduccionActividadService members .

        public List<OrdenProduccionActividad> ObtenerTodo(OrdenProduccion orden)
        {
            List<OrdenProduccionActividad> OrdenProduccionActividads = OrdenProduccionActividadBL.ObtenerTodo(orden);
            return OrdenProduccionActividads;
        }

        public bool Insertar(List<OrdenProduccionActividad> listaOrdenProduccionActividad)
        {
            return OrdenProduccionActividadBL.Insertar(listaOrdenProduccionActividad);
        }

        //public bool Eliminar(OrdenProduccionActividad relacion)
        //{
        //    return OrdenProduccionActividadBL.Eliminar(relacion.Id);
        //}

        #endregion

    }

    public class OrdenProduccionActividadEditor
    {
        #region . variables .

        private IOrdenProduccionActividadView mView;
        private IOrdenProduccionActividadService mOrdenProduccionActividadService;
        private IOrdenProduccionService mOrdenProduccionService;
        private IActividadService mActividadService;
        private List<OrdenProduccion> mActives = null;
        private OrdenProduccion mCurrent;
        private OrdenProduccion mOld;
        private List<OrdenProduccionActividad> ListaDistribucion;
        private string mTipoOrdenActivo;

        #endregion

        public List<OrdenProduccion> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public OrdenProduccionActividadEditor(IOrdenProduccionActividadView view)
        {
            this.mView = view;
            this.mOrdenProduccionActividadService = OrdenProduccionActividadService.Instance;
            this.mOrdenProduccionService = OrdenProduccionService.Instance;
            this.mActividadService = ActividadService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            // Set EventHandler
            this.mView.CancelAction += new EventHandler<EventArgs>(mView_Cancel);
            this.mView.DeleteAction += new EventHandler<EventArgs>(mView_Delete);
            this.mView.NewAction += new EventHandler<EventArgs>(mView_New);
            this.mView.SaveAction += new EventHandler<EventArgs>(mView_Save);
            this.mView.SelectingTabAction += mview_ValidateTab;
            this.mView.ViewAction += new EventHandler<EventArgs>(mView_View);

        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mOrdenProduccionService.ObtenerTodo().Where(c => c.FechaCierre.Date == new DateTime(1900, 1, 1) ||
                    (c.FechaCierre.Year == AppInfo.CurrentPeriod.FechaInicio.Year && c.FechaCierre.Month == AppInfo.CurrentPeriod.FechaInicio.Month)).ToList();
            this.mActives.Sort((e, e1) => e.NumeroOrden.CompareTo(e1.NumeroOrden));
            this.mView.DataSource = this.AllActive;
        }

        private void GetData()
        {
            ListaDistribucion = new List<OrdenProduccionActividad>();
            foreach (var item in this.mView.Asignacion)
            {
                ListaDistribucion.Add(new OrdenProduccionActividad
                {
                    OrdenProduccion = this.mCurrent,
                    Actividad = item.Actividad
                });
            }
        }

        private void SetData()
        {

        }

        private void Insertar(ref bool successful, ref string message)
        {
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mCurrent.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mCurrent);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.OrdenProduccionActividad, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mCurrent.ToString()), changes);
        }

        #endregion

        #region . EventHandler .

        private void mView_Cancel(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mCurrent = this.mOld;
        }

        private void mView_Delete(object sender, EventArgs e)
        {
        }

        private void mview_KeyPressOrdenProduccionActividad(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
                mView_New(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.Escape)
                mView_Cancel(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.F2)
                mView_View(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.Delete)
                mView_Delete(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.F6)
                mView_Save(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void mView_New(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mOld = this.mCurrent;
            this.mCurrent = new OrdenProduccion();
            SetData();
        }

        private void mView_Save(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro de guardar los cambios?", AppInfo.Tittle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                string message = string.Empty;
                GetData();
                if (ListaDistribucion.Count > 0)
                {
                    successful = mOrdenProduccionActividadService.Insertar(ListaDistribucion);
                }

                if (successful)
                {
                    MessageBox.Show("Los cambios se realizaron correctamente", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    LoadData();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SetData();
            }
        }

        private void mview_ValidateTab(object sender, TabControlCancelEventArgs e)
        {
            TabPage tp = e.TabPage;
            if (e.TabPage.Name == "tpDatos" && !this.mView.IsEditing)
                e.Cancel = true;
            else if (e.TabPage.Name != "tpDatos" && this.mView.IsEditing)
                e.Cancel = true;
        }

        private void mview_SortOrdenProduccionActividadActivo(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                this.mTipoOrdenActivo = ((RadioButton)sender).Tag.ToString();
                if (this.mTipoOrdenActivo == "Codigo")
                    this.mActives = this.AllActive.OrderBy(c => c.NumeroOrden).ToList();
                //else if (this.mTipoOrdenActivo == "Nombre")
                //    this.mActives = this.AllActive.OrderBy(c => c.Nombre).ToList();

                this.mView.DataSource = this.AllActive;
            }
        }

        private void mView_View(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mCurrent = this.mOrdenProduccionService.ObtenerPorId(this.mView.SelectId);
            if (this.mCurrent != null)
            {
                this.mView.ActividadDataSource = this.mActividadService.ObtenerTodoPorOrden(this.mCurrent, true).Where(c => c.EstaActivo == true).ToList();
                this.mView.Asignacion = mOrdenProduccionActividadService.ObtenerTodo(this.mCurrent);
            }
            this.mOld = GenericEntityAction<OrdenProduccion>.Clone(this.mCurrent);
            SetData();
        }

        #endregion

    }
}
