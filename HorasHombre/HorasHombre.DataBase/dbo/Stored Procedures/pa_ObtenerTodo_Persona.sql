-- =============================================
-- Autor:  Generador AOP Beta
-- Fecha Creación: 13/02/2015
-- =============================================
CREATE PROCEDURE [dbo].[pa_ObtenerTodo_Persona]
AS

SELECT 
     IdPersona
     , CoPersona
     , NoPersona
     , TxPaterno
     , TxMaterno
     , NuTipo
     , NuTipoDocumento
     , TxNumeroDocumento
     , TxEmail
	 , IdCentroCosto
     , FlActivo
FROM Persona


-- Usar si existe borrado lógico con un campo con el prefijo 'esta' 
SET ANSI_NULLS ON
