-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_UsuarioModulo]
 @IdUsuario Int = NULL
 , @NuModulo Int = NULL
AS

INSERT INTO UsuarioModulo(
     IdUsuario
     , NuModulo
)
VALUES(
     @IdUsuario
     , @NuModulo
)


SET ANSI_NULLS ON