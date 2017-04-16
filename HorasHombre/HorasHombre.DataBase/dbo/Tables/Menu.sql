CREATE TABLE [dbo].[Menu] (
    [IdMenu]            INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [NoMenu]            VARCHAR (50)  NOT NULL,
    [TxDescripcionMenu] VARCHAR (100) NOT NULL,
    [IdMenuPadre]       INT           NOT NULL,
    [FlFormulario]      BIT           NOT NULL,
    [TxFormulario]      VARCHAR (60)  NULL,
    [NuModulo]          INT           NULL,
    CONSTRAINT [PkMenu] PRIMARY KEY CLUSTERED ([IdMenu] ASC),
    CONSTRAINT [UqMenu] UNIQUE NONCLUSTERED ([NoMenu] ASC)
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nombre del formulario asociado.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Menu', @level2type = N'COLUMN', @level2name = N'TxFormulario';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si tiene un formulario asociado.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Menu', @level2type = N'COLUMN', @level2name = N'FlFormulario';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del menu superior.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Menu', @level2type = N'COLUMN', @level2name = N'IdMenuPadre';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción del menu.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Menu', @level2type = N'COLUMN', @level2name = N'TxDescripcionMenu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nombre del menu.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Menu', @level2type = N'COLUMN', @level2name = N'NoMenu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único del menu.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Menu', @level2type = N'COLUMN', @level2name = N'IdMenu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del modulo del sistema.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Menu', @level2type = N'COLUMN', @level2name = N'NuModulo';

