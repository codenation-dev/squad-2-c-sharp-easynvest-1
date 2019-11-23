--create database CENTRAL_ERROS
--go

create table USUARIO (
	ID_USUARIO int not null identity primary key,
	EMAIL varchar(200) not null,
	NOME varchar(200) not null,
	SENHA varchar(50) not null,
	TOKEN varchar(40) not null
)

create table AMBIENTE (
	ID_AMBIENTE int not null identity primary key,
	DE_AMBIENTE varchar(20) not null
)

create table NIVEL (
	ID_NIVEL int not null identity primary key,
	DE_NIVEL varchar(20) not null
)

create table SITUACAO (
	ID_SITUACAO int not null identity primary key,
	DE_SITUACAO varchar(20) not null
)

create table ERRO (
	ID_ERRO int not null identity primary key,
	ID_AMBIENTE int not null,
	ID_NIVEL int not null,
	ID_SITUACAO int not null,
	TITULO varchar(200) not null
)

ALTER TABLE ERRO
   ADD CONSTRAINT FK_ERRO_AMBIENTE FOREIGN KEY (ID_AMBIENTE)
      REFERENCES AMBIENTE (ID_AMBIENTE)

ALTER TABLE ERRO
   ADD CONSTRAINT FK_ERRO_NIVEL FOREIGN KEY (ID_NIVEL)
      REFERENCES NIVEL (ID_NIVEL)

ALTER TABLE ERRO
   ADD CONSTRAINT FK_ERRO_SITUACAO FOREIGN KEY (ID_SITUACAO)
      REFERENCES SITUACAO (ID_SITUACAO)
	  
create table OCORRENCIA_ERRO (
	ID_OCORRENCIA_ERRO int not null identity primary key,
	ID_ERRO int not null,
	ORIGEM varchar(200) not null,
	DETALHES varchar(2000) not null,
	DTHR_OCORRENCIA datetime not null,
	TOKEN_USUARIO varchar(40)
	--ID_USUARIO int --substituiria o TOKEN_USUARIO
)

ALTER TABLE OCORRENCIA_ERRO
   ADD CONSTRAINT FK_OCORRENCIA_ERRO_ERRO FOREIGN KEY (ID_ERRO)
      REFERENCES ERRO (ID_ERRO)

--ALTER TABLE OCORRENCIA_ERRO
--   ADD CONSTRAINT FK_OCORRENCIA_ERRO_USUARIO FOREIGN KEY (ID_USUARIO)
--      REFERENCES USUARIO (ID_USUARIO)

--inserir valores
insert into AMBIENTE values ('Produção')
insert into AMBIENTE values ('Homologação')
insert into AMBIENTE values ('Desenvolvimento')

insert into NIVEL values ('Erro')
insert into NIVEL values ('Alerta')
insert into NIVEL values ('Depuração')

insert into SITUACAO values ('Cadastrado')
insert into SITUACAO values ('Em Análise')
insert into SITUACAO values ('Resolvido')
insert into SITUACAO values ('Arquivado')
insert into SITUACAO values ('Apagado (Inativo)')
