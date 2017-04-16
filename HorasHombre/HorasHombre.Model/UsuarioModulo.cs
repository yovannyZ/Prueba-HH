using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Permiso Usuario - Módulo")]
    public class UsuarioModulo : ModelBase, IDataErrorInfo
    {
        private Usuario usuario;
        private Modulo modulo;

        public UsuarioModulo()
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

        public Modulo Modulo
        {
            get { return modulo; }
            set
            {
                if (modulo == value) return;
                modulo = value;
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
