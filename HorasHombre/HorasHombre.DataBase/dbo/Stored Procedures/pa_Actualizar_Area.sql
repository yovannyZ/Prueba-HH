-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Area]
 @IdArea Int = NULL
 , @CoArea VarChar(2) = NULL
 , @NoArea VarChar(40) = NULL
 , @TxDescCorta VarChar(15) = NULL
 , @FlAutomatico Bit = NULL
 , @FlActivo Bit = NULL
AS
UPDATE Area SET
     CoArea = @CoArea
     , NoArea = @NoArea
     , TxDescripcionCorta = @TxDescCorta
	 , FlAutomatico = @FlAutomatico
     , FlActivo = @FlActivo
WHERE IdArea = @IdArea


SET ANSI_NULLS ON
