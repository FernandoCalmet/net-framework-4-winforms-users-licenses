USE [LicensesDB]
GO
/****** Object:  Table [dbo].[acquired_license]    Script Date: 11/11/2021 16:31:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[acquired_license](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[activation] [int] NOT NULL,
	[status] [varchar](10) NOT NULL,
	[mac_address] [nvarchar](50) NULL,
	[purchase_date] [date] NOT NULL,
	[expiration_date] [date] NOT NULL,
	[license_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_acquired_license] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[license]    Script Date: 11/11/2021 16:31:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[license](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_license] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 11/11/2021 16:31:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](150) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[acquired_license]  WITH CHECK ADD  CONSTRAINT [FK_acquired_license_license] FOREIGN KEY([license_id])
REFERENCES [dbo].[license] ([id])
GO
ALTER TABLE [dbo].[acquired_license] CHECK CONSTRAINT [FK_acquired_license_license]
GO
ALTER TABLE [dbo].[acquired_license]  WITH CHECK ADD  CONSTRAINT [FK_acquired_license_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[acquired_license] CHECK CONSTRAINT [FK_acquired_license_user]
GO
