-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_Actividad]
AS

SELECT 
     IdActividad
     , CoActividad
     , NoActividad
     , TxDescripcionCorta
     , IdActividadPrincipal
     , TxObservacion
     , NuNivel
     , FlActivo
FROM Actividad


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
