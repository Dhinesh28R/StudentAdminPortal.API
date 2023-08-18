using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    //anotate out controller
    [ApiController]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        //use our services in controller
        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        //GET method
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
           var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<Student>>(students));

             

          /*  var domainModelStudents = new List<Student>();

            foreach (var student in students)
            {
                domainModelStudents.Add(new Student()
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImageUrl = student.ProfileImageUrl,
                    GenderID = student.GenderID,
                    Address = new Address()
                    {
                        Id = student.Address.Id,
                        PhysicalAddress = student.Address.PhysicalAddress,
                        PostalAddress = student.Address.PostalAddress
                    },
                    Gender = new Gender()
                    {
                        Id = student.Gender.Id,
                        Description = student.Gender.Description

                    }
                });
            }  */
           // return Ok(domainModelStudents);
        }


        [HttpGet]
        //[Route("GetStudentById/{studentId:guid}")]
        [Route("{studentId:guid}"), ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            //Fetch student details by id
            var student = await studentRepository.GetStudentAsync(studentId);

            //return 
            if(student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Student>(student));
        }


    }
}
