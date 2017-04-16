-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Periodo]
 @IdPeriodo Int = NULL
 , @FeInicio DateTime = NULL
 , @FeCierre DateTime = NULL
 , @NuModulo Int = NULL
 , @FlCierre Bit = NULL
 , @FlActivo Bit = NULL
AS
UPDATE Periodo SET
     FeInicio = @FeInicio
     , FeCierre = @FeCierre
     , NuModulo = @NuModulo
     , FlCierre = @FlCierre
     , FlActivo = @FlActivo
WHERE IdPeriodo = @IdPeriodo


SET ANSI_NULLS ON
