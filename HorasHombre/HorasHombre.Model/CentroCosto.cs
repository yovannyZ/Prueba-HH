using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Centro de costo")]
    public class CentroCosto : ModelBase, IDataErrorInfo, IComparable
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcionCorta;
        private bool estaActivo;

        public CentroCosto()
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

        [Title("Nombre")]
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
            CentroCosto newObj = obj as CentroCosto;
            if (newObj != null)
                return this.Nombre.CompareTo(newObj.Nombre);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            CentroCosto newObj = obj as CentroCosto;
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
