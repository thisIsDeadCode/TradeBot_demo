USE [TradeBot_demo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyPrice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BTCUSDT] [decimal](38, 20) NOT NULL,
	[ETHBTC] [decimal](38, 20) NOT NULL,
	[ETHUSDT] [decimal](38, 20) NOT NULL,
	[BNBBTC] [decimal](38, 20) NOT NULL,
	[BNBUSDT] [decimal](38, 20) NOT NULL,
	[BNBETH] [decimal](38, 20) NOT NULL,
	[LTCBTC] [decimal](38, 20) NOT NULL,
	[LTCUSDT] [decimal](38, 20) NOT NULL,
	[LTCBNB] [decimal](38, 20) NOT NULL,
	[LTCETH] [decimal](38, 20) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_CurrencyPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Strategies](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[NameCurrency1] [nvarchar](10) NULL,
	[NameCurrency2] [nvarchar](10) NULL,
	[NameCurrency3] [nvarchar](10) NULL,
	[StartBalanceCurrency1] [decimal](38, 20) NOT NULL,
	[StartBalanceCurrency2] [decimal](38, 20) NOT NULL,
	[StartBalanceCurrency3] [decimal](38, 20) NOT NULL,
	[BalanceCurrency1] [decimal](38, 20) NOT NULL,
	[BalanceCurrency2] [decimal](38, 20) NOT NULL,
	[BalanceCurrency3] [decimal](38, 20) NOT NULL,
	[ProfitCurrency1] [decimal](38, 20) NOT NULL,
	[ProfitCurrency2] [decimal](38, 20) NOT NULL,
	[ProfitCurrency3] [decimal](38, 20) NOT NULL,
	[PercentProfitCurrency1] [decimal](38, 20) NOT NULL,
	[PercentProfitCurrency2] [decimal](38, 20) NOT NULL,
	[PercentProfitCurrency3] [decimal](38, 20) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Strategies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCurrencyPrice] 
@BTCUSDT decimal(38,20),
@ETHUSDT decimal(38,20),
@ETHBTC decimal(38,20),
@BNBBTC decimal(38,20),
@BNBUSDT decimal(38,20),
@BNBETH decimal(38,20),
@LTCBTC decimal(38,20),
@LTCUSDT decimal(38,20),
@LTCBNB decimal(38,20),
@LTCETH decimal(38,20),
@date nvarchar(max)
AS
BEGIN

INSERT INTO CurrencyPrice ([Date], BTCUSDT, ETHUSDT, ETHBTC,
							BNBBTC, BNBUSDT, BNBETH,
							LTCBTC, LTCUSDT, LTCBNB,
							LTCETH)
VALUES (@date, @BTCUSDT, @ETHUSDT, @ETHBTC,
		@BNBBTC, @BNBUSDT, @BNBETH,
		@LTCBTC, @LTCUSDT, @LTCBNB,
		@LTCETH)

END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStrategyData] 
@name nvarchar(max),

@nameCurrency1 nvarchar (10) NULL,
@nameCurrency2 nvarchar (10) NULL,
@nameCurrency3 nvarchar (10) NULL,

@startBalanceCurrency1 decimal(38,20),
@startBalanceCurrency2 decimal(38,20),
@startBalanceCurrency3 decimal(38,20),

@balanceCurrency1 decimal(38,20),
@balanceCurrency2 decimal(38,20),
@balanceCurrency3 decimal(38,20),

@profitCurrency1 decimal(38,20),
@profitCurrency2 decimal(38,20),
@profitCurrency3 decimal(38,20),

@percentProfitCurrency1 decimal(38,20),
@percentProfitCurrency2 decimal(38,20),
@percentProfitCurrency3 decimal(38,20),

@date nvarchar(max)
AS
BEGIN

INSERT INTO Strategies (Name, StartBalanceCurrency1, StartBalanceCurrency2, StartBalanceCurrency3,
						NameCurrency1, NameCurrency2, NameCurrency3, 
						BalanceCurrency1, BalanceCurrency2, BalanceCurrency3, ProfitCurrency1, ProfitCurrency2, ProfitCurrency3,
						PercentProfitCurrency1, PercentProfitCurrency2, PercentProfitCurrency3, Date)
VALUES (@name, @startBalanceCurrency1, @startBalanceCurrency2, @startBalanceCurrency3,
		@nameCurrency1, @nameCurrency2, @nameCurrency3,
		@balanceCurrency1, @balanceCurrency2, @balanceCurrency3, @profitCurrency1, @profitCurrency2, @profitCurrency3, 
		@percentProfitCurrency1, @percentProfitCurrency2, @percentProfitCurrency3, @date)

END
GO
