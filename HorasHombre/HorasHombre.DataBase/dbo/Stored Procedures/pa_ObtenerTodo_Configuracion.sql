-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 11/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_Configuracion]
AS

SELECT 
     IdConfiguracion
     , CoConfiguracion
     , TxDescripcion
     , TxValor
     , FlActivo
FROM Configuracion


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON