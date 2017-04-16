-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Actividad]
 @IdActividad Int = NULL
 , @CoActividad VarChar(5) = NULL
 , @NoActividad VarChar(60) = NULL
 , @TxDescripcionCorta VarChar(30) = NULL
 , @IdActividadPrincipal Int = 0
 , @TxObservacion VarChar(100) = NULL
 , @NuNivel Int = NULL
 , @FlActivo Bit = NULL
AS
UPDATE Actividad SET
     CoActividad = @CoActividad
     , NoActividad = @NoActividad
     , TxDescripcionCorta = @TxDescripcionCorta
     , IdActividadPrincipal = @IdActividadPrincipal
     , TxObservacion = @TxObservacion
     , NuNivel = @NuNivel
     , FlActivo = @FlActivo
WHERE IdActividad = @IdActividad


SET ANSI_NULLS ON
