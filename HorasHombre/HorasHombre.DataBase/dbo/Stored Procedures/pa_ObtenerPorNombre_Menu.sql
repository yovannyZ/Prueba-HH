-- =============================================
-- Autor:  Donald A. Sullon Porras
-- Fecha Creación: 25/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorNombre_Menu]
 @NoMenu VarChar(50) = NULL
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
WHERE NoMenu = @NoMenu


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON