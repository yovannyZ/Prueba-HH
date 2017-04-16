-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 27/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_Numeracion]
AS

SELECT 
     IdArea
     , TxCorrelativo
FROM Numeracion


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON