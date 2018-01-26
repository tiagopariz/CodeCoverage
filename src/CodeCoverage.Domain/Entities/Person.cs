using System;

namespace CodeCoverage.Domain.Entities
{
    public class Person
    {
        public Person(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}