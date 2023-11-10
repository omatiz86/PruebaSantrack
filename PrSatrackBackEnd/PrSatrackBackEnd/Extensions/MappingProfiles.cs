using AutoMapper;
using BnSatrack.Api.DTO;
using BnSatrack.Core.Entites;

namespace BnSatrack.Api.Extensions
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ClienteDto, Cliente>();               
            CreateMap<Cliente, ClienteDto>();
                
            CreateMap<ProductoDto, Producto>();
            CreateMap<Producto, ProductoDto>();

            CreateMap<Transacciones, TransaccionDto>();
            CreateMap<TransaccionDto, Transacciones>();

            CreateMap<Ubicacion, UbicacionDto>(); 
            CreateMap<UbicacionDto, Ubicacion>(); 

            
            //CreateMap<List<Ubicacion>, List<UbicacionDto>>();            
            //CreateMap<List<UbicacionDto>, List<Ubicacion>>();


        }
    }
}
