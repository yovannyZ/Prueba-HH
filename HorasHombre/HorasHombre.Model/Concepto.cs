using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Concepto")]
    public class Concepto : ModelBase, IDataErrorInfo, IComparable
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcionCorta;
        private string referencia;
        private TipoPlanilla tipoPlanilla;
        private bool estaActivo;

        public Concepto()
        {
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

        public string DescripcionCorta
        {
            get { return descripcionCorta; }
            set
            {
                if (descripcionCorta == value) return;
                descripcionCorta = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Referencia
        {
            get { return referencia; }
            set
            {
                if (referencia == value) return;
                referencia = value;
                this.NotifyPropertyChanged();
            }
        }

        public TipoPlanilla TipoPlanilla
        {
            get { return tipoPlanilla; }
            set
            {
                if (tipoPlanilla == value) return;
                tipoPlanilla = value;
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
            return string.Format("{0} - {1}", this.codigo, this.nombre);
        }

        #region . Compare .

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Concepto newObj = obj as Concepto;
            if (newObj != null)
                return this.Nombre.CompareTo(newObj.Nombre);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            Concepto newObj = obj as Concepto;
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
