create database araçkira;

create table Users(
id int identity (0,1) primary key,
name  nvarchar(100)  null,
surname nvarchar(100) null,
password nvarchar(100)  null,
email nvarchar(100)  null,
telephone numeric(18,0)  null
)