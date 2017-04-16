-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Planilla]
 @IdPlanilla Int = NULL OUTPUT
 , @NuPlanilla VarChar(20) = NULL
 , @FePlanilla DateTime = NULL
 , @IdUsuario Int = NULL
 , @IdSucursal Int = NULL
 , @IdPeriodo Int = NULL
 , @IdArea Int = NULL
 , @FlActivo Bit = NULL
AS
INSERT INTO Planilla(
     NuPlanilla
     , FePlanilla
     , IdUsuario
     , IdSucursal
     , IdPeriodo
     , IdArea
     , FlActivo
)
VALUES(
     @NuPlanilla
     , @FePlanilla
     , @IdUsuario
     , @IdSucursal
     , @IdPeriodo
     , @IdArea
     , @FlActivo
)
SET @IdPlanilla = SCOPE_IDENTITY()


SET ANSI_NULLS ON
