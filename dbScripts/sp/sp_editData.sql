USE [movieIMDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_editData]    Script Date: 05/22/2017 11:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_editData]
	-- Add the parameters for the stored procedure here
	@movieId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from movies where movieId = @movieId
	
	select * from actors 
	where actorId In 
	(select actorId from movieNActor where movieId = @movieId)
	
	select * from producers
	where producerId In
	(select producerId from movieNProducer where movieId = @movieId)
END
