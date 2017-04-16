CREATE TABLE [dbo].[UsuarioMenu] (
    [IdUsuario]       INT NOT NULL,
    [IdMenu]          INT NOT NULL,
    [FlActivar]       BIT NULL,
    [FlEliminar]      BIT NULL,
    [FlEscribir]      BIT NULL,
    [FlLeer]          BIT NULL,
    [FlVer] BIT NULL, 
    CONSTRAINT [PkUsuarioMenu] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdMenu] ASC),
    CONSTRAINT [Menu_UsuarioMenu] FOREIGN KEY ([IdMenu]) REFERENCES [dbo].[Menu] ([IdMenu])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el usuario puede ver registros eliminados.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioMenu', @level2type = N'COLUMN', @level2name = 'FlVer';



GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el usuario puede leer registros.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioMenu', @level2type = N'COLUMN', @level2name = N'FlLeer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el usuario puede crear/modificar registros.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioMenu', @level2type = N'COLUMN', @level2name = N'FlEscribir';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el usuario puede eliminar registros.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioMenu', @level2type = N'COLUMN', @level2name = N'FlEliminar';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el usuario puede activar registros.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioMenu', @level2type = N'COLUMN', @level2name = N'FlActivar';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del usuario.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioMenu', @level2type = N'COLUMN', @level2name = N'IdUsuario';

