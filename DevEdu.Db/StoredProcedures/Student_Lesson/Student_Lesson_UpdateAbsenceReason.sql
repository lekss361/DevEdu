﻿CREATE PROCEDURE dbo.Student_Lesson_UpdateAbsenceReason
	@UserId int,
	@LessonId int,
	@AbsenceReason nvarchar(500)
	
AS
BEGIN
	UPDATE dbo.Student_Lesson   
	SET
	AbsenceReason = @AbsenceReason  
	WHERE UserId = @UserId AND LessonId = @LessonId
END