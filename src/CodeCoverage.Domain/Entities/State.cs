using System;
using System.Collections.Generic;

namespace CodeCoverage.Domain.Entities
{
    public class State
    {
        public State(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        #region Relationships

        public virtual IEnumerable<Person> Person { get; set; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}