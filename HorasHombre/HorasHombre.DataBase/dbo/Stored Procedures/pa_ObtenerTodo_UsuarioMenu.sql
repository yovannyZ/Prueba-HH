-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_UsuarioMenu]
 @IdUsuario Int = NULL
AS

SELECT 
     IdUsuario
     , IdMenu
     , FlActivar
     , FlEliminar
     , FlEscribir
     , FlLeer
	 , FlVer
FROM UsuarioMenu
WHERE IdUsuario = @IdUsuario


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON