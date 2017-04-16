using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IConfiguracionView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string Codigo { get; set; }
        string Descripcion { get; set; }
        string Valor { get; set; }
        bool Activo { get; set; }
        List<Configuracion> DataSource { set; }
        List<Configuracion> InactiveDataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

    }

    public interface IConfiguracionService
    {
        List<Configuracion> ObtenerTodo();
        Configuracion ObtenerPorId(int id);
        Configuracion ObtenerPorCodigo(string codigo);
        bool Insertar(Configuracion Configuracion);
        bool Actualizar(Configuracion Configuracion);
        bool Eliminar(int id);
        bool Activar(int id);
    }

    public class ConfiguracionService : IConfiguracionService
    {
        #region . Instance .

        private static ConfiguracionService mInstance = null;

        public static ConfiguracionService Instance
        {
            get { return mInstance; }
        }

        static ConfiguracionService()
        {
            mInstance = new ConfiguracionService();
        }

        #endregion

        #region . IConfiguracionService members .

        public List<Configuracion> ObtenerTodo()
        {
            List<Configuracion> configuraciones = ConfiguracionBL.ObtenerTodo();
            return configuraciones;
        }

        public Configuracion ObtenerPorId(int id)
        {
            Configuracion configuracion = ConfiguracionBL.ObtenerPorId(id);
            return configuracion;
        }

        public Configuracion ObtenerPorCodigo(string codigo)
        {
            Configuracion configuracion = ConfiguracionBL.ObtenerPorCodigo(codigo);
            return configuracion;
        }

        public bool Insertar(Configuracion configuracion)
        {
            return ConfiguracionBL.Insertar(configuracion) > 0;
        }

        public bool Actualizar(Configuracion configuracion)
        {
            return ConfiguracionBL.Actualizar(configuracion);
        }

        public bool Eliminar(int id)
        {
            return ConfiguracionBL.Eliminar(id);
        }

        public bool Activar(int id)
        {
            return false;
            //return ConfiguracionBL.Activar(id);
        }

        #endregion

    }

    public class ConfiguracionEditor
    {
        #region . variables .

        private IConfiguracionView mView;
        private IConfiguracionService mConfiguracionService;
        private ICentroCostoService mCentroCostoService;
        private IPersonaService mPersonaService;
        private List<Configuracion> mActives = null;
        private List<Configuracion> mInactives = null;
        private Configuracion mActual;
        private Configuracion mOld;
        private string mTipoOrdenActivo;

        #endregion

        public List<Configuracion> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public List<Configuracion> AllInactive
        {
            get
            {
                return this.mInactives;
            }
        }

        public ConfiguracionEditor(IConfiguracionView view)
        {
            this.mView = view;
            this.mConfiguracionService = ConfiguracionService.Instance;
            this.mCentroCostoService = CentroCostoService.Instance;
            this.mPersonaService = PersonaService.Instance;
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
            this.mActives = this.mConfiguracionService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            // Load inactive data
            this.mInactives = this.mConfiguracionService.ObtenerTodo().Where(c => c.EstaActivo == false).ToList();
            this.mInactives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            this.mView.DataSource = this.AllActive;
            this.mView.InactiveDataSource = this.AllInactive;
        }

        private void GetData()
        {
            this.mActual.Codigo = this.mView.Codigo;
            this.mActual.Descripcion = this.mView.Descripcion;
            this.mActual.Valor = this.mView.Valor;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.Codigo = this.mActual.Codigo;
            this.mView.Descripcion = this.mActual.Descripcion;
            this.mView.Valor = this.mActual.Valor;
        }

        private void Insertar(ref bool successful, ref string message)
        {
            this.mActual.EstaActivo = true;
            successful = this.mConfiguracionService.Insertar(this.mActual);
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Configuracion, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mActual);
            successful = this.mConfiguracionService.Actualizar(this.mActual);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Configuracion, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()), changes);
        }

        #endregion

        #region . EventHandler .

        private void mView_Activate(object sender, EventArgs e)
        {
            this.mActual = this.mConfiguracionService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea activar el área {0}-{1}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mConfiguracionService.Activar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se activó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Configuracion, TipoLog.Informacion,
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
            this.mActual = this.mConfiguracionService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea eliminar el área {0}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mConfiguracionService.Eliminar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se eliminó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Configuracion, TipoLog.Informacion,
                        string.Format("Registro eliminado: {0}", this.mActual.ToString()));
                    LoadData();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mview_KeyPressConfiguracion(object sender, KeyEventArgs e)
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
            this.mOld = this.mActual;
            this.mActual = new Configuracion();
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

        private void mview_SortConfiguracionActivo(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                this.mTipoOrdenActivo = ((RadioButton)sender).Tag.ToString();
                if (this.mTipoOrdenActivo == "Codigo")
                    this.mActives = this.AllActive.OrderBy(c => c.Codigo).ToList();
                else if (this.mTipoOrdenActivo == "Nombre")
                    this.mActives = this.AllActive.OrderBy(c => c.Descripcion).ToList();

                this.mView.DataSource = this.AllActive;
            }
        }

        private void mView_View(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mActual = this.mConfiguracionService.ObtenerPorId(this.mView.SelectId);
            this.mOld = GenericEntityAction<Configuracion>.Clone(this.mActual);
        }

        #endregion
    }
}
