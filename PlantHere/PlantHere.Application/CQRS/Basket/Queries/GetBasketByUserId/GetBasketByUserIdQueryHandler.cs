namespace PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId
{
    public class GetBasketByUserIdQueryHandler : IRequestHandler<GetBasketByUserIdQuery, GetBasketByUserIdQueryResult>
    {

        private readonly IBasketRepository _basketRepository;

        private readonly IMapper _mapper; 
        public GetBasketByUserIdQueryHandler(IBasketRepository basketRepositoy, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepositoy;
        }

        public async Task<GetBasketByUserIdQueryResult> Handle(GetBasketByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetBasketByUserIdQueryResult>(await _basketRepository.GetBasketByUserId(request.UserId));
        }
    }
}
