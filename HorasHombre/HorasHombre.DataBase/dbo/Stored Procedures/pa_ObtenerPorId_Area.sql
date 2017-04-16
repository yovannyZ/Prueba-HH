-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorId_Area]
 @IdArea Int = NULL
AS

SELECT 
     IdArea
     , CoArea
     , NoArea
     , TxDescripcionCorta
	 , FlAutomatico
     , FlActivo
FROM Area
WHERE IdArea = @IdArea


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
