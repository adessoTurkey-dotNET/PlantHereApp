using AuthServer.Application.CustomResponses;
using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Application.Interfaces.Services;
using AuthServer.Application.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Persistence.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<TEntity> _genericRepository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<CustomResponse<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);

            await _genericRepository.AddAsync(newEntity);

            await _unitOfWork.CommmitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);

            return CustomResponse<TDto>.Success(newDto, 200);
        }

        public async Task<CustomResponse<IEnumerable<TDto>>> GetAllAsync()
        {
            var products = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());

            return CustomResponse<IEnumerable<TDto>>.Success(products, 200);
        }

        public async Task<CustomResponse<TDto>> GetByIdAsync(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);

            if (product == null)
            {
                return CustomResponse<TDto>.Fail("Id not found", 404, true);
            }

            return CustomResponse<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(product), 200);
        }

        public async Task<CustomResponse<NoContentResponse>> Remove(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return CustomResponse<NoContentResponse>.Fail("Id not found", 404, true);
            }

            _genericRepository.Remove(isExistEntity);

            await _unitOfWork.CommmitAsync();
            //204 durum kodu =>  No Content  => Response body'sinde hiç bir dat  olmayacak.
            return CustomResponse<NoContentResponse>.Success(204);
        }

        public async Task<CustomResponse<NoContentResponse>> Update(TDto entity, int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return CustomResponse<NoContentResponse>.Fail("Id not found", 404, true);
            }

            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);

            _genericRepository.Update(updateEntity);

            await _unitOfWork.CommmitAsync();
            //204 durum kodu =>  No Content  => Response body'sinde hiç bir data  olmayacak.
            return CustomResponse<NoContentResponse>.Success(204);
        }

        public async Task<CustomResponse<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            // where(x=>x.id>5)
            var list = _genericRepository.Where(predicate);

            return CustomResponse<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()), 200);
        }
    }
}
