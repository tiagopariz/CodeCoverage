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
        
        #region Relationships

        public Guid? CityId { get; }
        public virtual City City { get; set; }
        public Guid? StateId { get; set; }
        public virtual State State { get; set; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}