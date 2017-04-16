using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Relación Usuario - Area")]
    public class UsuarioArea : ModelBase, IDataErrorInfo
    {
        private Usuario usuario;
        private Area area;

        public UsuarioArea()
        {
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set
            {
                if (usuario == value) return;
                usuario = value;
                this.NotifyPropertyChanged();
            }
        }

        public Area Area
        {
            get { return area; }
            set
            {
                if (area == value) return;
                area = value;
                this.NotifyPropertyChanged();
            }
        }

        #region · IDataErrorInfo Members ·

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get { return null; }
        }

        #endregion
    }
}
