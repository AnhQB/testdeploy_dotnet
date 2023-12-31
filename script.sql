Create database Assg1Prn231
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CategoryName] [nvarchar](50) NULL,
)

CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,


	[ProductName] [nvarchar](40) NOT NULL,
	[CategoryID] [int]  NOT NULL,
	[Weight] decimal NOT null,
	[UnitPrice] decimal null,
	[UnitInStock] decimal null,
  FOREIGN KEY ([CategoryID]) REFERENCES [Categories]([CategoryID])

)
 CREATE TABLE [dbo].[Member](
	[MemberID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Email] [nvarchar](40) NOT NULL,
	CompanyName [nvarchar](40) NOT NULL,
		City [nvarchar](40) NOT NULL,
	Coutry [nvarchar](40) NOT NULL,
		Password [nvarchar](40) NOT NULL,
		
 )

CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[MemberID] INT NULL,
	[UnitPrice] decimal null,
		Quantity int null,
		Discount bit null,
	FOREIGN KEY ([MemberID]) REFERENCES [Member]([MemberID])
 )


CREATE TABLE [dbo].[Order Details](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[Discount] [real] NOT NULL,
	PRIMARY KEY ([OrderID],[ProductID]),
	 FOREIGN KEY ([ProductID]) REFERENCES [Product]([ProductID]),
	  FOREIGN KEY ([OrderID]) REFERENCES [Orders]([OrderID])
)
/****** Object:  Table [dbo].[Orders]    Script Date: 16/5/2023 8:07:07 PM ******/






