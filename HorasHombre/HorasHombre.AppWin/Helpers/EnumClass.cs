using HorasHombre.Model;

namespace HorasHombre.AppWin.Helpers
{
    public enum Mes
    {
        [Title("Enero")]
        Enero = 1,
        [Title("Febrero")]
        Febrero = 2,
        [Title("Marzo")]
        Marzo = 3,
        [Title("Abril")]
        Abril = 4,
        [Title("Mayo")]
        Mayo = 5,
        [Title("Junio")]
        Junio = 6,
        [Title("Julio")]
        Julio = 7,
        [Title("Agosto")]
        Agosto = 8,
        [Title("Septiembre")]
        Septiembre = 9,
        [Title("Octubre")]
        Octubre = 10,
        [Title("Noviembre")]
        Noviembre = 11,
        [Title("Diciembre")]
        Diciembre = 12
    }

    public enum ModuloLog
    {
        [Title("Otro")]
        Otro = 1,
        [Title("Administración")]
        Administracion = 1,
        [Title("Horas hombre")]
        HorasHombre = 2
    }

    public enum TipoLog
    {
        Error,
        Informacion,
        Aviso
    }

    public enum TipoOrden
    {
        Ascendente = 0,
        Descendente = 1
    }

    public enum TipoFiltro
    {
        Contiene,
        Termina,
        Igual,
        Empieza
    }

    public enum TipoObjeto
    {
        Otro, AccesoUsuario, Actividad, Area, CentroCosto, Concepto, Configuracion, DocumentoPersona,
        Empresa, Importacion, Login, Novedad, Numeracion, OrdenProduccionActividad, Periodo, Persona,
        PersonaArea, Planilla, PlanillaDetalle, Sucursal, Usuario
    }
}
