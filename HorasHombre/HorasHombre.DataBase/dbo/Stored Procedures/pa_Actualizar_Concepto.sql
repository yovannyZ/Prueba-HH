-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 19/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Concepto]
 @IdConcepto Int = NULL
 , @CoConcepto VarChar(3) = NULL
 , @NoConcepto VarChar(100) = NULL
 , @TxDescripcionCorta VarChar(50) = NULL
 , @TxReferencia VarChar(30) = NULL
 , @NuTipoPlanilla Int = NULL
 , @FlActivo Bit = NULL
AS

UPDATE Concepto SET
     CoConcepto = @CoConcepto
     , NoConcepto = @NoConcepto
     , TxDescripcionCorta = @TxDescripcionCorta
     , TxReferencia = @TxReferencia
     , NuTipoPlanilla = @NuTipoPlanilla
     , FlActivo = @FlActivo
WHERE IdConcepto = @IdConcepto


SET ANSI_NULLS ON