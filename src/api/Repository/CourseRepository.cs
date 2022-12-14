using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Repository
{
    public class CourseRepository
    {
        protected readonly MyContext _context;
        public CourseRepository(MyContext context)
        {
            _context = context;
        }

        public CourseWithIdDTO AddCourse(CourseDTO course)
        {
            var addedCourse = _context.Course.Add(new Course {
                Name = course.Name
            });
            _context.SaveChanges();

            return new CourseWithIdDTO {
                Id = Convert.ToInt32(addedCourse.Property("Id").CurrentValue),
                Name = course.Name
            };
        }
    }
}