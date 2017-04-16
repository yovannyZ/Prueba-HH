-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 11/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Configuracion]
 @IdConfiguracion Int = NULL OUTPUT
 , @CoConfiguracion VarChar(10) = NULL
 , @TxDescripcion VarChar(80) = NULL
 , @TxValor VarChar(80) = NULL
 , @FlActivo Bit = NULL
AS

INSERT INTO Configuracion(
     CoConfiguracion
     , TxDescripcion
     , TxValor
     , FlActivo
)
VALUES(
     @CoConfiguracion
     , @TxDescripcion
     , @TxValor
     , @FlActivo
)
SET @IdConfiguracion = SCOPE_IDENTITY()


SET ANSI_NULLS ON