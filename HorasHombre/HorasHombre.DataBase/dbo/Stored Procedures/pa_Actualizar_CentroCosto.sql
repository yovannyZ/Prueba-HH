-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_CentroCosto]
 @IdCentroCosto Int = NULL
 , @CoCentroCosto VarChar(5) = NULL
 , @NoCentroCosto VarChar(30) = NULL
 , @TxDescripcionCorta VarChar(15) = NULL
 , @FlActivo Bit = NULL
AS
UPDATE CentroCosto SET
     CoCentroCosto = @CoCentroCosto
     , NoCentroCosto = @NoCentroCosto
     , TxDescripcionCorta = @TxDescripcionCorta
     , FlActivo = @FlActivo
WHERE IdCentroCosto = @IdCentroCosto


SET ANSI_NULLS ON
