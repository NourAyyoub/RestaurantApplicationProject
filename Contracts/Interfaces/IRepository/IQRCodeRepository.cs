namespace Contracts.Interfaces.IRepository
{
    public interface IQRCodeRepository
    {
        Task CreateAsync(QRCodeEntity qrCodeEntity);
        Task<QRCodeEntity?> GetAsync(Guid id);
    }
}
