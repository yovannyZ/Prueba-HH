-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 17/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Activar_CentroCosto]
 @IdCentroCosto Int = NULL
AS

UPDATE CentroCosto SET FlActivo = 'True'
WHERE IdCentroCosto = @IdCentroCosto

-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON


