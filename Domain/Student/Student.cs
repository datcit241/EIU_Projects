using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Student
{
    public class Student : Person.Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string School_Id { get; set; }
    }
}
