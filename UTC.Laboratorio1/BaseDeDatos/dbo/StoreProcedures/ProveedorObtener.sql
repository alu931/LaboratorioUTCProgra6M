CREATE PROCEDURE [dbo].[ProveedorObtener]
	@IdProveedor INT = NULL

AS 
BEGIN
  SET NOCOUNT ON

  /*Obtener datos de proveedor*/
  SELECT
         IdProveedor
		,Identificacion
		,Nombre
		,PrimerApellido
		,SegundoApellido
		,Edad
		,FechaNacimiento
  FROM 
       dbo.Proveedor
  WHERE
      (@IdProveedor IS NULL OR IdProveedor=@IdProveedor)

END