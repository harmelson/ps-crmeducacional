using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Repository
{
    public class RegistrationRepository
    {
        protected readonly MyContext _context;
        public RegistrationRepository(MyContext context)
        {
            _context = context;
        }

        public Registration AddRegistration(RegistrationDTO registration)
        {
            try
            {
                _context.Registration.Add(new Registration {
                    IdCourse = registration.IdCourse,
                    IdLead = registration.IdLead
                });
                _context.SaveChanges();

                return new Registration {
                    IdCourse = registration.IdCourse,
                    IdLead = registration.IdLead
                };
            }
            catch (DbUpdateException exception)
            {
                return null!;
                throw exception;
            }
        }
    }
}