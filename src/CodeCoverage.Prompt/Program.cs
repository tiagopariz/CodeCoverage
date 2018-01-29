using System;
using CodeCoverage.Domain.Entities;
using CodeCoverage.Prompt.Dto;

namespace CodeCoverage.Prompt
{
    internal class Program
    {
        private static StateDto _stateDto;
        private static CityDto _cityDto;
        private static PersonDto _personDto;

        private static void Main()
        {
            var state = new State(Guid.NewGuid(), "RS");
            var city = new City(Guid.NewGuid(), "Porto Alegre", state.Id, state);
            var person = new Person(Guid.NewGuid(), "Tiago", city.Id, state.Id, city, state);
            SetMappings(person, city, state);

            Console.WriteLine($"Name: {_personDto.Name}");
            Console.WriteLine($"City: {_personDto.CityDto.Name}");
            Console.WriteLine($"State: {_personDto.StateDto.Name}");

            Console.ReadKey();
        }

        private static void SetMappings(Person person,
                                        City city,
                                        State state)
        {
            _stateDto = new StateDto(state.Id, state.Name);
            _cityDto = new CityDto(city.Id, city.Name, city.StateId, _stateDto);
            _personDto = new PersonDto(person.Id, person.Name, person.StateId, person.CityId, _cityDto, _stateDto);
        }
    }
}