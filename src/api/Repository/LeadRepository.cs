using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Repository
{
    public class LeadRepository
    {
        protected readonly MyContext _context;
        public LeadRepository(MyContext context)
        {
            _context = context;
        }

        public LeadDTO AddLead(Lead lead)
        {
            var addedLead = _context.Lead.Add(lead);
            _context.SaveChanges();

            return new LeadDTO {
                Id = Convert.ToInt32(addedLead.Property("Id").CurrentValue),
                CPF = lead.CPF,
                Name = lead.Name
            };
        }
    }
}
