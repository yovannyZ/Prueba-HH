﻿-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Eliminar_Area]
 @IdArea Int = NULL
AS
UPDATE Area SET FlActivo = 'False'
WHERE IdArea = @IdArea


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON