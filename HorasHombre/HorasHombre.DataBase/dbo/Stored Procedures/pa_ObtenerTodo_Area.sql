﻿-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_Area]
AS

SELECT 
     IdArea
     , CoArea
     , NoArea
     , TxDescripcionCorta
	 , FlAutomatico
     , FlActivo
FROM Area


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
