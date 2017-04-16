-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_PlanillaDetalle]
 @IdPlanilla Int = NULL
 , @IdPersona Int = NULL
 , @IdCentroCosto Int = 0
 , @IdNovedad Int = NULL
 , @IdRelacion Int = 0
 , @FeInicio time(0) = NULL
 , @FeFin time(0) = NULL
AS
INSERT INTO PlanillaDetalle(
	 IdPlanilla
     , IdPersona
     , IdCentroCosto
     , IdNovedad
     , IdRelacion
     , FeInicio
     , FeFin
)
VALUES(
	 @IdPlanilla
     , @IdPersona
     , @IdCentroCosto
     , @IdNovedad
     , @IdRelacion
     , @FeInicio
     , @FeFin
)


SET ANSI_NULLS ON
