using System;
using Task11_GraphQL.Models;
using Task11_GraphQL.Schema.Queries;

namespace Task11_GraphQL.Schema.Mutations
{
    public class CourseInputType
    {
        public string Name { get; set; }

        public Subject Subject { get; set; }

        public Guid InstructorId    { get; set; }
    }
}
