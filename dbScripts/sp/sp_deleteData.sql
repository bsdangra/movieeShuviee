USE [movieIMDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteData]    Script Date: 05/22/2017 11:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deleteData] 
	-- Add the parameters for the stored procedure here
	@movieId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from movieNActor where movieId = @movieId
	delete from movieNProducer where movieId = @movieId
	delete from movies where movieId = @movieId
END
