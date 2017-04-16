using HorasHombre.AppWin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Presenters
{
    public interface IUserLogEditorView
    {
        #region . Properties .

        string Description { set; }
        string Module { set; }
        TipoObjeto Source { set; }
        TipoLog Type { set; }
        DateTime Date { set; }
        string UserName { set; }
        string HostName { set; }
        string Changes { set; }
        List<UserLog> UserLogDataSource { set; }
        Guid SelectedGuid { get; }

        #endregion

        #region . EventHandler .

        event EventHandler<EventArgs> LoadUserLogs;
        event EventHandler<EventArgs> SelectUserLog;

        #endregion
    }

    public interface IUserLogService
    {
        List<UserLog> ObtenerTodoUserLogs();
    }

    public class UserLogService : IUserLogService
    {
        #region . Instance .

        private static UserLogService mInstance = null;
        public static UserLogService Instance
        {
            get { return mInstance; }
        }

        static UserLogService()
        {
            mInstance = new UserLogService();
        }

        #endregion

        #region . IUserLogService members .

        public List<UserLog> ObtenerTodoUserLogs()
        {
            List<UserLog> UserLogs = GenericUtil.GetUserLog();
            return UserLogs;
        }

        #endregion

    }

    public class UserLogEditor
    {
        #region . variables .

        private IUserLogEditorView mView;
        private IUserLogService mUserLogService;
        private List<UserLog> mUserLogs = null;
        private UserLog mCurrentUserLog;

        #endregion

        public List<UserLog> All
        {
            get
            {
                return this.mUserLogs;
            }
        }

        public UserLogEditor(IUserLogEditorView view)
        {
            this.mView = view;
            this.mUserLogService = UserLogService.Instance;
            this.Initialize();
        }

        private void Initialize()
        {
            LoadData();
            // Set EventHandler
            this.mView.LoadUserLogs += new EventHandler<EventArgs>(mview_LoadUserLogs);
            this.mView.SelectUserLog += new EventHandler<EventArgs>(mview_SelectUserLog);
        }

        private void LoadData()
        {
            //Load active data
            this.mUserLogs = this.mUserLogService.ObtenerTodoUserLogs();
        }

        #region . EventHandler .

        private void mview_LoadUserLogs(object sender, EventArgs e)
        {
            this.mView.UserLogDataSource = this.All;
        }

        private void mview_SelectUserLog(object sender, EventArgs e)
        {
            Guid userLogGuid;
            userLogGuid = this.mView.SelectedGuid;
            this.mCurrentUserLog = this.All.Find(u => u.Id == userLogGuid);
            if (this.mCurrentUserLog != null)
                SetData();
        }

        #endregion

        #region . Private Method .

        private void SetData()
        {
            this.mView.Description = this.mCurrentUserLog.Description;
            this.mView.Module = this.mCurrentUserLog.Module;
            this.mView.Source = this.mCurrentUserLog.Source;
            this.mView.Type = this.mCurrentUserLog.Type;
            this.mView.Date = this.mCurrentUserLog.Date;
            this.mView.UserName = this.mCurrentUserLog.UserName;
            this.mView.HostName = this.mCurrentUserLog.HostName;
            this.mView.Changes = this.mCurrentUserLog.Changes;
        }

        #endregion

    }
}
