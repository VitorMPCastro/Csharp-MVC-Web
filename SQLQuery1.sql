create database BDContato
go
use BDContato
go

create table Contato
(
	IdContato int primary key identity,
	nome varchar(60) not null,
	email varchar(100) not null
)

insert into Contato (nome, email) values ('Fulano', 'fulano@email.com')
insert into Contato (nome, email) values ('Ciclano', 'ciclano@gmail.com')