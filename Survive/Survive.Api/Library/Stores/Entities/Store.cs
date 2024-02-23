using Survive.Api.Database.Core;

namespace Survive.Api.Library.Stores.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Store() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Store(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
