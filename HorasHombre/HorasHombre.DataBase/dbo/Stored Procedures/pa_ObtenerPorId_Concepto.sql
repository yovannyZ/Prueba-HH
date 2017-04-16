-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 19/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorId_Concepto]
 @IdConcepto Int = NULL
AS

SELECT 
     IdConcepto
     , CoConcepto
     , NoConcepto
     , TxDescripcionCorta
     , TxReferencia
	 , NuTipoPlanilla
     , FlActivo
FROM Concepto
WHERE IdConcepto = @IdConcepto


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON