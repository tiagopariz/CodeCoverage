using System;

namespace CodeCoverage.Domain.Entities
{
    public class City
    {
        public City(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
