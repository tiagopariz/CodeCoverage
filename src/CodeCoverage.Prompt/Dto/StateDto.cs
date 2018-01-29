using System;
using System.Collections.Generic;

namespace CodeCoverage.Prompt.Dto
{
    public class StateDto
    {
        public StateDto(Guid id,
                        string name,
                        IEnumerable<PersonDto> people)
        {
            Id = id;
            Name = name;
            People = people;
        }

        public Guid Id { get; }
        public string Name { get; }

        #region Relationships

        public virtual IEnumerable<object> People { get; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}