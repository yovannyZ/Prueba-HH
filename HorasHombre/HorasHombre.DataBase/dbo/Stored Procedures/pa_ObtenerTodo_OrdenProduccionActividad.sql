-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_OrdenProduccionActividad]
 @IdOrdenProduccion Int = NULL
AS

SELECT 
     IdRelacion
     , IdOrdenProduccion
     , IdActividad
	 , FlActivo
FROM OrdenProduccionActividad
WHERE IdOrdenProduccion = @IdOrdenProduccion


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
