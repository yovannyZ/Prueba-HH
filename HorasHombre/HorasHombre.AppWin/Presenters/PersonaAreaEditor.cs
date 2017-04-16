using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IPersonaAreaView : IMethodProvider
    {
        #region . Properties .

        Area Area { get; set; }
        List<PersonaArea> Asignacion { get; set; }
        bool EstaActivo { get; set; }
        List<Area> DataSource { set; }
        List<Persona> PersonaDataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> SelectActivo;

        #endregion
    }

    public interface IPersonaAreaService
    {
        List<PersonaArea> ObtenerTodo(Area area);
        bool Insertar(List<PersonaArea> personaArea);
        bool Eliminar(Area area);
    }

    public class PersonaAreaService : IPersonaAreaService
    {
        #region . Instance .

        private static PersonaAreaService mInstance = null;

        public static PersonaAreaService Instance
        {
            get { return mInstance; }
        }

        static PersonaAreaService()
        {
            mInstance = new PersonaAreaService();
        }

        #endregion

        #region . IPersonaAreaService members .

        public List<PersonaArea> ObtenerTodo(Area area)
        {
            List<PersonaArea> PersonaAreas = PersonaAreaBL.ObtenerTodo(area);
            return PersonaAreas;
        }

        public bool Insertar(List<PersonaArea> listaPersonaArea)
        {
            return PersonaAreaBL.Insertar(listaPersonaArea);
        }

        public bool Eliminar(Area area)
        {
            return PersonaAreaBL.Eliminar(area);
        }

        #endregion

    }

    public class PersonaAreaEditor
    {
        #region . variables .

        private IPersonaAreaView mView;
        private IPersonaAreaService mPersonaAreaService;
        private IAreaService mAreaService;
        private IPersonaService mPersonaService;
        private List<Area> mActives = null;
        private Area mActual;
        private Area mOld;
        private List<PersonaArea> ListaDistribucion;
        private string mTipoOrdenActivo;

        #endregion

        public List<Area> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public PersonaAreaEditor(IPersonaAreaView view)
        {
            this.mView = view;
            this.mPersonaAreaService = PersonaAreaService.Instance;
            this.mAreaService = AreaService.Instance;
            this.mPersonaService = PersonaService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.DataSource = this.mAreaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mView.PersonaDataSource = this.mPersonaService.ObtenerTodo().Where(c => c.Codigo.Length == 5 && c.EstaActivo == true).ToList();
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
            this.mActives = this.mAreaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));
            this.mView.DataSource = this.AllActive;
        }

        private void GetData()
        {
            ListaDistribucion = new List<PersonaArea>();
            foreach (var item in this.mView.Asignacion)
            {
                ListaDistribucion.Add(new PersonaArea
                {
                    Area = this.mActual,
                    Persona = item.Persona
                });
            }
        }

        private void SetData()
        {

        }

        private void Insertar(ref bool successful, ref string message)
        {
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.PersonaArea, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mActual);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.PersonaArea, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()), changes);
        }

        #endregion

        #region . EventHandler .

        private void mView_Cancel(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mActual = this.mOld;
        }

        private void mView_Delete(object sender, EventArgs e)
        {
        }

        private void mview_KeyPressPersonaArea(object sender, KeyEventArgs e)
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
            this.mActual = new Area();
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
                    successful = mPersonaAreaService.Insertar(ListaDistribucion);
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

        private void mview_SortPersonaAreaActivo(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                this.mTipoOrdenActivo = ((RadioButton)sender).Tag.ToString();
                if (this.mTipoOrdenActivo == "Codigo")
                    this.mActives = this.AllActive.OrderBy(c => c.Codigo).ToList();
                else if (this.mTipoOrdenActivo == "Nombre")
                    this.mActives = this.AllActive.OrderBy(c => c.Nombre).ToList();

                this.mView.DataSource = this.AllActive;
            }
        }

        private void mView_View(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mActual = this.mAreaService.ObtenerPorId(this.mView.SelectId);
            if (this.mActual != null)
            {
                this.mView.Asignacion = mPersonaAreaService.ObtenerTodo(this.mActual);
            }
            this.mOld = GenericEntityAction<Area>.Clone(this.mActual);
            SetData();
        }

        #endregion

    }
}
