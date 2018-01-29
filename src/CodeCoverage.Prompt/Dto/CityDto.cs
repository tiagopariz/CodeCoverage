using System;
using System.Collections.Generic;

namespace CodeCoverage.Prompt.Dto
{
    public class CityDto
    {
        public CityDto(Guid id,
                       string name,
                       Guid stateId,
                       StateDto stateDto,
                       IEnumerable<PersonDto> people)
        {
            Id = id;
            Name = name;
            StateId = stateId;
            State = stateDto;
            People = people;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid StateId { get; }

        #region Relationships

        public virtual StateDto State { get; }
        public virtual IEnumerable<PersonDto> People { get; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}