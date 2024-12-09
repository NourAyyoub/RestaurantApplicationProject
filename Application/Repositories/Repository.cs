using Domain.Entities;
using AutoMapper;
using Contracts.Dtos.Drink;
using EFC;
using Application.Repositories.Operations;
using Contracts.Interfaces.IRepository;

public class Repository<TEntity, TDto, TCreateDto, TUpdateDto> 
    : IRepository<TEntity, TDto, TCreateDto, TUpdateDto>
    where TEntity : FoodDrinkBaseEntity
    where TDto : BaseWithIdDto
    where TCreateDto : CreateBaseDto
    where TUpdateDto : UpdateBaseDto
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    private readonly GetRepository<TEntity, TDto> _getRepository;
    private readonly DeleteRepository<TEntity> _deleteRepository;
    private readonly CreateRepository<TEntity, TDto, TCreateDto> _createRepository;
    private readonly UpdateRepository<TEntity, TDto, TUpdateDto> _updateRepository;

    public Repository(AppDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;

        _deleteRepository = new DeleteRepository<TEntity>(context);
        _getRepository = new GetRepository<TEntity, TDto>(context, mapper);
        _createRepository = new CreateRepository<TEntity, TDto, TCreateDto>(context, mapper);
        _updateRepository = new UpdateRepository<TEntity, TDto, TUpdateDto>(context, mapper);
    }

    public async Task<TDto> CreateAsync(TCreateDto newEntity)
    {

        return await _createRepository.CreateAsync(newEntity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _deleteRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<TDto>?> GetAllAsync()
    {

       return await _getRepository.GetAllAsync();
    }

    public async Task<TDto?> GetAsync(Guid id)
    {
        return await _getRepository.GetAsync(id);
    }

    public async Task<TDto> UpdateAsync(TUpdateDto updatedEntity)
    {
      return await _updateRepository.UpdateAsync(updatedEntity);
    }
}
