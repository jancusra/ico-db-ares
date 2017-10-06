using System;
using System.Collections.Generic;

namespace ICO.Core.Entities
{
    public partial class Obce
    {
        public Obce()
        {
            Data = new HashSet<Data>();
        }

        public int Id { get; set; }
        public string NazevObce { get; set; }

        public ICollection<Data> Data { get; set; }
    }
}
