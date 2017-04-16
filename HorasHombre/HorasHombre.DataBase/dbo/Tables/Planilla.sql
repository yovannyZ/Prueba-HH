CREATE TABLE [dbo].[Planilla] (
    [IdPlanilla] INT          IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [NuPlanilla] VARCHAR (20) NOT NULL,
    [FePlanilla] DATETIME     NULL,
    [IdUsuario]  INT          NOT NULL,
    [IdSucursal] INT          NOT NULL,
    [IdPeriodo]  INT          NOT NULL,
    [IdArea]     INT          NOT NULL,
    [FlActivo]   BIT          NULL,
    CONSTRAINT [PkPlanilla] PRIMARY KEY CLUSTERED ([IdPlanilla] ASC),
    CONSTRAINT [Area_Planilla] FOREIGN KEY ([IdArea]) REFERENCES [dbo].[Area] ([IdArea]),
    CONSTRAINT [Periodo_Planilla] FOREIGN KEY ([IdPeriodo]) REFERENCES [dbo].[Periodo] ([IdPeriodo]),
    CONSTRAINT [Sucursal_Planilla] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursal] ([IdSucursal]),
    CONSTRAINT [UqPlanilla] UNIQUE NONCLUSTERED ([NuPlanilla] ASC, [IdArea] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único de la planilla', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Planilla', @level2type = N'COLUMN', @level2name = N'IdPlanilla';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Número único de la planilla', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Planilla', @level2type = N'COLUMN', @level2name = N'NuPlanilla';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Fecha de elaboración de la planilla', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Planilla', @level2type = N'COLUMN', @level2name = N'FePlanilla';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del usuario que elabora la planilla', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Planilla', @level2type = N'COLUMN', @level2name = N'IdUsuario';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si la planilla se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Planilla', @level2type = N'COLUMN', @level2name = N'FlActivo';

