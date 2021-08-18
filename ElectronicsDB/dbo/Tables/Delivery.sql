CREATE TABLE Delivery (
 SalesOrderId int unique not null,
 CustomerId int not null,
 PostalCodeId int not null,
 Address nvarchar(100),
 SendDate datetime2,
 foreign key (SalesOrderId) references SalesOrder(Id),
 foreign key (PostalCodeId) references PostalCode(PostalCodeId),
 foreign key (CustomerId) references Customer(Id),
 constraint Pk_Delivery primary key(SalesOrderId)
);
