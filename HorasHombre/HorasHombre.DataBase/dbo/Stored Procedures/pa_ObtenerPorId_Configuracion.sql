-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 11/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorId_Configuracion]
 @IdConfiguracion Int = NULL
AS

SELECT 
     IdConfiguracion
     , CoConfiguracion
     , TxDescripcion
     , TxValor
     , FlActivo
FROM Configuracion
WHERE IdConfiguracion = @IdConfiguracion


SET ANSI_NULLS ON