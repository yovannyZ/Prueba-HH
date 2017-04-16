-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_UsuarioSucursal]
 @IdUsuario Int = NULL
 , @IdSucursal Int = NULL
AS

INSERT INTO UsuarioSucursal(
     IdUsuario
     , IdSucursal
)
VALUES(
     @IdUsuario
     , @IdSucursal
)


SET ANSI_NULLS ON