USE [movieIMDB]
GO

/****** Object:  Table [dbo].[producers]    Script Date: 05/22/2017 11:24:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[producers](
	[producerId] [int] IDENTITY(1,1) NOT NULL,
	[producerName] [nvarchar](max) NULL,
	[producerSex] [nvarchar](max) NULL,
	[producerDOB] [datetime] NOT NULL,
	[producerInfo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.producers] PRIMARY KEY CLUSTERED 
(
	[producerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
