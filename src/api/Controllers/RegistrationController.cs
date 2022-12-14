using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Repository;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("registration")]
    public class RegistrationController : Controller
    {
        private readonly RegistrationRepository _repository;
        public RegistrationController(RegistrationRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Add([FromBody] RegistrationDTO registration)
        {
            var createdRegistration = _repository.AddRegistration(registration);
            
            return createdRegistration == null
            ? BadRequest(new {message = "CourseId e/ou LeadId inválido ou inexistente"})
            : Created("", createdRegistration);
        }
    }
}