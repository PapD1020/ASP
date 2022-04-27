using System;
using System.Collections.Generic;

#nullable disable

namespace EszkozNyilvantartoApi.Models
{
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int PhoneCoworkerId { get; set; }

        public virtual Coworker PhoneCoworker { get; set; }
    }
}
