using System;
using System.Collections.Generic;

#nullable disable

namespace EszkozNyilvantartoApi.Models
{
    public partial class Notebook
    {
        public int NotebookId { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int NotebookCoworkerId { get; set; }

        public virtual Coworker NotebookCoworker { get; set; }
    }
}
