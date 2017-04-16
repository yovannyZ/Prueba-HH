-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 11/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorCodigo_Configuracion]
 @CoConfiguracion VarChar(10) = NULL
AS

SELECT 
     IdConfiguracion
     , CoConfiguracion
     , TxDescripcion
     , TxValor
     , FlActivo
FROM Configuracion
WHERE CoConfiguracion = @CoConfiguracion


SET ANSI_NULLS ON