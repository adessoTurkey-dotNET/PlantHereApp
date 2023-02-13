﻿using AutoMapper;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Queries;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;

namespace PlantHere.Application.CQRS.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, IEnumerable<GetCategoriesQueryResult>>, IQueryCacheable
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public int Expiration { set; get; }

        public GetCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            Expiration = 20;
        }

        public async Task<IEnumerable<GetCategoriesQueryResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.GetGenericRepository<ModelCategory>().GetAsync();
            return _mapper.Map<IEnumerable<GetCategoriesQueryResult>>(categories);
        }
    }
}
