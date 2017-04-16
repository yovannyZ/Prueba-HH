-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 27/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_PlanillaDetalle]
 @IdPlanilla Int = 0
AS
UPDATE PlanillaDetalle SET FlActivo = 'False'
WHERE IdPlanilla = @IdPlanilla


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON