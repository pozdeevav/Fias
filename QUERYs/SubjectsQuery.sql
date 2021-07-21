select * from ADDROBJ where ACTSTATUS = 1 and (SHORTNAME = 'край' or SHORTNAME = 'обл' 
or SHORTNAME = 'Респ' or SHORTNAME = 'Чувашия' or SHORTNAME = 'АО' or SHORTNAME = 'Аобл')
or (FORMALNAME = 'Байконур' and SHORTNAME = 'г' and ACTSTATUS = 1) 
or (FORMALNAME = 'Севастополь' and SHORTNAME = 'г' and ACTSTATUS = 1)