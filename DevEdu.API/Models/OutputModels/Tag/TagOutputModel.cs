﻿using System.ComponentModel;

namespace DevEdu.API.Models
{
    public class TagOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}