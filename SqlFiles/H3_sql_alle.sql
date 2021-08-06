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


INSERT INTO Product([ProductCategoryId],[Name],[Description],[Price]) 
VALUES
(1,'IdeaPad Gaming 3i','Få den bedste spil- og esportsoplevelse med en pc, dine gamingvenner vil se langt efter. Den bærbare IdeaPad Gaming 3i-computer, der er udviklet med op til banebrydende 10. generation Intel® Core™ i7-processor, dedikeret NVIDIA®-grafik, op til 120 Hz FHD-skærm og et avanceret gamingtastatur, udstråler stille og skræmmende selvsikkerhed. Nyd tydelige billeder og glidende gaming på din vej til magten.',4088),
(1,'Vision W915 Workstation','Vision Workstation W915 er en stærk arbejdscomputer, der kan bruges til en meget bred vifte af professionelle opgaver. Uanset om du skal bruge en computer til musikproduktion, krævende kontoropgaver eller lettere billedredigering, er Vision Workstation W915 et rigtig godt valg.',6614),
(1,'Føniks Falcon III','Kraftfulde gaming monstre. Så simpelt kan vi beskrive Føniks Falcon Gamer serien. Der er fuld smæk på ydelsen, for Falcon maskinerne er designet til de seriøse gamere, der bruger rigtig mange timer foran skærmen - måske endda på konkurrence-niveau. Der er fokus på maksimal ydelse pr. krone, så du får den mest flydende oplevelse og de bedste odds for at vinde hver eneste kamp.',4861),
(1,'ACER ASPIRE XC-330','Aspire XC har et sofistikeret design og kraftig hardware til effektiv multitasking i hverdagen.',6488),
(1,'Vision Esport Ryzen','Vision Esport serien er målrettet foreninger, klubber, netcafeer og skoler med fokus på Esport. MM-Vision har siden 1999 været førende i Danmark indenfor sammensætning og produktion af computere. Vi er idag Danmarks største producent af computere. Sammen med anerkendte producenter som Asus og Corsair har vi udviklet dette esportskoncept.',8157),
(3,'SAMSUNG 82" UHD TV UE82TU8005','Ambient Mode – Lad dit TV smelte ind i din indretning, så du også kan nyde det slukketAuto Game Mode - Skifter automatisk over til hurtig gamingindstilling, når du bruger din spillekonsolOne Remote Control – En smartere fjernbetjening, som kan styre alle dine kompatible enheder',16930),
(3,'Samsung 43" Q60A QLED','SAMSUNG QE43Q60A QLED smart TV er det ideelle valg, hvis du vil have imponerende specifikationer, uden at dit tv dominerer stuen',8382),
(3,'LG 47" Full HD Signage monitor','Dette store 47” tv fra LG leverer billedet i formatforholdet på 16:9. Med en responstid på 11 millisekund, vil der ikke forekomme de store forsinkelser mellem billederne. Skærmen har en lysstyrke på hele 450 cd/m2, så du får det rette lys. LG 47LS35A-5B er designet specielt til alverdens forretningsmiljøer - Om det så er til lobbyen på hotellet, terminalen i lufthavnen eller som informationsskærm på kontoret.',7739),
(3,'Philips 58PUS7805/12 58" 4K UHD LED Smart TV','Opdag helt nye dimensioner med Alexa og Ambilight. 4K HDR Smart LED-TV Føj nye dimensioner til din TV-oplevelse. Dette Philips Smart TV leveres med Alexa, så du kan styre det med din stemme. Ambilight sætter stemningen for film, musik eller spil. Billedkvaliteten er lige så fantastisk som det indhold, du ser.',14665),
(3,'SHARP 50" UHD TV 50BL3EA','Google Assistant og Android Smart TV platform Med Android Smart TV får man indbygget Chromecast funktion i TVet som gør det let og caste fra en mobil eller tablet direkte til TVet. Google Assistant kobler dit TV sammen med alle andre Google produkter. Der er adgang til alle apps der kan findes på Google Play Store inklusiv Netflix, HBO Nordic, Youtube, Amazon Prime, TV2 Play og mange flere.',5788),
(5,'Xiaomi Mi 11i 5G','Med Xiaomi Mi 11i 5G får du hele pakken. Du betaler bare kun for halvdelen af pakken. Xiaomi Mi 11i er nemlig alt det, du kan forvente af en moderne smartphone i flagskibsklassen. Prisen er bare en helt anden, end du er vant til.',5190),
(5,'Blackview BV6300 Pro Grøn','Blackview BV6300 Pro er en vandtæt IP68-telefon med Android 10-operativsystem, 4380mAh batteri med lang levetid og desuden 4 bagkameraer. En af det mest anerkendte funktioner ved denne telefon, er dens slanke og kompakte design. Dette er en holdbar og robust telefon til dig, der ønsker en mobil, som ikke vejer for meget eller er for stor i hånden. Tykkelsen er kun 12,8 mm på den tykkeste del af telefonen, hvilket er ret tyndt i forhold til andre holdbare telefoner på markedet. Android 10 kombineret med et batteri på 4380 mAH giver Blackview BV6300 Pro en rigtig god levetid. De fire kameraer bagpå, sikrer billeder i høj kvalitet! Telefonen har også en del skarpe komponenter, der giver mulighed for nemt at køre de fleste tunge apps og programmer. For dem af jer, som ofte er på farten og kan lide at bruge telefonen til navigation, understøtter denne mobil også hele 3 forskellige positioneringsteknologier (GPS, GLONASS, Beidou). BV6300 Pro har også et 3,5 mm jackstik, som er noget, der efterhånden mangler på mange holdbare telefoner. Hvis du leder efter en kompakt og let telefon, kan Blackview BV6300 Pro varmt anbefales!',2983),
(5,'Samsung Galaxy A52 5G 128GB/6GB - Black','On the next-generation mobile data network, the power of 5G fast speeds changes the way you experience and share content - from super-smooth gaming and streaming, to ultrafast sharing and downloading. Upgrade to the Galaxy A52 5G and speed up your smartphone experience.',3035),
(5,'GOOGLE PIXEL 4A - 128GB - BARE SORT','Tag overdådige billeder med Google Pixel 4A. Det ikoniske design, de regelmæssige softwareopdateringer og den kraftfulde 12 MP sensor udgør den ideelle enhed. Telefonen kommer også med et fremragende batteri med hurtig opladningsteknologi, så du trygt kan bruge din telefon hele dagen.',3290),
(5,'Apple iPhone 12, 128GB, sort','Apple iPhone 12 er fremstillet med en 6,1” Super Retina XDR-skærm fra kant til kant, der er omfavnet af stærke aluminiumskanter i flykvalitet, samt Ceramic Shield, der har fire gange bedre beskyttelse, hvis du taber din telefon. Med det dobbelt­kamera-system med ultravidvinkel kan du indfange mere af alt det, du godt kan lide. Tag billeder i vidvinkel og ultravidvinkel. Optag og redigér video i den højeste kvalitet i en smartphone. iPhone 12 optager fantastisk skarp 4K-video med 60 billeder pr. sekund på alle kameraerne. Så nu skal du virkelig gøre dig umage for at tage et dårligt billede.',9746),
(7,'Scandomestic Back Bar køler 158 ltr sort','Back Bar køler med 2 selvlukkende skydedøre, udvendig håndtag og indvendigt LED lys.',25087),
(7,'Everglades EVUD4030','Funktionelt køle- og fryseskab fra Everglades, som er udstyret med en indbygget vanddispenser, så du altid kan servicere dig selv eller dine gæster med et koldt glas vand. Køleskabet har en kapacitet på 196 liter, mens fryseren kan rumme op til 66 liter. Desuden er det fritstående med et lavt støjniveau på 40 dB. Det kombinerede køle-/fryseskab er udført i et matsort design, som ser moderne og stilrent ud. Derudover er det muligt at flytte på de medfølgende hylder og skuffer, så du kan arrangere dem på den mest hensigtsmæssige måde for dig. Køle- og fryseskabet har desuden en vendbar dør, og ved strømsvigt opbevares indholdet sikkert i op til 15 timer efter.',16965),
(7,'Køleskab R 600L SS','Stort professionelt køleskab 600 liter med rustfrit stålhus, lås og fire justerbare hylder. Digital temperaturregulering.',9922),
(7,'Samsung RS6HA8891B1-EG','Samsung RS6HA8891B1-EG er et fritstående køle-/fryseskab der kan give dit køkken et unikt look. Da dette køle-/fryseskab er fritstående, er du ikke bundet til at det skal være i et køkkenskab, det betyder også at det ikke behøver at være en bestemt størrelse som giver dig mere frihed i forhold til plads. Med dens funktioner hjælper det dig med at holde alle dine madvarer friske i længere tid.',24692),
(7,'Candy CVBNM6182WH89 fritstående kølefryseskab','Dette Candy kølefryseskab er velegnet til opbevaring af dine mad- og drikkevarer. Den har en køle volumen på 231 liter og hele 87 liter frost volumen. Selve kølefryseskab har klimaklasse SN-N-ST-T og opnået energiklassen A+.',17434);

INSERT INTO StoreProduct([StoreId],[ProductId],[Quantity]) 
VALUES
(1,1,7),(1,2,15),(1,3,13),(1,4,4),(1,5,11),(1,6,11),(1,7,5),(1,8,11),(1,9,16),(1,10,20),(1,11,18),(1,12,2),(1,13,14),(1,14,3),(1,15,16),(1,16,17),(1,17,5),(1,18,0),(1,19,8),(1,20,9),
(2,1,1),(2,2,11),(2,3,9),(2,4,3),(2,5,14),(2,6,0),(2,7,16),(2,8,9),(2,9,1),(2,10,19),(2,11,4),(2,12,13),(2,13,14),(2,14,15),(2,15,11),(2,16,6),(2,17,0),(2,18,3),(2,19,6),(2,20,20),
(3,1,17),(3,2,8),(3,3,0),(3,4,17),(3,5,11),(3,6,0),(3,7,0),(3,8,3),(3,9,18),(3,10,11),(3,11,14),(3,12,2),(3,13,11),(3,14,13),(3,15,10),(3,16,10),(3,17,20),(3,18,7),(3,19,1),(3,20,12);

INSERT INTO Department([StoreId],[Name]) 
VALUES
(1,'Purchasing'),
(1,'Accounting & Finance'),
(1,'Human Resources'),
(1,'Logistics'),
(1,'Executive'),
(1,'Marketing'),
(1,'IT'),
(2,'Purchasing'),
(2,'Accounting & Finance'),
(2,'Human Resources'),
(2,'Logistics'),
(2,'Executive'),
(2,'Marketing'),
(2,'IT'),
(3,'Purchasing'),
(3,'Accounting & Finance'),
(3,'Human Resources'),
(3,'Logistics'),
(3,'Executive'),
(3,'Marketing'),
(3,'IT');

INSERT INTO Employee([PostalCodeId],[FirstName],[LastName],[EmailAddress],[PhoneNumber],[Address],[WorkStartDate],[IsActive],[DepartmentId]) 
VALUES
('1700','Joelle','Cervantes','Dusyuh33@maiu.vom','10028817','Aahiaqstreet 77',' 2022-05-01',1,1),('1700','Kieran','Howell','Kienom61@maio.bom','66844070','Pedtabstreet 47',' 2021-08-02',1,1),
('1700','Carter','Boyle','Zogjur59@maij.pom','41096912','Firfeestreet 05',' 2022-05-14',1,2),('1700','Quinn','Merrill','Eeewuw47@maii.dom','19384923','Cuwiugstreet 37',' 2021-08-26',1,2),('1700','Whoopi','Shannon','Buhriu36@maii.yom','60987131','Lernafstreet 13',' 2021-12-29',1,2),('1700','Salvador','Conley','Rulfic22@maiu.nom','21909089','Caayiwstreet 41',' 2021-04-20',1,2),
('1700','Lesley','Mcmahon','Sipjis78@maig.lom','69521441','Vixbodstreet 85',' 2021-05-20',1,3),('1700','Tucker','Foreman','Roigig09@maia.bom','94947558','Tihuoqstreet 83',' 2022-07-05',1,3),('1700','Dacey','Charles','Porvay59@maix.vom','54470965','Larfamstreet 79',' 2022-06-21',1,3),('1700','Darryl','Gibson','Kazaad87@maig.kom','77405903','Loyiutstreet 60',' 2020-08-05',1,3),
('1700','Vance','Lamb','Sagueq03@mait.zom','30475562','Woqvacstreet 97',' 2022-04-25',1,4),('1700','Genevieve','Hamilton','Tuitom37@maip.fom','03664833','Sickoustreet 30',' 2021-02-09',1,4),
('1700','Anika','Collier','Bucvuy11@maiw.vom','57723127','Nitpasstreet 92',' 2021-10-03',1,5),('1700','Hu','Rosario','Pidsae83@maih.pom','64050238','Mednusstreet 22',' 2022-01-05',1,5),
('1700','Bryar','Perkins','Xiadoz89@maih.gom','69832846','Yidverstreet 56',' 2021-09-17',1,6),('1700','Regina','Head','Qestoj65@maig.fom','64843684','Kehwofstreet 49',' 2022-05-02',1,6),
('1700','Sigourney','Morrow','Wimkeg10@maig.pom','98138753','Kagbaastreet 78',' 2021-01-26',1,7),('1700','Craig','Harrington','Poraug19@maiv.qom','42968789','Gubnurstreet 81',' 2020-10-02',1,7),
('8000','Penelope','Poole','Doqpeb82@maip.kom','67304459','Biqrodstreet 46',' 2022-07-11',1,8), ('8000','Cameran','Holloway','Hohnic14@maih.com','51654982','Kuwwolstreet 63',' 2020-09-27',1,8),
('8000','Wylie','Ross','Downac78@maiv.lom','55137332','Wimvojstreet 20',' 2022-05-28',1,9),('8000','Libby','Clemons','Febuaw57@maig.gom','45906324','Woehuhstreet 88',' 2021-05-18',1,9),('8000','Vivian','Grant','Ciaqey54@maie.xom','86988836','Naetarstreet 98',' 2020-08-19',1,9),('8000','Mufutau','Summers','Auoqam43@maie.xom','29131431','Yuadaqstreet 30',' 2021-10-05',1,9),
('8000','Roary','Hooper','Hiteeo01@mail.som','69755057','Wineuostreet 27',' 2021-09-20',1,10),('8000','Mason','Hodge','Paazei66@maic.som','91781515','Reduolstreet 04',' 2021-08-25',1,10),('8000','Gil','Wilkerson','Cionaa18@maig.wom','72244709','Aeksaxstreet 77',' 2021-03-26',1,10),
('8000','Amir','Merrill','Ruypec61@maiy.nom','60111039','Megredstreet 94',' 2022-05-06',1,11),('8000','Marshall','Pugh','Lapmog52@maiw.wom','08001844','Jaodavstreet 59',' 2022-04-10',1,11),
('8000','Jared','Bender','Sihvor73@maib.kom','40017819','Oiciucstreet 36',' 2021-10-31',1,12),('8000','Jack','Campos','Yihcag11@maig.dom','86342714','Fapjowstreet 58',' 2022-01-20',1,12),
('8000','Emi','Barr','Eamiel65@maii.jom','14778582','Uankeestreet 61',' 2021-05-22',1,13),('8000','Britanney','Berry','Sinsef33@maio.hom','61145093','Aeabeystreet 11',' 2022-01-17',1,13),
('8000','Laurel','Abbott','Bikmar39@maib.dom','98619404','Qedfuqstreet 88',' 2021-11-18',1,14),('8000','Craig','Berry','Qayqaz14@maic.pom','82967011','Uidkogstreet 69',' 2020-12-19',1,14),
('1700','Zoe','Ellis','Veiqaz92@maiq.som','08839460','Jovaabstreet 94',' 2020-12-01',1,15),
('1700','Farrah','Ware','Yomlay31@maif.rom','82277542','Gaycuwstreet 19',' 2022-02-22',1,16),('1700','Keiko','Mayo','Uiwbir38@maiv.mom','76863667','Xuwhubstreet 02',' 2022-04-17',1,16),
('1700','Madeline','Oneil','Mozbao55@maix.wom','18290937','Iicqelstreet 91',' 2022-06-14',1,17),('1700','Thaddeus','Fisher','Noznux19@maib.nom','65603515','Wisoamstreet 38',' 2020-08-24',1,17),
('1700','Rigel','Chapman','Eenxia73@mair.bom','55489415','Nenoubstreet 27',' 2021-02-03',1,18),('1700','Adara','Harrington','Pejxut36@maig.rom','35453206','Oublexstreet 05',' 2022-03-13',1,18),('1700','Steven','Livingston','Soxxog44@maip.hom','06953179','Saxrimstreet 76',' 2021-11-20',1,18),
('1700','Madonna','Evans','Zebhaa03@maic.lom','67562923','Wowaecstreet 76',' 2022-06-26',1,19),('1700','Harper','Burns','Hefxov79@maiu.kom','65242095','Datougstreet 33',' 2021-12-02',1,19),
('1700','Brody','Short','Yeqpaz06@maii.dom','74846625','Zifduistreet 57',' 2021-06-30',1,20),('1700','Jacob','Melton','Auroaj54@mail.zom','52221572','Hulwicstreet 63',' 2022-04-06',1,20),('1700','Hilary','Estrada','Aasuoh20@mait.bom','28757443','Zinjozstreet 38',' 2021-11-19',1,20),('1700','Nehru','Walter','Uiyies45@maie.zom','85502852','Vooaajstreet 61',' 2021-08-20',1,20),
('1700','Morgan','Russo','Wahwar23@mair.bom','57862373','Fazkejstreet 77',' 2022-07-22',1,21),('1700','Tatum','Savage','Oeagou58@main.yom','40499930','Secjiastreet 63',' 2022-05-28',1,21),('1700','Nissim','Lucas','Gawsan68@maic.dom','41042556','Faaoaustreet 05',' 2021-11-25',1,21),('1700','Orlando','Haynes','Iuyfoo62@maia.kom','87576703','Giafapstreet 32',' 2022-04-18',1,21),
('1700','Cara','Lott','Nerfoj76@maiv.yom','97208420','Uicroostreet 23',' 2022-07-26',1,21);

INSERT INTO SalesOrder([OrderStatusId],[OrderDate],[StoreId]) VALUES(8,'2021-07-24',2),(8,'2021-03-26',2),(3,'2021-05-22',3),(2,'2021-07-16',2),(4,'2021-01-06',3),(3,'2021-03-18',3),(2,'2021-04-12',2),(8,'2021-07-06',2),(5,'2021-06-05',3),(3,'2021-02-13',3),(5,'2021-02-20',1),(3,'2021-06-24',3),(2,'2021-02-24',3),(7,'2021-01-22',3),(4,'2021-07-30',1),(3,'2021-07-15',1),(8,'2021-03-11',2),(4,'2021-04-15',1),(4,'2021-05-15',2),(6,'2021-03-02',2);
INSERT INTO SalesOrder([OrderStatusId],[OrderDate],[StoreId]) VALUES(1,'2021-06-22',3),(4,'2021-07-26',2),(3,'2021-04-23',1),(1,'2021-02-08',1),(6,'2021-03-04',3),(4,'2021-04-21',1),(5,'2021-01-26',1),(8,'2021-03-17',2),(2,'2021-06-26',3),(7,'2021-02-14',3),(3,'2021-02-18',3),(6,'2021-04-16',3),(4,'2021-03-22',2),(8,'2021-01-24',2),(2,'2021-02-07',3),(6,'2021-03-26',2),(8,'2021-06-17',1),(6,'2021-04-02',2),(8,'2021-07-26',3),(8,'2021-07-11',3);
INSERT INTO SalesOrder([OrderStatusId],[OrderDate],[StoreId]) VALUES(8,'2021-07-28',3),(3,'2021-05-06',2),(2,'2021-03-02',1),(1,'2021-06-21',3),(1,'2021-05-24',3),(7,'2021-01-01',1),(3,'2021-06-13',3),(6,'2021-07-20',2),(6,'2021-03-22',2),(5,'2021-02-23',2),(6,'2021-07-20',2),(3,'2021-03-20',3),(5,'2021-02-06',1),(6,'2021-01-06',2),(5,'2021-05-07',2),(3,'2021-01-01',3),(4,'2021-04-15',2),(1,'2021-01-16',1),(2,'2021-07-24',1),(6,'2021-08-06',1);
INSERT INTO SalesOrder([OrderStatusId],[OrderDate],[StoreId]) VALUES(4,'2021-06-07',1),(5,'2021-05-27',2),(8,'2021-06-24',2),(8,'2021-02-17',3),(3,'2021-01-19',1),(5,'2021-03-17',1),(2,'2021-02-19',1),(7,'2021-03-21',2),(2,'2021-02-10',2),(1,'2021-01-25',1),(8,'2021-06-24',2),(4,'2021-01-05',1),(3,'2021-02-03',3),(1,'2021-06-05',2),(5,'2021-07-06',3),(1,'2021-06-16',1),(2,'2021-03-07',2),(6,'2021-02-09',3),(6,'2021-04-14',2),(3,'2021-03-20',1);
INSERT INTO SalesOrder([OrderStatusId],[OrderDate],[StoreId]) VALUES(4,'2021-02-19',3),(8,'2021-03-03',1),(3,'2021-06-08',1),(5,'2021-02-05',2),(7,'2021-03-10',1),(3,'2021-03-30',3),(8,'2021-06-15',1),(6,'2021-04-04',1),(2,'2021-04-06',3),(7,'2021-07-29',1),(5,'2021-01-04',3),(1,'2021-06-11',1),(2,'2021-01-11',1),(4,'2021-07-14',1),(7,'2021-05-06',3),(6,'2021-07-08',2),(4,'2021-02-06',3),(1,'2021-03-05',3),(5,'2021-04-13',2),(6,'2021-07-31',3);

INSERT INTO Delivery([SalesOrderId],[PostalCodeId],[CustomerId],[Address],[SendDate]) VALUES(1,'1700',17,'Jegeuestreet 92','2021-07-23'),(2,'1700',43,'Nuknoastreet 41','2021-07-03'),(3,'1700',78,'Ritboastreet 11','2021-07-04'),(4,'1700',59,'Qoqviistreet 43','2021-07-17'),(5,'1700',60,'Gostuustreet 83','2021-07-14'),(6,'1700',82,'Veoveistreet 96','2021-07-17'),(7,'1700',78,'Genioestreet 61','2021-07-03'),(8,'1700',21,'Aobruostreet 47','2021-07-24'),(9,'1700',42,'Euvfuustreet 03','2021-07-31'),(10,'1700',61,'Wuwluostreet 76','2021-07-13'),(11,'1700',41,'Zicuiistreet 11','2021-07-26'),(12,'1700',84,'Aasyeastreet 45','2021-07-29'),(13,'1700',5,'Kaxbuostreet 57','2021-07-20'),(14,'1700',75,'Yaraoustreet 88','2021-07-04'),(15,'1700',72,'Sapmiastreet 36','2021-07-22'),(16,'1700',45,'Gixjoustreet 14','2021-08-01'),(17,'1700',26,'Iihyaostreet 96','2021-07-04'),(18,'1700',8,'Bailiastreet 84','2021-07-11'),(19,'1700',16,'Nalpuostreet 23','2021-07-23'),(20,'1700',36,'Yarziustreet 38','2021-07-29'),(21,'1700',52,'Jabbeustreet 39','2021-07-29'),(22,'1700',6,'Oocsaustreet 47','2021-07-16'),(23,'1700',6,'Yanluastreet 29','2021-07-08'),(24,'1700',41,'Oegdaestreet 74','2021-07-24'),(25,'1700',23,'Mayuuastreet 58','2021-07-20'),(26,'1700',36,'Yanweustreet 62','2021-07-23'),(27,'1700',12,'Recduastreet 22','2021-07-23'),(28,'1700',49,'Kuykiestreet 33','2021-07-18'),(29,'1700',29,'Dehgoistreet 82','2021-07-25'),(30,'1700',39,'Ainvuustreet 67','2021-07-28'),(31,'1700',72,'Bofloistreet 00','2021-07-26'),(32,'1700',18,'Aexxuostreet 90','2021-08-01'),(33,'1700',51,'Biiaiistreet 26','2021-07-11'),(34,'1700',16,'Mijmoistreet 03','2021-07-29'),(35,'1700',31,'Rivvoostreet 49','2021-07-12'),(36,'1700',28,'Oahaaastreet 82','2021-07-28'),(37,'1700',65,'Kabgoostreet 61','2021-07-06'),(38,'1700',3,'Suzfeustreet 22','2021-07-29'),(39,'1700',60,'Iaypaastreet 07','2021-07-02'),(40,'1700',73,'Yihoeastreet 04','2021-07-17');
INSERT INTO Delivery([SalesOrderId],[PostalCodeId],[CustomerId],[Address],[SendDate]) VALUES(41,'1700',68,'Zirqaastreet 50','2021-07-08'),(42,'1700',14,'Yarqoistreet 05','2021-07-30'),(43,'1700',27,'Towsoostreet 47','2021-07-04'),(44,'1700',20,'Houqeestreet 70','2021-07-13'),(45,'1700',50,'Qajbiistreet 05','2021-07-01'),(46,'1700',67,'Cufeeastreet 89','2021-07-23'),(47,'1700',79,'Lapmuostreet 91','2021-07-23'),(48,'1700',10,'Yeqseostreet 38','2021-07-01'),(49,'1700',13,'Zocpeustreet 62','2021-07-09'),(50,'1700',20,'Xamzaistreet 28','2021-07-01'),(51,'1700',59,'Biugoustreet 81','2021-07-30'),(52,'1700',8,'Eeazeistreet 56','2021-07-30'),(53,'1700',31,'Xemxiistreet 20','2021-07-16'),(54,'1700',8,'Hulqaestreet 76','2021-07-15'),(55,'1700',67,'Eoimuistreet 87','2021-07-13'),(56,'1700',3,'Roofeustreet 31','2021-07-08'),(57,'1700',81,'Eiwriustreet 27','2021-07-30'),(58,'1700',30,'Eifwaestreet 31','2021-07-18'),(59,'1700',7,'Movteistreet 13','2021-07-07'),(60,'1700',43,'Mokloestreet 90','2021-07-15'),(61,'1700',66,'Ueuziustreet 76','2021-07-23'),(62,'1700',83,'Uidriustreet 05','2021-07-07'),(63,'1700',23,'Goxjeastreet 38','2021-07-11'),(64,'1700',10,'Digvuastreet 85','2021-07-26'),(65,'1700',6,'Aoezaastreet 50','2021-07-11'),(66,'1700',57,'Motyuostreet 05','2021-07-29'),(67,'1700',71,'Pargaestreet 90','2021-07-11'),(68,'1700',58,'Xiefeistreet 17','2021-07-02'),(69,'1700',83,'Wonpoastreet 28','2021-07-17'),(70,'1700',81,'Uazniastreet 99','2021-07-03'),(71,'1700',59,'Jakbeestreet 31','2021-07-12'),(72,'1700',65,'Totnoestreet 46','2021-07-14'),(73,'1700',29,'Qeenuustreet 02','2021-07-04'),(74,'1700',5,'Yuuqeestreet 75','2021-07-22'),(75,'1700',48,'Lozjiostreet 60','2021-07-28'),(76,'1700',24,'Zeukeistreet 39','2021-07-05'),(77,'1700',59,'Mubhaostreet 83','2021-07-29'),(78,'1700',42,'Qoejoistreet 07','2021-07-02'),(79,'1700',17,'Benkiostreet 42','2021-07-20'),(80,'1700',78,'Wanviostreet 21','2021-07-31');

INSERT INTO Orderline([SalesOrderId],[ProductId],[Price],[Quantity]) VALUES(40,15,14050,'1'),(4,15,5226,'1'),(63,12,16907,'1'),(46,14,3845,'1'),(8,1,7229,'1'),(77,7,4717,'1'),(96,10,4485,'1'),(98,5,15909,'1'),(22,1,13793,'1'),(64,8,18818,'1'),(47,3,9985,'1'),(82,7,13293,'1'),(34,11,15844,'1'),(25,20,12847,'1'),(56,8,12872,'1'),(41,16,16746,'1'),(94,17,5276,'1'),(96,1,4578,'1'),(23,9,7332,'1'),(71,3,5220,'1');
INSERT INTO Orderline([SalesOrderId],[ProductId],[Price],[Quantity]) VALUES(41,6,15141,'1'),(32,14,6169,'1'),(10,5,19349,'1'),(90,5,18386,'1'),(22,18,12979,'1'),(34,20,17900,'1'),(94,7,8620,'1'),(100,7,17057,'1'),(91,18,5912,'1'),(67,7,4513,'1'),(43,1,15943,'1'),(23,4,8576,'1'),(34,12,19461,'1'),(79,13,7631,'1'),(9,19,13016,'1'),(94,2,4295,'1'),(86,15,3636,'1'),(35,17,6786,'1'),(3,2,11982,'1'),(90,16,14558,'1');
INSERT INTO Orderline([SalesOrderId],[ProductId],[Price],[Quantity]) VALUES(3,5,3418,'1'),(91,9,12328,'1'),(28,18,17913,'1'),(77,9,17231,'1'),(1,3,10296,'1'),(51,9,14320,'1'),(9,7,3817,'1'),(7,18,18381,'1'),(25,2,16091,'1'),(20,13,6657,'1'),(72,19,10072,'1'),(76,13,19431,'1'),(75,5,12714,'1'),(8,20,6390,'1'),(15,8,18552,'1'),(62,1,13375,'1'),(3,10,12753,'1'),(90,3,3209,'1'),(61,7,13386,'1'),(27,7,19201,'1');
INSERT INTO Orderline([SalesOrderId],[ProductId],[Price],[Quantity]) VALUES(4,13,11421,'1'),(16,12,10779,'1'),(39,12,12851,'1'),(58,11,13557,'1'),(92,8,14491,'1'),(92,11,14357,'1'),(52,11,19085,'1'),(86,4,9378,'1'),(80,19,8887,'1'),(12,8,19455,'1'),(76,12,15210,'1'),(76,10,10705,'1'),(100,6,4646,'1'),(73,10,17376,'1'),(1,4,7699,'1'),(72,8,19780,'1'),(90,9,18346,'1'),(92,18,15896,'1'),(26,3,13137,'1'),(79,20,8170,'1');
INSERT INTO Orderline([SalesOrderId],[ProductId],[Price],[Quantity]) VALUES(33,1,11869,'1'),(35,2,11754,'1'),(74,18,12169,'1'),(91,12,6952,'1'),(99,17,15021,'1'),(49,5,15707,'1'),(62,13,4917,'1'),(3,19,14015,'1'),(80,15,18782,'1'),(50,2,6388,'1'),(95,11,3015,'1'),(31,2,12635,'1'),(33,10,7006,'1'),(52,5,19021,'1'),(95,19,8153,'1'),(100,9,18709,'1'),(30,11,13926,'1'),(79,7,3350,'1'),(39,3,12708,'1'),(88,17,13927,'1');







