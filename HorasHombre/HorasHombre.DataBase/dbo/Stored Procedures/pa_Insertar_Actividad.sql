-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Actividad]
 @IdActividad Int = NULL OUTPUT
 , @CoActividad VarChar(5) = NULL
 , @NoActividad VarChar(60) = NULL
 , @TxDescripcionCorta VarChar(30) = NULL
 , @IdActividadPrincipal Int = 0
 , @TxObservacion VarChar(100) = NULL
 , @NuNivel Int = NULL
 , @FlActivo Bit = NULL
AS
INSERT INTO Actividad(
     CoActividad
     , NoActividad
     , TxDescripcionCorta
     , IdActividadPrincipal
     , TxObservacion
     , NuNivel
     , FlActivo
)
VALUES(
     @CoActividad
     , @NoActividad
     , @TxDescripcionCorta
     , @IdActividadPrincipal
     , @TxObservacion
     , @NuNivel
     , @FlActivo
)
SET @IdActividad = SCOPE_IDENTITY()


SET ANSI_NULLS ON
