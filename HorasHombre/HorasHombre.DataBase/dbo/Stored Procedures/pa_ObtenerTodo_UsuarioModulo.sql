-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 24/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_UsuarioModulo]
 @IdUsuario Int = NULL
AS

SELECT 
     IdUsuario
     , NuModulo
FROM UsuarioModulo
WHERE IdUsuario = @IdUsuario


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON