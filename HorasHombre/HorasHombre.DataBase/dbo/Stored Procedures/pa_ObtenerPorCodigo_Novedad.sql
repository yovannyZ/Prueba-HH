-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorCodigo_Novedad]
 @CoNovedad VarChar(2) = NULL
AS

SELECT 
     IdNovedad
     , CoNovedad
     , NoNovedad
     , TxDescripcionCorta
     , NuTipoDistribucion
	 , FlCosto
     , FlActivo
FROM Novedad
WHERE CoNovedad = @CoNovedad


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON