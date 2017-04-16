using System;
using System.ComponentModel;

namespace HorasHombre.Model
{

    [Serializable()]
    [Title("Relación persona-area")]
    public class PersonaArea : ModelBase, IDataErrorInfo
    {
        private Area area;
        private Persona persona;

        public PersonaArea()
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

    }
}
