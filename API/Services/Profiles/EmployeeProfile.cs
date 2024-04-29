using API.DTOs.Requests;
using API.Entities;
using AutoMapper;

namespace API.Services.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeRequest, Employee>();
        }
    }
}