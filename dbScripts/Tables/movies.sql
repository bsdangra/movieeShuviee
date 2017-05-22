USE [movieIMDB]
GO

/****** Object:  Table [dbo].[movies]    Script Date: 05/22/2017 11:24:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[movies](
	[movieId] [int] IDENTITY(1,1) NOT NULL,
	[movieName] [nvarchar](max) NULL,
	[yor] [int] NOT NULL,
	[plot] [nvarchar](max) NULL,
	[path] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.movies] PRIMARY KEY CLUSTERED 
(
	[movieId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


