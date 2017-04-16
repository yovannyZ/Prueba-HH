-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_Periodo]
AS

SELECT 
     IdPeriodo
     , FeInicio
     , FeCierre
     , NuModulo
     , FlCierre
     , FlActivo
FROM Periodo


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
