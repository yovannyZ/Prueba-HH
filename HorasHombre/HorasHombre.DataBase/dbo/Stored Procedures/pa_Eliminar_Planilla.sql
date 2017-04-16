-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_Planilla]
 @IdPlanilla Int = NULL
AS
UPDATE Planilla SET FlActivo = 'False'
WHERE IdPlanilla = @IdPlanilla


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
