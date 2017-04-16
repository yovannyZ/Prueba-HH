-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 17/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Activar_Planilla]
 @IdPlanilla Int = NULL
AS

UPDATE Planilla SET FlActivo = 'True'
WHERE IdPlanilla = @IdPlanilla

-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON


