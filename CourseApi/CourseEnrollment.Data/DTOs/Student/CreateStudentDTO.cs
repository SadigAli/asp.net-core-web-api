﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnrollment.Data.DTOs.Student
{
    public class CreateStudentDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StudentId { get; set; }
    }
}
