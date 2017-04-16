using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Periodo")]
    public class Periodo : ModelBase, IDataErrorInfo, IComparable
    {
        private int _id;
        private DateTime fechaInicio;
        private DateTime fechaCierre;
        private bool estaActivo;
        private bool estaCerrado;
        private Modulo modulo;

        public Periodo()
        {
            FechaInicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value) return;
                _id = value;
                this.NotifyPropertyChanged();
            }
        }

        public DateTime FechaInicio
        {
            get { return new DateTime(fechaInicio.Year, fechaInicio.Month, 1); }
            set
            {
                if (fechaInicio == value) return;
                fechaInicio = value;
                this.NotifyPropertyChanged();
                FechaCierre = new DateTime(fechaInicio.Year, fechaInicio.Month, 1).AddMonths(1).AddDays(-1);
            }
        }

        public DateTime FechaCierre
        {
            get { return fechaCierre; }
            set
            {
                if (fechaCierre == value) return;
                fechaCierre = value;
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

        public bool EstaCerrado
        {
            get { return estaCerrado; }
            set
            {
                if (estaCerrado == value) return;
                estaCerrado = value;
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

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.fechaInicio.ToShortDateString(), this.fechaCierre.ToShortDateString());
        }

        #region . Compare .

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Periodo newObj = obj as Periodo;
            if (newObj != null)
                return this.FechaInicio.CompareTo(newObj.FechaInicio);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            Periodo newObj = obj as Periodo;
            if (newObj == null)
                return false;
            else
                return _id.Equals(newObj._id);
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }

        #endregion
    }
}
