USE [master]
GO
/****** Object:  Database [ContractManagement]    Script Date: 19/01/2023 00:54:00 ******/
CREATE DATABASE [ContractManagement]
ALTER DATABASE [ContractManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContractManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContractManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContractManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContractManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContractManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContractManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContractManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ContractManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContractManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContractManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContractManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContractManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContractManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContractManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContractManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContractManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ContractManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContractManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContractManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContractManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContractManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContractManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ContractManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContractManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ContractManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ContractManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContractManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContractManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContractManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContractManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ContractManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ContractManagement] SET QUERY_STORE = OFF
GO
USE [ContractManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/01/2023 00:54:00 ******/
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
/****** Object:  Table [dbo].[Contract]    Script Date: 19/01/2023 00:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContractNumber] [nvarchar](max) NOT NULL,
	[ContractType] [int] NOT NULL,
	[CustomerID] [nvarchar](450) NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 19/01/2023 00:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[HomeNumber] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Package]    Script Date: 19/01/2023 00:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PackageType] [int] NOT NULL,
	[PackageName] [nvarchar](max) NOT NULL,
	[Size] [int] NOT NULL,
	[Utilzation] [int] NOT NULL,
	[ContractID] [int] NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230117143358_ContractManagementDB', N'7.0.1')
GO
SET IDENTITY_INSERT [dbo].[Contract] ON 
GO
INSERT [dbo].[Contract] ([ID], [ContractNumber], [ContractType], [CustomerID]) VALUES (1, N'1', 1, N'305022311')
GO
INSERT [dbo].[Contract] ([ID], [ContractNumber], [ContractType], [CustomerID]) VALUES (2, N'2', 2, N'545496966')
GO
INSERT [dbo].[Contract] ([ID], [ContractNumber], [ContractType], [CustomerID]) VALUES (3, N'2', 0, N'305022311')
GO
SET IDENTITY_INSERT [dbo].[Contract] OFF
GO
INSERT [dbo].[Customers] ([ID], [FirstName], [LastName], [City], [Street], [HomeNumber], [PostalCode]) VALUES (N'305022311', N'Roy', N'Yadid', N'Tel Aviv', N'Bazel', N'19', N'6565567')
GO
INSERT [dbo].[Customers] ([ID], [FirstName], [LastName], [City], [Street], [HomeNumber], [PostalCode]) VALUES (N'545496966', N'Tomer', N'Levi', N'Tel Aviv', N'Bazel', N'4', N'565566')
GO
INSERT [dbo].[Customers] ([ID], [FirstName], [LastName], [City], [Street], [HomeNumber], [PostalCode]) VALUES (N'656565666', N'Ido', N'Sror', NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Package] ON 
GO
INSERT [dbo].[Package] ([ID], [PackageType], [PackageName], [Size], [Utilzation], [ContractID]) VALUES (1, 1, N'Extra', 10, 5, 1)
GO
INSERT [dbo].[Package] ([ID], [PackageType], [PackageName], [Size], [Utilzation], [ContractID]) VALUES (2, 2, N'Full', 10, 8, 2)
GO
INSERT [dbo].[Package] ([ID], [PackageType], [PackageName], [Size], [Utilzation], [ContractID]) VALUES (5, 2, N'Full', 10, 7, 1)
GO
INSERT [dbo].[Package] ([ID], [PackageType], [PackageName], [Size], [Utilzation], [ContractID]) VALUES (7, 1, N'Extra', 10, 3, 2)
GO
INSERT [dbo].[Package] ([ID], [PackageType], [PackageName], [Size], [Utilzation], [ContractID]) VALUES (9, 1, N'Partly', 10, 1, 3)
GO
SET IDENTITY_INSERT [dbo].[Package] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Contract_CustomerID]    Script Date: 19/01/2023 00:54:00 ******/
CREATE NONCLUSTERED INDEX [IX_Contract_CustomerID] ON [dbo].[Contract]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Package_ContractID]    Script Date: 19/01/2023 00:54:00 ******/
CREATE NONCLUSTERED INDEX [IX_Package_ContractID] ON [dbo].[Package]
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Package]  WITH CHECK ADD  CONSTRAINT [FK_Package_Contract_ContractID] FOREIGN KEY([ContractID])
REFERENCES [dbo].[Contract] ([ID])
GO
ALTER TABLE [dbo].[Package] CHECK CONSTRAINT [FK_Package_Contract_ContractID]
GO
/****** Object:  StoredProcedure [dbo].[CheckCustomerExistById]    Script Date: 19/01/2023 00:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CheckCustomerExistById] 

    @ID varchar(max)

AS
BEGIN
    select count(*) as count from Customers
	where Customers.ID=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[EditCustomerAddress]    Script Date: 19/01/2023 00:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[EditCustomerAddress] 

    @ID varchar(max),
	@City varchar(max),
	@Street varchar(max),
	@HomeNumber varchar(max),
	@PostalCode varchar(max)

AS
BEGIN
	UPDATE
         Customers

    SET City=@City,
		Street=@Street,
		HomeNumber=@HomeNumber,
		PostalCode=@PostalCode

	where Customers.ID=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerInformationById]    Script Date: 19/01/2023 00:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerInformationById] 

    @ID varchar(max)

AS
BEGIN
     select * from (Customers left join Contract on Customers.ID=CustomerID) left join Package
	on Package.ContractID=Contract.ID
	where Customers.ID=@ID
END
GO
USE [master]
GO
ALTER DATABASE [ContractManagement] SET  READ_WRITE 
GO
