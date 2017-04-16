CREATE TABLE [dbo].[PlanillaDetalle] (
    [IdPlanillaDetalle] INT		IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [IdPlanilla]		INT     NOT NULL,
    [IdPersona]			INT     NOT NULL,
	[IdNovedad]			INT     NOT NULL,
    [IdCentroCosto]		INT     NULL,
	[IdRelacion]		INT     NULL,
    [FeInicio]			TIME(0) NOT NULL,
    [FeFin]				TIME(0)	NOT NULL,
	[FlActivo]			BIT     NULL CONSTRAINT Df_PlanillaDetalleActivo DEFAULT 'True'
    CONSTRAINT [PkPlanillaDetalle] PRIMARY KEY CLUSTERED ([IdPlanillaDetalle] ASC) ,
    --CONSTRAINT [CentroCosto_PlanillaDetalle] FOREIGN KEY ([IdCentroCosto]) REFERENCES [dbo].[CentroCosto] ([IdCentroCosto]),
    CONSTRAINT [Novedad_PlanillaDetalle] FOREIGN KEY ([IdNovedad]) REFERENCES [dbo].[Novedad] ([IdNovedad]),
    CONSTRAINT [Persona_PlanillaDetalle] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Persona] ([IdPersona]),
    CONSTRAINT [Planilla_PlanillaDetalle] FOREIGN KEY ([IdPlanilla]) REFERENCES [dbo].[Planilla] ([IdPlanilla]),
    --CONSTRAINT [OrdenProduccionActividad_PlanillaDetalle] FOREIGN KEY ([IdRelacion]) REFERENCES [dbo].[OrdenProduccionActividad] ([IdRelacion])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único del detalle.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PlanillaDetalle', @level2type = N'COLUMN', @level2name = N'IdPlanillaDetalle';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Hora de finalización del trabajo asignado.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PlanillaDetalle', @level2type = N'COLUMN', @level2name = N'FeFin';
GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Hora de inicio del trabajo asignado.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PlanillaDetalle', @level2type = N'COLUMN', @level2name = N'FeInicio';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el detalle de la planilla se encuentra con el estado activo o inactivo.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PlanillaDetalle', @level2type = N'COLUMN', @level2name = N'FlActivo';

GO
