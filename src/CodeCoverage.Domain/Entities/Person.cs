using System;

namespace CodeCoverage.Domain.Entities
{
    public class Person
    {
        public Person(Guid id, string name, Guid? stateId = null, Guid? cityId = null)
        {
            Id = id;
            Name = name;
            StateId = stateId;
            CityId = cityId;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid? StateId { get; }
        public Guid? CityId { get; }
    }
}