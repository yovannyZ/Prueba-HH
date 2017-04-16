using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Permiso Usuario - Menu")]
    public class UsuarioMenu : ModelBase, IDataErrorInfo
    {
        private Usuario usuario;
        private MenuSistema menu;
        private bool puedeActivar;
        private bool puedeEliminar;
        private bool puedeEscribir;
        private bool puedeLeer;
        private bool puedeVer;

        public UsuarioMenu()
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

        public MenuSistema Menu
        {
            get { return menu; }
            set
            {
                if (menu == value) return;
                menu = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool PuedeActivar
        {
            get { return puedeActivar; }
            set
            {
                if (puedeActivar == value) return;
                puedeActivar = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool PuedeEliminar
        {
            get { return puedeEliminar; }
            set
            {
                if (puedeEliminar == value) return;
                puedeEliminar = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool PuedeEscribir
        {
            get { return puedeEscribir; }
            set
            {
                if (puedeEscribir == value) return;
                puedeEscribir = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool PuedeLeer
        {
            get { return puedeLeer; }
            set
            {
                if (puedeLeer == value) return;
                puedeLeer = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool PuedeVer
        {
            get { return puedeVer; }
            set
            {
                if (puedeVer == value) return;
                puedeVer = value;
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
