USE [2C2PDemoWebAPI]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 3/26/2019 6:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerID] [numeric](10, 0) NOT NULL,
	[name] [nchar](30) NULL,
	[email] [nchar](25) NULL,
	[mobile] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 3/26/2019 6:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] NOT NULL,
	[date] [datetime] NULL,
	[amount] [decimal](18, 2) NULL,
	[currency] [nchar](3) NULL,
	[status] [nchar](25) NULL,
	[customerID] [numeric](10, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customers] ([customerID], [name], [email], [mobile]) VALUES (CAST(123456 AS Numeric(10, 0)), N'sattawee ramsri               ', N'sattawee.r@gmail.com     ', N'0123456789')
GO
INSERT [dbo].[Transaction] ([Id], [date], [amount], [currency], [status], [customerID]) VALUES (1, CAST(N'2019-03-26T00:00:00.000' AS DateTime), CAST(1000.00 AS Decimal(18, 2)), N'THB', N'Failed                   ', CAST(123456 AS Numeric(10, 0)))
GO
