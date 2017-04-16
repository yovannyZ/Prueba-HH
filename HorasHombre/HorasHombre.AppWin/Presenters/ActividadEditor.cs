using BLL;
using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace HorasHombre.AppWin.Presenters
{
    public interface IActividadView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        string DescripcionCorta { get; set; }
        Actividad ActividadPrincipal { get; set; }
        string Observacion { get; set; }
        string Nivel { set; }
        bool Activo { get; set; }
        List<Actividad> DataSource { set; }
        List<Actividad> InactiveDataSource { set; }
        List<Actividad> ActividadPrincipalDataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

    }

    public interface IActividadService
    {
        List<Actividad> ObtenerTodo();
        List<Actividad> ObtenerTodoPorOrden(OrdenProduccion orden, bool costos);
        Actividad ObtenerPorId(int id);
        bool Insertar(Actividad actividad);
        bool Insertar(List<Actividad> actividades);
        bool Actualizar(Actividad actividad);
        bool Eliminar(int id);
        bool Activar(int id);
    }

    public class ActividadService : IActividadService
    {
        #region . Instance .

        private static ActividadService mInstance = null;

        public static ActividadService Instance
        {
            get { return mInstance; }
        }

        static ActividadService()
        {
            mInstance = new ActividadService();
        }

        #endregion

        #region . IActividadService members .

        public List<Actividad> ObtenerTodo()
        {
            List<Actividad> actividades = ActividadBL.ObtenerTodo();
            return actividades;
        }

        public List<Actividad> ObtenerTodoPorOrden(OrdenProduccion orden, bool costos)
        {
            List<Actividad> actividades = ActividadBL.ObtenerTodoPorOrden(orden, costos);
            return actividades;
        }

        public Actividad ObtenerPorId(int id)
        {
            Actividad Actividad = ActividadBL.ObtenerPorId(id);
            return Actividad;
        }

        public bool Insertar(Actividad actividad)
        {
            return ActividadBL.Insertar(actividad) > 0;
        }

        public bool Insertar(List<Actividad> actividades)
        {
            return ActividadBL.Insertar(actividades);
        }

        public bool Actualizar(Actividad actividad)
        {
            return ActividadBL.Actualizar(actividad);
        }

        public bool Eliminar(int id)
        {
            return ActividadBL.Eliminar(id);
        }

        public bool Activar(int id)
        {
            return ActividadBL.Activar(id);
        }

        #endregion

    }

    public class ActividadEditor
    {
        #region . variables .

        private IActividadView mView;
        private IActividadService mActividadService;
        private List<Actividad> mActives = null;
        private List<Actividad> mInactives = null;
        private Actividad mActual;
        private Actividad mPadre;
        private Actividad mOld;
        private string mTipoOrdenActivo;

        #endregion

        public List<Actividad> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public List<Actividad> AllInactive
        {
            get
            {
                return this.mInactives;
            }
        }

        public ActividadEditor(IActividadView view)
        {
            this.mView = view;
            this.mActividadService = ActividadService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            // Set EventHandler
            this.mView.ActiveAction += new EventHandler<EventArgs>(mView_Activate);
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
            this.mActives = this.mActividadService.ObtenerTodo().Where(c => c.EstaActivo == true).OrderBy(c => c.ActividadPrincipal.Id).ThenBy(c => c.Codigo).ToList();
            //this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            // Load inactive data
            this.mInactives = this.mActividadService.ObtenerTodo().Where(c => c.EstaActivo == false).ToList();
            this.mInactives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            this.mView.DataSource = this.AllActive;
            this.mView.InactiveDataSource = this.AllInactive;

            // Load ComboBox DataSource
            this.mView.ActividadPrincipalDataSource = this.mActividadService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
        }

        private void GetData()
        {
            this.mActual.Codigo = this.mView.Codigo;
            this.mActual.Nombre = this.mView.Nombre;
            this.mActual.DescripcionCorta = this.mView.DescripcionCorta;
            this.mActual.ActividadPrincipal = this.mView.ActividadPrincipal;
            this.mActual.Observacion = this.mView.Observacion;
            this.mActual.Nivel = this.mView.ActividadPrincipal != null ? this.mView.ActividadPrincipal.Nivel + 1 : 1;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.Codigo = this.mActual.Codigo;
            this.mView.Nombre = this.mActual.Nombre;
            this.mView.DescripcionCorta = this.mActual.DescripcionCorta;

            this.mView.Observacion = this.mActual.Observacion;

            if (this.mActual.Id == 0)
            {
                this.mView.ActividadPrincipal = this.mPadre;
                this.mView.Nivel = string.Format("Actividad de nivel {0}", this.mPadre.Nivel + 1);
            }
            else
            {
                this.mView.ActividadPrincipal = this.mActual.ActividadPrincipal;
                this.mView.Nivel = string.Format("Actividad de nivel {0}", this.mActual.Nivel);
            }
        }

        private void Insertar(ref bool successful, ref string message)
        {
            this.mActual.EstaActivo = true;
            successful = this.mActividadService.Insertar(this.mActual);
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Actividad, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mActual);
            successful = this.mActividadService.Actualizar(this.mActual);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Actividad, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()), changes);
        }

        #endregion

        #region . EventHandler .

        private void mView_Activate(object sender, EventArgs e)
        {
            this.mActual = this.mActividadService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea activar el centro de costo {0}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mActividadService.Activar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se activó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Actividad, TipoLog.Informacion,
                        string.Format("Registro activado: {0}", this.mActual.ToString()));
                    LoadData();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mView_Cancel(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mActual = this.mOld;
        }

        private void mView_Delete(object sender, EventArgs e)
        {
            this.mActual = this.mActividadService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea eliminar el centro de costo {0}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mActividadService.Eliminar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se eliminó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Actividad, TipoLog.Informacion,
                        string.Format("Registro eliminado: {0}", this.mActual.ToString()));
                    LoadData();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mview_KeyPressActividad(object sender, KeyEventArgs e)
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

            this.mPadre = this.mActividadService.ObtenerPorId(this.mView.SelectId);
            this.mActual = new Actividad();
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
                if (this.mActual.Id != 0)
                {
                    string changes = ReflectionUtil.GetChangesFromObjects((object)this.mOld,
                       (object)this.mActual);

                    if (changes.Length == 3)
                    {
                        MessageBox.Show("No existen cambios para guardar", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Actualizar(changes, ref successful, ref message);
                }
                else
                {
                    Insertar(ref successful, ref message);
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
            if (e.TabPage.Name == "tpDatos" && !this.mView.IsEditing)
                e.Cancel = true;
            else if (e.TabPage.Name != "tpDatos" && this.mView.IsEditing)
                e.Cancel = true;
        }

        private void mView_View(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mActual = this.mActividadService.ObtenerPorId(this.mView.SelectId);
            this.mActual.ActividadPrincipal = this.mActividadService.ObtenerPorId(this.mActual.ActividadPrincipal.Id);
            this.mOld = GenericEntityAction<Actividad>.Clone(this.mActual);
            SetData();
        }

        #endregion

    }
}
