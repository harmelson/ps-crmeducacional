using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Api.Repository;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("lead")]
    public class LeadController : Controller
    {
        private readonly LeadRepository _repository;
        public LeadController(LeadRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Add([FromBody] Lead lead)
        {
            return Created("",_repository.AddLead(lead));
        }
    }
}
    
