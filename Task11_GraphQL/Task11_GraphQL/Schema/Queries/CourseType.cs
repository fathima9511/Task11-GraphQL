using HotChocolate;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Task11_GraphQL.Models;

namespace Task11_GraphQL.Schema.Queries
{
    
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }

        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }


    }
}
