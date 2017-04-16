-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_PlanillaDetalle]
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


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
