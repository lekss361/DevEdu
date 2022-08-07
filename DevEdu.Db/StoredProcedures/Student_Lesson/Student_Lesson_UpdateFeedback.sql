﻿CREATE PROCEDURE dbo.Student_Lesson_UpdateFeedback
	@UserId int,
	@LessonId int,
	@Feedback nvarchar(500)
	
AS
BEGIN
	UPDATE dbo.Student_Lesson
	SET
	Feedback = @Feedback  
	WHERE UserId = @UserId AND LessonId = @LessonId
END