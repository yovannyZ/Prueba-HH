using System;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Relación entre Orden de producción y actividad")]
    public class OrdenProduccionActividad : ModelBase
    {
        private int id;
        private OrdenProduccion ordenProduccion;
        private Actividad actividad;
        private bool estaActivo;

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

        public OrdenProduccion OrdenProduccion
        {
            get { return ordenProduccion; }
            set
            {
                if (ordenProduccion == value) return;
                ordenProduccion = value;
                this.NotifyPropertyChanged();
            }
        }

        public Actividad Actividad
        {
            get { return actividad; }
            set
            {
                if (actividad == value) return;
                actividad = value;
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
    }
}
