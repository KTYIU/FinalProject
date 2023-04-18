create database FinalProjectDataSet

use FinalProjectDataSet

create table Teachers(
id int IDENTITY(1,1) primary key,
_name varchar(100),
email varchar(100),
password varchar(12)
)

create table Assignments(
id int IDENTITY(1,1) primary key, 
subject varchar(100),
_name varchar(100),
class varchar(100),
dueDate date
)

insert into Teachers
values( 'Chaikovska','e.chaikovska@gmail.com','lalala');

select * from Teachers, Assignments;

insert into Assignments
values('Math', 'Homework 1', '11/3', '2023-09-20')