using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
   public abstract class FoodDrinkBaseEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
