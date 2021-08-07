CREATE TABLE Customer (
 Id int primary key identity(1,1) not null,
 PostalCodeId int not null,
 FirstName nvarchar(50) not null,
 LastName nvarchar(50) not null,
 EmailAddress nvarchar(150) unique not null,
 PhoneNumber nvarchar(50) not null,
 Address nvarchar(100) not null
 foreign key (PostalCodeId) references PostalCode(PostalCodeId)
);