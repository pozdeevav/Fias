--select * from FIAS.dbo.ADDROBJ where FORMALNAME = '���������' and ACTSTATUS = 1 and AOLEVEL = 7 and PARENTGUID = 'afff2611-ca9b-4e0e-9690-f5d13b7a7535'

--Select * from [FIAS].[dbo].ADDROBJ where FORMALNAME = '������������' and ACTSTATUS = 1 and AOGUID IN
--(SELECT PARENTGUID FROM [FIAS].[dbo].ADDROBJ where FORMALNAME = '�������������' and ACTSTATUS = 1 and AOGUID IN
--(SELECT PARENTGUID FROM [FIAS].[dbo].ADDROBJ WHERE FORMALNAME = '����� ����' and ACTSTATUS = 1 and AOGUID IN 
--(select PARENTGUID from FIAS.dbo.ADDROBJ where FORMALNAME = '���������' and ACTSTATUS = 1 and AOLEVEL = 7)))

Select * from [FIAS].[dbo].ADDROBJ where Contains (FORMALNAME, '"���������"') and ACTSTATUS = 1 and PARENTGUID IN (select AOGUID from [FIAS].[dbo].[ADDROBJ] where freetext (FORMALNAME, '"����� ����� ����"') and ACTSTATUS = 1)

SELECT * FROM [FIAS].[dbo].ADDROBJ where FREETEXT (FORMALNAME, '����� ����� ����') and ACTSTATUS = 1 and PARENTGUID IN (select AOGUID from [FIAS].[dbo].[ADDROBJ] where FREETEXT (FORMALNAME, '������������� �����') and ACTSTATUS = 1)

SELECT * FROM [FIAS].[dbo].ADDROBJ WHERE FREETEXT (FORMALNAME, '������������� �����') and ACTSTATUS = 1 and PARENTGUID IN (select AOGUID from [FIAS].[dbo].[ADDROBJ] where FREETEXT (FORMALNAME, '������������ ���') and ACTSTATUS = 1)

select * from FIAS.dbo.ADDROBJ where FREETEXT (FORMALNAME, '������������') and ACTSTATUS = 1 and AOLEVEL = 1