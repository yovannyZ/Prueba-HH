using System;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Detalle de la planilla")]
    public class PlanillaDetalle : ModelBase, IComparable
    {
        private int id;
        private Planilla planilla;
        private Persona persona;
        private Novedad novedad;
        private CentroCosto centroCosto;
        private OrdenProduccionActividad relacionActividad;
        private TimeSpan inicio;
        private TimeSpan fin;
        private bool estaActivo;

        public PlanillaDetalle()
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

        public Planilla Planilla
        {
            get { return planilla; }
            set
            {
                if (planilla == value) return;
                planilla = value;
                this.NotifyPropertyChanged();
            }
        }

        public Persona Persona
        {
            get { return persona; }
            set
            {
                if (persona == value) return;
                persona = value;
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

        public Novedad Novedad
        {
            get { return novedad; }
            set
            {
                if (novedad == value) return;
                novedad = value;
                this.NotifyPropertyChanged();
            }
        }

        public OrdenProduccionActividad RelacionActividad
        {
            get { return relacionActividad; }
            set
            {
                if (relacionActividad == value) return;
                relacionActividad = value;
                this.NotifyPropertyChanged();
            }
        }

        public TimeSpan Inicio
        {
            get { return inicio; }
            set
            {
                if (inicio == value) return;
                inicio = value;
                this.NotifyPropertyChanged();
            }
        }

        public TimeSpan Fin
        {
            get { return fin; }
            set
            {
                if (fin == value) return;
                fin = value;
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

        #region . Compare .

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            PlanillaDetalle newObj = obj as PlanillaDetalle;
            if (newObj != null)
                return this.Id.CompareTo(newObj.Id);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            PlanillaDetalle newObj = obj as PlanillaDetalle;
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
