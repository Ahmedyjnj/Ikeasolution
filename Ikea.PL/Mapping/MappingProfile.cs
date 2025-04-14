using AutoMapper;
using Ikea.BLL.Dto_s.Departments;
using Ikea.PL.ViewModel;
namespace Ikea.PL.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<DepartmentVM, CreatedDepartmentDto>().ReverseMap();
                //.ForMember(dest =>dest.name ,config =>config.MapFrom(src=>src.name));
            //we will use this column if name is different so we now will use 
            //a reverse map

            CreateMap<DepartmentDetailsDto,DepartmentVM>().ReverseMap();

            CreateMap<DepartmentVM,UpdatedDepartmentDto>().ReverseMap();











        }
    }
    
}
