USE [TSTS_SQL_F]

/*buscar usuario loggeado*/
GO
CREATE PROCEDURE [dbo].[BuscarLogin]
@nombreUsuario nvarchar(50),
@contraseña nvarchar(50)
AS
BEGIN

select distinct CodRep, DesRep 
from ResumenNomina 
where DesRep=@nombreUsuario 
	and CodRep=@contraseña
	
END

/*Consultar toda la info de los usuarios*/
GO
CREATE PROCEDURE [dbo].[BuscarLogin]
@contraseña nvarchar(50)
AS
BEGIN

 select distinct CodRep, desrep
 from "TSTS_SQL_F".dbo.ResumenNomina
 where CodRep=@contraseña
	
END