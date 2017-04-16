-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Menu]
 @IdMenu Int = NULL
 , @NoMenu VarChar(50) = NULL
 , @TxDescripcionMenu VarChar(100) = NULL
 , @IdMenuPadre Int = 0
 , @FlFormulario Bit = NULL
 , @TxFormulario VarChar(60) = NULL
 , @NuModulo Int = NULL
AS

UPDATE Menu SET
     NoMenu = @NoMenu
     , TxDescripcionMenu = @TxDescripcionMenu
     , IdMenuPadre = @IdMenuPadre
     , FlFormulario = @FlFormulario
     , TxFormulario = @TxFormulario
	 , NuModulo = @NuModulo
WHERE IdMenu = @IdMenu


SET ANSI_NULLS ON