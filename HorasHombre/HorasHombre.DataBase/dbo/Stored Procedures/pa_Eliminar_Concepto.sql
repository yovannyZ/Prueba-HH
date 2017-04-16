-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 19/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_Concepto]
 @IdConcepto Int = NULL
AS

UPDATE Concepto SET FlActivo='False'
WHERE IdConcepto = @IdConcepto


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON