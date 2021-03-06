﻿using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface INovedadView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        string DescripcionCorta { get; set; }
        TipoDistribucion TipoDistribucion { get; set; }
        bool AplicaCosto { get; set; }
        bool MostrarCheck { set; }
        bool Activo { get; set; }
        List<Novedad> DataSource { set; }
        List<Novedad> InactiveDataSource { set; }
        DataSourceContainer TipoDistribucionDataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> SelectTipoDistribucion;

        #endregion
    }

    public interface INovedadService
    {
        List<Novedad> ObtenerTodo();
        Novedad ObtenerPorId(int id);
        Novedad ObtenerPorCodigo(string codigo);
        bool Insertar(Novedad Novedad);
        bool Actualizar(Novedad Novedad);
        bool Eliminar(int id);
        bool Activar(int id);
    }

    public class NovedadService : INovedadService
    {
        #region . Instance .

        private static NovedadService mInstance = null;

        public static NovedadService Instance
        {
            get { return mInstance; }
        }

        static NovedadService()
        {
            mInstance = new NovedadService();
        }

        #endregion

        #region . INovedadService members .

        public List<Novedad> ObtenerTodo()
        {
            List<Novedad> novedades = NovedadBL.ObtenerTodo();
            return novedades;
        }

        public Novedad ObtenerPorId(int id)
        {
            Novedad novedad = NovedadBL.ObtenerPorId(id);
            return novedad;
        }

        public Novedad ObtenerPorCodigo(string codigo)
        {
            Novedad novedad = NovedadBL.ObtenerPorCodigo(codigo);
            return novedad;
        }

        public bool Insertar(Novedad novedad)
        {
            return NovedadBL.Insertar(novedad) > 0;
        }

        public bool Actualizar(Novedad novedad)
        {
            return NovedadBL.Actualizar(novedad);
        }

        public bool Eliminar(int id)
        {
            return NovedadBL.Eliminar(id);
        }

        public bool Activar(int id)
        {
            return NovedadBL.Activar(id);
        }

        #endregion

    }

    public class NovedadEditor
    {
        #region . variables .

        private INovedadView mView;
        private INovedadService mNovedadService;
        private ICentroCostoService mCentroCostoService;
        private IPersonaService mPersonaService;
        private List<Novedad> mActives = null;
        private List<Novedad> mInactives = null;
        private Novedad mActual;
        private Novedad mOld;
        private string mTipoOrdenActivo;

        #endregion

        public List<Novedad> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public List<Novedad> AllInactive
        {
            get
            {
                return this.mInactives;
            }
        }

        public NovedadEditor(INovedadView view)
        {
            this.mView = view;
            this.mNovedadService = NovedadService.Instance;
            this.mCentroCostoService = CentroCostoService.Instance;
            this.mPersonaService = PersonaService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.TipoDistribucionDataSource = new DataSourceContainer(typeof(TipoDistribucion));
            // Set EventHandler
            this.mView.ActiveAction += new EventHandler<EventArgs>(mView_Activate);
            this.mView.CancelAction += new EventHandler<EventArgs>(mView_Cancel);
            this.mView.DeleteAction += new EventHandler<EventArgs>(mView_Delete);
            this.mView.NewAction += new EventHandler<EventArgs>(mView_New);
            this.mView.SaveAction += new EventHandler<EventArgs>(mView_Save);
            this.mView.SelectTipoDistribucion += new EventHandler<EventArgs>(mview_SelectTipoDistribucion);
            this.mView.SelectingTabAction += mview_ValidateTab;
            this.mView.ViewAction += new EventHandler<EventArgs>(mView_View);

        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mNovedadService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            // Load inactive data
            this.mInactives = this.mNovedadService.ObtenerTodo().Where(c => c.EstaActivo == false).ToList();
            this.mInactives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            this.mView.DataSource = this.AllActive;
            this.mView.InactiveDataSource = this.AllInactive;
        }

        private void GetData()
        {
            this.mActual.Codigo = this.mView.Codigo;
            this.mActual.Nombre = this.mView.Nombre;
            this.mActual.DescripcionCorta = this.mView.DescripcionCorta;
            this.mActual.TipoDistribucion = this.mView.TipoDistribucion;
            this.mActual.AplicaCosto = this.mView.AplicaCosto;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.Codigo = this.mActual.Codigo;
            this.mView.Nombre = this.mActual.Nombre;
            this.mView.DescripcionCorta = this.mActual.DescripcionCorta;
            this.mView.TipoDistribucion = this.mActual.TipoDistribucion;
            this.mView.AplicaCosto = this.mActual.AplicaCosto;
        }

        private void Insertar(ref bool successful, ref string message)
        {
            this.mActual.EstaActivo = true;
            successful = this.mNovedadService.Insertar(this.mActual);
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Novedad, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mActual);
            successful = this.mNovedadService.Actualizar(this.mActual);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Novedad, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()), changes);
        }

        #endregion

        #region . EventHandler .

        private void mView_Activate(object sender, EventArgs e)
        {
            this.mActual = this.mNovedadService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea activar el área {0}-{1}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mNovedadService.Activar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se activó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Novedad, TipoLog.Informacion,
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
            this.mActual = this.mNovedadService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea eliminar el área {0}-{1}?", this.mActual), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mNovedadService.Eliminar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se eliminó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Novedad, TipoLog.Informacion,
                        string.Format("Registro eliminado: {0}", this.mActual.ToString()));
                    LoadData();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mview_KeyPressNovedad(object sender, KeyEventArgs e)
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
            this.mActual = new Novedad();
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

        private void mview_SelectTipoDistribucion(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            KeyValuePair<string, int> value = ((KeyValuePair<string, int>)cb.SelectedItem);
            TipoDistribucion t = (TipoDistribucion)value.Value;
            if (t != null)
                this.mView.MostrarCheck = t == TipoDistribucion.IndirectaSinCentroCosto;
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
            this.mActual = this.mNovedadService.ObtenerPorId(this.mView.SelectId);
            this.mOld = GenericEntityAction<Novedad>.Clone(this.mActual);
            SetData();
        }

        #endregion

    }
}
