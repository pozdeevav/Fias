USE [FIAS]
GO
/****** Object:  StoredProcedure [dbo].[GETFTINFO]    Script Date: 21.05.2020 14:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GETFTINFO] 
	-- Add the parameters for the stored procedure here
	@query nvarchar(max)
	--@parent2 nvarchar(50),
	--@parent3 nvarchar(50)
AS

DECLARE @i INT
DECLARE @guid nvarchar(max)
--CREATE TABLE ##results (aoguid nvarchar(max), FORMALNAME nvarchar(max))
CREATE TABLE #info (AOID nvarchar(max),
      AOGUID nvarchar(max),
      PARENTGUID nvarchar(max),
      PREVID nvarchar(max),
      NEXTID nvarchar(max),
      FORMALNAME nvarchar(max),
      OFFNAME nvarchar(max),
      SHORTNAME nvarchar(max),
      AOLEVEL int,
      REGIONCODE int,
      AREACODE int,
      AUTOCODE int,
      CITYCODE int,
      CTARCODE int,
      PLACECODE int,
      PLANCODE int,
      STREETCODE int,
      EXTRCODE int,
      SEXTCODE int,
      PLAINCODE bigint,
      CODE float,
      CURRSTATUS int,
      ACTSTATUS int,
      LIVESTATUS int,
      CENTSTATUS int,
      OPERSTATUS int,
      IFNSFL int,
      IFNSUL int,
      OKATO bigint,
      OKTMO bigint,
      POSTALCODE int,
      STARTDATE date,
      ENDDATE date,
      UPDATEDATE date,
      DIVTYPE int,
      NORMDOC nvarchar(max),
      TERRIFNSFL int,
      TERRIFNSUL int)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @guid = (select aoguid from ##results where ##results.fullname = @query)
	
	select 
	ADDROBJ.AOGUID,
      ADDROBJ.PARENTGUID,
      ADDROBJ.PREVID,
      ADDROBJ.NEXTID,
	  ##results.fullname AS 'FORMALNAME',
      ADDROBJ.OFFNAME,
      ADDROBJ.SHORTNAME,
      ADDROBJ.AOLEVEL,
      REGIONCODE,
      AREACODE,
      AUTOCODE,
      CITYCODE,
      CTARCODE,
      PLACECODE,
      PLANCODE,
      STREETCODE,
      EXTRCODE,
      SEXTCODE,
      PLAINCODE,
      CODE,
      CURRSTATUS,
      ACTSTATUS,
      LIVESTATUS,
      CENTSTATUS,
      OPERSTATUS,
      IFNSFL,
      IFNSUL,
      OKATO,
      OKTMO,
      POSTALCODE,
      STARTDATE,
      ENDDATE,
      UPDATEDATE,
      DIVTYPE,
      NORMDOC,
      TERRIFNSFL,
      TERRIFNSUL from ##results, ADDROBJ where ##results.aoguid = @guid and ADDROBJ.AOGUID = @guid and LIVESTATUS = 1;  

END
