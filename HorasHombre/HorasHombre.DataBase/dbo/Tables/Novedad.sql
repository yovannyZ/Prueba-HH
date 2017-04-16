CREATE TABLE [dbo].[Novedad] (
    [IdNovedad]          INT          IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CoNovedad]          VARCHAR (2)  NOT NULL,
    [NoNovedad]          VARCHAR (60) NOT NULL,
    [TxDescripcionCorta] VARCHAR (30) NULL,
    [NuTipoDistribucion] INT          NOT NULL,
	[FlCosto]            BIT          NULL,
    [FlActivo]           BIT          NOT NULL,
    CONSTRAINT [PkNovedad] PRIMARY KEY CLUSTERED ([IdNovedad] ASC),
    CONSTRAINT [UqNovedad] UNIQUE NONCLUSTERED ([CoNovedad] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único de la novedad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Novedad', @level2type = N'COLUMN', @level2name = N'IdNovedad';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Código de la novedad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Novedad', @level2type = N'COLUMN', @level2name = N'CoNovedad';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nombre de la novedad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Novedad', @level2type = N'COLUMN', @level2name = N'NoNovedad';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción corta de la novedad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Novedad', @level2type = N'COLUMN', @level2name = N'TxDescripcionCorta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Tipo de distribución de la novedad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Novedad', @level2type = N'COLUMN', @level2name = N'NuTipoDistribucion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si la novedad se aplica al costo.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Novedad', @level2type = N'COLUMN', @level2name = N'FlCosto';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si la novedad se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Novedad', @level2type = N'COLUMN', @level2name = N'FlActivo';

