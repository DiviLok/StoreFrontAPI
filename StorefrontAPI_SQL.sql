USE [master]
GO
/****** Object:  Database [ShopClothesDB]    Script Date: 12/4/2022 7:46:29 PM ******/
CREATE DATABASE [ShopClothesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopClothesDB', FILENAME = N'F:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopClothesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopClothesDB_log', FILENAME = N'F:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopClothesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShopClothesDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopClothesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopClothesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopClothesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopClothesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopClothesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopClothesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopClothesDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopClothesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopClothesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopClothesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopClothesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopClothesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopClothesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopClothesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopClothesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopClothesDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopClothesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopClothesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopClothesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopClothesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopClothesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopClothesDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ShopClothesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopClothesDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopClothesDB] SET  MULTI_USER 
GO
ALTER DATABASE [ShopClothesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopClothesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopClothesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopClothesDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopClothesDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopClothesDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopClothesDB', N'ON'
GO
ALTER DATABASE [ShopClothesDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShopClothesDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShopClothesDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/4/2022 7:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[availableSizes]    Script Date: 12/4/2022 7:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[availableSizes](
	[SizeID] [int] IDENTITY(1,1) NOT NULL,
	[SizeName] [nvarchar](max) NOT NULL,
	[SizeDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_availableSizes] PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clothes]    Script Date: 12/4/2022 7:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clothes](
	[ClothId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Material] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[price] [int] NOT NULL,
 CONSTRAINT [PK_clothes] PRIMARY KEY CLUSTERED 
(
	[ClothId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clothesAndSizes]    Script Date: 12/4/2022 7:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clothesAndSizes](
	[ClothId] [int] NOT NULL,
	[SizeID] [int] NOT NULL,
 CONSTRAINT [PK_clothesAndSizes] PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC,
	[ClothId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kidsclothes]    Script Date: 12/4/2022 7:46:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kidsclothes](
	[KidClothID] [int] IDENTITY(1,1) NOT NULL,
	[KidClothName] [nvarchar](max) NOT NULL,
	[KidClothType] [nvarchar](max) NOT NULL,
	[ClothId] [int] NOT NULL,
	[clothesClothId] [int] NOT NULL,
 CONSTRAINT [PK_kidsclothes] PRIMARY KEY CLUSTERED 
(
	[KidClothID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221130130506_CreateDB', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221130131808_RealtionsBetweenObjects', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221130165751_FK', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221204074453_price', N'7.0.0')
GO
SET IDENTITY_INSERT [dbo].[availableSizes] ON 

INSERT [dbo].[availableSizes] ([SizeID], [SizeName], [SizeDescription]) VALUES (1, N'xs', N'ExtraSmall')
INSERT [dbo].[availableSizes] ([SizeID], [SizeName], [SizeDescription]) VALUES (2, N's', N'Small')
INSERT [dbo].[availableSizes] ([SizeID], [SizeName], [SizeDescription]) VALUES (3, N'm', N'Medium')
INSERT [dbo].[availableSizes] ([SizeID], [SizeName], [SizeDescription]) VALUES (4, N'l', N'Large')
INSERT [dbo].[availableSizes] ([SizeID], [SizeName], [SizeDescription]) VALUES (5, N'xl', N'ExtraLarge')
INSERT [dbo].[availableSizes] ([SizeID], [SizeName], [SizeDescription]) VALUES (1002, N'xxl', N'xxLarge')
INSERT [dbo].[availableSizes] ([SizeID], [SizeName], [SizeDescription]) VALUES (1003, N'xxxl', N'xxxLarge')
SET IDENTITY_INSERT [dbo].[availableSizes] OFF
GO
SET IDENTITY_INSERT [dbo].[clothes] ON 

INSERT [dbo].[clothes] ([ClothId], [Name], [Description], [Material], [Type], [price]) VALUES (6, N'Kids Pants', N'pants', N'cotton', N'/images/redpant.jpeg', 70)
INSERT [dbo].[clothes] ([ClothId], [Name], [Description], [Material], [Type], [price]) VALUES (7, N'Kids Shirt', N'shirt', N' cotton', N'/images/redshirt.jpeg', 40)
INSERT [dbo].[clothes] ([ClothId], [Name], [Description], [Material], [Type], [price]) VALUES (8, N'Kids Pants', N'pants', N'cotton', N'/images/bluepant.jpeg', 30)
INSERT [dbo].[clothes] ([ClothId], [Name], [Description], [Material], [Type], [price]) VALUES (1005, N'kids sweater', N'kids sweater', N'wool', N'/images/colorsweater.jpeg', 90)
INSERT [dbo].[clothes] ([ClothId], [Name], [Description], [Material], [Type], [price]) VALUES (1006, N'sweater', N'sweater', N'wool', N'/images/blueyellowsweater.jpeg', 75)
INSERT [dbo].[clothes] ([ClothId], [Name], [Description], [Material], [Type], [price]) VALUES (1007, N'blueskirt', N'blueskirt', N'jeans', N'/images/blueskirt.jpeg', 52)
SET IDENTITY_INSERT [dbo].[clothes] OFF
GO
INSERT [dbo].[clothesAndSizes] ([ClothId], [SizeID]) VALUES (7, 2)
INSERT [dbo].[clothesAndSizes] ([ClothId], [SizeID]) VALUES (7, 3)
GO
SET IDENTITY_INSERT [dbo].[kidsclothes] ON 

INSERT [dbo].[kidsclothes] ([KidClothID], [KidClothName], [KidClothType], [ClothId], [clothesClothId]) VALUES (1005, N'Sweater', N'Wool', 1005, 1006)
SET IDENTITY_INSERT [dbo].[kidsclothes] OFF
GO
/****** Object:  Index [IX_clothesAndSizes_ClothId]    Script Date: 12/4/2022 7:46:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_clothesAndSizes_ClothId] ON [dbo].[clothesAndSizes]
(
	[ClothId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_kidsclothes_clothesClothId]    Script Date: 12/4/2022 7:46:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_kidsclothes_clothesClothId] ON [dbo].[kidsclothes]
(
	[clothesClothId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[clothes] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[kidsclothes] ADD  DEFAULT ((0)) FOR [ClothId]
GO
ALTER TABLE [dbo].[kidsclothes] ADD  DEFAULT ((0)) FOR [clothesClothId]
GO
ALTER TABLE [dbo].[clothesAndSizes]  WITH CHECK ADD  CONSTRAINT [FK_clothesAndSizes_availableSizes_SizeID] FOREIGN KEY([SizeID])
REFERENCES [dbo].[availableSizes] ([SizeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[clothesAndSizes] CHECK CONSTRAINT [FK_clothesAndSizes_availableSizes_SizeID]
GO
ALTER TABLE [dbo].[clothesAndSizes]  WITH CHECK ADD  CONSTRAINT [FK_clothesAndSizes_clothes_ClothId] FOREIGN KEY([ClothId])
REFERENCES [dbo].[clothes] ([ClothId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[clothesAndSizes] CHECK CONSTRAINT [FK_clothesAndSizes_clothes_ClothId]
GO
ALTER TABLE [dbo].[kidsclothes]  WITH CHECK ADD  CONSTRAINT [FK_kidsclothes_clothes_clothesClothId] FOREIGN KEY([clothesClothId])
REFERENCES [dbo].[clothes] ([ClothId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[kidsclothes] CHECK CONSTRAINT [FK_kidsclothes_clothes_clothesClothId]
GO
USE [master]
GO
ALTER DATABASE [ShopClothesDB] SET  READ_WRITE 
GO
