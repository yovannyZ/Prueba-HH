-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 19/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Concepto]
 @IdConcepto Int = NULL OUTPUT
 , @CoConcepto VarChar(3) = NULL
 , @NoConcepto VarChar(100) = NULL
 , @TxDescripcionCorta VarChar(50) = NULL
 , @TxReferencia VarChar(30) = NULL
 , @NuTipoPlanilla Int = NULL
 , @FlActivo Bit = NULL
AS

INSERT INTO Concepto(
     CoConcepto
     , NoConcepto
     , TxDescripcionCorta
     , TxReferencia
     , NuTipoPlanilla
     , FlActivo
)
VALUES(
     @CoConcepto
     , @NoConcepto
     , @TxDescripcionCorta
     , @TxReferencia
     , @NuTipoPlanilla
     , @FlActivo
)
SET @IdConcepto = SCOPE_IDENTITY()


SET ANSI_NULLS ON