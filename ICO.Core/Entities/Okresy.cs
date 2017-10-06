using System;
using System.Collections.Generic;

namespace ICO.Core.Entities
{
    public partial class Okresy
    {
        public Okresy()
        {
            Data = new HashSet<Data>();
        }

        public int Id { get; set; }
        public string NazevOkresu { get; set; }

        public ICollection<Data> Data { get; set; }
    }
}
