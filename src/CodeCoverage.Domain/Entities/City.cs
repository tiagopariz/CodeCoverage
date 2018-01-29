using System;

namespace CodeCoverage.Domain.Entities
{
    public class City
    {
        public City(Guid id,
                    string name,
                    Guid stateId,
                    State state)
        {
            Id = id;
            Name = name;
            StateId = stateId;
            State = state;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid StateId { get; }

        #region Relationships

        public virtual State State { get; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}