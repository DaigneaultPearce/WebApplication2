using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Lists
    {
        public Lists()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
