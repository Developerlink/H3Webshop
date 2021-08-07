CREATE TABLE Department (
 Id int primary key identity(1,1) not null,
 StoreId int not null,
 Name nvarchar(50) not null,
 foreign key (StoreId) references Store(Id)
);
