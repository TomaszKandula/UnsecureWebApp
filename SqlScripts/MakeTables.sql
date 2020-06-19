
create table Users
(
	Id				int identity(1, 1) primary key not null,
	EmailAddress	nvarchar(255) not null,
	HashedPassword	varchar(255) not null
)

insert into Users (EmailAddress,HashedPassword) values
('jonny@example.com','password1234'),
('bravo@example.com','admin2020')

create table Laptops
(
	Id			int identity(1, 1) primary key not null,
	Brand		varchar(50) not null,
	SerialNo	varchar(255) not null,
	UserId		int foreign key references Users (Id) not null
)

insert into Laptops (Brand,SerialNo,UserId) values
('Lenovo','C02L456987',1),
('Dell','123AB458GH',2),
('HP','PO54654PUXR',2)
