CREATE TABLE [dbo].[UsuarioArea] (
    [IdUsuario] INT NOT NULL,
    [IdArea]    INT NOT NULL,
    CONSTRAINT [PkUsuarioArea] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdArea] ASC),
    CONSTRAINT [Area_UsuarioArea] FOREIGN KEY ([IdArea]) REFERENCES [dbo].[Area] ([IdArea])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del area.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioArea', @level2type = N'COLUMN', @level2name = N'IdArea';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del usuario.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioArea', @level2type = N'COLUMN', @level2name = N'IdUsuario';

