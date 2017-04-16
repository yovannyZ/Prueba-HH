using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface INumeracionView : IMethodProvider
    {
        #region . Properties .

        Area Area { get; set; }
        string Numero { get; set; }
        List<Area> DataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

    }

    public interface INumeracionService
    {
        List<Numeracion> ObtenerTodo();
        Numeracion ObtenerPorId(Area area);
        bool Insertar(Numeracion Numeracion);
        bool Actualizar(Numeracion Numeracion);
        //bool Eliminar(Area area);
    }

    public class NumeracionService : INumeracionService
    {
        #region . Instance .

        private static NumeracionService mInstance = null;

        public static NumeracionService Instance
        {
            get { return mInstance; }
        }

        static NumeracionService()
        {
            mInstance = new NumeracionService();
        }

        #endregion

        #region . INumeracionService members .

        public List<Numeracion> ObtenerTodo()
        {
            List<Numeracion> Numeracions = NumeracionBL.ObtenerTodo();
            return Numeracions;
        }

        public Numeracion ObtenerPorId(Area area)
        {
            Numeracion numeracion = NumeracionBL.ObtenerPorId(area.Id);
            return numeracion;
        }

        public bool Insertar(Numeracion numeracion)
        {
            return NumeracionBL.Insertar(numeracion) > 0;
        }

        public bool Actualizar(Numeracion numeracion)
        {
            return NumeracionBL.Actualizar(numeracion);
        }

        //public bool Eliminar(Area area)
        //{
        //    return NumeracionBL.Eliminar(area);
        //}

        #endregion

    }

    public class NumeracionEditor
    {
        #region . variables .

        private INumeracionView mView;
        private INumeracionService mNumeracionService;
        private IAreaService mAreaService;
        private List<Area> mActives = null;
        private Area mCurrent;
        private Area mOld;
        private string mTipoOrdenActivo;
        private Numeracion mNumeracion;

        #endregion

        public List<Area> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public NumeracionEditor(INumeracionView view)
        {
            this.mView = view;
            this.mNumeracionService = NumeracionService.Instance;
            this.mAreaService = AreaService.Instance;
            this.mNumeracion = new Numeracion();
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.DataSource = this.mAreaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
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
            this.mNumeracion.Area = this.mCurrent;
            this.mNumeracion.NumeroCorrelativo = this.mView.Numero;
        }

        private void SetData()
        {

        }

        private void Insertar(ref bool successful, ref string message)
        {
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Numeracion, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mCurrent.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mCurrent);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Numeracion, TipoLog.Informacion,
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

        private void mview_KeyPressNumeracion(object sender, KeyEventArgs e)
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
            this.mCurrent = new Area();
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
                var n = mNumeracionService.ObtenerPorId(this.mCurrent);
                if (n != null)
                    successful = mNumeracionService.Actualizar(this.mNumeracion);
                else
                    successful = mNumeracionService.Insertar(this.mNumeracion);


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

        private void mView_View(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mCurrent = this.mAreaService.ObtenerPorId(this.mView.SelectId);
            if (this.mCurrent != null)
            {
                var n = mNumeracionService.ObtenerPorId(this.mCurrent);
                if (n != null)
                    this.mView.Numero = n.NumeroCorrelativo;
                else
                    this.mView.Numero = string.Empty;
            }
            this.mOld = GenericEntityAction<Area>.Clone(this.mCurrent);
            SetData();
        }

        #endregion

    }
}
