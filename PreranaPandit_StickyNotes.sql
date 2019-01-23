Create database PreranaStickyNotes;
Use PreranaStickyNotes;

/*Usertype is created where Usertype_ID is primary key*/
Create table Usertype
(
Usertype_ID int not null identity(1,1),
Usertype_Name varchar(30),
Constraint pk_Usertype Primary key(Usertype_ID)
);

sp_help Usertype;

/*Users is created where Users_ID is primary key and Usertype_ID is foreign key 
with references Usertype table */
Create table Users
(
Usertype_ID int,
Users_ID int not null identity(1,1),
FirstName varchar(20),
LastName varchar(20),
Address_Name varchar(20),
Phone_No varchar(20),
Email varchar (30),
Gender varchar(10),
Username varchar(50),
Passcode varchar(50), 
Constraint pk_Users Primary key(Users_ID),
Constraint fk_Usertype foreign key(Usertype_ID)
references Usertype
);

sp_help Users;

/*Categories is created where Categories_ID is primary key*/
Create table Categories
(
Categories_ID int not null identity(1,1),
Categories_Name varchar(10),
Constraint pk_Categories Primary key(Categories_ID)
);

sp_help Categories;

/*StickyNotes is created where StickyNotes_ID is primary key and Users_ID and 
Categories_ID are both foreign keys where references with two different tables.*/
Create table StickyNotes
(
StickyNotes_ID int not null identity(1,1),
Users_ID int,
Categories_ID int,
Date_Created date,
Title varchar(20),
Content_of_Notes varchar(200),
IsStickied bit,
IsCompleted bit,
Constraint pk_StickyNotes Primary key(StickyNotes_ID),
Constraint fk_Users foreign key (Users_ID)
references Users,
Constraint fk_Categories foreign key (Categories_ID)
references Categories,
);

sp_help StickyNotes;

/*selection query begins......*/
select*from Usertype;
select*from Users;
select*from Categories;
select*from StickyNotes;
