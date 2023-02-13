using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Queries;
using ModelOrder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;

namespace PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId
{
    public class GetOrderByUserIdHandlerQuery : IRequestHandler<GetOrderByUserIdQuery, ICollection<GetOrderByUserIdQueryResult>>, IQueryCacheable
    {
        public int Expiration { set; get; }

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;
        public GetOrderByUserIdHandlerQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            Expiration = 20;
        }

        public async Task<ICollection<GetOrderByUserIdQueryResult>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.GetGenericRepository<ModelOrder>().GetQueryable().Include(x => x.OrderItems).Include(x => x.Address).Where(x => x.BuyerId == request.userId).ToListAsync();
            return _mapper.Map<ICollection<GetOrderByUserIdQueryResult>>(orders);
        }
    }
}

