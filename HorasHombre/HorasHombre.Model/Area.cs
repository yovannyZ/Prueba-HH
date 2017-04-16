using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Area")]
    public class Area : ModelBase, IDataErrorInfo, IComparable
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcionCorta;
        //private Numeracion numeracion;
        private bool esAutomatico;
        private bool estaActivo;

        public Area()
        {
            this.estaActivo = true;
            //this.numeracion = new Numeracion();
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

        //public Numeracion Numeracion
        //{
        //    get { return numeracion; }
        //    set
        //    {
        //        if (numeracion == value) return;
        //        numeracion = value;
        //        this.NotifyPropertyChanged();
        //    }
        //}

        public bool EsAutomatico
        {
            get { return esAutomatico; }
            set
            {
                if (esAutomatico == value) return;
                esAutomatico = value;
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
            Area newObj = obj as Area;
            if (newObj != null)
                return this.Nombre.CompareTo(newObj.Nombre);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            Area newObj = obj as Area;
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
