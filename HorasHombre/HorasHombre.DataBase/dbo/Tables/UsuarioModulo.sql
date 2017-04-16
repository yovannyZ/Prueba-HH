CREATE TABLE [dbo].[UsuarioModulo] (
    [IdUsuario] INT NOT NULL,
    [NuModulo]  INT NOT NULL,
    CONSTRAINT [PkUsuarioModulo] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [NuModulo] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del modulo del sistema.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioModulo', @level2type = N'COLUMN', @level2name = N'NuModulo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador del usuario.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsuarioModulo', @level2type = N'COLUMN', @level2name = N'IdUsuario';

