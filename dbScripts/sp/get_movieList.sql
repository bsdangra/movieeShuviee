USE [movieIMDB]
GO
/****** Object:  StoredProcedure [dbo].[get_movieList]    Script Date: 05/22/2017 11:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_movieList]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select movies.movieId, movies.movieName, actors.actorName, movies.path as imagePath,
	movies.plot as moviePlot, movies.yor into #Table1 from movieNActor  
	inner join actors On movieNActor.actorId = actors.actorId  
	inner join movies on movieNActor.movieId = movies.movieId   
	order by movieNActor.movieId
	
	select movies.movieName, producers.producerName
	into #Table2 from movieNProducer
	inner join movies on movieNProducer.movieId = movies.movieId
	inner join producers on movieNProducer.producerId = producers.producerId	
	
	
	SELECT movieId, movieName, imagePath, moviePlot, yor, STUFF(( SELECT  ','+ actorName FROM #Table1 a  
	WHERE b.movieName = a.movieName FOR XML PATH('')),1 ,1, '')  actorName into #Table3
	FROM #Table1 b  
	GROUP BY movieId, movieName, imagePath, moviePlot, yor;  
		
	select #Table3.movieId, #Table3.movieName, #Table3.actorName, #Table2.producerName, #Table3.moviePlot,
	#Table3.imagePath, #Table3.yor
	from #Table3
	inner join #Table2 on #Table3.movieName = #Table2.movieName
END
