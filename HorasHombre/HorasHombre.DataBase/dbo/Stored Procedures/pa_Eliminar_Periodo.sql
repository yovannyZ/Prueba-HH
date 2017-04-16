-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_Periodo]
 @IdPeriodo Int = NULL
AS
UPDATE Periodo SET FlActivo = 'False'
WHERE IdPeriodo = @IdPeriodo


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
