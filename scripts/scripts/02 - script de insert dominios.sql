--inserir valores ambiente
if not exists (select 'x' from ENVIRONMENT where ENVIRONMENT = 'Produção')
begin
	insert into ENVIRONMENT (ENVIRONMENT) values ('Produção')
end
if not exists (select 'x' from ENVIRONMENT where ENVIRONMENT = 'Homologação')
begin
	insert into ENVIRONMENT (ENVIRONMENT) values ('Homologação')
end
if not exists (select 'x' from ENVIRONMENT where ENVIRONMENT = 'Desenvolvimento')
begin
	insert into ENVIRONMENT (ENVIRONMENT) values ('Desenvolvimento')
end

--inserir valores nivel
if not exists (select 'x' from LEVEL where LEVEL = 'Fatal')
begin
	insert into LEVEL (LEVEL) values ('Fatal')
end
if not exists (select 'x' from LEVEL where LEVEL = 'Error')
begin
	insert into LEVEL (LEVEL) values ('Error')
end
if not exists (select 'x' from LEVEL where LEVEL = 'Warn')
begin
	insert into LEVEL (LEVEL) values ('Warn')
end
if not exists (select 'x' from LEVEL where LEVEL = 'Info')
begin
	insert into LEVEL (LEVEL) values ('Info')
end
if not exists (select 'x' from LEVEL where LEVEL = 'Debug')
begin
	insert into LEVEL (LEVEL) values ('Debug')
end
if not exists (select 'x' from LEVEL where LEVEL = 'Trace')
begin
	insert into LEVEL (LEVEL) values ('Trace')
end

--inserir valores situação
if not exists (select 'x' from SITUATION where SITUATION = 'Arquivado')
begin
	insert into SITUATION (SITUATION) values ('Arquivado')
end
if not exists (select 'x' from SITUATION where SITUATION = 'Apagado (Inativo)')
begin
	insert into SITUATION (SITUATION) values ('Apagado (Inativo)')
end