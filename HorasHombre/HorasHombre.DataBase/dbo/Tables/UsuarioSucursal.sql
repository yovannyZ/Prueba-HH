CREATE TABLE [dbo].[UsuarioSucursal] (
    [IdUsuario]  INT NOT NULL,
    [IdSucursal] INT NOT NULL,
    CONSTRAINT [PkUsuarioSucursal] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdSucursal] ASC),
    CONSTRAINT [Sucursal_UsuarioSucursal] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursal] ([IdSucursal])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador de la sucursal.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioSucursal', @level2type = N'COLUMN', @level2name = N'IdSucursal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del usuario.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioSucursal', @level2type = N'COLUMN', @level2name = N'IdUsuario';

