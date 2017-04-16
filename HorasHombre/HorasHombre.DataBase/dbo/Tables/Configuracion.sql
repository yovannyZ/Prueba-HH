CREATE TABLE [dbo].[Configuracion] (
    [IdConfiguracion]          INT          IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CoConfiguracion]                   VARCHAR (10) NULL,
    [TxDescripcion]            VARCHAR (80) NULL,
    [TxValor]                  VARCHAR (80) NULL,
    [FlActivo]                  BIT          NULL,
    CONSTRAINT [PkConfiguracion] PRIMARY KEY CLUSTERED ([IdConfiguracion] ASC),
    CONSTRAINT [UqConfiguracion] UNIQUE NONCLUSTERED ([CoConfiguracion] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si la configuración se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Configuracion', @level2type = N'COLUMN', @level2name = N'FlActivo';


GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Valor de la configuración.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Configuracion', @level2type = N'COLUMN', @level2name = N'TxValor';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción de la configuración.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Configuracion', @level2type = N'COLUMN', @level2name = N'TxDescripcion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Código de la configuración.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Configuracion', @level2type = N'COLUMN', @level2name = 'CoConfiguracion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único de la configuración.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Configuracion', @level2type = N'COLUMN', @level2name = N'IdConfiguracion';

