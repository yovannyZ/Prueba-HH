-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 22/01/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_PersonaArea]
 @IdArea Int = NULL
AS

DELETE FROM PersonaArea
WHERE IdArea = @IdArea

-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
