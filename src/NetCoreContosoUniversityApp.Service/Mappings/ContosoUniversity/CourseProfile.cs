using AutoMapper;
using NetCoreContosoUniversityApp.Data.Model;
using NetCoreContosoUniversityApp.Service.Dtos.ContosoUniversity;

namespace NetCoreContosoUniversityApp.Service.Mappings.ContosoUniversity
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            //CreateMap<ExampletDto, Example>()
            //    .ForMember(destination => destination.id, options => options.MapFrom(source => source.Id))
            //    .ForMember(dto => dto.some_field, opt => opt.MapFrom(src => src.SomeFiled))
            //    ;

            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}