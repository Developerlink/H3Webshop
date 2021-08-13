CREATE TABLE StoreProduct (
 StoreId int not null,
 ProductId int not null,
 Quantity int not null,
 foreign key (StoreId) references Store(Id),
 foreign key (ProductId) references Product(Id),
 constraint Pk_StoreProduct primary key(StoreId, ProductId)
);