-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 27/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Numeracion]
 @IdArea Int 
 , @TxCorrelativo VarChar(7)
AS

INSERT INTO Numeracion(
     IdArea
	 , TxCorrelativo
)
VALUES(
     @IdArea
	 , @TxCorrelativo
)


SET ANSI_NULLS ON