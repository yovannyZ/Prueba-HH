using HorasHombre.AppWin.Helpers;
using HorasHombre.Model;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HorasHombre.AppWin.Presenters
{
    public interface IDocumentoPersonaView : IMethodProvider
    {
        #region . Properties .

        int Id { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        List<DocumentoPersona> DocumentoPersonaDataSource { set; }
        bool IsSuccessful { set; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> SelectCargo;

        #endregion
    }

    public interface IDocumentoPersonaService
    {
        List<DocumentoPersona> ObtenerTodo();
        DocumentoPersona ObtenerPorId(int id);
    }

    public class DocumentoPersonaService : IDocumentoPersonaService
    {
        #region . Instance .

        private static DocumentoPersonaService mInstance = null;

        public static DocumentoPersonaService Instance
        {
            get { return mInstance; }
        }

        static DocumentoPersonaService()
        {
            mInstance = new DocumentoPersonaService();
        }

        #endregion

        #region . ICargoService members .

        public List<DocumentoPersona> ObtenerTodo()
        {
            List<DocumentoPersona> DocumentoPersonas = DocumentoPersonaBL.ObtenerTodo();
            return DocumentoPersonas;
        }

        public DocumentoPersona ObtenerPorId(int id)
        {
            DocumentoPersona cargo = DocumentoPersonaBL.ObtenerPorId(id);
            return cargo;
        }

        #endregion

    }

    public class DocumentoPersonaEditor
    {
        #region . variables .

        private IDocumentoPersonaView mView;
        private IDocumentoPersonaService mDocumentoPersonaService;
        private List<DocumentoPersona> mActives = null;
        private DocumentoPersona mActual = null;

        #endregion

        public List<DocumentoPersona> AllActive
        {
            get
            {
                return this.mActives;
            }
        }

        public DocumentoPersonaEditor(IDocumentoPersonaView view)
        {
            this.mView = view;
            this.mDocumentoPersonaService = DocumentoPersonaService.Instance;
            this.Initialize();
        }

        #region . Private Method .

        private void Initialize()
        {
            LoadData();
            this.mView.DocumentoPersonaDataSource = this.mDocumentoPersonaService.ObtenerTodo();
        }

        private void LoadData()
        {
            //Load active data
            this.mActives = this.mDocumentoPersonaService.ObtenerTodo().ToList();
            this.mActives.Sort((e, e1) => e.Codigo.CompareTo(e1.Codigo));
        }

        private void GetData()
        {
            this.mActual.Codigo = this.mView.Codigo;
            this.mActual.Nombre = this.mView.Nombre;
        }

        private void SetData()
        {
            this.mView.Id = this.mActual.Id;
            this.mView.Codigo = this.mActual.Codigo;
            this.mView.Nombre = this.mActual.Nombre;
        }

        #endregion

        #region . EventHandler .

        private void mView_Cancel(object sender, EventArgs e)
        {
            this.mView.IsSuccessful = false;
        }

        private void mView_View(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
