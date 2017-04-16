CREATE TABLE [dbo].[Concepto] (
    [IdConcepto]         INT           NOT NULL IDENTITY,
    [CoConcepto]         VARCHAR (3)   NULL,
    [NoConcepto]         VARCHAR (100) NULL,
    [TxDescripcionCorta] VARCHAR (50)  NULL,
    [TxReferencia]       VARCHAR (30)  NULL,
	[NuTipoPlanilla]	 INT		   NULL,
    [FlActivo]           BIT           NULL,
    CONSTRAINT [PkConcepto] PRIMARY KEY CLUSTERED ([IdConcepto] ASC),
    CONSTRAINT [UqConcepto] UNIQUE NONCLUSTERED ([CoConcepto] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado que indica si el concepto se encuentra con el estado activo o inactivo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Concepto', @level2type = N'COLUMN', @level2name = N'FlActivo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Tipo de planilla del concepto.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Concepto', @level2type = N'COLUMN', @level2name = N'NuTipoPlanilla';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Referencia del nombre de columna del concepto.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Concepto', @level2type = N'COLUMN', @level2name = N'TxReferencia';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Descripción corta del concepto.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Concepto', @level2type = N'COLUMN', @level2name = N'TxDescripcionCorta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nombre del concepto.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Concepto', @level2type = N'COLUMN', @level2name = N'NoConcepto';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Código del concepto.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Concepto', @level2type = N'COLUMN', @level2name = N'CoConcepto';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Identificador único del concepto.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Concepto', @level2type = N'COLUMN', @level2name = N'IdConcepto';

