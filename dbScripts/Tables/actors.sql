USE [movieIMDB]
GO

/****** Object:  Table [dbo].[actors]    Script Date: 05/22/2017 11:24:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[actors](
	[actorId] [int] IDENTITY(1,1) NOT NULL,
	[actorName] [nvarchar](max) NULL,
	[actorSex] [nvarchar](max) NULL,
	[actorDOB] [datetime] NOT NULL,
	[actorInfo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.actors] PRIMARY KEY CLUSTERED 
(
	[actorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


