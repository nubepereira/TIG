USE [TSTS_SQL_F]
GO
/****** Object:  StoredProcedure [dbo].[ComboAnos]    Script Date: 12/02/2014 19:19:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ComboAnos]

AS
BEGIN

	SELECT Ano
	FROM dbo.Anos
	
END