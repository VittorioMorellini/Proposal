USE [master]
GO
/****** Object:  Database [Proposal]    Script Date: 31/07/2022 22:14:32 ******/
CREATE DATABASE [Proposal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Warehouse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Warehouse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Warehouse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Warehouse_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Proposal] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Proposal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Proposal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Proposal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Proposal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Proposal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Proposal] SET ARITHABORT OFF 
GO
ALTER DATABASE [Proposal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Proposal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Proposal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Proposal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Proposal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Proposal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Proposal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Proposal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Proposal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Proposal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Proposal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Proposal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Proposal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Proposal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Proposal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Proposal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Proposal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Proposal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Proposal] SET  MULTI_USER 
GO
ALTER DATABASE [Proposal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Proposal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Proposal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Proposal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Proposal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Proposal] SET QUERY_STORE = OFF
GO
USE [Proposal]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[InsertUser] [varchar](100) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateUser] [varchar](100) NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NULL,
	[City] [varchar](100) NOT NULL,
	[Cap] [varchar](10) NULL,
	[Address] [varchar](100) NOT NULL,
	[AddressNumber] [int] NULL,
	[District] [varchar](50) NULL,
	[Country] [varchar](10) NULL,
	[Sex] [varchar](1) NULL,
	[Type] [varchar](1) NULL,
	[Phone] [varchar](100) NULL,
	[MobilePhone] [varchar](50) NULL,
	[Mail] [varchar](100) NULL,
	[TaxCode] [varchar](100) NULL,
	[VatCode] [varchar](50) NULL,
	[BirthDate] [datetime] NULL,
	[IdentificationDocType] [varchar](10) NULL,
	[IdentificationDocNumber] [varchar](100) NULL,
	[IdentificationDocCountry] [varchar](10) NULL,
	[IdentificationDocReleaseDate] [datetime] NULL,
	[IdentificationDocExpirationDate] [datetime] NULL,
	[ContactDate] [datetime] NULL,
	[RecallDate] [datetime] NULL,
	[Notes] [varchar](max) NULL,
	[Disabled] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[BarCode] [varchar](24) NOT NULL,
	[WarehouseId] [bigint] NOT NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lot]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lot](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](100) NULL,
	[Description] [varchar](200) NULL,
	[PurchaseOrderId] [bigint] NULL,
	[ListOfMaterial] [varchar](200) NULL,
 CONSTRAINT [PK_Lot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StoreId] [bigint] NOT NULL,
	[Date] [datetime] NULL,
	[CustomerId] [bigint] NULL,
	[DeliveryAddress] [varchar](100) NULL,
	[DeliveryCity] [varchar](100) NULL,
 CONSTRAINT [PK_ProductPurchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Principal]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Principal](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InsertUser] [varchar](100) NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUser] [varchar](100) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NULL,
	[Name] [varchar](100) NULL,
	[Surname] [varchar](100) NULL,
	[Mail] [varchar](100) NULL,
	[Phone] [varchar](50) NULL,
	[Role] [varchar](100) NULL,
	[Disabled] [bit] NOT NULL,
	[TaxCode] [varchar](50) NULL,
	[Language] [varchar](10) NULL,
	[City] [varchar](100) NULL,
	[MobilePhone] [varchar](50) NULL,
	[District] [varchar](100) NULL,
	[Cap] [varchar](50) NULL,
	[Notes] [varchar](500) NULL,
	[AgendaLocked] [bit] NOT NULL,
	[Country] [varchar](10) NULL,
	[Address] [varchar](200) NULL,
 CONSTRAINT [PK_Principal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[Price] [float] NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[InsertUser] [varchar](100) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateUser] [varchar](100) NULL,
	[CategoryId] [bigint] NULL,
	[ExpirationDate] [datetime] NULL,
	[Disabled] [datetime] NULL,
	[Brand] [varchar](100) NULL,
	[SupplierId] [bigint] NULL,
	[ReorderLeadDays] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOperation]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOperation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[State] [varchar](20) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[WarehouseId] [bigint] NULL,
	[StoreId] [bigint] NULL,
	[LotInId] [bigint] NULL,
	[DateEnd] [datetime] NULL,
 CONSTRAINT [PK_ProductState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStoreMovement]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStoreMovement](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[StoreId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[MoveDate] [datetime] NOT NULL,
	[CustomerId] [bigint] NULL,
 CONSTRAINT [PK_ProductStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierId] [bigint] NOT NULL,
	[Date] [datetime] NULL,
	[Product] [varchar](100) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[InsertUser] [varchar](100) NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateUser] [varchar](100) NULL,
	[WarehouseId] [bigint] NOT NULL,
	[City] [varchar](100) NULL,
	[ImageUrl] [varchar](200) NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[BusinessName] [varchar](100) NOT NULL,
	[City] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
	[Country] [varchar](50) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[WarehouseTypeId] [bigint] NULL,
	[InsertUser] [varchar](100) NULL,
	[InsertDate] [datetime] NULL,
	[UpdateUser] [varchar](100) NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WarehouseMovement]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseMovement](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MovementDate] [datetime] NULL,
	[ProductId] [bigint] NOT NULL,
	[Quantity] [int] NULL,
	[InsertUser] [varchar](100) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateUser] [varchar](100) NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[DeleteUser] [varchar](100) NULL,
	[DeleteDate] [datetime] NULL,
	[Notes] [varchar](255) NULL,
	[CustomerId] [bigint] NULL,
	[LocationFrom] [bigint] NULL,
	[LocationTo] [bigint] NOT NULL,
	[PurchaseOrderId] [bigint] NULL,
 CONSTRAINT [PK_WarehouseMovement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WarehouseType]    Script Date: 31/07/2022 22:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_WarehouseType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Principal] ADD  CONSTRAINT [DF__Principal__Inser__5AEE82B9]  DEFAULT (getdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[Principal] ADD  CONSTRAINT [DF__Principal__Updat__5BE2A6F2]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Principal] ADD  CONSTRAINT [DF__Principal__Disab__34C8D9D1]  DEFAULT ((0)) FOR [Disabled]
GO
ALTER TABLE [dbo].[Principal] ADD  CONSTRAINT [DF_Principal_AgendaLocked]  DEFAULT ((0)) FOR [AgendaLocked]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Store] ADD  CONSTRAINT [DF_Store_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[Store] ADD  CONSTRAINT [DF_Store_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([Id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Warehouse]
GO
ALTER TABLE [dbo].[Lot]  WITH CHECK ADD  CONSTRAINT [FK_Lot_PurchaseOrder] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([Id])
GO
ALTER TABLE [dbo].[Lot] CHECK CONSTRAINT [FK_Lot_PurchaseOrder]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Store]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Supplier]
GO
ALTER TABLE [dbo].[ProductOperation]  WITH CHECK ADD  CONSTRAINT [FK_ProductOperation_Lot] FOREIGN KEY([LotInId])
REFERENCES [dbo].[Lot] ([Id])
GO
ALTER TABLE [dbo].[ProductOperation] CHECK CONSTRAINT [FK_ProductOperation_Lot]
GO
ALTER TABLE [dbo].[ProductOperation]  WITH CHECK ADD  CONSTRAINT [FK_ProductOperation_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[ProductOperation] CHECK CONSTRAINT [FK_ProductOperation_Store]
GO
ALTER TABLE [dbo].[ProductOperation]  WITH CHECK ADD  CONSTRAINT [FK_ProductOperation_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([Id])
GO
ALTER TABLE [dbo].[ProductOperation] CHECK CONSTRAINT [FK_ProductOperation_Warehouse]
GO
ALTER TABLE [dbo].[ProductOperation]  WITH CHECK ADD  CONSTRAINT [FK_ProductState_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOperation] CHECK CONSTRAINT [FK_ProductState_Product]
GO
ALTER TABLE [dbo].[ProductStoreMovement]  WITH CHECK ADD  CONSTRAINT [FK_ProductStore_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductStoreMovement] CHECK CONSTRAINT [FK_ProductStore_Product]
GO
ALTER TABLE [dbo].[ProductStoreMovement]  WITH CHECK ADD  CONSTRAINT [FK_ProductStore_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[ProductStoreMovement] CHECK CONSTRAINT [FK_ProductStore_Store]
GO
ALTER TABLE [dbo].[ProductStoreMovement]  WITH CHECK ADD  CONSTRAINT [FK_ProductStoreMove_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[ProductStoreMovement] CHECK CONSTRAINT [FK_ProductStoreMove_Customer]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([Id])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_Warehouse]
GO
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_WarehouseType] FOREIGN KEY([WarehouseTypeId])
REFERENCES [dbo].[WarehouseType] ([Id])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_WarehouseType]
GO
ALTER TABLE [dbo].[WarehouseMovement]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseMovement_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[WarehouseMovement] CHECK CONSTRAINT [FK_WarehouseMovement_Customer]
GO
ALTER TABLE [dbo].[WarehouseMovement]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseMovement_LocationFrom] FOREIGN KEY([LocationFrom])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[WarehouseMovement] CHECK CONSTRAINT [FK_WarehouseMovement_LocationFrom]
GO
ALTER TABLE [dbo].[WarehouseMovement]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseMovement_LocationTo] FOREIGN KEY([LocationTo])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[WarehouseMovement] CHECK CONSTRAINT [FK_WarehouseMovement_LocationTo]
GO
ALTER TABLE [dbo].[WarehouseMovement]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseMovement_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[WarehouseMovement] CHECK CONSTRAINT [FK_WarehouseMovement_Product]
GO
ALTER TABLE [dbo].[WarehouseMovement]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseMovement_PurchaseOrder] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([Id])
GO
ALTER TABLE [dbo].[WarehouseMovement] CHECK CONSTRAINT [FK_WarehouseMovement_PurchaseOrder]
GO
EXEC sys.sp_addextendedproperty @name=N'Note', @value=N'Categoria del prodotto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'the unit is days to reorder' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'ReorderLeadDays'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Informations about the production Lot' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductOperation', @level2type=N'COLUMN',@level2name=N'LotInId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'is not null if this is a return form a customer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductStoreMovement', @level2type=N'COLUMN',@level2name=N'CustomerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Good that is a return from customer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WarehouseMovement', @level2type=N'COLUMN',@level2name=N'CustomerId'
GO
USE [master]
GO
ALTER DATABASE [Proposal] SET  READ_WRITE 
GO
