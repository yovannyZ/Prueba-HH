-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 27/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Numeracion]
 @IdArea Int = NULL
 , @TxCorrelativo VarChar(7) = NULL
AS

UPDATE Numeracion SET
     TxCorrelativo = @TxCorrelativo
WHERE IdArea = @IdArea


SET ANSI_NULLS ON