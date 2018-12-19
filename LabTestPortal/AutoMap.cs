using AutoMapper;
using LabTestPortal.Models;
using LabTestPortal.DataAccess.DataModels;

namespace LabTestPortal
{
    public class AutoMap
    {
        public static IMapper Mapper;
        public static void ConfigureAutoMapper() =>
            Mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<PersonDataModel, PersonModel>();                
                cfg.CreateMap<PersonModel, PersonDataModel>();
            }).CreateMapper();
    }
}
