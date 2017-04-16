-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Area]
 @IdArea Int = NULL OUTPUT
 , @CoArea VarChar(2) = NULL
 , @NoArea VarChar(40) = NULL
 , @TxDescCorta VarChar(15) = NULL
 , @FlAutomatico Bit = NULL
 , @FlActivo Bit = NULL
AS
INSERT INTO Area(
     CoArea
     , NoArea
     , TxDescripcionCorta
	 , FlAutomatico
     , FlActivo
)
VALUES(
     @CoArea
     , @NoArea
     , @TxDescCorta
	 , @FlAutomatico
     , @FlActivo
)
SET @IdArea = SCOPE_IDENTITY()


SET ANSI_NULLS ON
