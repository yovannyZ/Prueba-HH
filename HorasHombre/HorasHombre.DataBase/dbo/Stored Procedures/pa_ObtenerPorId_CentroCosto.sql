-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorId_CentroCosto]
 @IdCentroCosto Int = NULL
AS

SELECT 
     IdCentroCosto
     , CoCentroCosto
     , NoCentroCosto
     , TxDescripcionCorta
     , FlActivo
FROM CentroCosto
WHERE IdCentroCosto = @IdCentroCosto


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
