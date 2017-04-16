-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_PlanillaDetalle]
 @IdPlanillaDetalle Int = 0
 , @IdNovedad Int = 0
 , @IdCentroCosto Int = 0
 , @IdRelacion Int = 0
 , @FeInicio DateTime = NULL
 , @FeFin DateTime = NULL
AS

UPDATE PlanillaDetalle SET
     IdNovedad = @IdNovedad
     , IdCentroCosto = @IdCentroCosto
     , IdRelacion = @IdRelacion
     , FeInicio = @FeInicio
     , FeFin = @FeFin
	 , FlActivo = 'True'
WHERE IdPlanillaDetalle = @IdPlanillaDetalle


SET ANSI_NULLS ON
