﻿-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorId_Novedad]
 @IdNovedad Int = NULL
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
WHERE IdNovedad = @IdNovedad


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
