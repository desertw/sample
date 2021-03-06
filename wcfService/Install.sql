IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExRate]') AND type in (N'U'))
DROP TABLE [dbo].[ExRate]
GO

CREATE TABLE [dbo].[ExRate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromCurCode] [nchar](3) NOT NULL,
	[ToCurCode] [nchar](3) NOT NULL,
	[AverageRate] [money] NOT NULL,
	[EndOfDayRate] [money] NOT NULL,
	[PostDate] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExRate] ADD  CONSTRAINT [PK_ExRate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Currency]') AND type in (N'U'))
DROP TABLE [dbo].[Currency]
GO
 
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Code] [nchar](3) NOT NULL,
	[Symbol] [nvarchar](10) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Currency] ADD  CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Currency] ON [dbo].[Currency] 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_ExRate] ON [dbo].[ExRate] 
(
	[FromCurCode] ASC,
	[ToCurCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExRate]  WITH CHECK ADD  CONSTRAINT [FK_ExRate_CurFrom] FOREIGN KEY([FromCurCode])
REFERENCES [dbo].[Currency] ([Code])
GO

ALTER TABLE [dbo].[ExRate] CHECK CONSTRAINT [FK_ExRate_CurFrom]
GO

ALTER TABLE [dbo].[ExRate]  WITH CHECK ADD  CONSTRAINT [FK_ExRate_CurTo] FOREIGN KEY([ToCurCode])
REFERENCES [dbo].[Currency] ([Code])
GO

ALTER TABLE [dbo].[ExRate] CHECK CONSTRAINT [FK_ExRate_CurTo]
GO

INSERT INTO dbo.currency (Country,Name,Code,Symbol) VALUES ('United States of America','Dollars','USD',N'$');
INSERT INTO dbo.currency (Country,Name,Code,Symbol) VALUES ('Australia','Dollars','AUD',N'$');
INSERT INTO dbo.currency (Country,Name,Code,Symbol) VALUES ('Canada','Dollars','CAD',N'$');    
INSERT INTO dbo.currency (Country,Name,Code,Symbol) VALUES ('China','Yuan Renminbi','CNY',N'¥');   
INSERT INTO dbo.currency (Country,Name,Code,Symbol) VALUES ('Hong Kong','Dollars','HKD',N'$');
INSERT INTO dbo.currency (Country,Name,Code,Symbol) VALUES ('Japan','Yen','JPY',N'¥');
INSERT INTO dbo.currency (Country,Name,Code,Symbol) VALUES ('United Kingdom','Pounds','GBP',N'£');

INSERT INTO [dbo].[ExRate] ([FromCurCode] ,[ToCurCode] ,[AverageRate] ,[EndOfDayRate] ,[PostDate])
     VALUES ('USD','CAD',1.15,1.21,GETDATE());
INSERT INTO [dbo].[ExRate] ([FromCurCode] ,[ToCurCode] ,[AverageRate] ,[EndOfDayRate] ,[PostDate])
     VALUES ('USD','AUD',2.11,2.25,GETDATE());
INSERT INTO [dbo].[ExRate] ([FromCurCode] ,[ToCurCode] ,[AverageRate] ,[EndOfDayRate] ,[PostDate])
     VALUES ('USD','CNY',6.15,6.21,GETDATE());
INSERT INTO [dbo].[ExRate] ([FromCurCode] ,[ToCurCode] ,[AverageRate] ,[EndOfDayRate] ,[PostDate])
     VALUES ('USD','HKD',7.15,7.21,GETDATE());
INSERT INTO [dbo].[ExRate] ([FromCurCode] ,[ToCurCode] ,[AverageRate] ,[EndOfDayRate] ,[PostDate])
     VALUES ('USD','JPY',115,121,GETDATE());
INSERT INTO [dbo].[ExRate] ([FromCurCode] ,[ToCurCode] ,[AverageRate] ,[EndOfDayRate] ,[PostDate])
     VALUES ('USD','GBP',3.15,3.21,GETDATE());