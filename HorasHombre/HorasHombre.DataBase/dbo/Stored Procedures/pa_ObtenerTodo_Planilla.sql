-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_Planilla]
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


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
