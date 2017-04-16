-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_Actividad]
 @IdActividad Int = NULL
AS
UPDATE Actividad SET FlActivo = 'False'
WHERE IdActividad = @IdActividad


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
