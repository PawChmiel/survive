using System.ComponentModel.DataAnnotations.Schema;

namespace Survive.Api.Library.Products.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private Product()
        {

        }
        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
