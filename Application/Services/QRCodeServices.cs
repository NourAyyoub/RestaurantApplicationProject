using Contracts.Dtos.QRCodeDtos;
using Contracts.Interfaces.IRepository;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
#pragma warning disable CA1416 // Validate platform compatibility

public class QRCodeServices : IQRCodeServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QRCodeServices(IUnitOfWork UnitOfWork, IMapper mapper)
    {
        _unitOfWork = UnitOfWork;
        _mapper = mapper;
    }

    public async Task<QRCodeDto> CreateAsync(string qrCodeText)
    {
        var qrCodeId = GenerateGuidFromString(qrCodeText);

        byte[] imageBytes = GenerateQRCodeImage(qrCodeText, qrCodeId);

        var qrCodeEntity = new QRCodeEntity(qrCodeId)
        {
            QRCodeText = qrCodeText,
            Image = imageBytes
        };

        await _unitOfWork.QRCodeRepository.CreateAsync(qrCodeEntity);

        var qrCodeDto = _mapper.Map<QRCodeDto>(qrCodeEntity);
        qrCodeDto.ImageBase64 = Convert.ToBase64String(qrCodeEntity.Image);

        return qrCodeDto;
    }

    public async Task<QRCodeDto?> GetAsync(string qrCodeText)
    {
        var id = GenerateGuidFromString(qrCodeText);
        var qrCodeEntity = await _unitOfWork.QRCodeRepository.GetAsync(id);

        if (qrCodeEntity is null)
        {
            return null;
        }

        var qrCodeDto = _mapper.Map<QRCodeDto>(qrCodeEntity);
        qrCodeDto.ImageBase64 = Convert.ToBase64String(qrCodeEntity.Image);

        return qrCodeDto;
    }

    private byte[] GenerateQRCodeImage(string qrCodeText, Guid qrCodeId)
    {
        var barcodeWriter = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Height = 250,
                Width = 250,
                Margin = 1
            }
        };

        var pixelData = barcodeWriter.Write(qrCodeText);

        using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);

        var bitmapData = bitmap.LockBits(
            new Rectangle(0, 0, pixelData.Width, pixelData.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format32bppRgb);

        try
        {
            System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }

        string fileName = $"{qrCodeId}.png";
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "qrcodes");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string filePath = Path.Combine(folderPath, fileName);

        bitmap.Save(filePath, ImageFormat.Png);

        using var stream = new MemoryStream();
        bitmap.Save(stream, ImageFormat.Png);
        return stream.ToArray();
    }


    public static Guid GenerateGuidFromString(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

            byte[] guidBytes = new byte[16];
            Array.Copy(hash, guidBytes, 16);

            return new Guid(guidBytes);
        }
    }
}
