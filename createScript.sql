use master
go
create database CSProject
go
use CSProject
go
create table Users(
	[username] nvarchar(200) primary key,
	[password] nvarchar(max) not null,
	isAdmin bit not null,
	usedQuota bigint,
	maxQuota bigint
)

create table Items(
	id int identity (1,1) primary key,
	name nvarchar(max) not null,
	[owner] nvarchar(200) foreign key references Users(username),
	isPublic bit,
	isFolder bit,
	[size] bigint,
	parent int null	
)
alter table Items add foreign key(parent) references Items(id)

create table [Permits](
	itemID int foreign key references Items(id),
	username nvarchar(200) foreign key references Users(username)
)

create table [SyncFolder](
	id int identity(1,1) primary key,
	item int foreign key references Items(id),
	username nvarchar(200) foreign key references Users(username)
)