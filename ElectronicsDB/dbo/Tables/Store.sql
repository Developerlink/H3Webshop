CREATE TABLE Store (
 Id int primary key identity(1,1) not null,
 PostalCodeId int not null,
 Address nvarchar(100) not null,
 Name nvarchar(100) not null,
 foreign key(PostalCodeId) references PostalCode(PostalCodeId)
);

