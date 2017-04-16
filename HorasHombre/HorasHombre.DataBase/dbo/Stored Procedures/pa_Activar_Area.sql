-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 17/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Activar_Area]
 @IdArea Int = NULL
AS

UPDATE Area SET FlActivo = 'True'
WHERE IdArea = @IdArea

-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON


