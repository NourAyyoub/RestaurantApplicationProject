using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class QRCodeController : ControllerBase
{
    private readonly IQRCodeServices _qrCodeServices;
    private readonly ILogger<QRCodeController> _logger;

    public QRCodeController(IQRCodeServices qrCodeServices, ILogger<QRCodeController> logger)
    {
        _qrCodeServices = qrCodeServices;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateQRCode(string QRCodeText)
    {
        if (string.IsNullOrWhiteSpace(QRCodeText))
        {
            _logger.LogWarning("QR Code text is empty or null.");
            return BadRequest("QR Code text cannot be empty.");
        }

        _logger.LogInformation("Creating QR Code for text: {QRCodeText}", QRCodeText);

        try
        {
            var qrCode = await _qrCodeServices.CreateAsync(QRCodeText);
            _logger.LogInformation("QR Code created successfully with ID: {QRCodeId}", qrCode.Id);
            return Ok(qrCode);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating QR Code for text: {QRCodeText}", QRCodeText);
            return StatusCode(500, "An internal error occurred while creating the QR Code.");
        }
    }

    [HttpGet("{qrCodeText}")]
    public async Task<IActionResult> GetQRCode(string qrCodeText)
    {
        _logger.LogInformation("Fetching QR Code for text: {QRCodeText}", qrCodeText);

        try
        {
            var qrCode = await _qrCodeServices.GetAsync(qrCodeText);

            if (qrCode is null)
            {
                _logger.LogWarning("QR Code not found for text: {QRCodeText}", qrCodeText);
                return NotFound("QR Code not found.");
            }

            _logger.LogInformation("QR Code fetched successfully for text: {QRCodeText}", qrCodeText);
            return Ok(qrCode);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching QR Code for text: {QRCodeText}", qrCodeText);
            return StatusCode(500, "An internal error occurred while fetching the QR Code.");
        }
    }
}
