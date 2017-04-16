-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_OrdenProduccionActividad]
 @IdRelacion Int = NULL
AS
DELETE FROM OrdenProduccionActividad
WHERE IdRelacion = @IdRelacion

UPDATE OrdenProduccionActividad SET FlActivo = 'False'
WHERE IdRelacion = @IdRelacion


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
