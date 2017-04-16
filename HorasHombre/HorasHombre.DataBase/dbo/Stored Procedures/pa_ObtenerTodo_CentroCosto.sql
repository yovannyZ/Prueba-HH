-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_CentroCosto]
AS

SELECT 
     IdCentroCosto
     , CoCentroCosto
     , NoCentroCosto
     , TxDescripcionCorta
     , FlActivo
FROM CentroCosto


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
