CREATE TABLE [dbo].[Area] (
    [IdArea]             INT          IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CoArea]             VARCHAR (2)  NOT NULL,
    [NoArea]             VARCHAR (40) NOT NULL,
    [TxDescripcionCorta] VARCHAR (15) NULL,
	[FlAutomatico]       BIT          NULL,
    [FlActivo]           BIT          NOT NULL,
    CONSTRAINT [PkArea] PRIMARY KEY CLUSTERED ([IdArea] ASC),
    CONSTRAINT [UqArea] UNIQUE NONCLUSTERED ([CoArea] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único del área', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Area', @level2type = N'COLUMN', @level2name = N'IdArea';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Código único del área', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Area', @level2type = N'COLUMN', @level2name = N'CoArea';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nombre del área', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Area', @level2type = N'COLUMN', @level2name = N'NoArea';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción corta del área', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Area', @level2type = N'COLUMN', @level2name = N'TxDescripcionCorta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el área genera planilla de horas hombre automática.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Area', @level2type = N'COLUMN', @level2name = N'FlAutomatico';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el área se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Area', @level2type = N'COLUMN', @level2name = N'FlActivo';

