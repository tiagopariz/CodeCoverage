using System;

namespace CodeCoverage.Domain.Entities
{
    public class Person
    {
        public Person(Guid id,
                      string name,
                      Guid? cityId,
                      Guid? stateId,
                      City city,
                      State state)
        {
            Id = id;
            Name = name;
            CityId = cityId;
            StateId = stateId;
            City = city;
            State = state;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid? CityId { get; }
        public Guid? StateId { get; set; }

        #region Relationships

        public virtual City City { get; }
        public virtual State State { get; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}