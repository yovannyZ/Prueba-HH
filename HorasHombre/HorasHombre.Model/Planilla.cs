using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Planilla")]
    public class Planilla : ModelBase, IDataErrorInfo, IComparable
    {
        private int id;
        private string numeroPlanilla;
        private DateTime fecha;
        private Usuario usuario;
        private Sucursal sucursal;
        private Periodo periodo;
        private Area area;
        private List<PlanillaDetalle> detalle;
        private bool estaActivo;

        public Planilla()
        {
            this.fecha = DateTime.Today;
            this.detalle = new List<PlanillaDetalle>();
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

        public string NumeroPlanilla
        {
            get { return numeroPlanilla; }
            set
            {
                if (numeroPlanilla == value) return;
                numeroPlanilla = value;
                this.NotifyPropertyChanged();
            }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (fecha == value) return;
                fecha = value;
                this.NotifyPropertyChanged();
            }
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

        public Periodo Periodo
        {
            get { return periodo; }
            set
            {
                if (periodo == value) return;
                periodo = value;
                this.NotifyPropertyChanged();
            }
        }

        public Area Area
        {
            get { return area; }
            set
            {
                if (area == value) return;
                area = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<PlanillaDetalle> Detalle
        {
            get { return detalle; }
            set
            {
                if (detalle == value) return;
                detalle = value;
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
            return string.Format("{0}", this.numeroPlanilla);
        }

        #region . Compare .

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Planilla newObj = obj as Planilla;
            if (newObj != null)
                return this.NumeroPlanilla.CompareTo(newObj.NumeroPlanilla);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            Planilla newObj = obj as Planilla;
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
