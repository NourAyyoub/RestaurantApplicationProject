using Domain.Entities;

public class QRCodeEntity : BaseEntity
{
    public byte[] Image { get; set; }
    public string QRCodeText { get; set; }

    private QRCodeEntity() { }

    public QRCodeEntity(Guid? customId)
    {
        if (customId.HasValue)
        {
            SetId(customId.Value);
        }
    }
}
