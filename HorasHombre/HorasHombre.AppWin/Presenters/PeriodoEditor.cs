using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IPeriodoView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        DateTime FechaInicio { get; set; }
        DateTime FechaCierre { get; }
        Modulo Modulo { get; set; }
        bool Activo { get; set; }
        List<Periodo> DataSource { set; }
        List<Periodo> InactiveDataSource { set; }
        DataSourceContainer ModuloDataSource { set; }
        int SelectId { get; }
        bool IsEditing { get; }
        bool IsSuccessful { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> ClosePeriodo;

        #endregion
    }

    public interface IPeriodoService
    {
        List<Periodo> ObtenerTodo();
        Periodo ObtenerPorId(int id);
        Periodo ObtenerActivo(Modulo modulo);
        bool Insertar(Periodo Periodo);
        bool Actualizar(Periodo Periodo);
        bool Eliminar(int id);
        bool Activar(Periodo periodo);
        bool Close(Periodo periodo);
    }

    public class PeriodoService : IPeriodoService
    {
        #region . Instance .

        private static PeriodoService mInstance = null;

        public static PeriodoService Instance
        {
            get { return mInstance; }
        }

        static PeriodoService()
        {
            mInstance = new PeriodoService();
        }

        #endregion

        #region . IPeriodoService members .

        public List<Periodo> ObtenerTodo()
        {
            List<Periodo> Periodos = PeriodoBL.ObtenerTodo();
            return Periodos;
        }

        public Periodo ObtenerPorId(int id)
        {
            Periodo Periodo = PeriodoBL.ObtenerPorId(id);
            return Periodo;
        }

        public Periodo ObtenerActivo(Modulo modulo)
        {
            Periodo Periodo = PeriodoBL.ObtenerActivo(modulo);

            return Periodo;
        }

        public bool Insertar(Periodo periodo)
        {
            return PeriodoBL.Insertar(periodo) > 0;
        }

        public bool Actualizar(Periodo periodo)
        {
            return PeriodoBL.Actualizar(periodo);
        }

        public bool Eliminar(int id)
        {
            return PeriodoBL.Eliminar(id);
        }

        public bool Activar(Periodo periodo)
        {
            return PeriodoBL.Activar(periodo);
        }

        public bool Close(Periodo periodo)
        {
            return PeriodoBL.Close(periodo);
        }

        #endregion

    }

    public class PeriodoEditor
    {
        #region . variables .

        private IPeriodoView mView;
        private IPeriodoService mPeriodoService;
        private List<Periodo> mActives = null;
        private List<Periodo> mInactives = null;
        private Periodo mActual;
        private Periodo mOld;

        #endregion

        public List<Periodo> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public List<Periodo> AllInactive
        {
            get
            {
                return this.mInactives;
            }
        }

        public PeriodoEditor(IPeriodoView view)
        {
            this.mView = view;
            this.mPeriodoService = PeriodoService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.ModuloDataSource = new DataSourceContainer(typeof(Modulo));
            // Set EventHandler
            this.mView.ActiveAction += new EventHandler<EventArgs>(mView_Activate);
            this.mView.CancelAction += new EventHandler<EventArgs>(mView_Cancel);
            this.mView.ClosePeriodo += new EventHandler<EventArgs>(mView_Close);
            this.mView.DeleteAction += new EventHandler<EventArgs>(mView_Eliminar);
            this.mView.NewAction += new EventHandler<EventArgs>(mView_New);
            this.mView.SaveAction += new EventHandler<EventArgs>(mView_Save);
            this.mView.SelectingTabAction += mview_ValidateTab;
            this.mView.ViewAction += new EventHandler<EventArgs>(mView_View);

        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mPeriodoService.ObtenerTodo().ToList();
            this.mActives.Sort((e, e1) => e.FechaInicio.CompareTo(e1.FechaInicio));

            // Load inactive data
            this.mInactives = this.mPeriodoService.ObtenerTodo().Where(c => c.EstaActivo == false).ToList();
            //this.mInactives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));

            this.mView.DataSource = this.AllActive;
            this.mView.InactiveDataSource = this.AllInactive;
        }

        private void GetData()
        {
            this.mActual.FechaInicio = this.mView.FechaInicio;
            this.mActual.FechaCierre = this.mView.FechaCierre;
            this.mActual.Modulo = this.mView.Modulo;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.FechaInicio = this.mActual.FechaInicio;
            this.mView.Modulo = this.mActual.Modulo;
        }

        private void Insertar(ref bool successful, ref string message)
        {
            this.mActual.EstaActivo = false;
            successful = this.mPeriodoService.Insertar(this.mActual);
            message = "Nuevo registro";
            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Periodo, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()));
        }

        private void Actualizar(string changes, ref bool successful, ref string message)
        {
            var tr = object.Equals(this.mOld, this.mActual);
            successful = this.mPeriodoService.Actualizar(this.mActual);
            message = "Registro actualizado";

            GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Periodo, TipoLog.Informacion,
                string.Format("{0}: {1}", message, this.mActual.ToString()), changes);
        }

        #endregion

        #region . EventHandler .

        private void mView_Activate(object sender, EventArgs e)
        {
            this.mActual = this.mPeriodoService.ObtenerPorId(this.mView.SelectId);
            if (this.mActual.EstaActivo || this.mActual.EstaCerrado)
                return;
            if (MessageBox.Show(string.Format("¿Desea activar el periodo {0} - {1}?", this.mActual.FechaInicio.ToShortDateString(),
                this.mActual.FechaCierre.ToShortDateString()), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                var periodoActivo = this.mPeriodoService.ObtenerActivo(this.mActual.Modulo);
                successful = this.mPeriodoService.Activar(periodoActivo);
                if (successful)
                    successful = this.mPeriodoService.Activar(this.mActual);

                if (successful)
                {
                    MessageBox.Show("El periodo se activó correctamente.", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Periodo, TipoLog.Informacion,
                        string.Format("Periodo activado: {0}", this.mActual.ToString()));
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

        private void mView_Close(object sender, EventArgs e)
        {
            var periodoPosterior = PeriodoBL.ObtenerPorFechaInicio(this.mActual.FechaInicio.AddMonths(1));
            var periodoAnterior = PeriodoBL.ObtenerPorFechaInicio(this.mActual.FechaInicio.AddMonths(-1));

            if ((periodoPosterior != null && periodoPosterior.EstaCerrado) || (periodoAnterior != null && !periodoAnterior.EstaCerrado))
            {
                MessageBox.Show("No se puede modificar este periodo.", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show(string.Format("¿Desea modificar el cierre del periodo {0} - {1}?", this.mView.FechaInicio.ToShortDateString(),
                this.mView.FechaCierre.ToShortDateString()), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mPeriodoService.Close(this.mActual);
                if (successful)
                {
                    MessageBox.Show("El registro se modificó correctamente.", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Periodo, TipoLog.Informacion,
                        string.Format("Registro activado: {0}", this.mActual.ToString()));
                    LoadData();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mView_Eliminar(object sender, EventArgs e)
        {
            this.mActual = this.mPeriodoService.ObtenerPorId(this.mView.SelectId);
            if (MessageBox.Show(string.Format("¿Desea eliminar el periodo {0}-{1}?", this.mActual.FechaInicio,
                this.mActual.FechaCierre), AppInfo.Tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool successful = false;
                successful = this.mPeriodoService.Eliminar(this.mActual.Id);
                if (successful)
                {
                    MessageBox.Show("El registro se eliminó correctamente", AppInfo.Tittle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.mView.IsSuccessful = successful;
                    GenericUtil.CreateLog(ModuloLog.Administracion, TipoObjeto.Periodo, TipoLog.Informacion,
                        string.Format("Registro eliminado: {0}", this.mActual.ToString()));
                    LoadData();
                }
                else
                    MessageBox.Show("No se pudo completar la operación", AppInfo.Tittle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mview_KeyPressPeriodo(object sender, KeyEventArgs e)
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
            this.mActual = new Periodo();
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

        private void mview_SortPeriodoActivo(object sender, EventArgs e)
        {

        }

        private void mView_View(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
            this.mActual = this.mPeriodoService.ObtenerPorId(this.mView.SelectId);
            this.mOld = GenericEntityAction<Periodo>.Clone(this.mActual);
            SetData();

        }

        #endregion

    }
}
