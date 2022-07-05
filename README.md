# OnlineGrocery



create database amazon;

use amazon;


//------users table------
	create table users(name varchar(100),email varchar(100)primary key,
	mobileNumber bigint, securityQuestion varchar(200),
	answer varchar(200),password varchar(100),
	address varchar(500),city varchar(100),
	state varchar(100),country varchar(100));
	
	  
	create table product(id int NOT NULL IDENTITY(1,1),
	name varchar(500),image varchar(500),
	category varchar(200),
	price int,active varchar(10),
	primary key(id));
	
	drop table cart
	//------cart table--------
	create table cart(id int Not Null,email varchar(100),product_id int,
	quantity int,price int,total int,
	primary key(id),
	FOREIGN KEY (email) REFERENCES users(email),
	FOREIGN KEY (product_id) REFERENCES product(id)
);
	create table Orders(id int NOT NULL IDENTITY(1,1),email varchar(100), address varchar(500)
	,city varchar(100),state varchar(100),
	country varchar(100),
	mobileNumber bigint,orderDate varchar(100),deliveryDate varchar(100),
	paymentMethod varchar(100),transactionId varchar(100),status varchar(10),
	primary key(id),
	FOREIGN KEY (email) REFERENCES users(email)
);
	create table message(id int IDENTITY(1,1),email varchar(100),subject varchar(200),body varchar(1000),PRIMARY KEY(ID));
	use amazon
	insert into users (name,email) Values('yaswanth','test@gmail.com')
	     INSERT INTO product(name,image,category,price,active) VALUES("Tomato-1kg","https://www.freepnglogos.com/uploads/tomato-png/tomato-and-kidney-stone-everyday-life-23.png","vegetables",10,"Yes");
	INSERT INTO product(name,image,category,price,active) VALUES("Potato-1kg","http://alrafique.com/images/potatoes.png","vegetables",15,"Yes");
	select *from product
	select *from  cart
	select *from users
	delete  from Orders where email='test@gmail.com'
	insert into cart values('bob@gmail.com','onion',1,1,50,50)
	insert into users(name,email,password) values('admin','admin@gmail.com','admin')
	update users set password='test' where email='test@gmail.com'
	

