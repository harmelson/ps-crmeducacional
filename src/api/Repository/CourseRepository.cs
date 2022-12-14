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

        public CourseDTO AddCourse(CourseDTO course)
        {
            var addedCourse = _context.Course.Add(course);
            _context.SaveChanges();

            return new CourseDTO {
                Id = Convert.ToInt32(addedCourse.Property("Id").CurrentValue),
                Name = course.Name
            };
        }
    }
}