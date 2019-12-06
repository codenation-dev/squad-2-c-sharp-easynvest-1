create database CentralDeErros
go

use CentralDeErros
go

create table dbo.[USER] (
	ID int not null identity primary key,
	EMAIL varchar(200) not null,
	NAME varchar(200) not null,
	PASSWORD varchar(50) not null,
	TOKEN varchar(40) not null
)

create table ENVIRONMENT(
	ID int not null identity primary key,
	ENVIRONMENT varchar(30) not null
)

create table LEVEL (
	ID int not null identity primary key,
	LEVEL varchar(30) not null
)

create table SITUATION (
	ID int not null identity primary key,
	SITUATION varchar(30) not null
)

create table ERROR (
	ID int not null identity primary key,
	CODE int not null,
	TITLE varchar(200) not null,
	DESCRIPTION varchar(200) not null,
	ENVIRONMENTID int not null,
	LEVELID int not null,
	SITUATIONID int not null
)

ALTER TABLE ERROR
   ADD CONSTRAINT FK_ERROR_ENVIRONMENT FOREIGN KEY (ENVIRONMENTID)
      REFERENCES ENVIRONMENT (ID)

ALTER TABLE ERROR
   ADD CONSTRAINT FK_ERROR_LEVEL FOREIGN KEY (LEVELID)
      REFERENCES LEVEL (ID)

ALTER TABLE ERROR
   ADD CONSTRAINT FK_ERROR_SITUATION FOREIGN KEY (SITUATIONID)
      REFERENCES SITUATION (ID)
	  
create table ERROR_OCCURRENCE (
	ID int not null identity primary key,
	ORIGIN varchar(200) not null,
	DETAILS varchar(2000) not null,
	DATE_TIME datetime not null,
	USERID int not null,
	ERRORID int not null
)

ALTER TABLE ERROR_OCCURRENCE
   ADD CONSTRAINT FK_ERROR_OCCURRENCE_ERROR FOREIGN KEY (ERRORID)
      REFERENCES ERROR (ID)

ALTER TABLE ERROR_OCCURRENCE
   ADD CONSTRAINT FK_ERROR_OCCURRENCE_USER FOREIGN KEY (USERID)
      REFERENCES dbo.[USER] (ID)

