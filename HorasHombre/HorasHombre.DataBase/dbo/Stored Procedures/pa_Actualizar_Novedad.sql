-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Novedad]
 @IdNovedad Int = NULL
 , @CoNovedad VarChar(2) = NULL
 , @NoNovedad VarChar(60) = NULL
 , @TxDescripcionCorta VarChar(30) = NULL
 , @NuTipoDistribucion Int = NULL
 , @FlCosto Bit = NULL
 , @FlActivo Bit = NULL
AS
UPDATE Novedad SET
     CoNovedad = @CoNovedad
     , NoNovedad = @NoNovedad
     , TxDescripcionCorta = @TxDescripcionCorta
     , NuTipoDistribucion = @NuTipoDistribucion
	 , FlCosto = @FlCosto
     , FlActivo = @FlActivo
WHERE IdNovedad = @IdNovedad


SET ANSI_NULLS ON
