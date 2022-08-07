﻿using System.Collections.Generic;

namespace DevEdu.DAL.Models
{
    public class CourseDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GroupDto> Groups { get; set; }
        public List<TopicDto> Topics { get; set; }
        public List<MaterialDto> Materials { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}