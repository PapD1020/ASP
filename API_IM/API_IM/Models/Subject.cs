using System;
using System.Collections.Generic;

#nullable disable

namespace API_IM.Models
{
    public partial class Subject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }

        public virtual Student Student { get; set; }
    }
}
