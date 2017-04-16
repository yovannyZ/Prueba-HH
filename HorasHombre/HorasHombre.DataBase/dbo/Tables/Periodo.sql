CREATE TABLE [dbo].[Periodo] (
    [IdPeriodo] INT      IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [FeInicio]  DATETIME NOT NULL,
    [FeCierre]  DATETIME NOT NULL,
    [NuModulo]  INT      NOT NULL,
    [FlCierre]  BIT      NOT NULL,
    [FlActivo]  BIT      NOT NULL,
    CONSTRAINT [PkPeriodo] PRIMARY KEY CLUSTERED ([IdPeriodo] ASC),
    CONSTRAINT [UqPeriodo] UNIQUE NONCLUSTERED ([FeInicio] ASC, [FeCierre] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único del periodo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Periodo', @level2type = N'COLUMN', @level2name = N'IdPeriodo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Fecha de inicio del periodo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Periodo', @level2type = N'COLUMN', @level2name = N'FeInicio';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Fecha de cierre del periodo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Periodo', @level2type = N'COLUMN', @level2name = N'FeCierre';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Módulo de la aplicación(Será ingresado mediante ennumeración)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Periodo', @level2type = N'COLUMN', @level2name = N'NuModulo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica el cierre del periodo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Periodo', @level2type = N'COLUMN', @level2name = N'FlCierre';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el periodol se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Periodo', @level2type = N'COLUMN', @level2name = N'FlActivo';

