CREATE TABLE SalesOrder (
 Id int primary key identity(1,1) not null,
 StoreId int,
 OrderStatusId int,
 OrderDate datetime2,
 foreign key(StoreId) references Store(Id),
 foreign key(OrderStatusId) references OrderStatus(Id)
);