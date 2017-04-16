using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Usuario")]
    public class Usuario : ModelBase, IDataErrorInfo, IComparable
    {
        private int id;
        private string codigo;
        private string nombre;
        private string apellido;
        private string nick;
        private string clave;
        private bool estaActivo;
        private TipoUsuario tipoUsuario;
        private List<UsuarioModulo> accesoModulo;
        private List<UsuarioMenu> accesoMenu;
        private List<UsuarioArea> accesoArea;
        private List<UsuarioSucursal> accesoSucursal;

        public Usuario()
        {
            this.accesoModulo = new List<UsuarioModulo>();
            this.accesoMenu = new List<UsuarioMenu>();
            this.accesoArea = new List<UsuarioArea>();
            this.accesoSucursal = new List<UsuarioSucursal>();
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

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (codigo == value) return;
                codigo = value;
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

        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (apellido == value) return;
                apellido = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Nick
        {
            get { return nick; }
            set
            {
                if (nick == value) return;
                nick = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Clave
        {
            get { return clave; }
            set
            {
                if (clave == value) return;
                clave = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool EstaActivo
        {
            get { return estaActivo; }
            set
            {
                if (estaActivo == value) return;
                estaActivo = value;
                this.NotifyPropertyChanged();
            }
        }

        public TipoUsuario TipoUsuario
        {
            get { return tipoUsuario; }
            set
            {
                if (tipoUsuario == value) return;
                tipoUsuario = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<UsuarioModulo> AccesoModulo
        {
            get { return accesoModulo; }
            set
            {
                if (accesoModulo == value) return;
                accesoModulo = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<UsuarioMenu> AccesoMenu
        {
            get { return accesoMenu; }
            set
            {
                if (accesoMenu == value) return;
                accesoMenu = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<UsuarioArea> AccesoArea
        {
            get { return accesoArea; }
            set
            {
                if (accesoArea == value) return;
                accesoArea = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<UsuarioSucursal> AccesoSucursal
        {
            get { return accesoSucursal; }
            set
            {
                if (accesoSucursal == value) return;
                accesoSucursal = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Descripcion
        {
            get { return string.Format("{0}, {1}", this.apellido, this.nombre); }
        }

        #region · IDataErrorInfo Members ·

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "Nick": if (string.IsNullOrEmpty(Nick)) result = "El nick es requerido"; break;
                    case "Clave": if (string.IsNullOrEmpty(Clave)) result = "El nick es requerido"; break;
                };
                return result;
            }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0} - {1}, {2}", this.codigo, this.apellido, this.nombre);
        }

        #region . Compare .

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Usuario newObj = obj as Usuario;
            if (newObj != null)
                return this.Nombre.CompareTo(newObj.Nombre);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            Usuario newObj = obj as Usuario;
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
