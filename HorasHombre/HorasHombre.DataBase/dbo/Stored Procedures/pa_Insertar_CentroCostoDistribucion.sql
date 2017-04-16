-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 29/09/2014
-- =============================================
CREATE PROCEDURE [dbo].[pa_Insertar_PersonaArea]
 @IdArea Int = NULL
 , @IdPersona Int = NULL
AS

INSERT INTO PersonaArea(
     IdArea
     , IdPersona
)
VALUES(
     @IdArea
     , @IdPersona
)


SET ANSI_NULLS ON
