using System.Xml.Serialization;

namespace ICO.Services.IcoServices
{
    [XmlRoot("Ares_odpovedi")]
    public class Ares_odpovedi
    {
        [XmlElement("Odpoved")]
        public Odpoved Odpoved { get; set; }
    }

    public class Odpoved
    {
        [XmlElement("Pocet_zaznamu")]
        public int Pocet_zaznamu { get; set; }

        [XmlElement("Typ_vyhledani")]
        public string Typ_vyhledani { get; set; }

        [XmlElement("Zaznam")]
        public Zaznam Zaznam { get; set; }
    }

    public class Zaznam
    {
        [XmlElement("Shoda_ICO")]
        public object Shoda_ICO { get; set; }

        [XmlElement("Vyhledano_dle")]
        public string Vyhledano_dle { get; set; }

        [XmlElement("Typ_registru")]
        public object Typ_registru { get; set; }

        [XmlElement("Datum_vzniku")]
        public string Datum_vzniku { get; set; }

        [XmlElement("Datum_platnosti")]
        public string Datum_platnosti { get; set; }

        [XmlElement("Pravni_forma")]
        public object Pravni_forma { get; set; }

        [XmlElement("Obchodni_firma")]
        public string Obchodni_firma { get; set; }

        [XmlElement("ICO")]
        public int ICO { get; set; }

        [XmlElement("Identifikace")]
        public Identifikace Identifikace { get; set; }

        [XmlElement("Kod_FU")]
        public int Kod_FU { get; set; }

        [XmlElement("Priznaky_subjektu")]
        public string Priznaky_subjektu { get; set; }
    }

    public class Identifikace
    {
        [XmlElement("Adresa_ARES")]
        public AdresaAres Adresa_ARES { get; set; }
    }

    public class AdresaAres
    {
        [XmlElement("ID_adresy")]
        public int ID_adresy { get; set; }

        [XmlElement("Kod_statu")]
        public int Kod_statu { get; set; }

        [XmlElement("Nazev_okresu")]
        public string Nazev_okresu { get; set; }

        [XmlElement("Nazev_obce")]
        public string Nazev_obce { get; set; }

        [XmlElement("Nazev_casti_obce")]
        public string Nazev_casti_obce { get; set; }

        [XmlElement("Nazev_mestske_casti")]
        public string Nazev_mestske_casti { get; set; }

        [XmlElement("Nazev_ulice")]
        public string Nazev_ulice { get; set; }

        [XmlElement("Cislo_domovni")]
        public int Cislo_domovni { get; set; }

        [XmlElement("Typ_cislo_domovni")]
        public int Typ_cislo_domovni { get; set; }

        [XmlElement("Cislo_orientacni")]
        public string Cislo_orientacni { get; set; }

        [XmlElement("PSC")]
        public int PSC { get; set; }

        [XmlElement("Adresa_UIR")]
        public object Adresa_UIR { get; set; }
    }
}
