-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorId_Menu]
 @IdMenu Int = NULL
AS

SELECT 
     IdMenu
     , NoMenu
     , TxDescripcionMenu
     , IdMenuPadre
     , FlFormulario
     , TxFormulario
	 , NuModulo
FROM Menu
WHERE IdMenu = @IdMenu


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON