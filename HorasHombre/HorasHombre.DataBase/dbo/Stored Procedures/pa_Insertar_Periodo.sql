-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Periodo]
 @IdPeriodo Int = NULL OUTPUT
 , @FeInicio DateTime = NULL
 , @FeCierre DateTime = NULL
 , @NuModulo Int = NULL
 , @FlCierre Bit = NULL
 , @FlActivo Bit = NULL
AS
INSERT INTO Periodo(
     FeInicio
     , FeCierre
     , NuModulo
     , FlCierre
     , FlActivo
)
VALUES(
     @FeInicio
     , @FeCierre
     , @NuModulo
     , @FlCierre
     , @FlActivo
)
SET @IdPeriodo = SCOPE_IDENTITY()


SET ANSI_NULLS ON
