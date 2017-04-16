-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorId_PlanillaDetalle]
 @IdPlanilla Int = NULL
AS

SELECT 
     IdPlanillaDetalle
	 , IdPlanilla
     , IdPersona
     , IdCentroCosto
     , IdNovedad
     , IdRelacion
     , FeInicio
     , FeFin
	 , FlActivo
FROM PlanillaDetalle
WHERE IdPlanilla = @IdPlanilla


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
