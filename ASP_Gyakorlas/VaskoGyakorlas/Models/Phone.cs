using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace VaskoGyakorlas.Models
{
    public partial class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int Coworkerid { get; set; }

        [JsonIgnore]
        public virtual Coworker Coworker { get; set; }
    }
}
