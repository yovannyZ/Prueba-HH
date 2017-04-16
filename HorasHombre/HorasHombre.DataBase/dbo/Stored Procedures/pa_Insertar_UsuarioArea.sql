-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_UsuarioArea]
 @IdUsuario Int = NULL
 , @IdArea Int = NULL
AS

INSERT INTO UsuarioArea(
     IdUsuario
     , IdArea
)
VALUES(
     @IdUsuario
     , @IdArea
)


SET ANSI_NULLS ON