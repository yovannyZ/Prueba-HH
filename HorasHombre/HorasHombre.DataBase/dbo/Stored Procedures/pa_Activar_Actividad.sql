-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 17/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Activar_Actividad]
 @IdActividad Int = NULL
AS

UPDATE Actividad SET FlActivo = 'True'
WHERE IdActividad = @IdActividad

-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON


