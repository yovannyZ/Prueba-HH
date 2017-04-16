-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_CentroCosto]
 @IdCentroCosto Int = NULL
AS
UPDATE CentroCosto SET FlActivo = 'False'
WHERE IdCentroCosto = @IdCentroCosto


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
