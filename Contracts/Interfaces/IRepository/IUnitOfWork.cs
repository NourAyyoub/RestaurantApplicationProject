namespace Contracts.Interfaces.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IFoodRepository FoodRepository { get; }
        IMenuRepository MenuRepository { get; }
        IDrinkRepository DrinkRepository { get; }
        IQRCodeRepository QRCodeRepository { get; }

        Task<int> CompleteAsync();
    }
}
