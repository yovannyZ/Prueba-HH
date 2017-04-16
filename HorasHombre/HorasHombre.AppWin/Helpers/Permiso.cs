using System;

namespace HorasHombre.AppWin.Helpers
{
    public class Permiso
    {
        private int _id;
        private bool _canActivate;
        private bool _canDelete;
        private bool _canRead;
        private bool _canWrite;
        private bool _showDeleteItems;

        /// <summary>
        /// 
        /// </summary>
        public Permiso()
        {
            this._canActivate = false;
            this._canDelete = false;
            this._canRead = false;
            this._canWrite = false;
            this._showDeleteItems = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_idAdelantoSueldo"></param>
        /// <param name="canRead"></param>
        /// <param name="canWrite"></param>
        /// <param name="canDelete"></param>
        public Permiso(bool canActivate, bool canDelete, bool canRead, bool canWrite, bool showDeleteItems)
        {
            this._canActivate = canActivate;
            this._canDelete = canDelete;
            this._canRead = canRead;
            this._canWrite = canWrite;
            this._showDeleteItems = showDeleteItems;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CanActivate
        {
            get { return _canActivate; }
            set { _canActivate = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CanDelete
        {
            get { return _canDelete; }
            set { _canDelete = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CanRead
        {
            get { return _canRead; }
            set { _canRead = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool CanWrite
        {
            get { return _canWrite; }
            set { _canWrite = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowDeleteItems
        {
            get { return _showDeleteItems; }
            set { _showDeleteItems = value; }
        }
    }
}
