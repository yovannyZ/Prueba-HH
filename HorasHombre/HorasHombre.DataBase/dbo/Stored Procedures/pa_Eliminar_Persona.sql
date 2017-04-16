-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_Persona]
 @IdPersona Int = NULL
AS
UPDATE Persona SET FlActivo = 'False'
WHERE IdPersona = @IdPersona


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
