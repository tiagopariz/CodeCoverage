﻿using System;
using CodeCoverage.Domain.Entities;
using CodeCoverage.Prompt.Dto;

namespace CodeCoverage.Prompt
{
    internal class Program
    {
        private StateDto stateDto;
        private CityDto cityDto;
        private PersonDto personDto;

        private static void Main()
        {
            var state = new State(Guid.NewGuid(), "RS", null);
            var city = new City(Guid.NewGuid(), "Porto Alegre", state.Id, state, null);
            var person = new Person(Guid.NewGuid(), "Tiago", city.Id, state.Id, city, state);
        }

        private void Mappings(Person person,
                              City city,
                              State state)
        {
            stateDto = new StateDto(state.Id, state.Name, null);
        }
    }
}