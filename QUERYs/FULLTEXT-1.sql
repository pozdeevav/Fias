-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE FTSEARCH 
	-- Add the parameters for the stored procedure here
	@query nvarchar(50),
	@query2 nvarchar(50),
	@query3 nvarchar(50),
	@query4 nvarchar(50)
AS

DECLARE @i INT
CREATE TABLE #parent (id int NOT NULL IDENTITY(1,1), aoguid nvarchar(max), parentguid nvarchar(max), formalname nvarchar(MAX), shortname nvarchar(max))
CREATE TABLE #parent1 (id int NOT NULL IDENTITY(1,1), aoguid nvarchar(max), parentguid nvarchar(max), formalname nvarchar(MAX), shortname nvarchar(max))
CREATE TABLE #parent2 (id int NOT NULL IDENTITY(1,1), aoguid nvarchar(max), parentguid nvarchar(max), formalname nvarchar(MAX), shortname nvarchar(max))
CREATE TABLE #parent3 (id int NOT NULL IDENTITY(1,1), aoguid nvarchar(max), parentguid nvarchar(max), formalname nvarchar(MAX), shortname nvarchar(max))
--ALTER TABLE ##results (aoguid nvarchar(max), fullname nvarchar(max))

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	truncate table ##results;
	if (@query != '"null"' and @query2 = '"null"' and @query3 = '"null"' and @query4 = '"null"')
	begin
		insert into #parent SELECT TOP(10) AOGUID, PARENTGUID, FORMALNAME, SHORTNAME from FIAS.dbo.ADDROBJ WHERE CONTAINS(FORMALNAME, @query) and LIVESTATUS = 1;
		insert into #parent1 SELECT DISTINCT ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent where ADDROBJ.AOGUID = #parent.parentguid and LIVESTATUS = 1;
		insert into #parent2 SELECT DISTINCT ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent1 where ADDROBJ.AOGUID = #parent1.parentguid and LIVESTATUS = 1;
		insert into #parent3 SELECT DISTINCT ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent2 where ADDROBJ.AOGUID = #parent2.parentguid and LIVESTATUS = 1;
	end;		
	if (@query != '"null"' and @query2 != '"null"' and @query3 = '"null"' and @query4 = '"null"')
	begin
		insert into #parent SELECT AOGUID, PARENTGUID, FORMALNAME, SHORTNAME from FIAS.dbo.ADDROBJ WHERE CONTAINS(FORMALNAME, @query) and LIVESTATUS = 1;
		insert into #parent1 SELECT DISTINCT TOP(10) ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent where ADDROBJ.AOGUID = #parent.parentguid and CONTAINS(ADDROBJ.FORMALNAME, @query2) and LIVESTATUS = 1;
		insert into #parent2 SELECT DISTINCT ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent1 where ADDROBJ.AOGUID = #parent1.parentguid and LIVESTATUS = 1;
		insert into #parent3 SELECT DISTINCT ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent2 where ADDROBJ.AOGUID = #parent2.parentguid and LIVESTATUS = 1;
	end;
	if (@query != '"null"' and @query2 != '"null"' and @query3 != '"null"' and @query4 = '"null"')
	begin
		insert into #parent SELECT AOGUID, PARENTGUID, FORMALNAME, SHORTNAME from FIAS.dbo.ADDROBJ WHERE CONTAINS(FORMALNAME, @query) and LIVESTATUS = 1;
		insert into #parent1 SELECT DISTINCT TOP(10) ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent where ADDROBJ.AOGUID = #parent.parentguid and CONTAINS(ADDROBJ.FORMALNAME, @query2) and LIVESTATUS = 1;
		insert into #parent2 SELECT DISTINCT ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent1 where CONTAINS(ADDROBJ.FORMALNAME, @query3) and ADDROBJ.AOGUID = #parent1.parentguid and LIVESTATUS = 1;
		insert into #parent3 SELECT DISTINCT ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent2 where ADDROBJ.AOGUID = #parent2.parentguid and LIVESTATUS = 1;
	end;
	if (@query != '"null"' and @query2 != '"null"' and @query3 != '"null"' and @query4 != '"null"')
	begin
		insert into #parent SELECT AOGUID, PARENTGUID, FORMALNAME, SHORTNAME from FIAS.dbo.ADDROBJ WHERE CONTAINS(FORMALNAME, @query) and LIVESTATUS = 1;
		insert into #parent1 SELECT DISTINCT TOP(10) ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent where ADDROBJ.AOGUID = #parent.parentguid and CONTAINS(ADDROBJ.FORMALNAME, @query2) and LIVESTATUS = 1;
		insert into #parent2 SELECT DISTINCT ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent1 where CONTAINS(ADDROBJ.FORMALNAME, @query3) and ADDROBJ.AOGUID = #parent1.parentguid and LIVESTATUS = 1;
		insert into #parent3 SELECT DISTINCT ADDROBJ.AOGUID, ADDROBJ.PARENTGUID, ADDROBJ.FORMALNAME, ADDROBJ.SHORTNAME from ADDROBJ, #parent2 where ADDROBJ.AOGUID = #parent2.parentguid and LIVESTATUS = 1;
	end;

	insert into ##results 
	select distinct #parent.aoguid, #parent3.shortname + '. ' + #parent3.formalname + ', ' + #parent2.shortname + '. ' + #parent2.formalname + ', ' + #parent1.shortname + '. ' + #parent1.formalname + ', ' + #parent.shortname + '. ' + #parent.formalname 
	AS 'FULLNAME' 
	from #parent, #parent1, #parent2, #parent3 
	where #parent.parentguid = #parent1.aoguid
	and #parent1.parentguid = #parent2.aoguid
	and #parent2.parentguid = #parent3.aoguid

	insert into ##results 
	select distinct #parent.aoguid, #parent2.shortname + '. ' + #parent2.formalname + ', ' + #parent1.shortname + '. ' + #parent1.formalname + ', ' + #parent.shortname + '. ' + #parent.formalname 
	AS 'FULLNAME' 
	from #parent, #parent1, #parent2
	where #parent.parentguid = #parent1.aoguid
	and #parent1.parentguid = #parent2.aoguid
	and #parent2.parentguid is null

	select * from ##results
	
END
GO
