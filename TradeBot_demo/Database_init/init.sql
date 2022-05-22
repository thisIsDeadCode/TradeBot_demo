USE [master]
GO
/****** Object:  Database [TradeBot_demo]    Script Date: 22.05.2022 19:34:54 ******/
CREATE DATABASE [TradeBot_demo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TradeBot_demo', FILENAME = N'C:\Users\igubanov\TradeBot_demo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TradeBot_demo_log', FILENAME = N'C:\Users\igubanov\TradeBot_demo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TradeBot_demo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TradeBot_demo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TradeBot_demo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TradeBot_demo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TradeBot_demo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TradeBot_demo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TradeBot_demo] SET ARITHABORT OFF 
GO
ALTER DATABASE [TradeBot_demo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TradeBot_demo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TradeBot_demo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TradeBot_demo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TradeBot_demo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TradeBot_demo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TradeBot_demo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TradeBot_demo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TradeBot_demo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TradeBot_demo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TradeBot_demo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TradeBot_demo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TradeBot_demo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TradeBot_demo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TradeBot_demo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TradeBot_demo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TradeBot_demo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TradeBot_demo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TradeBot_demo] SET  MULTI_USER 
GO
ALTER DATABASE [TradeBot_demo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TradeBot_demo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TradeBot_demo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TradeBot_demo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TradeBot_demo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TradeBot_demo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TradeBot_demo] SET QUERY_STORE = OFF
GO
USE [TradeBot_demo]
GO
/****** Object:  Table [dbo].[CurrencyPrice]    Script Date: 22.05.2022 19:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyPrice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BTCUSDT] [decimal](38, 20) NOT NULL,
	[ETHBTC] [decimal](38, 20) NOT NULL,
	[ETHUSDT] [decimal](38, 20) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_CurrencyPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Strategies]    Script Date: 22.05.2022 19:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Strategies](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[StartBalanceUSDT] [decimal](38, 20) NOT NULL,
	[StartBalanceBTC] [decimal](38, 20) NOT NULL,
	[StartBalanceETH] [decimal](38, 20) NOT NULL,
	[BalanceUSDT] [decimal](38, 20) NOT NULL,
	[BalanceBTC] [decimal](38, 20) NOT NULL,
	[BalanceETH] [decimal](38, 20) NOT NULL,
	[ProfitUSDT] [decimal](38, 20) NOT NULL,
	[ProfitBTC] [decimal](38, 20) NOT NULL,
	[ProfitETH] [decimal](38, 20) NOT NULL,
	[PercentProfitUSDT] [decimal](38, 20) NOT NULL,
	[PercentProfitBTC] [decimal](38, 20) NOT NULL,
	[PercentProfitETH] [decimal](38, 20) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Strategies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddCurrencyPrice]    Script Date: 22.05.2022 19:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCurrencyPrice] 
@BTCUSDT decimal(38,20),
@ETHUSDT decimal(38,20),
@ETHBTC decimal(38,20),
@date nvarchar(max)
AS
BEGIN

INSERT INTO CurrencyPrice ([Date], BTCUSDT, ETHUSDT, ETHBTC)
VALUES (@date, @BTCUSDT, @ETHUSDT, @ETHBTC)

END
GO
/****** Object:  StoredProcedure [dbo].[AddStrategyData]    Script Date: 22.05.2022 19:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStrategyData] 
@name nvarchar(max),
@startBalanceUSDT decimal(38,20),
@startBalanceBTC decimal(38,20),
@startBalanceETH decimal(38,20),

@balanceUSDT decimal(38,20),
@balanceBTC decimal(38,20),
@balanceETH decimal(38,20),

@profitUSDT decimal(38,20),
@profitBTC decimal(38,20),
@profitETH decimal(38,20),

@percentProfitUSDT decimal(38,20),
@percentProfitBTC decimal(38,20),
@percentProfitETH decimal(38,20),

@date nvarchar(max)
AS
BEGIN

INSERT INTO Strategies (Name, StartBalanceUSDT, StartBalanceBTC, StartBalanceETH,
						BalanceUSDT, BalanceBTC, BalanceETH, ProfitUSDT, ProfitBTC, ProfitETH,
						PercentProfitUSDT, PercentProfitBTC, PercentProfitETH, Date)
VALUES (@name, @startBalanceUSDT, @startBalanceBTC, @startBalanceETH,
		@balanceUSDT, @balanceBTC, @balanceETH, @profitUSDT, @profitBTC, @profitETH, 
		@percentProfitUSDT, @percentProfitBTC, @percentProfitETH, @date)

END
GO
USE [master]
GO
ALTER DATABASE [TradeBot_demo] SET  READ_WRITE 
GO
