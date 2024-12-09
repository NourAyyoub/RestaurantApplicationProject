using Contracts.Interfaces.IRepository;
using EFC;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class QRCodeRepository : IQRCodeRepository
    {
        private readonly AppDbContext _context;

        public QRCodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(QRCodeEntity qrCodeEntity)
        {
            await _context.QRCodes.AddAsync(qrCodeEntity);
            await _context.SaveChangesAsync();

        }

        public async Task<QRCodeEntity?> GetAsync(Guid id)
        {
            return await _context.QRCodes.FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
