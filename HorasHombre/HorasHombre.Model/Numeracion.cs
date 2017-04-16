using System;
using System.ComponentModel;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Numeración de documentos")]
    public class Numeracion : ModelBase, IDataErrorInfo, IComparable
    {
        private Area area;
        private string numeroCorrelativo;

        public Numeracion()
        {
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

        public string NumeroCorrelativo
        {
            get { return numeroCorrelativo; }
            set
            {
                if (numeroCorrelativo == value) return;
                numeroCorrelativo = value;
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
            return string.Format("{0}", this.numeroCorrelativo);
        }

        #region . Compare .

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Numeracion newObj = obj as Numeracion;
            if (newObj != null)
                return this.Area.CompareTo(newObj.Area);
            else
                throw new ArgumentException("El objeto es incorrecto");
        }

        public override bool Equals(object obj)
        {
            Numeracion newObj = obj as Numeracion;
            if (newObj == null)
                return false;
            else
                return numeroCorrelativo.Equals(newObj.numeroCorrelativo);
        }

        public override int GetHashCode()
        {
            return this.numeroCorrelativo.GetHashCode();
        }

        #endregion
    }
}
