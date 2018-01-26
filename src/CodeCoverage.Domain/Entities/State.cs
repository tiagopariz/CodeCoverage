using System;

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

        public override string ToString()
        {
            return Name;
        }
    }
}
