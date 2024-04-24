using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; } = true;
    }
}
