if not exists (select 'x' from dbo.[USER] where EMAIL = 'lilia@gmail.com.br')
begin
	insert into dbo.[USER] (EMAIL, NAME, PASSWORD, TOKEN, EXPIRATION) values ('lilia@gmail.com.br', 'Lilia Gomes de Matos', '1234', '', '19000101')
end
if not exists (select 'x' from dbo.[USER] where EMAIL = 'julia@gmail.com.br')
begin
	insert into dbo.[USER] (EMAIL, NAME, PASSWORD, TOKEN, EXPIRATION) values ('julia@gmail.com.br', 'Julia Alves de Gois', '1234', '', '19000101')
end
if not exists (select 'x' from dbo.[USER] where EMAIL = 'ana@gmail.com.br')
begin
	insert into dbo.[USER] (EMAIL, NAME, PASSWORD, TOKEN, EXPIRATION) values ('ana@gmail.com.br', 'Ana Paula Silva de Souza', '1234', '', '19000101')
end
if not exists (select 'x' from dbo.[USER] where EMAIL = 'jessica@gmail.com.br')
begin
	insert into dbo.[USER] (EMAIL, NAME, PASSWORD, TOKEN, EXPIRATION) values ('jessica@gmail.com.br', 'Jessica Nascimento Santana', '1234', '', '19000101')
end
if not exists (select 'x' from dbo.[USER] where EMAIL = 'leticia@gmail.com.br')
begin
	insert into dbo.[USER] (EMAIL, NAME, PASSWORD, TOKEN, EXPIRATION) values ('leticia@gmail.com.br', 'Letícia Leandro Nunes Serpa', '1234', '', '19000101')
end

select * from dbo.[USER]