﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.School;

namespace Domain.Student
{
    public class Student : Person.Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public School.School  School { get; set; }
    }
}
