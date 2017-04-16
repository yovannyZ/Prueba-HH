-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Planilla]
 @IdPlanilla Int = NULL
 , @NuPlanilla VarChar(20) = NULL
 , @FePlanilla DateTime = NULL
 , @IdUsuario Int = NULL
 , @IdSucursal Int = NULL
 , @IdPeriodo Int = NULL
 , @IdArea Int = NULL
 , @FlActivo Bit = NULL
AS
UPDATE Planilla SET
     NuPlanilla = @NuPlanilla
     , FePlanilla = @FePlanilla
     , IdUsuario = @IdUsuario
     , IdSucursal = @IdSucursal
     , IdPeriodo = @IdPeriodo
     , IdArea = @IdArea
     , FlActivo = @FlActivo
WHERE IdPlanilla = @IdPlanilla


SET ANSI_NULLS ON
