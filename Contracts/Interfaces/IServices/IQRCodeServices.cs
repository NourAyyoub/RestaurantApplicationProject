using Contracts.Dtos.QRCodeDtos;

public interface IQRCodeServices
{
    Task<QRCodeDto> CreateAsync(string qrCodeText);
    Task<QRCodeDto?> GetAsync(string qrCodeText);
}
