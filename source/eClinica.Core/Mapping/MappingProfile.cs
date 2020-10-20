using AutoMapper;
using eClinica.Infrastructure.Data.Entities;
using eClinica.Models.Atenciones.AtencionesDelDia;

namespace eClinica.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            CreateMap<AtencionDelDiaRequestModel, AtencionDelDia>();
            CreateMap<AtencionDelDia, AtencionDelDiaModel>();
        }
    }
}
