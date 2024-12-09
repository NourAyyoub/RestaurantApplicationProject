using Contracts.Dtos.BaseDtos;

namespace Contracts.Dtos.Drink
{
    public abstract class BaseWithIdDto: BaseDto
    {
        public Guid Id { get; set; }
    }
}
