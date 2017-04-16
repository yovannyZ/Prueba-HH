-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerPorId_Sucursal]
 @IdSucursal Int = NULL
AS

SELECT 
     IdSucursal
     , CoSucursal
     , NoSucursal
     , TxDescripcionCorta
     , TxNumeroRuc
     , TxTelefono
     , TxDireccion
     , TxLocalidad
     , FlActivo
FROM Sucursal
WHERE IdSucursal = @IdSucursal


