using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Tabla de configuración")]
    public class Configuracion : ModelBase, IDataErrorInfo, IComparable
    {
        private int id;
        private string codigo;
        private string descripcion;
        private string valor;
        private bool estaActivo;

        public Configuracion()
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

        public string Valor
        {
            get { return valor; }
            set
            {
                if (valor == value) return;
                valor = value;
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
            return string.Format("{0} - {1}", this.codigo, this.descripcion);
        }

        #region . Compare .

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Configuracion newObj = obj as Configuracion;
            if (newObj != null)
                return this.Codigo.CompareTo(newObj.Codigo);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            Configuracion newObj = obj as Configuracion;
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
