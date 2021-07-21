--select * from FIAS.dbo.ADDROBJ where FORMALNAME = 'Уральская' and ACTSTATUS = 1 and AOLEVEL = 7 and PARENTGUID = 'afff2611-ca9b-4e0e-9690-f5d13b7a7535'

--Select * from [FIAS].[dbo].ADDROBJ where FORMALNAME = 'Свердловская' and ACTSTATUS = 1 and AOGUID IN
--(SELECT PARENTGUID FROM [FIAS].[dbo].ADDROBJ where FORMALNAME = 'Новолялинский' and ACTSTATUS = 1 and AOGUID IN
--(SELECT PARENTGUID FROM [FIAS].[dbo].ADDROBJ WHERE FORMALNAME = 'Новая Ляля' and ACTSTATUS = 1 and AOGUID IN 
--(select PARENTGUID from FIAS.dbo.ADDROBJ where FORMALNAME = 'Уральская' and ACTSTATUS = 1 and AOLEVEL = 7)))

Select * from [FIAS].[dbo].ADDROBJ where Contains (FORMALNAME, '"Уральская"') and ACTSTATUS = 1 and PARENTGUID IN (select AOGUID from [FIAS].[dbo].[ADDROBJ] where freetext (FORMALNAME, '"город Новая Ляля"') and ACTSTATUS = 1)

SELECT * FROM [FIAS].[dbo].ADDROBJ where FREETEXT (FORMALNAME, 'город Новая Ляля') and ACTSTATUS = 1 and PARENTGUID IN (select AOGUID from [FIAS].[dbo].[ADDROBJ] where FREETEXT (FORMALNAME, 'Новолялинский район') and ACTSTATUS = 1)

SELECT * FROM [FIAS].[dbo].ADDROBJ WHERE FREETEXT (FORMALNAME, 'Новолялинский район') and ACTSTATUS = 1 and PARENTGUID IN (select AOGUID from [FIAS].[dbo].[ADDROBJ] where FREETEXT (FORMALNAME, 'Свердловская обл') and ACTSTATUS = 1)

select * from FIAS.dbo.ADDROBJ where FREETEXT (FORMALNAME, 'Свердловская') and ACTSTATUS = 1 and AOLEVEL = 1