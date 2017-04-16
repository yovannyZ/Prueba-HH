-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_UsuarioArea]
 @IdUsuario Int = NULL
AS

SELECT 
     IdUsuario
     , IdArea
FROM UsuarioArea
WHERE IdUsuario = @IdUsuario


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON