using System;

namespace CodeCoverage.Prompt.Dto
{
    public class PersonDto
    {
        public PersonDto(Guid id,
                         string name,
                         Guid? stateId,
                         Guid? cityId,
                         CityDto cityDto,
                         StateDto stateDto)
        {
            Id = id;
            Name = name;
            StateId = stateId;
            CityId = cityId;
            CityDto = cityDto;
            StateDto = stateDto;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid? CityId { get; }
        public Guid? StateId { get; set; }

        #region Relationships

        public virtual CityDto CityDto { get; }
        public virtual StateDto StateDto { get; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}