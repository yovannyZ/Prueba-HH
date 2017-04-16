CREATE TABLE [dbo].[Sucursal] (
    [IdSucursal]         INT          IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CoSucursal]         VARCHAR (4)  NOT NULL,
    [NoSucursal]         VARCHAR (60) NOT NULL,
    [TxDescripcionCorta] VARCHAR (30) NULL,
    [TxNumeroRuc]        VARCHAR (11) NULL,
    [TxTelefono]         VARCHAR (20) NULL,
    [TxDireccion]        VARCHAR (60) NULL,
    [TxLocalidad]        VARCHAR (20) NULL,
    [FlActivo]           BIT          NOT NULL,
    CONSTRAINT [PkSucursal] PRIMARY KEY CLUSTERED ([IdSucursal] ASC),
    CONSTRAINT [UqSucursal] UNIQUE NONCLUSTERED ([CoSucursal] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único de la suscursal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Sucursal', @level2type = N'COLUMN', @level2name = N'IdSucursal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Código de la suscursal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Sucursal', @level2type = N'COLUMN', @level2name = N'CoSucursal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción de la suscursal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Sucursal', @level2type = N'COLUMN', @level2name = N'NoSucursal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción corta de la suscursal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Sucursal', @level2type = N'COLUMN', @level2name = N'TxDescripcionCorta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Número de Ruc de la suscursal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Sucursal', @level2type = N'COLUMN', @level2name = N'TxNumeroRuc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Télefono de la suscursal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Sucursal', @level2type = N'COLUMN', @level2name = N'TxTelefono';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Dirección de la suscursal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Sucursal', @level2type = N'COLUMN', @level2name = N'TxDireccion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Localidad de la suscursal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Sucursal', @level2type = N'COLUMN', @level2name = N'TxLocalidad';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si la sucursal se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Sucursal', @level2type = N'COLUMN', @level2name = N'FlActivo';

