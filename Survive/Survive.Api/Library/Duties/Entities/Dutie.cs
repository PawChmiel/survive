using Survive.Api.Database.Core;

namespace Survive.Api.Library.Duties.Entities
{
    public class Dutie : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Dutie() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Dutie(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
