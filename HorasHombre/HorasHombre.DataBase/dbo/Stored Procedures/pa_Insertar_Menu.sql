-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Menu]
 @IdMenu Int = NULL OUTPUT
 , @NoMenu VarChar(50) = NULL
 , @TxDescripcionMenu VarChar(100) = NULL
 , @IdMenuPadre Int = 0
 , @FlFormulario Bit = NULL
 , @TxFormulario VarChar(60) = NULL
 , @NuModulo Int = NULL
AS

INSERT INTO Menu(
     NoMenu
     , TxDescripcionMenu
     , IdMenuPadre
     , FlFormulario
     , TxFormulario
	 , NuModulo
)
VALUES(
     @NoMenu
     , @TxDescripcionMenu
     , @IdMenuPadre
     , @FlFormulario
     , @TxFormulario
	 , @NuModulo
)
SET @IdMenu = SCOPE_IDENTITY()


SET ANSI_NULLS ON