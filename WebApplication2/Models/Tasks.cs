using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public int Listid { get; set; }
        public string Desc { get; set; }

        public Lists List { get; set; }
    }
}
