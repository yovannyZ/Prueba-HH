-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Novedad]
 @IdNovedad Int = NULL OUTPUT
 , @CoNovedad VarChar(2) = NULL
 , @NoNovedad VarChar(60) = NULL
 , @TxDescripcionCorta VarChar(30) = NULL
 , @NuTipoDistribucion Int = NULL
 , @FlCosto Bit = NULL
 , @FlActivo Bit = NULL
AS
INSERT INTO Novedad(
     CoNovedad
     , NoNovedad
     , TxDescripcionCorta
     , NuTipoDistribucion
	 , FlCosto
     , FlActivo
)
VALUES(
     @CoNovedad
     , @NoNovedad
     , @TxDescripcionCorta
     , @NuTipoDistribucion
	 , @FlCosto
     , @FlActivo
)
SET @IdNovedad = SCOPE_IDENTITY()


SET ANSI_NULLS ON
