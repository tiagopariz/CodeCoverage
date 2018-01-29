using System;
using System.Collections.Generic;

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

        #region Relationships

        public Guid StateId { get; set; }
        public virtual State State { get; set; }
        public virtual IEnumerable<Person> Person { get; set; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}