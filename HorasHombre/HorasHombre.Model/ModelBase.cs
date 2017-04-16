using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HorasHombre.Model
{
    [Serializable()]
    public abstract class ModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Property changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                // property changed
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                // send app message (mvvm light toolkit)
            }
        }
        #endregion

        #region Notify data error
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        // get errors by property
        public IEnumerable GetErrors(string propertyName)
        {
            if (this._errors.ContainsKey(propertyName))
                return this._errors[propertyName];
            return null;
        }


        // has errors
        [Browsable(false)]
        public bool HasErrors
        {
            get { return (this._errors.Count > 0); }
        }

        // object is valid
        [Browsable(false)]
        public bool IsValid
        {
            get { return !this.HasErrors; }

        }

        public void AddError(string error, [CallerMemberName]string propertyName = "")
        {
            // Add error to list
            this._errors[propertyName] = new List<string>() { error };
            this.NotifyErrorsChanged(propertyName);
        }

        public void RemoveError([CallerMemberName]string propertyName = "")
        {
            // remove error
            if (this._errors.ContainsKey(propertyName))
                this._errors.Remove(propertyName);
            this.NotifyErrorsChanged(propertyName);
        }

        public void NotifyErrorsChanged([CallerMemberName]string propertyName = "")
        {
            // Notify
            if (this.ErrorsChanged != null)
                this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        #endregion
    }
}
