CREATE TABLE [dbo].[CentroCosto] (
    [IdCentroCosto]      INT          IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CoCentroCosto]      VARCHAR (5)  NOT NULL,
    [NoCentroCosto]      VARCHAR (30) NOT NULL,
    [TxDescripcionCorta] VARCHAR (15) NULL,
    [FlActivo]           BIT          NOT NULL,
    CONSTRAINT [PkCentroCosto] PRIMARY KEY CLUSTERED ([IdCentroCosto] ASC),
    CONSTRAINT [UqCentroCosto] UNIQUE NONCLUSTERED ([CoCentroCosto] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único del centro de costo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CentroCosto', @level2type = N'COLUMN', @level2name = N'IdCentroCosto';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Código del centro de costo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CentroCosto', @level2type = N'COLUMN', @level2name = N'CoCentroCosto';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción del centro de costo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CentroCosto', @level2type = N'COLUMN', @level2name = N'NoCentroCosto';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción corta del centro de costo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CentroCosto', @level2type = N'COLUMN', @level2name = N'TxDescripcionCorta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el centro de costo se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CentroCosto', @level2type = N'COLUMN', @level2name = N'FlActivo';

