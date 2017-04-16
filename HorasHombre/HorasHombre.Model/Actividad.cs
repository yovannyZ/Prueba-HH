using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Actividad")]
    public class Actividad : ModelBase, IDataErrorInfo, IComparable
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcionCorta;
        private Actividad actividadPrincipal;
        private string observacion;
        private int nivel;
        private List<Actividad> subActividades;
        private bool estaActivo;

        public Actividad()
        {
            this.estaActivo = true;
            this.subActividades = new List<Actividad>();
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

        [Browsable(false)]
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

        [Browsable(false)]
        public Actividad ActividadPrincipal
        {
            get { return actividadPrincipal; }
            set
            {
                if (actividadPrincipal == value) return;
                actividadPrincipal = value;
                this.NotifyPropertyChanged();
            }
        }

        [Browsable(false)]
        public string Observacion
        {
            get { return observacion; }
            set
            {
                if (observacion == value) return;
                observacion = value;
                this.NotifyPropertyChanged();
            }
        }

        [Browsable(false)]
        public int Nivel
        {
            get { return nivel; }
            set
            {
                if (nivel == value) return;
                nivel = value;
                this.NotifyPropertyChanged();
            }
        }

        [Browsable(false)]
        public List<Actividad> SubActividades
        {
            get { return subActividades; }
            set
            {
                if (subActividades == value) return;
                subActividades = value;
                this.NotifyPropertyChanged();
            }
        }

        [Browsable(false)]
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

        [Browsable(false)]
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
            Actividad newObj = obj as Actividad;
            if (newObj != null)
                return this.Nombre.CompareTo(newObj.Nombre);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            Actividad newObj = obj as Actividad;
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
