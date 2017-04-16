CREATE TABLE [dbo].[Actividad] (
    [IdActividad]          INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CoActividad]          VARCHAR (5)   NOT NULL,
    [NoActividad]          VARCHAR (60)  NOT NULL,
    [TxDescripcionCorta]   VARCHAR (30)  NULL,
    [IdActividadPrincipal] INT           NULL DEFAULT 0,
    [TxObservacion]        VARCHAR (100) NULL,
    [NuNivel]              INT           NOT NULL,
    [FlActivo]             BIT           NOT NULL,
    CONSTRAINT [PkActividad] PRIMARY KEY CLUSTERED ([IdActividad] ASC),
    CONSTRAINT [UqActividad] UNIQUE NONCLUSTERED ([CoActividad], [NuNivel], [IdActividadPrincipal])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único de la actividad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Actividad', @level2type = N'COLUMN', @level2name = N'IdActividad';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Código de la actividad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Actividad', @level2type = N'COLUMN', @level2name = N'CoActividad';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nombre de la actividad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Actividad', @level2type = N'COLUMN', @level2name = N'NoActividad';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción corta de la actividad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Actividad', @level2type = N'COLUMN', @level2name = N'TxDescripcionCorta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador de la actividad principal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Actividad', @level2type = N'COLUMN', @level2name = N'IdActividadPrincipal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Observación de la actividad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Actividad', @level2type = N'COLUMN', @level2name = N'TxObservacion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nivel de la actividad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Actividad', @level2type = N'COLUMN', @level2name = N'NuNivel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si la actividad se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Actividad', @level2type = N'COLUMN', @level2name = N'FlActivo';

