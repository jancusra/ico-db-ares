using System;
using System.Collections.Generic;

namespace ICO.Core.Entities
{
    public partial class Data
    {
        public int Id { get; set; }
        public string ObchodniFirma { get; set; }
        public int Ico { get; set; }
        public int IdAdresy { get; set; }
        public int KodStatu { get; set; }
        public int Okres { get; set; }
        public int Obec { get; set; }
        public string Ulice { get; set; }
        public int CisloDomovni { get; set; }
        public string CisloOrientacni { get; set; }
        public int Psc { get; set; }

        public Obce ObecNavigation { get; set; }
        public Okresy OkresNavigation { get; set; }
    }
}
