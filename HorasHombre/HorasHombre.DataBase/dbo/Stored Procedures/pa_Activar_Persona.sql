-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 17/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Activar_Persona]
 @IdPersona Int = NULL
AS

UPDATE Persona SET FlActivo = 'True'
WHERE IdPersona = @IdPersona

-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON


