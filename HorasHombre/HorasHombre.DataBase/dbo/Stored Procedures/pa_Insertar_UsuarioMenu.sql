-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_UsuarioMenu]
 @IdUsuario Int = NULL
 , @IdMenu Int = NULL
 , @FlActivar Bit = NULL
 , @FlEliminar Bit = NULL
 , @FlEscribir Bit = NULL
 , @FlLeer Bit = NULL
 , @FlVer Bit = NULL
AS

INSERT INTO UsuarioMenu(
     IdUsuario
     , IdMenu
     , FlActivar
     , FlEliminar
     , FlEscribir
     , FlLeer
	 , FlVer
)
VALUES(
     @IdUsuario
     , @IdMenu
     , @FlActivar
     , @FlEliminar
     , @FlEscribir
     , @FlLeer
	 , @FlVer
)


SET ANSI_NULLS ON