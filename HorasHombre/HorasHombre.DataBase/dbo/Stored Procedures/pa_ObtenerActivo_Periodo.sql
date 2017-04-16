-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 16/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerActivo_Periodo]
 @NuModulo Int = NULL
AS

SELECT 
     IdPeriodo
     , FeInicio
     , FeCierre
     , FlActivo
     , FlCierre
     , NuModulo
FROM Periodo
WHERE FlActivo = 'True' AND
	NuModulo = @NuModulo


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON