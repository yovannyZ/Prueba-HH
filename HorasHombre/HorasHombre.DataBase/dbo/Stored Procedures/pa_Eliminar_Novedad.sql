-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_Novedad]
 @IdNovedad Int = NULL
AS
UPDATE Novedad SET FlActivo = 'False'
WHERE IdNovedad = @IdNovedad


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
