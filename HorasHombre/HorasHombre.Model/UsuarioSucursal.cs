using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Permiso Usuario - Sucursal")]
    public class UsuarioSucursal : ModelBase, IDataErrorInfo
    {
        private Usuario usuario;
        private Sucursal sucursal;

        public UsuarioSucursal()
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

        public Sucursal Sucursal
        {
            get { return sucursal; }
            set
            {
                if (sucursal == value) return;
                sucursal = value;
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
