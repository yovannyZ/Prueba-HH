-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_Sucursal]
 @IdSucursal Int = NULL
AS
UPDATE Sucursal SET FlActivo = 'False'
WHERE IdSucursal = @IdSucursal
