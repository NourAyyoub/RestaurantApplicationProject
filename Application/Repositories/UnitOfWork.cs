using AutoMapper;
using Contracts.Interfaces.IRepository;
using EFC;
using Infrastructure.Repositories;
//using Infrastructure.Repositories;

namespace Application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public IFoodRepository FoodRepository { get; private set; }
        public IMenuRepository MenuRepository { get; private set; }
        public IDrinkRepository DrinkRepository { get; private set; }
        public IQRCodeRepository QRCodeRepository { get; private set; }

        public UnitOfWork(AppDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

            MenuRepository = new MenuRepository();
            FoodRepository = new FoodRepository(_context,_mapper);
            DrinkRepository = new DrinkRepository(_context, _mapper);
            QRCodeRepository = new QRCodeRepository(_context);

        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
