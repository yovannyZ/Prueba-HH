-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Persona]
 @IdPersona Int = NULL
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
UPDATE Persona SET
     CoPersona = @CoPersona
     , NoPersona = @NoPersona
     , TxPaterno = @TxPaterno
     , TxMaterno = @TxMaterno
     , NuTipo = @NuTipo
     , NuTipoDocumento = @NuTipoDocumento
     , TxNumeroDocumento = @TxNumeroDocumento
     , TxEmail = @TxEmail
	 , IdCentroCosto = @IdCentroCosto
     , FlActivo = @FlActivo
WHERE IdPersona = @IdPersona


SET ANSI_NULLS ON
