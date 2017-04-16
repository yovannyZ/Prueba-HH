using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Persona")]
    public class Persona : ModelBase, IDataErrorInfo, IComparable
    {
        private int id;
        private string codigo;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private TipoPersona tipoPersona;
        private DocumentoPersona tipoDocumento;
        private string numeroDocumento;
        private string email;
        private CentroCosto centroCosto;
        private bool estaActivo;

        public Persona()
        {
            estaActivo = true;
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

        [Title("Código")]
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

        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set
            {
                if (apellidoPaterno == value) return;
                apellidoPaterno = value;
                this.NotifyPropertyChanged();
            }
        }

        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set
            {
                if (apellidoMaterno == value) return;
                apellidoMaterno = value;
                this.NotifyPropertyChanged();
            }
        }

        [Title("Nombre completo")]
        public string Descripcion
        {
            get
            {
                if (!(string.IsNullOrEmpty(apellidoPaterno) && string.IsNullOrEmpty(apellidoMaterno)))
                    return string.Format("{0} {1}, {2}", this.apellidoPaterno, this.apellidoMaterno,
                        this.nombre);
                else
                    return string.Format("{0}", this.nombre);
            }

        }

        public TipoPersona TipoPersona
        {
            get { return tipoPersona; }
            set
            {
                if (tipoPersona == value) return;
                tipoPersona = value;
                this.NotifyPropertyChanged();
            }
        }

        public DocumentoPersona TipoDocumento
        {
            get { return tipoDocumento; }
            set
            {
                if (tipoDocumento == value) return;
                tipoDocumento = value;
                this.NotifyPropertyChanged();
            }
        }

        public string NumeroDocumento
        {
            get { return numeroDocumento; }
            set
            {
                if (numeroDocumento == value) return;
                numeroDocumento = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email == value) return;
                email = value;
                this.NotifyPropertyChanged();
            }
        }

        public CentroCosto CentroCosto
        {
            get { return centroCosto; }
            set
            {
                if (centroCosto == value) return;
                centroCosto = value;
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
            string nombreMostrar = string.Empty;
            if (!(string.IsNullOrEmpty(apellidoPaterno) && string.IsNullOrEmpty(apellidoMaterno)))
                nombreMostrar = string.Format("{0} - {1} {2}, {3}", this.codigo, this.apellidoPaterno, this.apellidoMaterno,
                    this.nombre);
            else
                nombreMostrar = string.Format("{0} - {1}", this.codigo, this.nombre);

            return nombreMostrar;
        }

        #region . Compare .

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Persona newObj = obj as Persona;
            if (newObj != null)
                return this.Nombre.CompareTo(newObj.Nombre);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            Persona newObj = obj as Persona;
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
