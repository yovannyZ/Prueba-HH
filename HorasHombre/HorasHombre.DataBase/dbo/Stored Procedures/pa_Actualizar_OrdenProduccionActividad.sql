-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_Actualizar_OrdenProduccionActividad]
 @IdRelacion Int = NULL
 , @IdOrdenProduccion Int = NULL
 , @IdActividad Int = NULL
 , @FlActivo Bit = NULL
AS
UPDATE OrdenProduccionActividad SET
     IdOrdenProduccion = @IdOrdenProduccion
     , IdActividad = @IdActividad
	 , FlActivo = @FlActivo
WHERE IdRelacion = @IdRelacion


SET ANSI_NULLS ON
