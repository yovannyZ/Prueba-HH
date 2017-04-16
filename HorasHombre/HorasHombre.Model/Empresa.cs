using System;

namespace HorasHombre.Model
{
    [Serializable()]
    [Title("Empresa")]
    public class Empresa
    {
        private int id;
        private string codigo;
        private string nombre;
        private string numeroRuc;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string NumeroRuc
        {
            get { return numeroRuc; }
            set { numeroRuc = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.codigo, this.nombre);
        }
    }
}
