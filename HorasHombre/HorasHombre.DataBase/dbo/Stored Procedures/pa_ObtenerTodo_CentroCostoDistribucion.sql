-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 29/09/2014
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_PersonaArea]
 @IdArea Int = NULL
 , @IdPersona Int = NULL

AS

SELECT 
     IdArea
     , IdPersona
FROM PersonaArea 
WHERE IdArea = @IdArea


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
