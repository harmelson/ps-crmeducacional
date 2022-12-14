using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Repository;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("course")]
    public class CourseController : Controller
    {
        private readonly CourseRepository _repository;
        public CourseController(CourseRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Add([FromBody] CourseDTO course)
        {
            return Created("",_repository.AddCourse(course));
        }
    }
}