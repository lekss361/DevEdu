﻿namespace DevEdu.API.Models
{
    public class StudentAnswerOnTaskInfoOutputModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Answer { get; set; }
        public UserInfoShortOutputModel Student { get; set; }
    }
}