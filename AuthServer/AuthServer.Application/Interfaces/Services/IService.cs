using AuthServer.Application.CustomResponses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.Interfaces.Services
{
    public interface IService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<CustomResponse<TDto>> GetByIdAsync(int id);

        Task<CustomResponse<IEnumerable<TDto>>> GetAllAsync();

        Task<CustomResponse<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);

        Task<CustomResponse<TDto>> AddAsync(TDto entity);

        Task<CustomResponse<NoContentResponse>> Remove(int id);

        Task<CustomResponse<NoContentResponse>> Update(TDto entity, int id);
    }
}