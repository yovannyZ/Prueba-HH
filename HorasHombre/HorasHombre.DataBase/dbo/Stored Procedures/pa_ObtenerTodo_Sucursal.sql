-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_Sucursal]
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


