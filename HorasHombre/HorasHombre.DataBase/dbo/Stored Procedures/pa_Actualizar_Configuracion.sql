-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 11/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Configuracion]
 @IdConfiguracion Int = NULL
 , @CoConfiguracion VarChar(10) = NULL
 , @TxDescripcion VarChar(80) = NULL
 , @TxValor VarChar(80) = NULL
 , @FlActivo Int = NULL
AS

UPDATE Configuracion SET
     CoConfiguracion = @CoConfiguracion
     , TxDescripcion = @TxDescripcion
     , TxValor = @TxValor
     , FlActivo = @FlActivo
WHERE IdConfiguracion = @IdConfiguracion


SET ANSI_NULLS ON