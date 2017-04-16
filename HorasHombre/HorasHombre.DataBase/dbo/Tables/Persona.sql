CREATE TABLE [dbo].[Persona] (
    [IdPersona]         INT          IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CoPersona]         VARCHAR (5)  NOT NULL,
    [NoPersona]         VARCHAR (60) NOT NULL,
    [TxPaterno]         VARCHAR (20) NOT NULL,
    [TxMaterno]         VARCHAR (20) NOT NULL,
    [NuTipo]            INT          NOT NULL,
    [NuTipoDocumento]   INT          NOT NULL,
    [TxNumeroDocumento] VARCHAR (20) NOT NULL,
    [TxEmail]           VARCHAR (50) NULL,
    [FlActivo]          BIT          NOT NULL,
	[IdCentroCosto]		INT          NULL
    CONSTRAINT [PkPersona] PRIMARY KEY CLUSTERED ([IdPersona] ASC),
    CONSTRAINT [UqPersona] UNIQUE NONCLUSTERED ([CoPersona] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único de la persona', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'IdPersona';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Código de la persona', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'CoPersona';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nombre de la persona', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'NoPersona';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Apellido paterno de la persona', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'TxPaterno';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Apellido materno de la persona', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'TxMaterno';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Tipo de de persona(Natural, Juridica)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'NuTipo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Tipo de documento de la persona(No existe una tabla de relación, esta información se encuentra en la base de datos BD_GenerealCoi)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'NuTipoDocumento';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Número de documento de la persona', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'TxNumeroDocumento';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Email de la persona', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'TxEmail';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del centro de costo.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'IdCentroCosto';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si la persona se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Persona', @level2type = N'COLUMN', @level2name = N'FlActivo';

