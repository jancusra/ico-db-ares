using ICO.Core.Entities;
using ICO.Services.IcoServices;
using ICO.Web.Models;
using AutoMapper;

namespace ICO.Web
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("MyProfile") { }

        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<Data, IcoViewModel>()
                .ForMember(dest => dest.Obec,
                           opts => opts.MapFrom(src => src.ObecNavigation.NazevObce))
                .ForMember(dest => dest.Okres,
                           opts => opts.MapFrom(src => src.OkresNavigation.NazevOkresu));

            CreateMap<Zaznam, IcoViewModel>()
                .ForMember(dest => dest.ObchodniFirma,
                           opts => opts.MapFrom(src => src.Obchodni_firma))
                .ForMember(dest => dest.Ico,
                           opts => opts.MapFrom(src => src.ICO))
                .ForMember(dest => dest.IdAdresy,
                           opts => opts.MapFrom(src => src.Identifikace.Adresa_ARES.ID_adresy))
                .ForMember(dest => dest.KodStatu,
                           opts => opts.MapFrom(src => src.Identifikace.Adresa_ARES.Kod_statu))
                .ForMember(dest => dest.Okres,
                           opts => opts.MapFrom(src => src.Identifikace.Adresa_ARES.Nazev_okresu))
                .ForMember(dest => dest.Obec,
                           opts => opts.MapFrom(src => src.Identifikace.Adresa_ARES.Nazev_obce))
                .ForMember(dest => dest.Ulice,
                           opts => opts.MapFrom(src => src.Identifikace.Adresa_ARES.Nazev_ulice))
                .ForMember(dest => dest.CisloDomovni,
                           opts => opts.MapFrom(src => src.Identifikace.Adresa_ARES.Cislo_domovni))
                .ForMember(dest => dest.CisloOrientacni,
                           opts => opts.MapFrom(src => src.Identifikace.Adresa_ARES.Cislo_orientacni))
                .ForMember(dest => dest.Psc,
                           opts => opts.MapFrom(src => src.Identifikace.Adresa_ARES.PSC));
        }
    }
}
