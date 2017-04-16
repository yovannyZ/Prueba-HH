using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HorasHombre.Model
{
    public class MenuSistema : ModelBase, IDataErrorInfo, IComparable
    {
        private int id;
        private string nombre;
        private string descripcion;
        private MenuSistema menuPrincipal;
        private bool tieneFormulario;
        private string formulario;
        private Modulo modulo;
        private List<MenuSistema> subMenu;

        public MenuSistema()
        {
            this.tieneFormulario = false;
            this.subMenu = new List<MenuSistema>();
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (id == value) return;
                id = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre == value) return;
                nombre = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (descripcion == value) return;
                descripcion = value;
                this.NotifyPropertyChanged();
            }
        }

        public MenuSistema MenuPrincipal
        {
            get { return menuPrincipal; }
            set
            {
                if (menuPrincipal == value) return;
                menuPrincipal = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Formulario
        {
            get { return formulario; }
            set
            {
                if (formulario == value) return;
                formulario = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool TieneFormulario
        {
            get { return tieneFormulario; }
            set
            {
                if (tieneFormulario == value) return;
                tieneFormulario = value;
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

        public List<MenuSistema> SubMenu
        {
            get { return subMenu; }
            set
            {
                if (subMenu == value) return;
                subMenu = value;
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

        public override string ToString()
        {
            return string.Format("{0}", this.descripcion);
        }

        #region . Compare .

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            MenuSistema newObj = obj as MenuSistema;
            if (newObj != null)
                return this.Nombre.CompareTo(newObj.Nombre);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            MenuSistema newObj = obj as MenuSistema;
            if (newObj == null)
                return false;
            else
                return id.Equals(newObj.id);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        #endregion
    }
}
