-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_CentroCosto]
 @IdCentroCosto Int = NULL OUTPUT
 , @CoCentroCosto VarChar(5) = NULL
 , @NoCentroCosto VarChar(30) = NULL
 , @TxDescripcionCorta VarChar(15) = NULL
 , @FlActivo Bit = NULL
AS
INSERT INTO CentroCosto(
     CoCentroCosto
     , NoCentroCosto
     , TxDescripcionCorta
     , FlActivo
)
VALUES(
     @CoCentroCosto
     , @NoCentroCosto
     , @TxDescripcionCorta
     , @FlActivo
)
SET @IdCentroCosto = SCOPE_IDENTITY()


SET ANSI_NULLS ON
