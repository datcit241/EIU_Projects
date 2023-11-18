using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string School_Id { get; set; }
        public string? Email { get; set; }
        public string? Phone_Number { get; set; }
    }
}
