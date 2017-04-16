-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_OrdenProduccionActividad]
 @IdRelacion Int = NULL OUTPUT
 , @IdOrdenProduccion Int = NULL
 , @IdActividad Int = NULL
 , @FlActivo Bit = NULL
AS
INSERT INTO OrdenProduccionActividad(
     IdOrdenProduccion
     , IdActividad
	 , FlActivo
)
VALUES(
     @IdOrdenProduccion
     , @IdActividad
	 , @FlActivo

)
SET @IdRelacion = SCOPE_IDENTITY()


SET ANSI_NULLS ON
