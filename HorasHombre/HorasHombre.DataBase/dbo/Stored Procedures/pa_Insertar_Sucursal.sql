-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_Sucursal]
 @IdSucursal Int = NULL OUTPUT
 , @CoSucursal VarChar(4) = NULL
 , @NoSucursal VarChar(60) = NULL
 , @TxDescripcionCorta VarChar(30) = NULL
 , @TxNumeroRuc VarChar(11) = NULL
 , @TxTelefono VarChar(20) = NULL
 , @TxDireccion VarChar(60) = NULL
 , @TxLocalidad VarChar(20) = NULL
 , @FlActivo Bit = NULL
AS
INSERT INTO Sucursal(
     CoSucursal
     , NoSucursal
     , TxDescripcionCorta
     , TxNumeroRuc
     , TxTelefono
     , TxDireccion
     , TxLocalidad
     , FlActivo
)
VALUES(
     @CoSucursal
     , @NoSucursal
     , @TxDescripcionCorta
     , @TxNumeroRuc
     , @TxTelefono
     , @TxDireccion
     , @TxLocalidad
     , @FlActivo
)
SET @IdSucursal = SCOPE_IDENTITY()
