using HorasHombre.Data.Provider;

namespace HorasHombre.Data
{
    public static class AppProvider
    {
        public static ActividadProvider Actividad
        {
            get { return ActividadProvider.Instance; }
        }
        public static AreaProvider Area
        {
            get { return AreaProvider.Instance; }
        }
        public static CentroCostoProvider CentroCosto
        {
            get { return CentroCostoProvider.Instance; }
        }
        public static ConceptoProvider Concepto
        {
            get { return ConceptoProvider.Instance; }
        }
        public static ConfiguracionProvider Configuracion
        {
            get { return ConfiguracionProvider.Instance; }
        }
        public static DocumentoPersonaProvider DocumentoPersona
        {
            get { return DocumentoPersonaProvider.Instance; }
        }
        public static ImportarCostoProvider ImportarCosto
        {
            get { return ImportarCostoProvider.Instance; }
        }
        public static ImportarGestionProvider ImportarGestion
        {
            get { return ImportarGestionProvider.Instance; }
        }
        public static ImportarKsdProvider ImportarKsd
        {
            get { return ImportarKsdProvider.Instance; }
        }
        public static EmpresaProvider Empresa
        {
            get { return EmpresaProvider.Instance; }
        }
        public static MenuSistemaProvider Menu
        {
            get { return MenuSistemaProvider.Instance; }
        }
        public static NovedadProvider Novedad
        {
            get { return NovedadProvider.Instance; }
        }
        public static NumeracionProvider Numeracion
        {
            get { return NumeracionProvider.Instance; }
        }
        public static OrdenProduccionProvider OrdenProduccion
        {
            get { return OrdenProduccionProvider.Instance; }
        }
        public static PeriodoProvider Periodo
        {
            get { return PeriodoProvider.Instance; }
        }
        public static PersonaAreaProvider PersonaArea
        {
            get { return PersonaAreaProvider.Instance; }
        }
        public static PersonaProvider Persona
        {
            get { return PersonaProvider.Instance; }
        }
        public static PlanillaProvider Planilla
        {
            get { return PlanillaProvider.Instance; }
        }
        public static PlanillaDetalleProvider PlanillaDetalle
        {
            get { return PlanillaDetalleProvider.Instance; }
        }
        public static OrdenProduccionActividadProvider OrdenProduccionActividad
        {
            get { return OrdenProduccionActividadProvider.Instance; }
        }
        public static SucursalProvider Sucursal
        {
            get { return SucursalProvider.Instance; }
        }
        public static UsuarioProvider Usuario
        {
            get { return UsuarioProvider.Instance; }
        }
        public static UsuarioAreaProvider UsuarioArea
        {
            get { return UsuarioAreaProvider.Instance; }
        }
        public static UsuarioMenuProvider UsuarioMenu
        {
            get { return UsuarioMenuProvider.Instance; }
        }
        public static UsuarioModuloProvider UsuarioModulo
        {
            get { return UsuarioModuloProvider.Instance; }
        }
        public static UsuarioSucursalProvider UsuarioSucursal
        {
            get { return UsuarioSucursalProvider.Instance; }
        }
    }
}
