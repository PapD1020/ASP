using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Data
{
    public class Record
    {
        public int Id { get; set; }

        public Record()
        {

        }

        public Record(int id)
        {
            this.Id = id;
        }
    }
}
