﻿CREATE TABLE [Tag] (
	Id int NOT NULL IDENTITY(1,1),
	Name nvarchar(50) NOT NULL,
	IsDeleted bit NOT NULL DEFAULT '0',
  CONSTRAINT [PK_TAG] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)