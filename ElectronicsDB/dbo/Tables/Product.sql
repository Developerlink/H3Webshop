CREATE TABLE Product (
 Id int primary key identity(1,1) not null,
 ProductTypeId int not null,
 Name nvarchar(255) not null,
 Description text,
 Price decimal not null,
 CreateDate datetime2 default getdate(),
 EditDate datetime2,
 Foreign key (ProductTypeId) references ProductType(Id)
);
