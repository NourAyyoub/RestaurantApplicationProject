using Contracts.Dtos.MenuDtos;

namespace Contracts.Interfaces.IServices
{
    public interface IMenuServices
    {
        Task<MenuDto> GetMenuAsync();
    }
}
