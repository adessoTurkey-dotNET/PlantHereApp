﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Queries;
using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductsByPage
{
    public class GetProductsByPageQueryHandler : IQueryHandler<GetProductsByPageQuery, IEnumerable<GetProductsByPageQueryResult>>, IQueryCacheable
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public int Expiration { set; get;}

        public GetProductsByPageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            Expiration = 20;
        }

        public async Task<IEnumerable<GetProductsByPageQueryResult>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var products = _mapper.Map<ICollection<GetProductsByPageQueryResult>>(await _unitOfWork.GetGenericRepository<ModelProduct>().GetQueryable().Include(x => x.Images).OrderBy(x => x.Id).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync());

            return products;
        }

    }
}


