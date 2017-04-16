-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 17/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Activar_Novedad]
 @IdNovedad Int = NULL
AS

UPDATE Novedad SET FlActivo = 'True'
WHERE IdNovedad = @IdNovedad

-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON


