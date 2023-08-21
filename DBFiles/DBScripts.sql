DROP TABLE Agreement
GO
DROP TABLE Product
GO
DROP TABLE ProductGroup
GO

CREATE TABLE [dbo].[ProductGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupDescription] [varchar](100) NULL,
	[GroupCode] [varchar](50) NULL,
	[Active] [bit] NULL,
	CONSTRAINT UC_ProductGroup UNIQUE (GroupCode),
 CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductGroupId] [int] NOT NULL,
	[ProductDescription] [varchar](100) NOT NULL,
	[ProductNumber] [varchar](50) NOT NULL,
	[Price] [money] NULL,
	[Active] [bit] NOT NULL,
	CONSTRAINT UC_Product UNIQUE (ProductNumber),
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_ProductGroup_Product] FOREIGN KEY([ProductGroupId])
REFERENCES [dbo].[ProductGroup] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_ProductGroup_Product]
GO


CREATE TABLE [dbo].[Agreement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](100) NOT NULL,
	[ProductGroupId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NULL,
	[ProductPrice] [money] NULL,
	[NewPrice] [money] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Agreement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [FK_Product_Agreement] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [FK_Product_Agreement]
GO

ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [FK_ProductGroup_Agreement] FOREIGN KEY([ProductGroupId])
REFERENCES [dbo].[ProductGroup] ([Id])
GO

ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [FK_ProductGroup_Agreement]
GO
