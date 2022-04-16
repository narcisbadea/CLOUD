using AutoMapper;

namespace CLOUD.Utils.Mappers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap(typeof(Medic), typeof(MedicRequest)).ReverseMap();
    }
}