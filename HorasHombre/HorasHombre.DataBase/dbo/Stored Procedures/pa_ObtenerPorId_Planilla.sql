-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorId_Planilla]
 @IdPlanilla Int = NULL
AS

SELECT 
     IdPlanilla
     , NuPlanilla
     , FePlanilla
     , IdUsuario
     , IdSucursal
     , IdPeriodo
     , IdArea
     , FlActivo
FROM Planilla
WHERE IdPlanilla = @IdPlanilla


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
