using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Task11_GraphQL.DTOs;

namespace Task11_GraphQL.Services.Courses
{
    public class CoursesRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _ContextFactory;

        public CoursesRepository(IDbContextFactory<SchoolDbContext> ContextFactory)
        {
            _ContextFactory = ContextFactory;
        }
        public async Task<CourseDTO> Create(CourseDTO course)
        {
            using(SchoolDbContext context = _ContextFactory.CreateDbContext())
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        public async Task<CourseDTO> Update(CourseDTO course)
        {
            using (SchoolDbContext context = _ContextFactory.CreateDbContext())
            {
                context.Courses.Update(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (SchoolDbContext context = _ContextFactory.CreateDbContext())
            {
                CourseDTO course = new CourseDTO()
                {
                    Id = id
                };

                context.Courses.Remove(course);
                return await context.SaveChangesAsync() > 0;

            }
        }

    }
}
