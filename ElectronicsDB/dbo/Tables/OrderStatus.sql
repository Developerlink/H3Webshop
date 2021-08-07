CREATE TABLE OrderStatus (
 Id int primary key identity(1,1) not null,
 Name nvarchar(50) unique not null
);