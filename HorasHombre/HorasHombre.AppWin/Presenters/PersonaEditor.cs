using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IPersonaView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        string ApellidoPaterno { get; set; }
        string ApellidoMaterno { get; set; }
        TipoPersona TipoPersona { get; set; }
        DocumentoPersona TipoDocumento { get; set; }
        string NumeroDocumento { get; set; }
        string Email { get; set; }
        CentroCosto CentroCosto { get; set; }
        bool Activo { get; set; }
        List<Persona> DataSource { set; }
        List<Persona> InactiveDataSource { set; }
        DataSourceContainer TipoPersonaDataSource { set; }
        List<DocumentoPersona> TipoDocumentoDataSource { set; }
        List<CentroCosto> CentroCostoDataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

    }

    public interface IPersonaService
    {
        List<Persona> ObtenerTodo();
        Persona ObtenerPorId(int id);
        List<Persona> ObtenerTodoPorArea(Area area);
        bool Insertar(Persona persona);
        bool Insertar(List<Persona> personas);
        bool Actualizar(Persona persona);
        bool Eliminar(int id);
        bool Activar(int id);
    }

    public class PersonaService : IPersonaService
    {
        #region . Instance .

        private static PersonaService mInstance = null;

        public static PersonaService Instance
        {
            get { return mInstance; }
        }

        static PersonaService()
        {
            mInstance = new PersonaService();
        }

        #endregion

        #region . IPersonaService members .

        public List<Persona> ObtenerTodo()
        {
            List<Persona> personas = PersonaBL.ObtenerTodo();
            return personas;
        }

        public Persona ObtenerPorId(int id)
        {
            Persona persona = PersonaBL.ObtenerPorId(id);
            return persona;
        }

        public List<Persona> ObtenerTodoPorArea(Area area)
        {
            List<Persona> personas = PersonaBL.ObtenerTodoPorArea(area);
            return personas;
        }

        public bool Insertar(Persona persona)
        {
            return PersonaBL.Insertar(persona) > 0;
        }

        public bool Insertar(List<Persona> personas)
        {
            return PersonaBL.Insertar(personas);
        }

        public bool Actualizar(Persona persona)
        {
            return PersonaBL.Actualizar(persona);
        }

        public bool Eliminar(int id)
        {
            return PersonaBL.Eliminar(id);
        }

        public bool Activar(int id)
        {
            return PersonaBL.Activar(id);
        }

        #endregion

    }

    public class PersonaEditor
    {
        #region . variables .

        private IPersonaView mView;
        private IPersonaService mPersonaService;
        private IDocumentoPersonaService mDocumentoPersonaService;
        private ICentroCostoService mCentroCostoService;
        private List<Persona> mActives = null;
        private List<Persona> mInactives = null;
        private Persona mActual;
        private Persona mOld;
        private string mTipoOrdenActivo;

        #endregion

        public List<Persona> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public List<Persona> AllInactive
        {
            get
            {
                return this.mInactives;
            }
        }

        public PersonaEditor(IPersonaView view)
        {
            this.mView = view;
            this.mPersonaService = PersonaService.Instance;
            this.mDocumentoPersonaService = DocumentoPersonaService.Instance;
            this.mCentroCostoService = CentroCostoService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.TipoDocumentoDataSource = this.mDocumentoPersonaService.ObtenerTodo().ToList();
            this.mView.CentroCostoDataSource = this.mCentroCostoService.ObtenerTodo().Where(c => c.Codigo.Length == 5).ToList();
            this.mView.TipoPersonaDataSource = new DataSourceContainer(typeof(TipoPersona));
            // Set EventHandler
            this.mView.ActiveAction += new EventHandler<EventArgs>(mView_Activate);
            this.mView.CancelAction += new EventHandler<EventArgs>(mView_Cancel);
            this.mView.DeleteAction += new EventHandler<EventArgs>(mView_Eliminar);
            this.mView.NewAction += new EventHandler<EventArgs>(mView_New);
            this.mView.SaveAction += new EventHandler<EventArgs>(mView_Save);
            this.mView.SelectingTabAction += mview_ValidateTab;
            this.mView.ViewAction += new EventHandler<EventArgs>(mView_View);

        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mPersonaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            // Load inactive data
            this.mInactives = this.mPersonaService.ObtenerTodo().Where(c => c.EstaActivo == false).ToList();
            this.mInactives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            this.mView.DataSource = this.AllActive;
            this.mView.InactiveDataSource = this.AllInactive;
        }

        private void GetData()
        {
            this.mActual.Codigo = this.mView.Codigo;
            this.mActual.Nombre = this.mView.Nombre;
            this.mActual.ApellidoPaterno = this.mView.ApellidoPaterno;
            this.mActual.ApellidoMaterno = this.mView.ApellidoMaterno;
            this.mActual.TipoPersona = this.mView.TipoPersona;
            this.mActual.TipoDocumento = this.mView.TipoDocumento;
            this.mActual.NumeroDocumento = this.mView.NumeroDocumento;
            this.mActual.Email = this.mView.Email;
            this.mActual.CentroCosto = this.mView.CentroCosto;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.Codigo = this.mActual.Codigo;
            this.mView.Nombre = this.mActual.Nombre;
            this.mView.ApellidoPaterno = this.mActual.ApellidoPaterno;
            this.mView.ApellidoMaterno = this.mActual.ApellidoMaterno;
            this.mView.TipoPersona = this.mActual.TipoPersona;
            this.mView.TipoDocumento = this.mActual.TipoDocumento;
            this.mView.NumeroDocumento = this.mActual.NumeroDocumento;
            this.mView.Email = this.mActual.Email;
            this.mView.CentroCosto = this.mActual.CentroCosto;

        }

        private void Insertar(ref bool successful, ref string message)
        {
            this.mActual.EstaActivo = true;
            successful = this.mPersonaService.Insertar(this.mActual);
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Persona, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mActual);
            successful = this.mPersonaService.Actualizar(this.mActual);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Persona, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()), changes);
        }

        #endregion

        #region . EventHandler .

        private void mView_Activate(object sender, EventArgs e)
        {
            this.mActual = this.mPersonaService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea activar la persona {0}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mPersonaService.Activar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se activó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Persona, TipoLog.Informacion,
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

        private void mView_Eliminar(object sender, EventArgs e)
        {
            this.mActual = this.mPersonaService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea eliminar la persona {0}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mPersonaService.Eliminar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se eliminó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Persona, TipoLog.Informacion,
                        string.Format("Registro eliminado: {0}", this.mActual.ToString()));
                    LoadData();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mview_KeyPressPersona(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
                mView_New(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.Escape)
                mView_Cancel(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.F2)
                mView_View(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.Delete)
                mView_Eliminar(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.F6)
                mView_Save(sender, EventArgs.Empty);
            else if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void mView_New(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mOld = this.mActual;
            this.mActual = new Persona();
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
            this.mActual = this.mPersonaService.ObtenerPorId(this.mView.SelectId);
            if (this.mActual != null)
            {
                this.mActual.TipoDocumento = this.mDocumentoPersonaService.ObtenerPorId(this.mActual.TipoDocumento.Id);
                if (mActual.CentroCosto != null)
                    this.mActual.CentroCosto = this.mCentroCostoService.ObtenerPorId(this.mActual.CentroCosto.Id);
            }


            this.mOld = GenericEntityAction<Persona>.Clone(this.mActual);
            SetData();
        }

        #endregion

    }
}
