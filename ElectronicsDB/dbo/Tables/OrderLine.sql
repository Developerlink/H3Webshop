CREATE TABLE OrderLine (
 SalesOrderId int,
 ProductId int,
 Price decimal,
 Quantity smallint,
 foreign key (SalesOrderId) references SalesOrder(Id),
 foreign key (ProductId) references Product(Id),
 constraint Pk_OrderLine primary key(SalesOrderId, ProductId)
);
