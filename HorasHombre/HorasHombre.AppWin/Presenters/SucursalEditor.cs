using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace HorasHombre.AppWin.Presenters
{
    public interface ISucursalView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        string DescripcionCorta { get; set; }
        string NumeroRuc { get; set; }
        string Telefono { get; set; }
        string Direccion { get; set; }
        string Localidad { get; set; }
        bool Activo { get; set; }
        List<Sucursal> DataSource { set; }
        List<Sucursal> InactiveDataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

    }

    public interface ISucursalService
    {
        List<Sucursal> ObtenerTodo();
        Sucursal ObtenerPorId(int id);
        bool Insertar(Sucursal sucursal);
        bool Insertar(List<Sucursal> sucursales);
        bool Actualizar(Sucursal sucursal);
        bool Eliminar(int id);
        bool Activar(int id);
    }

    public class SucursalService : ISucursalService
    {
        #region . Instance .

        private static SucursalService mInstance = null;

        public static SucursalService Instance
        {
            get { return mInstance; }
        }

        static SucursalService()
        {
            mInstance = new SucursalService();
        }

        #endregion

        #region . ISucursalService members .

        public List<Sucursal> ObtenerTodo()
        {
            List<Sucursal> Sucursals = SucursalBL.ObtenerTodo();
            return Sucursals;
        }

        public Sucursal ObtenerPorId(int id)
        {
            Sucursal Sucursal = SucursalBL.ObtenerPorId(id);
            return Sucursal;
        }

        public bool Insertar(Sucursal sucursal)
        {
            return SucursalBL.Insertar(sucursal) > 0;
        }

        public bool Insertar(List<Sucursal> sucursales)
        {
            return SucursalBL.Insertar(sucursales);
        }

        public bool Actualizar(Sucursal sucursal)
        {
            return SucursalBL.Actualizar(sucursal);
        }

        public bool Eliminar(int id)
        {
            return SucursalBL.Eliminar(id);
        }

        public bool Activar(int id)
        {
            return SucursalBL.Activar(id);
        }

        #endregion

    }

    public class SucursalEditor
    {
        #region . variables .

        private ISucursalView mView;
        private ISucursalService mSucursalService;
        private List<Sucursal> mActives = null;
        private List<Sucursal> mInactives = null;
        private Sucursal mActual;
        private Sucursal mOld;
        private string mTipoOrdenActivo;

        #endregion

        public List<Sucursal> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public List<Sucursal> AllInactive
        {
            get
            {
                return this.mInactives;
            }
        }

        public SucursalEditor(ISucursalView view)
        {
            this.mView = view;
            this.mSucursalService = SucursalService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
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
            this.mActives = this.mSucursalService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            // Load inactive data
            this.mInactives = this.mSucursalService.ObtenerTodo().Where(c => c.EstaActivo == false).ToList();
            this.mInactives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            this.mView.DataSource = this.AllActive;
            this.mView.InactiveDataSource = this.AllInactive;
        }

        private void GetData()
        {
            this.mActual.Codigo = this.mView.Codigo;
            this.mActual.Nombre = this.mView.Nombre;
            this.mActual.DescripcionCorta = this.mView.DescripcionCorta;
            this.mActual.NumeroRuc = this.mView.NumeroRuc;
            this.mActual.Telefono = this.mView.Telefono;
            this.mActual.Direccion = this.mView.Direccion;
            this.mActual.Localidad = this.mView.Localidad;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.Codigo = this.mActual.Codigo;
            this.mView.Nombre = this.mActual.Nombre;
            this.mView.DescripcionCorta = this.mActual.DescripcionCorta;
            this.mView.NumeroRuc = this.mActual.NumeroRuc;
            this.mView.Telefono = this.mActual.Telefono;
            this.mView.Direccion = this.mActual.Direccion;
            this.mView.Localidad = this.mActual.Localidad;
        }

        private void Insertar(ref bool successful, ref string message)
        {
            this.mActual.EstaActivo = true;
            successful = this.mSucursalService.Insertar(this.mActual);
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Sucursal, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mActual);
            successful = this.mSucursalService.Actualizar(this.mActual);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Sucursal, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()), changes);
        }

        #endregion

        #region . EventHandler .

        private void mView_Activate(object sender, EventArgs e)
        {
            this.mActual = this.mSucursalService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea activar la sucursal {0}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mSucursalService.Activar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se activó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Sucursal, TipoLog.Informacion,
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
            this.mActual = this.mSucursalService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea eliminar la sucursal {0}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mSucursalService.Eliminar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se eliminó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Sucursal, TipoLog.Informacion,
                        string.Format("Registro eliminado: {0}", this.mActual.ToString()));
                    LoadData();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mview_KeyPressSucursal(object sender, KeyEventArgs e)
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
            this.mActual = new Sucursal();
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
            this.mActual = this.mSucursalService.ObtenerPorId(this.mView.SelectId);
            this.mOld = GenericEntityAction<Sucursal>.Clone(this.mActual);
            SetData();
        }

        #endregion

    }
}
