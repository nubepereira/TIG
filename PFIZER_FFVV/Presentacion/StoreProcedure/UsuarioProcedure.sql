/*
select R.CodRep
from Reps R
where R.idL in('79','84','71','129','49','67','104','133','75','134','135','142','141','153','154','149','150','141') and R.Pago= 1;  
*/

USE [TSTS_SQL_F]
GO

CREATE PROCEDURE [dbo].[BuscarLogin]
@nombreUsuario varchar(50),
@contraseña varchar(50)
AS
BEGIN

select distinct CodRep, DesRep 
from ResumenNomina 
where DesRep=@nombreUsuario 
	and CodRep=@contraseña
	
END


/*MUESTRA EL USUARIO  LOGGEADO */
GO
CREATE PROCEDURE [dbo].[ConsultarUsuarioLoggeado]
@loggin varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	select rn.idL, rn.nIdL, rn.CodRep, rn.DesRep 
	from ResumenNomina rn, Linea l 
	where l.ID=rn.idL and rn.CodRep =  @loggin		
	order by CodRep
END

/*MUESTRA TODOS LOSUSUARIOS*/
GO
CREATE PROCEDURE [dbo].[ConsultarUsuarioTodo]

AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT distinct rn.CodRep, rn.DesRep, rn.idL, rn.nIdL
	FROM Reps r, ResumenNomina rn, Linea l
	where  r.idL= rn.idL and r.idL= l.ID and rn.idL= l.ID 
	ORDER BY rn.idL
END 