﻿CREATE PROCEDURE dbo.Lesson_Topic_Insert
	@TopicId int,
	@LessonId int
AS
BEGIN
	INSERT INTO dbo.Lesson_Topic (TopicId, LessonId)
	VALUES (@TopicId, @LessonId)
END
