using System;

namespace HorasHombre.AppWin.Helpers
{
    [Serializable()]
    public class UserLog
    {
        #region . Private members .

        private Guid _id;
        private string _description;
        private ModuloLog _logModule;
        private TipoObjeto _source;
        private TipoLog _type;
        private DateTime _date;
        private string _userName;
        private string _hostName;
        private string _changes;

        #endregion

        #region . Public members .

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ModuloLog LogSourceModule
        {
            set { _logModule = value; }
        }

        public string Module
        {
            get
            {
                return _logModule.GetEnumTittleAttribute();
            }
        }

        public TipoObjeto Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public TipoLog Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string HostName
        {
            get { return _hostName; }
        }

        public string Changes
        {
            get { return _changes; }
            set { _changes = value; }
        }

        #endregion

        public UserLog(ModuloLog logModule, TipoObjeto logSource, TipoLog logType, string description, string changes)
        {
            this._id = Guid.NewGuid();
            this._description = description;
            this._logModule = logModule;
            this._source = logSource;
            this._type = logType;
            this._date = DateTime.Now;
            this.UserName = AppInfo.CurrentUser.Nick;
            this._hostName = AppInfo.HostName;
            this._changes = changes;
        }
    }
}
