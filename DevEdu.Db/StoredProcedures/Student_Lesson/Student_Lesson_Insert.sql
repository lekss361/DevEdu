﻿CREATE PROCEDURE dbo.Student_Lesson_Insert
	@UserId int,
	@LessonId int
AS
BEGIN
	INSERT INTO dbo.Student_Lesson   (UserId, LessonId)
	VALUES (@UserId,@LessonId)
END