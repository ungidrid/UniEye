﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniEye.Shared.Domain;

namespace UniEye.Modules.Students.Core.Models
{
    public class Group : IDomainModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StudyFormId { get; set; }
        public StudyForm StudyForm { get; set; }
        
        public ICollection<Student> Students { get; set; }
    }
}
