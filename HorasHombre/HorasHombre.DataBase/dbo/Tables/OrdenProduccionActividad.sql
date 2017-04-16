CREATE TABLE [dbo].[OrdenProduccionActividad] (
    [IdRelacion]        INT IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [IdOrdenProduccion] INT NOT NULL,
    [IdActividad]       INT NOT NULL,
	[FlActivo]          BIT NOT NULL
    CONSTRAINT [PkOrdenProduccionActividad] PRIMARY KEY CLUSTERED ([IdRelacion] ASC),
    CONSTRAINT [Actividad_OrdenProduccionActividad] FOREIGN KEY ([IdActividad]) REFERENCES [dbo].[Actividad] ([IdActividad]),
    CONSTRAINT [UqOrdenProduccionActividad] UNIQUE NONCLUSTERED ([IdOrdenProduccion] ASC, [IdActividad] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único de la relación', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrdenProduccionActividad', @level2type = N'COLUMN', @level2name = N'IdRelacion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador de la orden de produción', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrdenProduccionActividad', @level2type = N'COLUMN', @level2name = N'IdOrdenProduccion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si la relación se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrdenProduccionActividad', @level2type = N'COLUMN', @level2name = N'FlActivo';

