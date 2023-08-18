using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    //anotate our controller
    [ApiController]
    [Route("api/Genders")]
    public class GendersController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper; // now ready to use repo and mapper inside our controller

        //inject the repository in the constructor
        public GendersController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
       // [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
          var genderList =  await studentRepository.GetGendersAsync();

            if(genderList == null || !genderList.Any()) 
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<Gender>>(genderList)); ;
        }
    }
}
