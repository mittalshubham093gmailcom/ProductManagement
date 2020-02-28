USE [master]
GO
/****** Object:  Database [ProductManagement]    Script Date: 16-Feb-20 6:36:52 AM ******/
CREATE DATABASE [ProductManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductManagement', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProductManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProductManagement_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProductManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProductManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ProductManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProductManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ProductManagement]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [int] NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK__Category__3214EC074E6F594E] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([Id], [CartId], [ProductId]) VALUES (2, 1, 1)
INSERT [dbo].[Cart] ([Id], [CartId], [ProductId]) VALUES (4, 2, 2)
SET IDENTITY_INSERT [dbo].[Cart] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Clothes')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Shoes')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'Electronics')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [Price]) VALUES (1, N'djbdw', 1, CAST(232 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [Price]) VALUES (2, N'T-shirt', 2, CAST(400 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [Price]) VALUES (3, N'fyfyf', 3, CAST(4544 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [Price]) VALUES (4, N'dtydutd', 2, CAST(6464 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [Price]) VALUES (5, N'dtydutd', 2, CAST(6464 AS Decimal(18, 0)))
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [Price]) VALUES (6, N'nudeb', 3, CAST(344 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Product] OFF
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddProduct]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_AddProduct](
@categoryId int,
@name nvarchar(Max)=NULL,
@price decimal
)
AS
BEGIN
	insert into Product (Name,Price,CategoryId) values(@name,@price,@categoryId);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_AddProductInCart]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_AddProductInCart](
@productId int,
@cartId int
)
AS
BEGIN
	insert into Cart (ProductId,CartId) values(@productId,@cartId);
END


GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteProduct]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteProduct](
@productId int
)
AS
BEGIN
	delete from Product  where Id=@productId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProducts]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllProducts]
AS
BEGIN
	SELECT * from Product
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategories]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_GetCategories]
AS
BEGIN
	SELECT * from Category
END


GO
/****** Object:  StoredProcedure [dbo].[sp_GetItemFromCart]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_GetItemFromCart](
@cartId int
)
AS
BEGIN
	select * from Product prod join Cart c on c.ProductId=prod.Id  where CartId=@cartId
END


GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductById]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetProductById](
@productId int
)
AS
BEGIN
	select * from Product  where Id=@productId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductsBasedOnCategory]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetProductsBasedOnCategory](
@categoryId int
)
AS
BEGIN
	select * from Product  where Id=@categoryId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductsByCategory]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetProductsByCategory](
@categoryId int
)
AS
BEGIN
	select * from Product  where Id=@categoryId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_isSameProductExistsInCart]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_isSameProductExistsInCart](
@productId int,
@cartId int
)
AS
BEGIN
	select * from  Cart where ProductId= @productId and CartId =@cartId;
END



GO
/****** Object:  StoredProcedure [dbo].[sp_RemoveAllProductFromCart]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_RemoveAllProductFromCart](
@cartId int
)
AS
BEGIN
	delete from Cart where CartId= @cartId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_RemoveProductFromCart]    Script Date: 16-Feb-20 6:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_RemoveProductFromCart](
@productId int,
@cartId int
)
AS
BEGIN
	delete from Cart where ProductId=@productId and CartId= @cartId
END


GO
USE [master]
GO
ALTER DATABASE [ProductManagement] SET  READ_WRITE 
GO
