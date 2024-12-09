using Contracts.Dtos.Drink;

namespace Contracts.Dtos.QRCodeDtos
{
    public class QRCodeDto : BaseWithIdDto
    {
        public required string QRCodeText { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
