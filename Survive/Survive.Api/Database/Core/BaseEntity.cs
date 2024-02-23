using System.ComponentModel.DataAnnotations.Schema;

namespace Survive.Api.Database.Core
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Edited { get; set; }

        public BaseEntity()
        {
            Created = DateTime.UtcNow;
        }
    }
}
