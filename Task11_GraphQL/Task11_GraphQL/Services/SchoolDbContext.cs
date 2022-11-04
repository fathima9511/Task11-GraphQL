using Microsoft.EntityFrameworkCore;
using Task11_GraphQL.DTOs;

namespace Task11_GraphQL.Services
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options) { }
        public DbSet<CourseDTO> Courses { get; set; }

        public DbSet<InstructorDTO> Instructors { get; set; }
        public DbSet<StudentDTO> Students { get; set; }

        
    }
}
