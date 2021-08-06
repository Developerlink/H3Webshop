CREATE DATABASE ElectronicsDB

CREATE TABLE OrderStatus (
 Id int primary key identity(1,1) not null,
 Name nvarchar(50) unique not null
);

CREATE TABLE ProductType (
 Id int primary key identity(1,1) not null,
 Name nvarchar(150) unique not null
);

CREATE TABLE PostalCode (
 PostalCodeId int primary key identity(1,1) not null,
 AreaName nvarchar(50) not null
);



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

CREATE TABLE Product (
 Id int primary key identity(1,1) not null,
 ProductCategoryId int not null,
 Name nvarchar(255) not null,
 Description text,
 Price decimal not null,
 CreateDate datetime2 default getdate(),
 EditDate datetime2,
);

CREATE TABLE Store (
 Id int primary key identity(1,1) not null,
 PostalCodeId int not null,
 Address nvarchar(100) not null,
 Name nvarchar(100) not null,
 foreign key(PostalCodeId) references PostalCode(PostalCodeId)
);



CREATE TABLE Department (
 Id int primary key identity(1,1) not null,
 StoreId int not null,
 Name nvarchar(50) not null,
 foreign key (StoreId) references Store(Id)
);

CREATE TABLE Employee (
 Id int primary key identity(1,1) not null,
 PostalCodeId int not null,
 FirstName nvarchar(50) not null,
 LastName nvarchar(50) not null,
 EmailAddress nvarchar(150) unique not null,
 PhoneNumber nvarchar(50) not null,
 WorkStartDate datetime,
 WorkEndDate datetime,
 IsActive bit not null,
 Address nvarchar(100) not null,
 foreign key (PostalCodeId) references PostalCode(PostalCodeID)
);

CREATE TABLE StoreProduct (
 StoreId int not null,
 ProductId int not null,
 Quantity int not null,
 foreign key (StoreId) references Store(Id),
 foreign key (ProductId) references Product(Id)
);



CREATE TABLE SalesOrder (
 Id int primary key identity(1,1) not null,
 StoreId int,
 OrderStatusId int,
 OrderDate datetime2,
 foreign key(StoreId) references Store(Id),
 foreign key(OrderStatusId) references OrderStatus(Id)
);

CREATE TABLE OrderLine (
 SalesOrderId int,
 ProductId int,
 Price decimal,
 Quantity smallint,
 foreign key (SalesOrderId) references SalesOrder(Id),
 foreign key (ProductId) references Product(Id)
);

CREATE TABLE Delivery (
 SalesOrderId int,
 CustomerId int,
 PostalCodeId int,
 Address nvarchar(100),
 SendDate datetime2,
 foreign key (SalesOrderId) references SalesOrder(Id),
 foreign key (PostalCodeId) references PostalCode(PostalCodeId),
 foreign key (CustomerId) references Customer(Id)
);



alter table delivery
add CustomerId int not null,
foreign key (CustomerId) references Customer(Id)

alter table salesorder
add StoreId int not null,
foreign key (StoreId) references Store(Id)

alter table salesorder
drop constraint [FK__SalesOrde__Custo__412EB0B6]

alter table salesorder
drop column CustomerId



// 1-8
insert into OrderStatus 
values 
('Pending'),
('Processing'),
('Ready for packaging'),
('Ready to deliver'),
('Delivery in progress'),
('Received'),
('Returned'),
('Not delivered')

// 1-11
insert into ProductType 
values 
('PC & Tablets'),
('Gaming'),
('TV & Screen'),
('Sound & Hi-Fi'),
('Mobile phones'),
('Kitchenware'),
('Appliances'),
('Accessories'),
('Chargers & Cables'),
('Other')



INSERT INTO Customer([PostalCodeId],[FirstName],[LastName],[EmailAddress],[PhoneNumber],[Address]) 
VALUES('5000','Michael','Soto','Vebqot20@maiy.jom','38963540','Zuefuxstreet 27'),('5000','Bree','Hartman','Puyoeq29@maib.bom','75867651','Meqfojstreet 92'),
('5000','Carter','Mason','Lucniy47@maie.jom','09500516','Lefioestreet 85'),('5000','Genevieve','Benson','Aaktik31@mais.pom','17914518','Xishaustreet 66'),
('5000','Salvador','Fields','Voasoc26@maiz.wom','62879034','Zuawimstreet 80'),('5000','Connor','Singleton','Favzah38@maih.yom','35527609','Uepwakstreet 26'),
('5000','Winifred','Albert','Uehkuo01@main.xom','07031314','Sarnoustreet 00'),('5000','Travis','Schmidt','Xibauq55@maiy.hom','44750137','Oeqlegstreet 78'),
('5000','Jenna','Fulton','Vexliu53@maid.qom','88988853','Bitwegstreet 11'),('5000','Reagan','Hudson','Ouelul87@maic.gom','92008326','Koktoastreet 39'),
('5000','Jena','Foster','Gihxaa86@maic.tom','00670527','Joqpiistreet 19'),('5000','Delilah','Hughes','Wilvim88@maiq.pom','70518635','Mimciestreet 19'),
('5000','Lysandra','Morin','Ziweed89@maip.qom','00234442','Vabriestreet 73'),('5000','Brian','Dotson','Podsez55@main.jom','47340219','Heliiestreet 11'),
('5000','Aline','Erickson','Riueau15@main.yom','33774265','Uiudoostreet 89'),('5000','Germane','Prince','Qabtou40@maif.xom','25737941','Easzecstreet 05'),
('5000','Bruno','Robinson','Wewmaw80@mait.bom','24162595','Aiguaestreet 82'),('5000','Jonah','Hall','Iavnao24@maib.pom','32733441','Liqbezstreet 14'),
('5000','Leroy','Jacobs','Kazvon86@maii.lom','84203164','Lioooastreet 32'),('5000','Erin','Vega','Hennux46@maid.jom','46203905','Doqquvstreet 25'),
('5000','Laura','Burris','Qojfez76@maij.som','25242431','Wadwomstreet 82'),('5000','Denton','Mcdaniel','Busjuy55@maid.dom','52231493','Uuqqoostreet 41'),
('5000','Upton','Holt','Cosuar04@mair.vom','15319532','Nakguistreet 23'),('5000','Brandon','Ryan','Hoyqox64@maif.lom','61588062','Zalmimstreet 35'),
('5000','Astra','Curtis','Aazkan40@maik.lom','77693280','Qizqeystreet 87'),('5000','Ruby','Cross','Ougjam02@maiy.zom','78210808','Aonpaxstreet 67'),
('5000','Lydia','Buchanan','Sievow61@maiy.rom','77873817','Iaqrabstreet 67'),('5000','Cadman','Dillard','Kozluz70@main.rom','13913238','Cakriwstreet 08');

INSERT INTO Customer([PostalCodeId],[FirstName],[LastName],[EmailAddress],[PhoneNumber],[Address]) 
VALUES('8000','Gregory','Vaughan','Cagwuy52@maix.kom','02014152','Racxilstreet 43'),('8000','Cally','Tanner','Peukoo26@maik.com','25680052','Duzriqstreet 09'),
('8000','Brenden','Frank','Yoanan49@maix.jom','66800127','Saauujstreet 49'),('8000','Courtney','Meyer','Oockit62@maiz.kom','51356351','Moccajstreet 88'),
('8000','Clarke','Mcdowell','Donmah16@mair.lom','41120549','Oiwuibstreet 69'),('8000','Dustin','Baxter','Fozmox55@mais.mom','17353268','Gagxojstreet 49'),
('8000','Cody','James','Eoicea87@maig.nom','56318444','Uaeiukstreet 67'),('8000','Barrett','Wiley','Taptej60@maie.fom','03690051','Iebwejstreet 19'),
('8000','Jameson','Rosales','Fangui28@maiu.gom','87517048','Biknuhstreet 81'),('8000','Xanthus','Moss','Qeavik08@maim.vom','77374173','Qocjimstreet 63'),
('8000','Merritt','Hawkins','Luvsid17@maix.hom','10683186','Niuvopstreet 83'),('8000','Quemby','Morrow','Hifyei50@mait.mom','55355165','Jeeluxstreet 39'),
('8000','Tara','Welch','Wocfoi26@maif.yom','28472455','Nokpilstreet 02'),('8000','Ignacia','Pierce','Goypoa00@maib.kom','54487192','Poekuestreet 58'),
('8000','Aaron','Reed','Xevuee19@main.som','68620857','Huavitstreet 15'),('8000','Lars','Cook','Biqhip39@maid.zom','53031416','Fintimstreet 12'),
('8000','Callie','Barnett','Quzbee08@maip.zom','42262930','Eukleqstreet 13'),('8000','India','Le','Kosnaj40@maip.wom','12636103','Aicrefstreet 84'),
('8000','Boris','Stone','Yahyii30@maih.kom','62926093','Havguvstreet 31'),('8000','Tatum','Osborne','Xoixim88@maib.hom','41220669','Yuiyiestreet 55'),
('8000','Sara','Oliver','Meocia85@maim.wom','45257455','Aumhusstreet 45'),('8000','Alice','Phelps','Nispif48@maid.fom','10445301','Zepvaestreet 15'),
('8000','Noble','Figueroa','Hugnem52@maiq.nom','42668208','Lofrahstreet 50'),('8000','Dara','Hayes','Wuaqiu91@maiu.jom','43893352','Gonvupstreet 32'),
('8000','Clio','Cunningham','Yamfai32@maix.xom','50411715','Rapdifstreet 31');

INSERT INTO Customer([PostalCodeId],[FirstName],[LastName],[EmailAddress],[PhoneNumber],[Address]) 
VALUES('1700','Genevieve','Forbes','Qugcia73@maiz.kom','30697925','Eoquetstreet 95'),('1700','Amity','Murphy','Himmuh72@maik.gom','14097232','Puqhazstreet 08'),
('1700','Cynthia','Stevens','Uuxwaq85@maiz.vom','03292548','Pogioxstreet 94'),('1700','Philip','Le','Iurvel12@maig.som','63358305','Oavjagstreet 15'),
('1700','Beatrice','Daniel','Xucteb66@maio.qom','31870947','Uithorstreet 01'),('1700','Boris','Little','Fagqim47@mais.bom','56792113','Oeliuqstreet 08'),
('1700','Cruz','Rivas','Carpea32@maiv.som','48637328','Auhwokstreet 73'),('1700','Kimberly','Love','Leylig35@maik.lom','86064113','Kunnukstreet 28'),
('1700','Lysandra','Mercado','Vaanom55@maii.lom','09230761','Pavloxstreet 67'),('1700','Lucy','Cunningham','Petyop57@maiz.zom','83973283','Tueuojstreet 89'),
('1700','Elijah','Zamora','Voivay38@maif.pom','08145940','Yebgeystreet 56'),('1700','Tatum','Williamson','Mixhoy22@maih.mom','60631618','Fejaumstreet 06'),
('1700','Flavia','Carpenter','Juvxoe79@mais.fom','81168642','Wotbelstreet 07'),('1700','Chancellor','Sparks','Lormai63@mait.wom','64407580','Dornudstreet 12'),
('1700','Kiona','Morton','Neqpud44@maiz.rom','39046718','Euzzocstreet 20'),('1700','Suki','Riddle','Eifkao63@maih.pom','55120374','Pummugstreet 08'),
('1700','Henry','Finch','Kultuq92@main.kom','49423428','Eecaifstreet 49'),('1700','Paul','Salinas','Tuloof73@maih.bom','19440328','Auuqofstreet 63'),
('1700','Clementine','Underwood','Pivdim26@maio.xom','48147769','Votuodstreet 34'),('1700','Kiayada','Hunt','Meznud30@maip.xom','42469442','Dosdegstreet 83'),
('1700','Clarke','Sparks','Genrua07@mait.xom','27775466','Veozuestreet 68'),('1700','Ferris','Cherry','Qaekeh94@maif.nom','20330099','Qinhusstreet 56'),
('1700','Janna','Vincent','Sarqoo37@maiy.xom','32716117','Eabjajstreet 57'),('1700','Sonya','Quinn','Pehdas39@maik.yom','82192103','Neggibstreet 73'),
('1700','Emery','Roberts','Oimjao96@maih.mom','07701889','Zadwefstreet 95'),('1700','Graiden','Calderon','Vunrot40@maio.com','86406655','Uevceistreet 59'),
('1700','Raven','Santos','Dodseg70@maik.gom','32486391','Yoozitstreet 65'),('1700','Quynn','Mclaughlin','Vetaou57@main.pom','09194976','Defeocstreet 50'),
('1700','Hamilton','Solis','Poeuih35@maif.dom','47336467','Eaceijstreet 81'),('1700','Lester','Berry','Uuyuan36@maih.yom','51554563','Iikladstreet 73'),
('1700','Francis','Jackson','Noqqai77@maip.dom','73744335','Dodsexstreet 03');

insert into Store 
Values 
(1700, 'Havnevej 100', 'Electronics Kbh V'),
(5000, 'Odensevej 30', 'Electronics Odense'),
(8000, 'Aarhusvej 50', 'Electronics Aarhus')












