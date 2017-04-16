using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasHombre.Model
{
    [Title("Módulo")]
    public enum Modulo
    {
        [Title("Administración")]
        [Browsable(false)]
        Administracion = 1,
        [Title("Horas hombre")]
        HorasHombre = 2
    }

    public enum DebeHaber
    {
        Debe = 1,
        Haber = 2
    }

    public enum TipoActivo
    {
        Leasing = 1,
        Referencial = 2
    }

    public enum TipoMovimiento
    {
        Ingreso = 1,
        Salida = 2,
        Transferencia = 3
    }

    public enum TipoOperacion
    {
        Compra = 1,
        Desinversion = 2,
        Transferencia = 3,
        Ajuste = 4
    }

    public enum TipoPersona
    {
        Natural = 1,
        Juridica = 2
    }

    public enum TipoPlanilla
    {
        Remuneracion = 1,
        Utilidades = 5
    }

    public enum TipoUsuario
    {
        Super = 1,
        Administrador = 2,
        Usuario = 3
    }

    public enum TipoDistribucion
    {
        Directa = 1,
        Indirecta = 2,
        [Title("Indirecta sin centro de costo")]
        IndirectaSinCentroCosto=3
    }
}
