-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 19/03/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_Concepto]
AS

SELECT 
     IdConcepto
     , CoConcepto
     , NoConcepto
     , TxDescripcionCorta
     , TxReferencia
	 , NuTipoPlanilla
     , FlActivo
FROM Concepto


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON