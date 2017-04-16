-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 17/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Activar_Sucursal]
 @IdSucursal Int = NULL
AS

UPDATE Sucursal SET FlActivo = 'True'
WHERE IdSucursal = @IdSucursal

-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON


