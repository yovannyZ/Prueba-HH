-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 17/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Activar_Periodo]
 @IdPeriodo Int = 0
 , @FlActivo Bit = 'False'
AS

UPDATE Periodo SET FlActivo = @FlActivo
WHERE IdPeriodo = @IdPeriodo

-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON


