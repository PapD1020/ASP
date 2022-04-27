using System;
using System.Collections.Generic;

#nullable disable

namespace API_IM.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
