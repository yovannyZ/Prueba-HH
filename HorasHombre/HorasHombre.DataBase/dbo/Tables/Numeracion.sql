CREATE TABLE [dbo].[Numeracion] (
    [IdArea]        INT         NOT NULL,
    [TxCorrelativo] VARCHAR (7) NULL,
    CONSTRAINT [PkNumeracion] PRIMARY KEY CLUSTERED ([IdArea] ASC),
    CONSTRAINT [Area_Numeracion] FOREIGN KEY ([IdArea]) REFERENCES [dbo].[Area] ([IdArea])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Numeración correlativa del documento.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Numeracion', @level2type = N'COLUMN', @level2name = N'TxCorrelativo';

