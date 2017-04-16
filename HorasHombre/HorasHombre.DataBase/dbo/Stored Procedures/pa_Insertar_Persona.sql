-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Persona]
 @IdPersona Int = NULL OUTPUT
 , @CoPersona VarChar(5) = NULL
 , @NoPersona VarChar(60) = NULL
 , @TxPaterno VarChar(20) = NULL
 , @TxMaterno VarChar(20) = NULL
 , @NuTipo Int = NULL
 , @NuTipoDocumento Int = NULL
 , @TxNumeroDocumento VarChar(20) = NULL
 , @TxEmail VarChar(50) = NULL
 , @IdCentroCosto Int = 0
 , @FlActivo Bit = NULL
AS
INSERT INTO Persona(
     CoPersona
     , NoPersona
     , TxPaterno
     , TxMaterno
     , NuTipo
     , NuTipoDocumento
     , TxNumeroDocumento
     , TxEmail
	 , IdCentroCosto
     , FlActivo
)
VALUES(
     @CoPersona
     , @NoPersona
     , @TxPaterno
     , @TxMaterno
     , @NuTipo
     , @NuTipoDocumento
     , @TxNumeroDocumento
     , @TxEmail
	 , @IdCentroCosto
     , @FlActivo
)
SET @IdPersona = SCOPE_IDENTITY()


SET ANSI_NULLS ON
