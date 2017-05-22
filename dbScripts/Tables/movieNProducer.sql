USE [movieIMDB]
GO

/****** Object:  Table [dbo].[movieNProducer]    Script Date: 05/22/2017 11:24:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[movieNProducer](
	[movieId] [int] NOT NULL,
	[producerId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.movieNProducer] PRIMARY KEY CLUSTERED 
(
	[movieId] ASC,
	[producerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[movieNProducer]  WITH CHECK ADD  CONSTRAINT [FK_dbo.movieNProducer_dbo.movies_movieId] FOREIGN KEY([movieId])
REFERENCES [dbo].[movies] ([movieId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[movieNProducer] CHECK CONSTRAINT [FK_dbo.movieNProducer_dbo.movies_movieId]
GO

ALTER TABLE [dbo].[movieNProducer]  WITH CHECK ADD  CONSTRAINT [FK_dbo.movieNProducer_dbo.producers_producerId] FOREIGN KEY([producerId])
REFERENCES [dbo].[producers] ([producerId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[movieNProducer] CHECK CONSTRAINT [FK_dbo.movieNProducer_dbo.producers_producerId]
GO


