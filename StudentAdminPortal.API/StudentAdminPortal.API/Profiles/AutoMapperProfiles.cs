using AutoMapper;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Profiles.AfterMaps;
using Models=StudentAdminPortal.API.Model;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles() {
            CreateMap<Model.Student, Student>()
                .ReverseMap();

            CreateMap<Model.Gender, Gender>()
                .ReverseMap();

            CreateMap<Model.Address, Address>()
                .ReverseMap();

            CreateMap<UpdateStudentRequest, Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();

        }
    }
}
