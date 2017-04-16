-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_Sucursal]
 @IdSucursal Int = NULL
 , @CoSucursal VarChar(4) = NULL
 , @NoSucursal VarChar(60) = NULL
 , @TxDescripcionCorta VarChar(30) = NULL
 , @TxNumeroRuc VarChar(11) = NULL
 , @TxTelefono VarChar(20) = NULL
 , @TxDireccion VarChar(60) = NULL
 , @TxLocalidad VarChar(20) = NULL
 , @FlActivo Bit = NULL
AS
UPDATE Sucursal SET
     CoSucursal = @CoSucursal
     , NoSucursal = @NoSucursal
     , TxDescripcionCorta = @TxDescripcionCorta
     , TxNumeroRuc = @TxNumeroRuc
     , TxTelefono = @TxTelefono
     , TxDireccion = @TxDireccion
     , TxLocalidad = @TxLocalidad
     , FlActivo = @FlActivo
WHERE IdSucursal = @IdSucursal
