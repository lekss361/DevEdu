﻿CREATE TABLE [GroupStatus] (
	Id int NOT NULL,
	Name nvarchar(50) NOT NULL,
  CONSTRAINT [PK_GROUPSTATUS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)