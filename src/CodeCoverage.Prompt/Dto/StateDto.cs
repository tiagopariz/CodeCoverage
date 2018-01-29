using System;

namespace CodeCoverage.Prompt.Dto
{
    public class StateDto
    {
        public StateDto(Guid id,
                        string name)
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