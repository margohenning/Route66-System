USE [master]
GO
/****** Object:  Database [itspRoute]    Script Date: 2016/10/30 8:00:23 PM ******/
CREATE DATABASE [itspRoute]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'itspRoute_data', FILENAME = N'c:\sqlProject\itspRoute_data.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'itspRoute_log', FILENAME = N'c:\sqlProject\itspRoute_log.ldf' , SIZE = 5120KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [itspRoute] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [itspRoute].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [itspRoute] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [itspRoute] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [itspRoute] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [itspRoute] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [itspRoute] SET ARITHABORT OFF 
GO
ALTER DATABASE [itspRoute] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [itspRoute] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [itspRoute] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [itspRoute] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [itspRoute] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [itspRoute] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [itspRoute] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [itspRoute] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [itspRoute] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [itspRoute] SET  ENABLE_BROKER 
GO
ALTER DATABASE [itspRoute] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [itspRoute] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [itspRoute] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [itspRoute] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [itspRoute] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [itspRoute] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [itspRoute] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [itspRoute] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [itspRoute] SET  MULTI_USER 
GO
ALTER DATABASE [itspRoute] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [itspRoute] SET DB_CHAINING OFF 
GO
ALTER DATABASE [itspRoute] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [itspRoute] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [itspRoute] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'itspRoute', N'ON'
GO
USE [itspRoute]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[IDno] [varchar](50) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Surname] [varchar](40) NOT NULL,
	[CellNo] [varchar](15) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[CustAddress] [varchar](40) NOT NULL,
 CONSTRAINT [PK__Customer__049E3A89ED51B33C] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[IDno] [varchar](20) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Surname] [varchar](40) NOT NULL,
	[Username] [varchar](40) NOT NULL,
	[Pass] [varchar](40) NOT NULL,
	[CellNo] [varchar](15) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[EmpAddress] [varchar](40) NOT NULL,
	[Salary] [decimal](18, 0) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Activated] [bit] NULL,
 CONSTRAINT [PK__Employee__AF2DBA796195CF14] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reserve]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reserve](
	[ResID] [int] IDENTITY(1,1) NOT NULL,
	[ResDate] [date] NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Surname] [varchar](40) NOT NULL,
	[IDno] [nvarchar](max) NOT NULL,
	[CellNo] [varchar](15) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[StockID] [int] NOT NULL,
 CONSTRAINT [PK__Reserve__29788216B57758CA] PRIMARY KEY CLUSTERED 
(
	[ResID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[SaleID] [int] IDENTITY(1,1) NOT NULL,
	[SaleDate] [date] NOT NULL,
	[EmpID] [int] NOT NULL,
	[StockID] [int] NOT NULL,
	[CustID] [int] NOT NULL,
	[Paid] [bit] NOT NULL,
 CONSTRAINT [PK__Sale__1EE3C41F869D49EF] PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stock](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[VIN] [nvarchar](max) NOT NULL,
	[VehicleYear] [varchar](40) NOT NULL,
	[Model] [varchar](40) NOT NULL,
	[Make] [varchar](40) NOT NULL,
	[VehicleStatus] [varchar](40) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK__Stock__2C83A9E2DB022DA0] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockRemoved]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockRemoved](
	[StockRemovedID] [int] IDENTITY(1,1) NOT NULL,
	[DateRemoved] [datetime] NOT NULL,
	[EmpId] [int] NOT NULL,
	[VIN] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StockRemoved] PRIMARY KEY CLUSTERED 
(
	[StockRemovedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmpID], [IDno], [Name], [Surname], [Username], [Pass], [CellNo], [Email], [EmpAddress], [Salary], [IsAdmin], [Activated]) VALUES (12, N'9405090055080', N'DEV', N'DEV', N'DEV', N'DEV', N'019092776', N'DEV@mail.com', N'DEV', CAST(10 AS Decimal(18, 0)), 1, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([StockID], [VIN], [VehicleYear], [Model], [Make], [VehicleStatus], [Price]) VALUES (11, N'FM12EBGP', N'2000', N'Mustang EcoBoost', N'Ford', N'Available', CAST(469580 AS Decimal(18, 0)))
INSERT [dbo].[Stock] ([StockID], [VIN], [VehicleYear], [Model], [Make], [VehicleStatus], [Price]) VALUES (12, N'FM34GTGP', N'2001', N'Mustang GT Fastback', N'Ford', N'Available', CAST(513137 AS Decimal(18, 0)))
INSERT [dbo].[Stock] ([StockID], [VIN], [VehicleYear], [Model], [Make], [VehicleStatus], [Price]) VALUES (13, N'MF56PCGP', N'2009', N'Mustang EcoBoostPremium Convertible', N'Ford', N'Available', CAST(556697 AS Decimal(18, 0)))
INSERT [dbo].[Stock] ([StockID], [VIN], [VehicleYear], [Model], [Make], [VehicleStatus], [Price]) VALUES (14, N'CS78CHGP', N'2010', N'Stingray Coupe', N'Corvette', N'Available', CAST(877536 AS Decimal(18, 0)))
INSERT [dbo].[Stock] ([StockID], [VIN], [VehicleYear], [Model], [Make], [VehicleStatus], [Price]) VALUES (15, N'CZ09RTGP', N'2011', N'Z51 Stingray Coupe', N'Corvette', N'Available', CAST(956736 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Stock] OFF
ALTER TABLE [dbo].[Reserve]  WITH CHECK ADD  CONSTRAINT [FK__Reserve__StockID__164452B1] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
GO
ALTER TABLE [dbo].[Reserve] CHECK CONSTRAINT [FK__Reserve__StockID__164452B1]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK__Sale__CustID__1B0907CE] FOREIGN KEY([CustID])
REFERENCES [dbo].[Customer] ([CustID])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK__Sale__CustID__1B0907CE]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK__Sale__EmpID__2F10007B] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK__Sale__EmpID__2F10007B]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK__Sale__StockID__1A14E395] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK__Sale__StockID__1A14E395]
GO
ALTER TABLE [dbo].[StockRemoved]  WITH CHECK ADD  CONSTRAINT [FK_StockRemoved_Employee] FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[StockRemoved] CHECK CONSTRAINT [FK_StockRemoved_Employee]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCustomer]
	@CustID int
AS
BEGIN
Delete from dbo.[Customer] where [CustID] = @CustID 
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEmployee]
	@EmpID int
AS
BEGIN
Delete from dbo.[Employee] where [EmpID] = @EmpID 
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteReserve]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteReserve]
	@ResID int
AS
BEGIN
Delete from dbo.[Reserve] where [ResID] = @ResID 
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteSale]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSale]
	@SaleID int
AS
BEGIN
Delete from dbo.[Sale] where [SaleID] = @SaleID 
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteStock]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStock]
	@StockID int
AS
BEGIN
Delete from dbo.[Stock] where [StockID] = @StockID 
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteStockRemoved]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStockRemoved]
	@StockRemovedID int
AS
BEGIN
Delete from dbo.[StockRemoved] where [StockRemovedID] = @StockRemovedID 
END

GO
/****** Object:  StoredProcedure [dbo].[Deletesysdiagrams]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Deletesysdiagrams]
	@diagram_id int
AS
BEGIN
Delete from dbo.[sysdiagrams] where [diagram_id] = @diagram_id 
END

GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCustomer]
	@CellNo varchar(15), 
	@CustAddress varchar(40), 
	@Email varchar(30), 
	@IDno varchar(50), 
	@Name varchar(40), 
	@Surname varchar(40),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Customer]([CellNo],[CustAddress],[Email],[IDno],[Name],[Surname])
values (@CellNo,@CustAddress,@Email,@IDno,@Name,@Surname)

set @ID = SCOPE_IDENTITY();

END

GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertEmployee]
	@Activated bit, 
	@CellNo varchar(15), 
	@Email varchar(30), 
	@EmpAddress varchar(40), 
	@IDno varchar(20), 
	@IsAdmin bit, 
	@Name varchar(40), 
	@Pass varchar(40), 
	@Salary decimal, 
	@Surname varchar(40), 
	@Username varchar(40),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Employee]([Activated],[CellNo],[Email],[EmpAddress],[IDno],[IsAdmin],[Name],[Pass],[Salary],[Surname],[Username])
values (@Activated,@CellNo,@Email,@EmpAddress,@IDno,@IsAdmin,@Name,@Pass,@Salary,@Surname,@Username)

set @ID = SCOPE_IDENTITY();

END

GO
/****** Object:  StoredProcedure [dbo].[InsertReserve]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertReserve]
	@CellNo varchar(15), 
	@Email varchar(30), 
	@IDno nvarchar(max), 
	@Name varchar(40), 
	@ResDate date, 
	@StockID int, 
	@Surname varchar(40),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Reserve]([CellNo],[Email],[IDno],[Name],[ResDate],[StockID],[Surname])
values (@CellNo,@Email,@IDno,@Name,@ResDate,@StockID,@Surname)

set @ID = SCOPE_IDENTITY();

END

GO
/****** Object:  StoredProcedure [dbo].[InsertSale]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSale]
	@CustID int, 
	@EmpID int, 
	@Paid bit, 
	@SaleDate date, 
	@StockID int,
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Sale]([CustID],[EmpID],[Paid],[SaleDate],[StockID])
values (@CustID,@EmpID,@Paid,@SaleDate,@StockID)

set @ID = SCOPE_IDENTITY();

END

GO
/****** Object:  StoredProcedure [dbo].[InsertStock]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStock]
	@Make varchar(40), 
	@Model varchar(40), 
	@Price decimal, 
	@VehicleStatus varchar(40), 
	@VehicleYear varchar(40), 
	@VIN nvarchar(max),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Stock]([Make],[Model],[Price],[VehicleStatus],[VehicleYear],[VIN])
values (@Make,@Model,@Price,@VehicleStatus,@VehicleYear,@VIN)

set @ID = SCOPE_IDENTITY();

END

GO
/****** Object:  StoredProcedure [dbo].[InsertStockRemoved]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStockRemoved]
	@DateRemoved datetime, 
	@EmpId int, 
	@VIN nvarchar(max),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[StockRemoved]([DateRemoved],[EmpId],[VIN])
values (@DateRemoved,@EmpId,@VIN)

set @ID = SCOPE_IDENTITY();

END

GO
/****** Object:  StoredProcedure [dbo].[Insertsysdiagrams]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insertsysdiagrams]
	@definition varbinary(max), 
	@name nvarchar(128), 
	@principal_id int, 
	@version int,
	@ID INT OUT
AS
BEGIN

Insert into dbo.[sysdiagrams]([definition],[name],[principal_id],[version])
values (@definition,@name,@principal_id,@version)

set @ID = SCOPE_IDENTITY();

END

GO
/****** Object:  StoredProcedure [dbo].[Sales]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sales]
AS
	SET NOCOUNT ON;
SELECT        Sale.SaleID, Sale.SaleDate, Sale.Paid, Stock.VIN, Stock.Price, Customer.Name, Customer.Surname, Customer.IDno, Sale.EmpID
FROM            Sale INNER JOIN
                         Stock ON Sale.StockID = Stock.StockID INNER JOIN
                         Customer ON Sale.CustID = Customer.CustID
ORDER BY Sale.SaleDate DESC
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomer]
	@CellNo varchar(15), 
	@CustAddress varchar(40), 
	@Email varchar(30), 
	@IDno varchar(50), 
	@Name varchar(40), 
	@Surname varchar(40), 
	@CustID int
AS
BEGIN
Update dbo.[Customer] set  [CellNo] = @CellNo , [CustAddress] = @CustAddress , [Email] = @Email , [IDno] = @IDno , [Name] = @Name , [Surname] = @Surname  where [CustID] = @CustID 
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateEmployee]
	@Activated bit, 
	@CellNo varchar(15), 
	@Email varchar(30), 
	@EmpAddress varchar(40), 
	@IDno varchar(20), 
	@IsAdmin bit, 
	@Name varchar(40), 
	@Pass varchar(40), 
	@Salary decimal, 
	@Surname varchar(40), 
	@Username varchar(40), 
	@EmpID int
AS
BEGIN
Update dbo.[Employee] set  [Activated] = @Activated , [CellNo] = @CellNo , [Email] = @Email , [EmpAddress] = @EmpAddress , [IDno] = @IDno , [IsAdmin] = @IsAdmin , [Name] = @Name , [Pass] = @Pass , [Salary] = @Salary , [Surname] = @Surname , [Username] = @Username  where [EmpID] = @EmpID 
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateReserve]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateReserve]
	@CellNo varchar(15), 
	@Email varchar(30), 
	@IDno nvarchar(max), 
	@Name varchar(40), 
	@ResDate date, 
	@StockID int, 
	@Surname varchar(40), 
	@ResID int
AS
BEGIN
Update dbo.[Reserve] set  [CellNo] = @CellNo , [Email] = @Email , [IDno] = @IDno , [Name] = @Name , [ResDate] = @ResDate , [StockID] = @StockID , [Surname] = @Surname  where [ResID] = @ResID 
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateSale]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSale]
	@CustID int, 
	@EmpID int, 
	@Paid bit, 
	@SaleDate date, 
	@StockID int, 
	@SaleID int
AS
BEGIN
Update dbo.[Sale] set  [CustID] = @CustID , [EmpID] = @EmpID , [Paid] = @Paid , [SaleDate] = @SaleDate , [StockID] = @StockID  where [SaleID] = @SaleID 
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateStock]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStock]
	@Make varchar(40), 
	@Model varchar(40), 
	@Price decimal, 
	@VehicleStatus varchar(40), 
	@VehicleYear varchar(40), 
	@VIN nvarchar(max), 
	@StockID int
AS
BEGIN
Update dbo.[Stock] set  [Make] = @Make , [Model] = @Model , [Price] = @Price , [VehicleStatus] = @VehicleStatus , [VehicleYear] = @VehicleYear , [VIN] = @VIN  where [StockID] = @StockID 
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateStockRemoved]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStockRemoved]
	@DateRemoved datetime, 
	@EmpId int, 
	@VIN nvarchar(max), 
	@StockRemovedID int
AS
BEGIN
Update dbo.[StockRemoved] set  [DateRemoved] = @DateRemoved , [EmpId] = @EmpId , [VIN] = @VIN  where [StockRemovedID] = @StockRemovedID 
END

GO
/****** Object:  StoredProcedure [dbo].[Updatesysdiagrams]    Script Date: 2016/10/30 8:00:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Updatesysdiagrams]
	@definition varbinary(max), 
	@name nvarchar(128), 
	@principal_id int, 
	@version int, 
	@diagram_id int
AS
BEGIN
Update dbo.[sysdiagrams] set  [definition] = @definition , [name] = @name , [principal_id] = @principal_id , [version] = @version  where [diagram_id] = @diagram_id 
END

GO
USE [master]
GO
ALTER DATABASE [itspRoute] SET  READ_WRITE 
GO
