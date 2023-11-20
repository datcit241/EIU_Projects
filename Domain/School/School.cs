using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.School
{
    public class School
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string current_milestone_id { get; set; }
    }
}
