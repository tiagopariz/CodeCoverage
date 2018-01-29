using System;

namespace CodeCoverage.Prompt.Dto
{
    public class CityDto
    {
        public CityDto(Guid id,
                       string name,
                       Guid stateId,
                       StateDto stateDto)
        {
            Id = id;
            Name = name;
            StateId = stateId;
            State = stateDto;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid StateId { get; }

        #region Relationships

        public virtual StateDto State { get; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}