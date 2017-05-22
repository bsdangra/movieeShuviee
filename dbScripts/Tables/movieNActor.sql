USE [movieIMDB]
GO

/****** Object:  Table [dbo].[movieNActor]    Script Date: 05/22/2017 11:24:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[movieNActor](
	[movieId] [int] NOT NULL,
	[actorId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.movieNActor] PRIMARY KEY CLUSTERED 
(
	[movieId] ASC,
	[actorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[movieNActor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.movieNActor_dbo.actors_actorId] FOREIGN KEY([actorId])
REFERENCES [dbo].[actors] ([actorId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[movieNActor] CHECK CONSTRAINT [FK_dbo.movieNActor_dbo.actors_actorId]
GO

ALTER TABLE [dbo].[movieNActor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.movieNActor_dbo.movies_movieId] FOREIGN KEY([movieId])
REFERENCES [dbo].[movies] ([movieId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[movieNActor] CHECK CONSTRAINT [FK_dbo.movieNActor_dbo.movies_movieId]
GO


