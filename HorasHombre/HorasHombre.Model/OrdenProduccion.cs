using System;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Orden producción")]
    public class OrdenProduccion : ModelBase
    {
        private int id;
        private string numeroOrden;
        private DateTime fechaCierre;
        private string articulo;

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

        public string NumeroOrden
        {
            get { return numeroOrden; }
            set
            {
                if (numeroOrden == value) return;
                numeroOrden = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Articulo
        {
            get { return articulo; }
            set
            {
                if (articulo == value) return;
                articulo = value;
                this.NotifyPropertyChanged();
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

        public override string ToString()
        {
            return string.Format("{0}", this.numeroOrden);
        }
    }
}
