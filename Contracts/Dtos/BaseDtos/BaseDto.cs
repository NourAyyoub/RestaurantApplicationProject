using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos.BaseDtos
{
    public abstract class BaseDto
    {
        public required string Name { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
